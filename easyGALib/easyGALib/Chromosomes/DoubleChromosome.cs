using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class DoubleChromosome : Chromosome<IDoubleChromosome>, IDoubleChromosome
    {
        public DoubleChromosome(Random rdm)
            : base(rdm)
        {
            Genes = new List<double>();
        }

        public override IChromosome CreateCopy()
        {
            throw new NotImplementedException();
        }

        public override void Mutate()
        {
            throw new NotImplementedException();
        }
    }
}
