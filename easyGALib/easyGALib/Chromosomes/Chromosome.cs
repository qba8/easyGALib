using System.Collections;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Chromosomes
{
    public abstract class Chromosome<T> : IChromosome
        where T : IChromosome
    {
        public ICollection Genes { get; set; }
    }
}
