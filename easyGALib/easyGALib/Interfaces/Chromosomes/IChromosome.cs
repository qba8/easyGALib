using System.Collections;

namespace easyGALib.Interfaces.Chromosomes
{
    public interface IChromosome
    {
        IList Genes { get; set; }
        int FitnessRank { get; set; }
        double Fitness { get; set; }
        IChromosome CreateCopy();

        void OnePtCrossover(IChromosome parentB);
        void TwoPtCrossover(IChromosome parentB);
        void UniformCrossover(IChromosome parentB);
        void Mutate();
    }
}
