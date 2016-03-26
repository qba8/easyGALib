using easyGALib.Interfaces.Chromosomes;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class DoubleChromosome : Chromosome<IDoubleChromosome>, IDoubleChromosome
    {
        public DoubleChromosome()
        {
            Genes = new List<double>();
        }
    }
}
