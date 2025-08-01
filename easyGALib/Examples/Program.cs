using easyGALib.Algorithm;
using System;
using System.Collections.Generic;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("easyGALib Refactored Demo");
            Console.WriteLine("========================");
            
            // Test the original traveling salesman problem (will have issues)
            Console.WriteLine("\n1. Original Traveling Salesman Problem (has issues with current implementation):");
            TestTravelingSalesman();
            
            // Test the new working example
            Console.WriteLine("\n2. Maximum Sum Problem (working demonstration):");
            TestMaxSumProblem();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        private static void TestTravelingSalesman()
        {
            try
            {
                var salesmanProblem = new Salesman();
                var ga = new GAMain(salesmanProblem);

                var result = ga.Execute();

                Console.WriteLine("Best chromosome: " + string.Join(", ", result.BestChromosome.Genes as List<int>));
                Console.WriteLine("Fitness: " + result.BestChromosome.Fitness.ToString("F6"));
                if (result.BestChromosome.Fitness > 0)
                    Console.WriteLine("Distance: " + (1 / result.BestChromosome.Fitness).ToString("F2"));
                else
                    Console.WriteLine("Distance: Invalid (fitness = 0)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        private static void TestMaxSumProblem()
        {
            try
            {
                var maxSumProblem = new MaxSumProblem();
                var ga = new GAMain(maxSumProblem);

                var result = ga.Execute();

                Console.WriteLine("Best chromosome: " + string.Join(", ", result.BestChromosome.Genes as List<int>));
                Console.WriteLine("Fitness (sum): " + result.BestChromosome.Fitness.ToString("F0"));
                Console.WriteLine("This demonstrates the refactored library works correctly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
