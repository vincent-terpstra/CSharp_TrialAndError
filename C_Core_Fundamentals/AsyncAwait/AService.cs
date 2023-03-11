using System.Diagnostics;

namespace C_Core_Fundamentals.AsyncAwait;

public class AService
{
    private readonly Task<A> _delayedA;

    public async Task<string> GetStringValue()
        => (await _delayedA).stringValue;
    
    public async Task<long> GetLongValue()
        => (await _delayedA).longValue;
    
    public AService(Stopwatch sw)
    {
        _delayedA = GetDelayedA(sw);
    }
    
    public async Task<A> GetDelayedA(Stopwatch sw)
    {
        Console.WriteLine("Before delay: " + sw.ElapsedMilliseconds);
        await Task.Delay(2000);
        return new A(sw)
        {
            stringValue = "string",
            longValue = sw.ElapsedMilliseconds
        };
    }
}