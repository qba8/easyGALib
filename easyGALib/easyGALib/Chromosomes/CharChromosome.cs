using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;
using System;

namespace easyGALib.Chromosomes
{
    internal class CharChromosome : Chromosome<ICharChromosome>, ICharChromosome
    {
        public CharChromosome()
        {
            Genes = new List<char>();
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
