using easyGALib.Interfaces.Chromosomes;
using System;
using System.Collections.Generic;

namespace easyGALib.Chromosomes
{
    internal class IntChromosome : Chromosome<IIntChromosome>, IIntChromosome
    {
        private Random _rdm;

        public IntChromosome()
        {
            Genes = new List<int>();
            _rdm = new Random();
        }

public override void Mutate()
{
    int index = _rdm.Next(0, Genes.Count - 1);
    int gene = (int)Genes[index];

    int diff = gene * _rdm.Next(1, 1000) / 1000;

    if (_rdm.Next(0, 1) == 1)
    {
        Genes[index] = gene + diff;
    }
    else
    {
        Genes[index] = gene - diff;
    }
}

        public override void OnePtCrossover(IChromosome parentB)
        {
            int crossoverPt = _rdm.Next(0, Genes.Count - 1);
            for (int i = crossoverPt; i < Genes.Count; i++)
            {
                swapGene(i, this, parentB);
            }

        }

        public override void TwoPtCrossover(IChromosome parentB)
        {
            int crossoverPtA = _rdm.Next(0, Genes.Count - 1);
            int crossoverPtB = _rdm.Next(0, Genes.Count - 1);

            if (crossoverPtA != crossoverPtB)
            {
                for (int i = crossoverPtA; i < crossoverPtB; i++)
                {
                    swapGene(i, this, parentB);
                }
            }
        }

        public override void UniformCrossover(IChromosome parentB)
        {
            for (int i = 0; i < Genes.Count; i++)
            {
                if (_rdm.Next(0, 1) == 1)
                {
                    swapGene(i, this, parentB);
                }
            }
        }

        private void swapGene(int i, IChromosome chromA, IChromosome chromB)
        {
            var temp = chromA.Genes[i];
            chromA.Genes[i] = chromB.Genes[i];
            chromB.Genes[i] = temp;
        }
    }
}
