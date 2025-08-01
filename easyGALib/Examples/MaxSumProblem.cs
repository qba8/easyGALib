using System.Linq;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace Examples
{
    /// <summary>
    /// Simple example that finds chromosomes with maximum sum fitness
    /// Works with default integer range (0-100)
    /// </summary>
    class MaxSumProblem : IGeneticAlgorithmInput
    {
        public IGAParameters Parameters { get; set; }

        public double GetFitness(IChromosome chromosome)
        {
            var genes = chromosome.Genes as List<int>;
            if (genes == null || genes.Count == 0)
                return 0;

            // Fitness is the sum of all genes (higher is better)
            return genes.Sum();
        }

        public MaxSumProblem()
        {
            Parameters = new Parameters()
            {
                ChromosomesQuantity = 50,
                ChromosomeType = easyGALib.Types.ChromosomeType.IntChromosome,
                CrossoverChance = 80,
                CrossoverType = easyGALib.Types.CrossoverType.TwoPt,
                GenerationsLimit = 100,
                GenesQuantity = 5,
                MutationChance = 5,
                RandomSelectionChance = 10,
                InitRunsQuantity = 10,
                BestChromosomesPerRun = 2,
                FitnessThreshold = 400 // Early termination when sum reaches 400
            };
        }
    }
}