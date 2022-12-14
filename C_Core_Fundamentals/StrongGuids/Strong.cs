using StronglyTypedIds;

namespace RangeExtensions.StrongGuids;

[StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
public partial struct StrongId
{
}



public class Strong
{
    public StrongId Id { get; init; } = StrongId.New();
    
    public Guid UserId { get; init; } = Guid.NewGuid();
}