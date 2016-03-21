using System;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Algorithm;

namespace easyGALib.Algorithm
{
    internal abstract class GABase : IGABase
    {
        public IGAResult Execute(IGeneticAlgorithmInput input)
        {
            PopulationInit();

            bool mostMatched = false;
            long generation = 0;

            while (!(mostMatched && generation > input.Parameters.GenerationsLimit))
            {
                CalculateFitness();
                int fittedChromosomesCount = CountFittedChromosomes();
                mostMatched = fittedChromosomesCount / input.Parameters.ChromosomesQuantity > 0.9;
                if (!mostMatched)
                {
                    Mutate();
                }
            }

            return null;
        }

        private void Mutate()
        {
            throw new NotImplementedException();
        }

        private int CountFittedChromosomes()
        {
            throw new NotImplementedException();
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
