using easyGALib.Types;
using easyGALib.Interfaces.Algorithm;

namespace easyGALib.Interfaces.Factories
{
    public interface IGAFactory
    {
        IGABase GetGA(ChromosomeType type);
    }
}
