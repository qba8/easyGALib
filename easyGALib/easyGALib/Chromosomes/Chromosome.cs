using System;
using System.Collections;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Chromosomes
{
    public abstract class Chromosome<T> : IChromosome
        where T : IChromosome
    {
        public double FitnessRank
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ICollection Genes { get; set; }

        public IChromosome CreateCopy()
        {
            throw new NotImplementedException();
        }

        public abstract IChromosome OnePtCrossover(IChromosome parentB);

        public abstract IChromosome TwoPtCrossover(IChromosome parentB);

        public abstract IChromosome UniformCrossover(IChromosome parentB);
    }
}
