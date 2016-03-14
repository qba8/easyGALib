using easyGALib.Chromosomes;

namespace easyGALib.Interfaces
{
    public interface GeneticAlgorithm
    {
        double GetFitness(Chromosome chromosome);
        IGAParameters Parameters { get; set; }
    }
}
