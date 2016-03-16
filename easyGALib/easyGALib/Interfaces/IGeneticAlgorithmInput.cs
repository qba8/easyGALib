using easyGALib.Chromosomes;

namespace easyGALib.Interfaces
{
    public interface IGeneticAlgorithmInput
    {
        double GetFitness(Chromosome chromosome);
        IGAParameters Parameters { get; set; }
    }
}
