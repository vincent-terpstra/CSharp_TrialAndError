// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Running;
using Benchmarks.Linq;

var summary = BenchmarkRunner.Run<LinqOrderBenchMarks>();