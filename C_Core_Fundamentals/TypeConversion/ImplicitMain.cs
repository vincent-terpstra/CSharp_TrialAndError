namespace C_Core_Fundamentals.TypeConversion;

public class ImplicitMain
{
    [Fact]
    public void TestingImplicitOperator()
    {
        Guid id = Guid.NewGuid();

        //Constructor
        //UserId newUser = new UserId(id);
        //implicit assignment
        UserId user = id;

        //Explicit operator forces casting to Guid
        Guid userGuid = (Guid)user;

    }
}