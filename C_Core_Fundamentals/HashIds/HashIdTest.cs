using HashidsNet;

namespace C_Core_Fundamentals.HashIds;

public class HashIdTest
{
    private readonly HashId _hashids;

    public HashIdTest()
    {
        _hashids = new HashId(new Hashids("random salt", minHashLength: 11));
    }

    [Theory]
    [InlineData(100)]
    [InlineData(101)]
    public void HashingIdsCanBeDecoded(int input)
    {
        //Arrange
        //Act
        string hash = _hashids.GetHashId(input);
        int decode = _hashids.DecodeHashId(hash);
        
        //Assert
        Assert.Equal(input, decode);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(101)]
    public void HashingMultipleIdsProducesSameResult(int input)
    {
        //Arrange

        //Act
        string firstHash = _hashids.GetHashId(input);
        string secondHash = _hashids.GetHashId(input);
        string thirdHash = _hashids.GetHashId(input);
        
        //Assert
        Assert.Equal(firstHash, secondHash);
        Assert.Equal(secondHash, thirdHash);
    }

    [Fact]
    public void TwoRandomHashesAreNotIdentical()
    {
        //Arrange
        Random rnd = new Random();

        int first = rnd.Next();
        int second = rnd.Next();
        if (first == second)
            first++;

        //Act
        string firstHash = _hashids.GetHashId(first);
        string secondHash = _hashids.GetHashId(second);

        //Assert
        Assert.NotEqual(firstHash, secondHash);
    }
}