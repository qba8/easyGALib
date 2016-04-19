using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class DoubleChromosome : Chromosome<IDoubleChromosome>, IDoubleChromosome
    {
        public DoubleChromosome()
        {
            Genes = new List<double>();
        }

        public override void Mutate()
        {
            throw new NotImplementedException();
        }

        public override void OnePtCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }

        public override void TwoPtCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }

        public override void UniformCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }
    }
}
