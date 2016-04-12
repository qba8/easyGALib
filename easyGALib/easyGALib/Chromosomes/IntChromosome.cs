using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class IntChromosome : Chromosome<IIntChromosome>, IIntChromosome
    {
        public IntChromosome()
        {
            Genes = new List<int>();
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
