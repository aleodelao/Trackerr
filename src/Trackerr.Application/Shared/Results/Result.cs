using Trackerr.Application.Shared.Results;

public sealed class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; set; }

    private Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
        => new (true, null);

    public static Result Failure(Error error)
        => new (false, error);
}