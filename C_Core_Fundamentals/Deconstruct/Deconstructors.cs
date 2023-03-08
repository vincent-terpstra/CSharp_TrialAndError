namespace C_Core_Fundamentals.Deconstruct;
#nullable disable

public class TestClass
{
    public int IntValue { get; init; }
    public string StringValue { get; init; }
    
    public DateOnly DateValue { get; init; }
    public void Deconstruct(out int value, out string str, out DateOnly date)
    {
        value = IntValue;
        str = StringValue;
        date = DateValue;
    }
}

public static class DeconstructExtensions
{
    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year)
    {
        year = date.Year;
        month = date.Month;
        day = date.Day;
    }
}