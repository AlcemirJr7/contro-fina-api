namespace ControlFina.Core.Abstractions.Results;

public class Error
{
    public string Description { get; }
    public int Code { get; }
    public ErrorType Type { get; }

    public static readonly Error None = new(0, string.Empty, ErrorType.None);
    public static readonly Error NullValue = new(
        0,
        "Null value was provided",
        ErrorType.Failure);

    public Error(int code, string description, ErrorType type)
    {
        Description = description;
        Code = code;
        Type = type;
    }
    public static Error Failure(int statusCode, string description) =>
        new(statusCode, description, ErrorType.Failure);

    public static Error NotFound(string description)
    {
        return new(CodeType.NotFound, description, ErrorType.NotFound);
    }

    public static Error Problem(int statusCode, string description) =>
        new(statusCode, description, ErrorType.Problem);

    public static Error Conflict(int statusCode, string description) =>
        new(statusCode, description, ErrorType.Conflict);
}
