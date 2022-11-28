using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace RangeExtensions.LoopingMethods;


[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(100, 100_000, 1_000_000)] public int Size { get; set; }
    private List<IntWrap> _items;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(42);
        _items = Enumerable.Range(1, Size).Select(x => (IntWrap)random.Next()).ToList();
    }

    [Benchmark]
    public List<IntWrap> For()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
            DoSomething(item);
        }

        return _items;
    }

    [Benchmark]
    public List<IntWrap> Foreach()
    {
        foreach (var item in _items)
        {
            DoSomething(item);
        }

        return _items;
    }

    [Benchmark]
    public List<IntWrap> For_Span()
    {
        Span<IntWrap> asSpan = CollectionsMarshal.AsSpan(_items);
        for (var i = 0; i < asSpan.Length; i++)
        {
            var item = asSpan[i];
            DoSomething(i);
        }

        return _items;
    }

    [Benchmark]
    public List<IntWrap> For_Unsafe_Span()
    {
        Span<IntWrap> asSpan = CollectionsMarshal.AsSpan(_items);
        ref var searchSpace = ref MemoryMarshal.GetReference(asSpan);

        for (int i = 0; i < asSpan.Length; i++)
        {
            var item = Unsafe.Add(ref searchSpace, i);
            DoSomething(item);
        }
        
        
        return _items;
    }
    
    
    private void DoSomething(int item)
    {
        
    }
}

public class IntWrap
{
    private int Value { get; init; }

    public IntWrap(int value)
    {
        Value = value;
    }

    public static implicit operator int(IntWrap number) => number.Value;
    public static implicit operator IntWrap(int number) => new IntWrap(number);
}