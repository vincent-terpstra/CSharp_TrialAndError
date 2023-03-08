namespace C_Core_Fundamentals.TypeConversion;

public class UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }

    
    //Allows conversion of Guid to UserId
    public static implicit operator UserId(Guid guid)
    {
        return new UserId(guid);
    }
    
    //Implicit conversion back
    // public static implicit operator Guid(UserId userId)
    // {
    //     return userId.Value;
    // }
    
    public static explicit operator Guid(UserId userId)
    {
        return userId.Value;
    }
    
    
}