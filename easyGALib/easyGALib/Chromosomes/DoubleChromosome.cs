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

        public override IChromosome OnePtCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }

        public override IChromosome TwoPtCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }

        public override IChromosome UniformCrossover(IChromosome parentB)
        {
            throw new NotImplementedException();
        }
    }
}
