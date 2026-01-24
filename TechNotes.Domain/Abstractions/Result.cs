namespace TechNotes.Domain.Abstractions;

public class Result
{
    public bool IsSuccessful { get; }
    public bool HasFailed => !IsSuccessful;
    public string? ErrorMessage { get; }

    public Result(bool IsSuccessful, string? errorMessage = null)
    {
        this.IsSuccessful = IsSuccessful;
        ErrorMessage = errorMessage;
    }

    public static Result Success() => new Result(true);
    public static Result Failure(string errorMessage) => new Result(false, errorMessage);
    public static Result<T> Ok<T>(T? value) => new Result<T>(value, true, null);
    public static Result<T> Fail<T>(string errorMessage) => new Result<T>(default, false, errorMessage);
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(T? value, bool isSuccessful, string? errorMessage = null)
        : base(isSuccessful, errorMessage)
    {
        Value = value;
    }
}