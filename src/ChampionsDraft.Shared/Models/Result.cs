using Microsoft.AspNetCore.Http;

namespace ChampionsDraft.Shared.Models;

public readonly struct Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; }
    public Error Error { get; }

    private Result(bool isSuccess, T? value, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("Successful results cannot have an error.");
        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("Failing results must have an error.");

        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success() => new(true, default, Error.None);
    public static Result<T> Success(T value) => new(true, value, Error.None);
    public static Result<T> Failure(Error error) => new(false, default, error);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
}

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Results.Ok(result.Value);
        }

        var statusCode = result.Error.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Results.Problem(
            statusCode: statusCode,
            detail: result.Error.Description
        );
    }
}