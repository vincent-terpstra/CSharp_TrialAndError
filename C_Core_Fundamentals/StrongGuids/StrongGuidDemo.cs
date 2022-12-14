namespace RangeExtensions.StrongGuids;

public class StrongGuidDemo
{
    public static void Run()
    {

        CreateStrong(Guid.NewGuid());
    }

    private static Strong CreateStrong(Guid userId)
    {
        //NOTE wrong assignment of Strong.Id from userId
        //This is a case of ID obsession where 
        return new Strong()
        {
            //NOTE TYPE ERROR
            //Id = userId,
            UserId = userId
        };
    }

    private static Strong CreateStrongSafe(Guid userId)
    {
        return new Strong()
        {
            Id = StrongId.New(),
            UserId = userId
        };
    }
}