using System.ComponentModel.Design.Serialization;
using Xunit.Sdk;

namespace RangeExtensions.RailRoadProgramming;

public class Result<T>
{
    public T Value { get; }
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    
    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
        Error = Error.None;
    }

    private Result(Error error)
    {
        Error = error;
        IsSuccess = false;
    }
    public Result<TOutput> Map<TOutput>(Func<T, TOutput> mappingFunction) => 
        IsFailure ? new Result<TOutput>(Error) 
                  : new Result<TOutput>( mappingFunction(Value) );

    public Result<T> Ensure(Func<T, bool> ensureCheck, Error error)
        => IsFailure || ensureCheck(Value) 
            ? this : new Result<T>(error);
    
    
    public static Result<TInput> Create<TInput>(TInput value) =>
        value is null ? new Result<TInput>(Error.NullValue) : new Result<TInput>(value);
    
}