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
}
