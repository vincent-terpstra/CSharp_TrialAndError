namespace C_Core_Fundamentals.RailRoadProgramming;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }
    public static Error None => new("No Issue");
    public static Error NullValue => new("Input cannot be null");
    
    public String Message { get; }
    

    public override bool Equals(object? obj)
    {
        return obj is Error error && error.Message.Equals( this.Message);
    }

    public override int GetHashCode()
    {
        return Message.GetHashCode();
    }
}