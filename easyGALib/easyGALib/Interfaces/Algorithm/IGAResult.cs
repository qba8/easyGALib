using easyGALib.Chromosomes;

namespace easyGALib.Interfaces.Algorithm
{
    public interface IGAResult
    {
        Chromosome BestChromosome { get; set; }
        double WorkTime { get; set; }
    }
}