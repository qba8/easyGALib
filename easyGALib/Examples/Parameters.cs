using System;
using easyGALib.Interfaces;
using easyGALib.Types;

namespace Examples
{
    class Parameters : IGAParameters
    {
        public int ChromosomesQuantity { get; set; }

        public ChromosomeType CromosomeType { get; set; }

        public int CrossoverChance { get; set; }

        public CrossoverType CrossoverType { get; set; }

        public long GenerationsLimit { get; set; }

        public int GenesQuantity { get; set; }

        public int MutationChance { get; set; }

        public int RandomSelectionChance { get; set; }
    }
}
