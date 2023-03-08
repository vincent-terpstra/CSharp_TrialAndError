namespace C_Core_Fundamentals.RailRoadProgramming;

public class EmailValidator
{
    private static int minLength = 5;
    public static string IsMissingAtSymbol => "Email must contain a single @ symbol";
    public static string EmailLength => $"Email Length must be greater than {minLength}";
    
    public Result<ValidEmail> Validate(string email)
    {
        var result = new Result<string>(email)
            .Ensure(str => str.Split("@").Length == 2, new Error(IsMissingAtSymbol))
            .Ensure(e => e.Length > minLength, new Error(EmailLength))
            .Map(str => new ValidEmail(str!));

        return result;
    }

}