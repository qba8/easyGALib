using easyGALib.Interfaces.Algorithm;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Algorithm
{
    public class GAResult : IGAResult
    {
        public IChromosome BestChromosome { get; set; }
        public double WorkTime { get; set; } 
    }
}
