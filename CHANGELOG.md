# Changelog

All notable changes to easyGALib will be documented in this file.

## [Refactored] - 2024

### ✨ New Features
- Added dependency injection support for `GAMain` constructor
- Added optional `FitnessThreshold` parameter for early termination
- Added comprehensive parameter validation with meaningful error messages
- Added working `MaxSumProblem` example demonstrating the refactored library

### 🔧 Fixed
- **Critical**: Fixed build issues by correcting solution file project references
- **Critical**: Fixed typo `CromosomeType` → `ChromosomeType` throughout codebase
- Fixed shuffle algorithm bug in `ExtensionMethods.Shuffle()`
- Fixed potential infinite loop in `FindChromosome()` method
- Fixed off-by-one error in random number generation ranges

### 🏗️ Changed
- **Breaking**: Modernized project files to use SDK-style format
- **Breaking**: Updated target framework to .NET Standard 2.0 for library
- **Breaking**: Updated Examples project to target .NET 8.0
- Made `GAFactory` class public instead of internal
- Made genetic algorithm interfaces (`IGABase`, `IGAChar`, etc.) public
- Made `IGAFactory` interface public for dependency injection
- Replaced magic numbers with named constants in `Settings` class
- Enhanced `GAMain` constructor to support factory injection
- Improved error handling with proper exception types instead of returning null

### 🚀 Performance
- Optimized chromosome selection algorithm to prevent infinite loops
- Added early termination support when fitness threshold is reached
- Improved random selection logic with better bounds checking

### 📚 Documentation
- Completely rewritten README with comprehensive usage examples
- Added inline documentation for new features
- Created CHANGELOG to track improvements
- Added code examples demonstrating dependency injection

### 🧹 Code Quality
- Replaced hardcoded values with constants from `Settings` class
- Added null checks and parameter validation throughout
- Improved method names and code organization
- Enhanced error messages for better debugging experience

## [Original] - Previous

### Features
- Basic genetic algorithm implementation
- Support for Integer, Double, Character, and String chromosomes
- Multiple crossover methods (One-point, Two-point, Uniform)
- Configurable mutation and selection parameters
- Factory pattern for creating genetic algorithm instances