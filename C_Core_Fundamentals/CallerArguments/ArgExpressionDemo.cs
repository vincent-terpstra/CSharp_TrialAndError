using System.Runtime.CompilerServices;

namespace C_Core_Fundamentals.CallerArguments;

public class ArgExpressionDemo
{
    public static (int number, string argument) Example(int number, [CallerArgumentExpression("number")]string parameter = default)
    {
        return (number, parameter);
    }

    public static (int number, string argument) Example(Func<int> number,  [CallerArgumentExpression("number")]string parameter = default)
    {
        return (number(), parameter);
    }
    
    [Fact]
    public void ExampleWithSum()
    {
        var example = Example(1 + 2);
        
        Assert.Equal(3, example.number);
        Assert.Equal("1 + 2", example.argument);
    }
    
    [Fact]
    public void ExampleWithFunction()
    {
        var example = Example(() => 3 + 4);
        
        Assert.Equal(7, example.number);
        Assert.Equal("() => 3 + 4", example.argument);
    }

    [Fact]
    public void FileDemoFromAnotherClass()
    {
        var output = FileDemo.Example();
        
        Assert.Equal(38, output.number);
        Assert.EndsWith(@"C_Core_Fundamentals\C_Core_Fundamentals\CallerArguments\ArgExpressionDemo.cs", output.path);
    }
    
    [Fact]
    public void FileDemoFromFileDemo()
    {
        var output = FileDemo.ExampleFromFileDemo();
        
        Assert.Equal(18, output.number);
        Assert.EndsWith(@"C_Core_Fundamentals\C_Core_Fundamentals\CallerArguments\FileDemo.cs", output.path);
    }

    
}