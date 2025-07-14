namespace ControlFina.Core.Abstractions.Results;

public class Result
{
    public bool IsSuccess { get; }

    public int Code { get; set; }

    public Error Error { get; }

    public Result(bool isSuccess, Error error, int code = CodeType.Ok)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Code = code;
    }

    public static Result Success() => new(true, Error.None, CodeType.Ok);

    public static Result<TData> Success<TData>(TData data) =>
        new(data, true, Error.None, CodeType.Ok);

    public static Result<TData> SuccessCreated<TData>(TData data) =>
        new(data, true, Error.None, CodeType.Created);

    public static Result Failure(Error error) => new(false, error, error.Code);

    public static Result<TData> Failure<TData>(Error error) =>
        new(default, false, error, error.Code);
}

public class Result<TData> : Result
{
    private readonly TData? _data;

    public Result(TData? data, bool isSuccess, Error error, int code)
        : base(isSuccess, error, code)
    {
        _data = data;
        Code = code;
    }

    public TData? Data => _data;

    public static implicit operator Result<TData>(TData? value) =>
        value is not null ? Success(value) : Failure<TData>(Error.NullValue);

    public static Result<TData> ValidationFailure(Error error) =>
        new(default, false, error, error.Code);
}
