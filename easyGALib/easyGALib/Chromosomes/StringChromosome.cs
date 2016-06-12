using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class StringChromosome : Chromosome<IStringChromosome>, IStringChromosome
    {
        public StringChromosome(Random rdm)
            :base(rdm)
        {
            Genes = new List<string>();
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
