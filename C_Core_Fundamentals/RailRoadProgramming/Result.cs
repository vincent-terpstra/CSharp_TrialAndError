using System.ComponentModel.Design.Serialization;
using Xunit.Sdk;

namespace RangeExtensions.RailRoadProgramming;

public class Result
{
    public Error Error { get; protected init; }

    protected Result()
    {
        Error = Error.None;
        IsSuccess = true;
    }
    
    protected Result(Error error)
    {
        Error = error;
        IsSuccess = false;
    }
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
}

public class Result<T> : Result
{
    public T Value { get; }
    
    public Result(T value) : base()
    {
        if (value is null)
        {
            Error = Error.NullValue;
            IsSuccess = false;
        }

        Value = value;
    }
    public Result(Error error) : base(error)
    {
    }

    public Result<T> Ensure(Func<T, bool> ensureCheck, Error error)
        => IsFailure || ensureCheck(Value) 
            ? this : new Result<T>(error);
    public Result<TOutput> Map<TOutput>(Func<T, TOutput> mappingFunction) 
        => IsFailure ? new Result<TOutput>(this.Error) 
                     : new Result<TOutput>( mappingFunction(Value) );
}