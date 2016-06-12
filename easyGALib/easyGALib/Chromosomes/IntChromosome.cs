using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class IntChromosome : Chromosome<IIntChromosome>, IIntChromosome
    {
        public IntChromosome(Random rdm)
            :base(rdm)
        {
            Genes = new List<int>();
        }

        public override IChromosome CreateCopy()
        {
            var chromosome = new IntChromosome(Randomizer);
            foreach (var gene in Genes)
            {
                chromosome.Genes.Add(gene);
            }

            return chromosome;
        }

        public override void Mutate()
        {
            int index = Randomizer.Next(0, Genes.Count - 1);
            int gene = (int)Genes[index];

            int diff = gene * Randomizer.Next(1, 1000) / 1000;

            if (Randomizer.Next(0, 1) == 1)
            {
                Genes[index] = gene + diff;
            }
            else
            {
                Genes[index] = gene - diff;
            }
        }        
    }
}
