namespace C_Core_Fundamentals.Deconstruct;

public class DeconstructTests
{
    [Fact]
    public void DeconstructTestShouldReturnValues()
    {
        TestClass test = new()
        {
            StringValue = "Hello world",
            IntValue = 42,
            DateValue = new DateOnly(1991, 01, 01)
        };

        var (value, _, date) = test;

        var (day, month, year) = date;
        
        Assert.Equal(date, test.DateValue);
        Assert.Equal(value, test.IntValue);
        
        Assert.Equal(day, test.DateValue.Day);
        Assert.Equal(year, test.DateValue.Year);
        Assert.Equal(month, test.DateValue.Month);
    }
}