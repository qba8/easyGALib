using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class IntChromosome : Chromosome<IIntChromosome>, IIntChromosome
    {
        public IntChromosome()
        {
            Genes = new List<int>();
        }
    }
}
