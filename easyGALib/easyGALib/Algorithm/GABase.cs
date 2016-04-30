using System;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Algorithm;
using easyGALib.Interfaces.Chromosomes;
using easyGALib.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace easyGALib.Algorithm
{
    internal abstract class GABase : IGABase
    {
        public List<IChromosome> CurrentGeneration { get; set; }
        public IChromosome BestChromosome { get; set; }
        public List<IChromosome> NextGeneration { get; set; }
        public List<IChromosome> InitChromosomes { get; set; }
        protected Random _rdm;

        public GABase()
        {
            CurrentGeneration = new List<IChromosome>();
            NextGeneration = new List<IChromosome>();
            InitChromosomes = new List<IChromosome>();
            _rdm = new Random();
        }

        public abstract void ChildrenInit();

        protected IGeneticAlgorithmInput _input;

        public IGAResult Execute(IGeneticAlgorithmInput input)
        {
            _input = input;
            long generation = 0;

            PopulationInit();

            while (!IsFinalGeneration(generation))
            {
                CalculateFitness();
                SelectChromosomes();
                Crossover();
                Mutate();

                NextGeneration.RemoveAt(NextGeneration.Count - 1);
                NextGeneration.Add(BestChromosome.CreateCopy());

                generation++;
            }

            return new GAResult() { BestChromosome = BestChromosome };
        }

        private void Crossover()
        {
            NextGeneration.Shuffle(_rdm);

            int length = NextGeneration.Count;
            if (length % 2 == 1)
            {
                length--;
            }

            for (int i = 0; i < length; i += 2)
            {
                var parentA = NextGeneration[i];
                var parentB = NextGeneration[i + 1];

                if (_rdm.Next(0, 100) < _input.Parameters.CrossoverChance)
                {
                    switch (_input.Parameters.CrossoverType)
                    {
                        case Types.CrossoverType.OnePt:
                            parentA.OnePtCrossover(parentB);
                            break;
                        case Types.CrossoverType.TwoPt:
                            parentA.TwoPtCrossover(parentB);
                            break;
                        case Types.CrossoverType.Uniform:
                            parentA.UniformCrossover(parentB);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void SelectChromosomes()
        {
            NextGeneration.Clear();

            //Elitism - best chromosome always go to the next generation
            NextGeneration.Add(BestChromosome.CreateCopy());

            for (int i = 0; i < _input.Parameters.ChromosomesQuantity - 1; i++)
            {
                var chromosome = FindChromosome();
                NextGeneration.Add(chromosome.CreateCopy());
            }
        }

        private IChromosome FindChromosome()
        {
            bool found = false;
            int index = -1;

            while (!found)
            {
                index = _rdm.Next(0, _input.Parameters.ChromosomesQuantity - 1);

                //We should give some random selection chance by parameter
                if (_input.Parameters.RandomSelectionChance > _rdm.Next(0, 100))
                {
                    found = true;
                }
                else if (CurrentGeneration[index].FitnessRank > _rdm.Next(0, _input.Parameters.ChromosomesQuantity)) //Better chromosome = bigger chance to go to the next generation
                {
                    found = true;
                }
            }

            return CurrentGeneration[index];
        }

        private bool IsFinalGeneration(long generation)
        {
            return generation >= _input.Parameters.GenerationsLimit;
        }

        private void Mutate()
        {
            foreach (IChromosome item in NextGeneration)
            {
                if (_input.Parameters.MutationChance > _rdm.Next(0, 100))
                {
                    item.Mutate();
                }
            }
        }

        private void CalculateFitness()
        {
            foreach (var chromosome in CurrentGeneration)
            {
                chromosome.Fitness = _input.GetFitness(chromosome);
            }

            CurrentGeneration = CurrentGeneration.OrderBy(g => g.Fitness).ToList();

            for (int i = 0; i < CurrentGeneration.Count; i++)
            {
                CurrentGeneration[i].FitnessRank = i;
            }

            BestChromosome = CurrentGeneration.Last();
        }

        private void PopulationInit()
        {
            for (int i = 0; i < _input.Parameters.InitRunsQuantity; i++)
            {
                CurrentGeneration.Clear();
                ChildrenInit();

                CalculateFitness();

                InitChromosomes.AddRange(CurrentGeneration.Skip(Math.Max(0, CurrentGeneration.Count() - _input.Parameters.BestChromosomesPerRun)));
            }

            CurrentGeneration.RemoveRange(0, _input.Parameters.BestChromosomesPerRun * _input.Parameters.InitRunsQuantity);
            CurrentGeneration.AddRange(InitChromosomes);
        }
    }
}
