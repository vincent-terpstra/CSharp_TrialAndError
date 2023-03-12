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
    

    public async Task<A> GetDelayedA(Stopwatch sw, string val = "string", int delay = 2000)
    {
        await Task.Delay(delay);
        return new A(sw)
        {
            stringValue = val,
            longValue = sw.ElapsedMilliseconds
        };
    }
    
}
