using System.Diagnostics;

namespace C_Core_Fundamentals.AsyncAwait;

public class AMain
{
    [Fact]
    public async Task AServiceReturnsValues()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        
        AService service = new AService(sw);
        
        //proving that the task starts
        await Task.Delay(1000);
        Assert.True(1000 < sw.ElapsedMilliseconds);
        
        long intVal = await service.GetLongValue();
        string stringVal = await service.GetStringValue();
        
        Assert.True(2000 <= intVal);
        Assert.True(2200 > intVal);
        Assert.Equal("string", stringVal);
    }
}