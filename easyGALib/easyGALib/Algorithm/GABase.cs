using System;
using easyGALib.Constants;
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
        protected IGeneticAlgorithmInput _input;

        public abstract void ChildrenInit();

        public GABase()
        {
            CurrentGeneration = new List<IChromosome>();
            NextGeneration = new List<IChromosome>();
            InitChromosomes = new List<IChromosome>();
            _rdm = new Random();
        }

        public IGAResult Execute(IGeneticAlgorithmInput input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            ValidateParameters(_input.Parameters);
            
            long generation = 0;

            PopulationInit();

            while (!IsFinalGeneration(generation))
            {
                CalculateFitness();
                SelectChromosomes();
                Crossover();
                Mutate();

                IncludeBestChromosome();
                generation++;
            }

            return new GAResult() { BestChromosome = BestChromosome };
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

        private bool IsFinalGeneration(long generation)
        {
            if (generation >= _input.Parameters.GenerationsLimit)
                return true;
                
            // Early termination if fitness threshold is reached
            if (_input.Parameters.FitnessThreshold.HasValue && 
                BestChromosome != null && 
                BestChromosome.Fitness >= _input.Parameters.FitnessThreshold.Value)
            {
                return true;
            }
                
            return false;
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

                if (_rdm.Next(0, Settings.PercentageMaxValue) < _input.Parameters.CrossoverChance)
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

        private void Mutate()
        {
            foreach (IChromosome item in NextGeneration)
            {
                if (_input.Parameters.MutationChance > _rdm.Next(0, Settings.PercentageMaxValue))
                {
                    item.Mutate();
                }
            }
        }

        private void IncludeBestChromosome()
        {
            NextGeneration.RemoveAt(NextGeneration.Count - 1);
            NextGeneration.Add(BestChromosome.CreateCopy());
        }

        private IChromosome FindChromosome()
        {
            const int maxAttempts = 1000; // Prevent infinite loops
            
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                int index = _rdm.Next(0, _input.Parameters.ChromosomesQuantity);

                //We should give some random selection chance by parameter
                if (_input.Parameters.RandomSelectionChance > _rdm.Next(0, Settings.PercentageMaxValue))
                {
                    return CurrentGeneration[index];
                }
                else if (CurrentGeneration[index].FitnessRank > _rdm.Next(0, _input.Parameters.ChromosomesQuantity)) //Better chromosome = bigger chance to go to the next generation
                {
                    return CurrentGeneration[index];
                }
            }
            
            // Fallback: return a random chromosome to prevent infinite loops
            int fallbackIndex = _rdm.Next(0, _input.Parameters.ChromosomesQuantity);
            return CurrentGeneration[fallbackIndex];
        }

        private void ValidateParameters(IGAParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentException("Parameters cannot be null");
            
            if (parameters.ChromosomesQuantity <= 0)
                throw new ArgumentException("ChromosomesQuantity must be positive", nameof(parameters.ChromosomesQuantity));
                
            if (parameters.GenesQuantity <= 0)
                throw new ArgumentException("GenesQuantity must be positive", nameof(parameters.GenesQuantity));
                
            if (parameters.GenerationsLimit <= 0)
                throw new ArgumentException("GenerationsLimit must be positive", nameof(parameters.GenerationsLimit));
                
            if (parameters.CrossoverChance < 0 || parameters.CrossoverChance > Settings.PercentageMaxValue)
                throw new ArgumentException($"CrossoverChance must be between 0 and {Settings.PercentageMaxValue}", nameof(parameters.CrossoverChance));
                
            if (parameters.MutationChance < 0 || parameters.MutationChance > Settings.PercentageMaxValue)
                throw new ArgumentException($"MutationChance must be between 0 and {Settings.PercentageMaxValue}", nameof(parameters.MutationChance));
                
            if (parameters.RandomSelectionChance < 0 || parameters.RandomSelectionChance > Settings.PercentageMaxValue)
                throw new ArgumentException($"RandomSelectionChance must be between 0 and {Settings.PercentageMaxValue}", nameof(parameters.RandomSelectionChance));
        }
    }
}
