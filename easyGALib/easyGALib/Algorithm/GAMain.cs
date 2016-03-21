using easyGALib.Chromosomes;
using easyGALib.Factories;
using easyGALib.Interfaces;
using easyGALib.Interfaces.Algorithm;
using easyGALib.Interfaces.Factories;

namespace easyGALib.Algorithm
{
    public class GAMain
    {
        private readonly IGeneticAlgorithmInput _input;
        private readonly IGAFactory _gaFactory;

        public GAMain(IGeneticAlgorithmInput input) {
            _input = input;
            _gaFactory = new GAFactory();
        }

        public IGAResult Execute()
        {
            IGABase ga = _gaFactory.GetGA(_input.Parameters.CromosomeType); 
            return ga.Execute(_input);
        }
    }
}
