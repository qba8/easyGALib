using easyGALib.Chromosomes;
using easyGALib.Interfaces.Algorithm;

namespace easyGALib.Algorithm
{
    public class GAResult : IGAResult
    {
        public Chromosome BestChromosome { get; set; }
        public double WorkTime { get; set; } 
    }
}
