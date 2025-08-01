# easyGALib

A modern, refactored C# library for easy Genetic Algorithms implementation.

## Overview

easyGALib provides a simple and extensible framework for implementing genetic algorithms in .NET applications. The library has been refactored to use modern .NET patterns, improved error handling, and enhanced extensibility.

## Features

- **Multiple Chromosome Types**: Support for Integer, Double, Character, and String chromosomes
- **Flexible Crossover Methods**: One-point, two-point, and uniform crossover
- **Configurable Parameters**: Customize population size, mutation rates, crossover chances, and more
- **Early Termination**: Optional fitness threshold for stopping evolution early
- **Dependency Injection**: Support for custom factory implementations
- **Parameter Validation**: Comprehensive validation with meaningful error messages
- **Modern .NET**: Built with .NET Standard 2.0 for broad compatibility

## Quick Start

```csharp
using easyGALib.Algorithm;
using easyGALib.Interfaces;

// Create your problem implementation
var problem = new YourProblem(); // Implements IGeneticAlgorithmInput
var ga = new GAMain(problem);

// Execute the genetic algorithm
var result = ga.Execute();

// Access the best solution
Console.WriteLine($"Best fitness: {result.BestChromosome.Fitness}");
Console.WriteLine($"Best genes: {string.Join(", ", result.BestChromosome.Genes)}");
```

## Parameter Configuration

```csharp
var parameters = new Parameters()
{
    ChromosomeType = ChromosomeType.IntChromosome,
    ChromosomesQuantity = 100,          // Population size
    GenesQuantity = 10,                 // Number of genes per chromosome
    GenerationsLimit = 1000,            // Maximum generations
    CrossoverType = CrossoverType.TwoPt,
    CrossoverChance = 80,               // Percentage (0-100)
    MutationChance = 5,                 // Percentage (0-100)
    RandomSelectionChance = 10,         // Percentage (0-100)
    FitnessThreshold = 100.0           // Optional early termination
};
```

## Advanced Usage

### Custom Factory Implementation

```csharp
// Use dependency injection for custom factories
var customFactory = new MyCustomGAFactory();
var ga = new GAMain(problem, customFactory);
```

### Implementing Your Own Problem

```csharp
public class MyProblem : IGeneticAlgorithmInput
{
    public IGAParameters Parameters { get; set; }
    
    public double GetFitness(IChromosome chromosome)
    {
        var genes = chromosome.Genes as List<int>;
        // Calculate and return fitness value
        return genes.Sum(); // Example: maximize sum
    }
}
```

## Refactoring Improvements

This version includes several improvements over the original:

### Build and Compatibility
- ✅ **Fixed build issues**: Updated project files to modern SDK format
- ✅ **Modernized targeting**: Uses .NET Standard 2.0 for broad compatibility
- ✅ **Fixed project references**: Corrected solution file paths

### Code Quality
- ✅ **Fixed typos**: `CromosomeType` → `ChromosomeType`
- ✅ **Replaced magic numbers**: Added constants for better maintainability
- ✅ **Fixed bugs**: Corrected shuffle algorithm implementation
- ✅ **Improved accessibility**: Made interfaces public for external use

### Design Patterns
- ✅ **Dependency injection**: Support for custom factory implementations
- ✅ **Enhanced error handling**: Proper exceptions with meaningful messages
- ✅ **Parameter validation**: Comprehensive validation of input parameters
- ✅ **Better factory pattern**: Improved error handling in factory methods

### Performance Optimizations
- ✅ **Fixed infinite loops**: Improved chromosome selection algorithm
- ✅ **Early termination**: Optional fitness threshold for better performance
- ✅ **Reduced allocations**: More efficient object creation patterns

## Examples

The library includes working examples:

1. **MaxSumProblem**: Demonstrates finding chromosomes that maximize gene sum
2. **Traveling Salesman**: Classic TSP implementation (educational purposes)

## Building

```bash
dotnet build
```

## Running Examples

```bash
cd Examples
dotnet run
```

## License

MIT License - see LICENSE file for details.

## Contributing

Contributions are welcome! Please ensure your changes:
- Include proper tests
- Follow existing code style
- Update documentation as needed
- Maintain backward compatibility where possible
