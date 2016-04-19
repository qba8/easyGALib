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

        IGeneticAlgorithmInput _input;

        public IGAResult Execute(IGeneticAlgorithmInput input)
        {
            _input = input;
            long generation = 0;

            PopulationInit();

            while (!IsFinalGeneration())
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
            Random rdm = new Random();

            NextGeneration.Shuffle();

            int length = NextGeneration.Count;
            if (length % 2 == 1)
            {
                length--;
            }

            for (int i = 0; i < length; i += 2)
            {
                var parentA = NextGeneration[i];
                var parentB = NextGeneration[i + 1];

                if (rdm.Next(0, 100) < _input.Parameters.CrossoverChance)
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

            for (int i = 0; i < _input.Parameters.ChromosomesQuantity; i++)
            {
                var chromosome = FindChromosome();
                NextGeneration.Add(chromosome.CreateCopy());
            }
        }

        private IChromosome FindChromosome()
        {
            Random rdm = new Random();
            bool found = false;
            int index = -1;

            while (!found)
            {
                index = rdm.Next(0, _input.Parameters.ChromosomesQuantity - 1);

                //We should give some random selection chance by parameter
                if (_input.Parameters.RandomSelectionChance > rdm.Next(0, 100))
                {
                    found = true;
                }
                else if (CurrentGeneration[index].FitnessRank > rdm.Next(0, 100)) //Better chromosome = bigger chance to go to the next generation
                {
                    found = true;
                }
            }

            return CurrentGeneration[index];
        }

        private bool IsFinalGeneration()
        {
            throw new NotImplementedException();
        }

        private void Mutate()
        {
            Random rdm = new Random();

            foreach (IChromosome item in NextGeneration)
            {
                if (_input.Parameters.MutationChance > rdm.Next(0, 100))
                {
                    item.Mutate();
                }
            }
        }

        private void CalculateFitness()
        {
            throw new NotImplementedException();
        }

        private void PopulationInit()
        {
            throw new NotImplementedException();
        }
    }
}
