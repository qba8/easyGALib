using easyGALib.Types;

namespace easyGALib.Interfaces
{
    public interface IGAParameters
    {
        ChromosomeType CromosomeType { get; set; }
        CrossoverType CrossoverType { get; set; }

        long GenerationsLimit { get; set; }

        int ChromosomesQuantity { get; set; }
        int GenesQuantity { get; set; }

        int RandomSelectionChance { get; set; }
        int CrossoverChance { get; set; }
        int MutationChance { get; set; }
    }
}
