using System.Runtime.CompilerServices;

namespace C_Core_Fundamentals.CallerArguments;

public class FileDemo
{
    public static (string path, int number) Example([CallerFilePath]string path = default!, 
        [CallerLineNumber]int number = 0
    )
    {
        Console.WriteLine(path);
        Console.WriteLine(number);
        return (path, number);
    }

    public static (string path, int number) ExampleFromFileDemo()
    {
        return Example();
    }
}