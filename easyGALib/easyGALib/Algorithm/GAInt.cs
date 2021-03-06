﻿using easyGALib.Chromosomes;
using easyGALib.Interfaces.Algorithm;
using System;

namespace easyGALib.Algorithm
{
    internal class GAInt : GABase, IGAInt
    {
        public override void ChildrenInit()
        {
            for (int i = 0; i < _input.Parameters.ChromosomesQuantity; i++)
            {
                var chromosome = new IntChromosome(_rdm);

                for (int j = 0; j < _input.Parameters.GenesQuantity; j++)
                {
                    int val = _rdm.Next(0, 100);

                    if (_rdm.Next(0, 1) == 1)
                    {
                        val = -val;
                    }

                    chromosome.Genes.Add(val);
                }

                CurrentGeneration.Add(chromosome);
            }
        }
    }
}
