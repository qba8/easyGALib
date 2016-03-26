using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Interfaces
{
    public interface IGeneticAlgorithmInput
    {
        double GetFitness(IChromosome chromosome);
        IGAParameters Parameters { get; set; }
    }
}
