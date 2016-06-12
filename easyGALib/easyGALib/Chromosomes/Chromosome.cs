using System;
using System.Collections;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Chromosomes
{
    public abstract class Chromosome<T> : IChromosome
        where T : IChromosome
    {
        protected Random Randomizer;

        public double Fitness { get; set; }

        public int FitnessRank { get; set; }

        public IList Genes { get; set; }

        public abstract IChromosome CreateCopy();

        public abstract void Mutate();

        public Chromosome(Random rdm)
        {
            Randomizer = rdm;
        }

        public void OnePtCrossover(IChromosome parentB)
        {
            int crossoverPt = Randomizer.Next(0, Genes.Count - 1);
            for (int i = crossoverPt; i < Genes.Count; i++)
            {
                SwapGene(i, this, parentB);
            }

        }

        public void TwoPtCrossover(IChromosome parentB)
        {
            int crossoverPtA = Randomizer.Next(0, Genes.Count - 1);
            int crossoverPtB = Randomizer.Next(0, Genes.Count - 1);

            if (crossoverPtA != crossoverPtB)
            {
                for (int i = crossoverPtA; i < crossoverPtB; i++)
                {
                    SwapGene(i, this, parentB);
                }
            }
        }

        public void UniformCrossover(IChromosome parentB)
        {
            for (int i = 0; i < Genes.Count; i++)
            {
                if (Randomizer.Next(0, 1) == 1)
                {
                    SwapGene(i, this, parentB);
                }
            }
        }

        private void SwapGene(int i, IChromosome chromA, IChromosome chromB)
        {
            var temp = chromA.Genes[i];
            chromA.Genes[i] = chromB.Genes[i];
            chromB.Genes[i] = temp;
        }
    }
}
