using easyGALib.Chromosomes;

namespace easyGALib.Interfaces
{
    public interface IGAParameters
    {
        ChromosomeType CromosomeType { get; set; }
        long GenerationsLimit { get; set; }
        int ChromosomesQuantity { get; set; }
    }
}
