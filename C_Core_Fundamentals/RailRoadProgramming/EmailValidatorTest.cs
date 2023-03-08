namespace C_Core_Fundamentals.RailRoadProgramming;

public class EmailValidatorTest
{
    private readonly EmailValidator _validator;

    public EmailValidatorTest()
    {
        _validator = new EmailValidator();
    }

    [Theory]
    [InlineData("vince@somemail.co")]
    [InlineData("someone@gmail.ca")]
    [InlineData("hot@hotmail.com")]
    public void ValidEmailShouldReturnEmail(string validEmail)
    {
        //Arrange
        
        //Act
        var result = _validator.Validate(validEmail);
        
        Assert.True(result.IsSuccess);
        Assert.Equal(validEmail, result.Value.Email);
    }

    [Fact]
    public void EmailMinLengthShouldReturnError()
    {
        //Arrange
        string tinyEmail = "t@ny";
        
        //Act
        var result = _validator.Validate(tinyEmail);
        
        Assert.True(result.IsFailure);
        Assert.Equal(result.Error.Message, EmailValidator.EmailLength);
    }

    [Fact]
    public void EmailWithoutAShouldReturnMissingCharacter()
    {   
        //Email should expect an "@" symbol
        //Arrange
        string emailNoAt = "missingsymbol";
        
        //Act
        var result = _validator.Validate(emailNoAt);
        
        Assert.True(result.IsFailure);
        Assert.Equal(result.Error.Message, EmailValidator.IsMissingAtSymbol);
    }
    
    [Fact]
    public void NullEmailShouldReturnNullValue()
    {
        //Arrange
        string nullEmail = null;        
        //Act
        var result = _validator.Validate(nullEmail);
        
        Assert.True(result.IsFailure);
        Assert.Equal(Error.NullValue, result.Error);
    }
    
}