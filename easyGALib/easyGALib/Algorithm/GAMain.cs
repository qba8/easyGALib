using System;
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

        public GAMain(IGeneticAlgorithmInput input) : this(input, new GAFactory())
        {
        }

        public GAMain(IGeneticAlgorithmInput input, IGAFactory gaFactory)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _gaFactory = gaFactory ?? throw new ArgumentNullException(nameof(gaFactory));
        }

        public IGAResult Execute()
        {
            if (_input.Parameters == null)
                throw new InvalidOperationException("Parameters cannot be null");

            IGABase ga = _gaFactory.GetGA(_input.Parameters.ChromosomeType);
            if (ga == null)
                throw new InvalidOperationException($"Unable to create GA for chromosome type: {_input.Parameters.ChromosomeType}");
                
            return ga.Execute(_input);
        }
    }
}
