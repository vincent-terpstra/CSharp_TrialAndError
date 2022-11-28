// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Running;
using RangeExtensions.LoopingMethods;

var summary = BenchmarkRunner.Run<Benchmarks>();