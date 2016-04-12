using easyGALib.Types;
using easyGALib.Interfaces.Algorithm;

namespace easyGALib.Interfaces.Factories
{
    interface IGAFactory
    {
        IGABase GetGA(ChromosomeType type);
    }
}
