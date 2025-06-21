using ControlFina.Core.Abstractions.Results;

namespace ControlFina.Api.Extensions;

public static class ResultExtensions
{
    public static IResult Response(this Result result, string? uri = null)
    {
        try
        {
            switch (result.Code)
            {
                case StatusCodes.Status200OK: return Results.Ok(result);
                case StatusCodes.Status201Created: return Results.Created(uri, result);
                case StatusCodes.Status400BadRequest: return Results.BadRequest(result);
                case StatusCodes.Status401Unauthorized: return Results.Unauthorized();
                case StatusCodes.Status404NotFound: return Results.NotFound(result);
                default: return Results.InternalServerError(result);
            }
        }
        catch (Exception)
        {
            return Results.InternalServerError(result);
        }
    }
}
