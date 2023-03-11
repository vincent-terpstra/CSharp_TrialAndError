using System.Diagnostics;

namespace C_Core_Fundamentals.AsyncAwait;

public class A
{
    public string stringValue {get; init; }
    public long longValue { get; init; }

    public A(Stopwatch sw)
    {
        Console.WriteLine("In Constructor: " + sw.ElapsedMilliseconds);
    }
}