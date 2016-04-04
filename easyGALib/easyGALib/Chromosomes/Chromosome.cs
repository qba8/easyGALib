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
    }
}
