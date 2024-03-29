﻿using System.Diagnostics;
using Xunit.Abstractions;

namespace C_Core_Fundamentals.AsyncAwait;

public class AMain
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AMain(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task AServiceStartsTaskWhenCreated()
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

        long intVal2 = await service.GetLongValue();
        Assert.Equal(intVal, intVal2);
        Assert.Equal(stringVal, await service.GetStringValue());
    }

    [Fact]
    public async Task AwaitForStartedTasksIsFine()
    {
        Stopwatch sw = new();
        sw.Start();
        AService aservice = new AService(sw);

        var a =  aservice.GetDelayedA(sw, "A", 2000);
        var b =  aservice.GetDelayedA(sw, "B", 3000);
        _testOutputHelper.WriteLine(sw.ElapsedMilliseconds.ToString());
        Assert.Equal("A", (await a).stringValue);
        Assert.Equal("B", (await b).stringValue);
        Assert.Equal("B", (await b).stringValue);
        _testOutputHelper.WriteLine(sw.ElapsedMilliseconds.ToString());
        
        Assert.True(sw.ElapsedMilliseconds < 3500);
    }

    [Fact]
    public async Task AwaitWhenStartingTaskIsBad()
    {
        Stopwatch sw = new();
        sw.Start();
        AService aservice = new AService(sw);

        var a =  await aservice.GetDelayedA(sw, "A", 3000);
        var b = await aservice.GetDelayedA(sw, "B", 3000);
        sw.Stop();
        
        _testOutputHelper.WriteLine(sw.ElapsedMilliseconds.ToString());
        Assert.False(sw.ElapsedMilliseconds < 3200);
        Assert.True(sw.ElapsedMilliseconds > 6000);
    }

    [Fact]
    public async void Prefer_Configure_Await()
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        
        Stopwatch sw = new();
        sw.Start();
        AService service = new AService(sw);
        
        var configureTrue = await service.GetDelayedA(sw, "A");

        //recommended configure await will allow any thread to pick up the process
        var configureFalse = await service.GetDelayedA(sw, "A").ConfigureAwait(false);
        var threadIdAfterAwait = Thread.CurrentThread.ManagedThreadId;
        
        Assert.NotEqual(threadId, threadIdAfterAwait);
    }

    [Fact]
    public void Prefer_Get_Awaiter_Get_Result()
    {
        Stopwatch sw = new();
        sw.Start();
        AService service = new AService(sw);
        
        //prefer using getAwaiter.GetResult over .Result
        // this will preserve stack trace
        var result = service.GetDelayedA(sw, "B").Result;
        
        //prefer using getAwaiter.GetResult over .Result
        // this will preserve stack trace
        var AwaiterResult = service.GetDelayedA(sw, "B").GetAwaiter().GetResult();
    }
    
}