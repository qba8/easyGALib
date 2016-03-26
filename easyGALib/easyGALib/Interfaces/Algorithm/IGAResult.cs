using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Interfaces.Algorithm
{
    public interface IGAResult
    {
        IChromosome BestChromosome { get; set; }
        double WorkTime { get; set; }
    }
}