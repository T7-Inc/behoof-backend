using Microsoft.AspNetCore.Http;

namespace Shared.Errors;

public class ApiResponse
{
    public int StatusCode { get; set; }

    public string Message { get; set; }

    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessage(statusCode);
    }

    private string GetDefaultMessage(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status400BadRequest => "Bad request!",
            StatusCodes.Status401Unauthorized => "Unauthorized!",
            StatusCodes.Status404NotFound => "Not Found!",
            StatusCodes.Status500InternalServerError => "Internal Server Error!",
            _ => "Error!"
        };
    }
}