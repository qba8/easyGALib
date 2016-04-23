using easyGALib.Algorithm;
using System;
using System.Collections.Generic;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesmanProblem = new Salesman();
            var ga = new GAMain(salesmanProblem);

            var result = ga.Execute();

            Console.WriteLine("Best chromosome: " + string.Join(", ", result.BestChromosome.Genes as List<int>));
            Console.WriteLine("Fitness: " + result.BestChromosome.Fitness.ToString());
            Console.WriteLine("Distance: " + (1 / result.BestChromosome.Fitness).ToString());
            Console.ReadKey();
        }
    }
}
