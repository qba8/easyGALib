﻿using System;
using System.Collections;
using easyGALib.Interfaces.Chromosomes;

namespace easyGALib.Chromosomes
{
    public abstract class Chromosome<T> : IChromosome
        where T : IChromosome
    {
        public double Fitness { get; set; }

        public int FitnessRank { get; set; }

        public IList Genes { get; set; }

        public abstract IChromosome CreateCopy();

        public abstract void Mutate();

        public abstract void OnePtCrossover(IChromosome parentB);

        public abstract void TwoPtCrossover(IChromosome parentB);

        public abstract void UniformCrossover(IChromosome parentB);
    }
}
