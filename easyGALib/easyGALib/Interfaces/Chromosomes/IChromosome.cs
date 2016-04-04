using System.Collections;

namespace easyGALib.Interfaces.Chromosomes
{
    public interface IChromosome
    {
        ICollection Genes { get; set; }
        double FitnessRank { get; set; }
        IChromosome CreateCopy();
    }
}
