namespace LambdaHelpers.Responses;

public static class ResponseHeaders
{
    public static List<(string Name, string Value)> DefaultHeaders =>
    [
        ("Content-Type", "application/json"),
        ("Access-Control-Allow-Origin", "*"),
        ("Access-Control-Allow-Credentials", "true")
    ];
}
