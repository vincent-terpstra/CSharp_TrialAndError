using System.Runtime.CompilerServices;

namespace C_Core_Fundamentals.CallerArguments;

public class FileDemo
{
    public static void Example([CallerFilePath]string path = default!, 
        [CallerLineNumber]int number = 0
    )
    {
        Console.WriteLine(path);
        Console.WriteLine(number);
    }

    public static void Test()
    {
        Example();
    }
}