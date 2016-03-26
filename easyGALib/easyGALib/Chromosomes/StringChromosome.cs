using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class StringChromosome : Chromosome<IStringChromosome>, IStringChromosome
    {
        public StringChromosome()
        {
            Genes = new List<string>();
        }
    }
}
