using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;
using System;

namespace easyGALib.Chromosomes
{
    internal class CharChromosome : Chromosome<ICharChromosome>, ICharChromosome
    {
        public CharChromosome(Random rdm)
            :base(rdm)
        {
            Genes = new List<char>();
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
