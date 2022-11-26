// ReSharper disable once CheckNamespace
namespace RangeExtensions;

public static class RangeExtensions
{
    public static void MainMethod()
    {
        Console.WriteLine("1..5");
        foreach(int i in 1..5)
            Console.WriteLine(i);

        Console.WriteLine("8..3");
        foreach(int i in 8..3)
            Console.WriteLine(i);

        Console.WriteLine(" ..3");    
        foreach(int i in ..3)
            Console.WriteLine(i);

        Console.WriteLine("5.To(10)");
        foreach (int i in 5.To(10))
            Console.WriteLine(i);

        Console.WriteLine("(-3).To(-5)");
        foreach (int i in (-3).To(-5))
            Console.WriteLine(i);

    
        Console.WriteLine("(-3, -5)");
        foreach(int i in (-3, -5))
            Console.WriteLine(i);
    }
    
    
    public static TupleEnumerator GetEnumerator(this (int start, int end) tuple )
    {
        return new TupleEnumerator(tuple);
        /*int increment = tuple.Item1 > tuple.Item2 ? -1 : 1;
        int start = tuple.Item1 - increment;
        int end = tuple.Item2;
        start -= increment;
        while (start != end)
        {
            start += increment;
            yield return start;
        }*/
    }

    public static IEnumerable<int> To(this int start, int end)
    {
        int increment = start > end ? -1 : 1;
        start -= increment;
        while (start != end)
        {
            start += increment;
            yield return start;
        }
    }

    public static IEnumerator<int> GetEnumerator(this Range range )
    {
        if (range.End.IsFromEnd)
            throw new NotSupportedException("Range as IEnumerator<int> must have an end value");
        
        int end = range.End.Value;
        int increment = range.Start.Value > end ? -1 : 1;
        int current = range.Start.Value - increment;
        
        while (current != end)
        {
            current += increment;
            yield return current;
        }
    }
}

public class TupleEnumerator
{
    private readonly int _end;
    private int _current;
    private readonly int _increment;
    public TupleEnumerator((int start, int end) tuple)
    {
        _end = tuple.end;
        _increment = tuple.start < tuple.end ? 1 : -1;
        _current = tuple.start - _increment;
    }

    public int Current => _current;

    public bool MoveNext()
    {
        if (_current == _end)
            return false;
        _current += _increment;
        return true;
    }
}
