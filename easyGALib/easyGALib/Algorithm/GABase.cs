using System;
using easyGALib.Chromosomes;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Algorithm;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Algorithm
{
    internal abstract class GABase : IGABase
    {
        public IGAResult Execute(IGeneticAlgorithmInput input)
        {
            long generation = 0;

            PopulationInit();

            while (!IsFinalGeneration())
            {
                CalculateFitness();
                SelectChromosomes();
                Crossover();
                Mutate();

                generation++;
            }

            return new GAResult() { BestChromosome = GetBestChromosome() };
        }

        private IChromosome GetBestChromosome()
        {
            throw new NotImplementedException();
        }

        private void Crossover()
        {
            throw new NotImplementedException();
        }

        private void SelectChromosomes()
        {
            throw new NotImplementedException();
        }

        private bool IsFinalGeneration()
        {
            throw new NotImplementedException();
        }

        private void Mutate()
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
