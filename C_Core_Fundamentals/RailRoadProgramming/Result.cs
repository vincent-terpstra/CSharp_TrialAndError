using Xunit.Sdk;

namespace RangeExtensions.RailRoadProgramming;

public class Result<T>
{
    public T Value { get; }

    public bool IsFailure => !IsSuccess;
    public bool IsSuccess { get; }
    
    public Error Error { get; }
    
    internal Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    internal Result(Error error)
    {
        Error = error;
        IsSuccess = false;
    }
    public Result<TOutput> Map<TOutput>(Func<T, TOutput> mappingFunction) => 
        IsFailure ? new Result<TOutput>(Error) 
                  : new Result<TOutput>( mappingFunction(Value) );

    public Result<T> Ensure(Func<T, bool> ensureCheck, Error error)
    {
        return IsFailure || ensureCheck(Value) ? this :
            new Result<T>(error);
    }
    
    public static Result<TInput> Create<TInput>(TInput value)
    {
        return value is null ? new Result<TInput>(Error.NullValue) : new Result<TInput>(value);
    }
}