using System.Runtime.CompilerServices;

namespace C_Core_Fundamentals.CallerArguments;

public class ArgExpressionDemo
{
    public static void Test()
    {
        Example(1 + 2);
        Example(() => 3 + 4);
    }

    public static void Example(int number, [CallerArgumentExpression("number")]string parameter = default)
    {
        Console.WriteLine(parameter);
        Console.WriteLine(number);
    }

    public static void Example(Func<int> number,  [CallerArgumentExpression("number")]string parameter = default)
    {
        Console.WriteLine(parameter);
        Console.WriteLine(number());
    }
}