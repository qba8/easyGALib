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

        public override IChromosome CreateCopy()
        {
            throw new NotImplementedException();
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
