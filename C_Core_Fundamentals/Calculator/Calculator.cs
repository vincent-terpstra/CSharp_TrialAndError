namespace C_Core_Fundamentals.Calculator;

/// <summary>
/// Calculator class used in XUnit testing project
/// </summary>
public class Calculator
{
    public double Add(double x, double y)
    {
        return x + y;
    }
    
    public double Subtract(double x, double y)
    {
        return x - y;
    }  
    
    public double Multiply(double x, double y)
    {
        return x * y;
    }  
    
    public double Divide(double x, double y)
    {
        //Instead of returning double.PositiveInfinity
        if (y == 0)
            throw new DivideByZeroException();
        
        return x / y;
    }  
}