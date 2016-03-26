using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class CharChromosome : Chromosome<ICharChromosome>, ICharChromosome
    {
        public CharChromosome()
        {
            Genes = new List<char>();
        }
    }
}
