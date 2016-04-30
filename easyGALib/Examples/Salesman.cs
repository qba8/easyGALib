using System.Linq;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace Examples
{
    class Salesman : IGeneticAlgorithmInput
    {
        public IGAParameters Parameters { get; set; }

        public double GetFitness(IChromosome chromosome)
        {
            var cities = new int[4, 4] { {0, 130, 180, 300 },
                                    {130, 0, 320, 350 },
                                    { 180, 320, 0, 360},
                                    { 300, 350, 360, 0} };
            var genes = chromosome.Genes as List<int>;

            //Cities can't repeat 
            if (genes.Distinct().Count() != Parameters.GenesQuantity)
            {
                return 0;
            }

            //Genes should be in <0,3>
            if (genes.Count(g => g < 0 || g > 3) > 0)
            {
                return 0;
            }

            var distance = 0;
            for (int i = 1; i < 4; i++)
            {
                distance += cities[genes[i], genes[i - 1]];
            }

            if (distance == 0)
            {
                return 0;
            }

            return (double)1 / (double)distance;
        }

        public Salesman()
        {
            Parameters = new Parameters()
            {
                ChromosomesQuantity = 300,
                CromosomeType = easyGALib.Types.ChromosomeType.IntChromosome,
                CrossoverChance = 80,
                CrossoverType = easyGALib.Types.CrossoverType.TwoPt,
                GenerationsLimit = 1000,
                GenesQuantity = 4,
                MutationChance = 5,
                RandomSelectionChance = 6,
                InitRunsQuantity = 100,
                BestChromosomesPerRun = 3
            };
        }
    }
}
