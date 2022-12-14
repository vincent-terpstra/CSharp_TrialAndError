using HashidsNet;

namespace RangeExtensions.HashIds;

public class HashId
{
    private readonly IHashids _hashids;

    public HashId(IHashids hashids)
    {
        _hashids = new Hashids("Salty", minHashLength: 11);
    }

    public string GetHashId(int number)
    {
        return _hashids.Encode(number);
    }

    public int DecodeHashId(string hash)
    {
        return _hashids.Decode(hash)[0];
    }
    
}