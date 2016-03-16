using easyGALib.Interfaces.Algorithm;
using easyGALib.Interfaces.Factories;
using easyGALib.Algorithm;
using easyGALib.Chromosomes;

namespace easyGALib.Factories
{
class GAFactory : IGAFactory
{
    public IGABase GetGA(ChromosomeType type)
    {
        switch (type)
        {
            case ChromosomeType.StringChromosome:
                return GetGAString();
            case ChromosomeType.CharChromosome:
                return GetGAChar();
            case ChromosomeType.DoubleChromosome:
                return GetGADouble();
            case ChromosomeType.IntChromosome:
                return GetGAInt();
            default:
                return null;
        }
    }

    private IGAChar GetGAChar()
    {
        return new GAChar();
    }

    private IGADouble GetGADouble()
    {
        return new GADouble();
    }

    private IGAInt GetGAInt()
    {
        return new GAInt();
    }

    private IGAString GetGAString()
    {
        return new GAString();
    }
}
}
