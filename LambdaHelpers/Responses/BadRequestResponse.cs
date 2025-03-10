namespace LambdaHelpers.Responses;

public record BadRequestResponse(
    string? Message,
    int? Code,
    string? ExceptionType);
