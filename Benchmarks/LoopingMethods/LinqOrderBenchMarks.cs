using BenchmarkDotNet.Attributes;

namespace Benchmarks.Linq;

[MemoryDiagnoser]
public class LinqOrderBenchMarks
{
    private readonly Random _random = new();
    private int[] _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(1, 100).Select(_ => _random.Next()).ToArray();
    }

    [Benchmark]
    public int[] OrderBy() => _items.OrderBy(x => x).ToArray();
    
    [Benchmark]
    public int[] OrderByDescending() => _items.OrderByDescending(x => x).ToArray();
    
    [Benchmark]
    public int[] Order() => _items.Order().ToArray();
    
    [Benchmark]
    public int[] OrderDescending() => _items.OrderDescending().ToArray();
    
    
}