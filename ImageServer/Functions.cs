using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using ImageServer;
using LambdaHelpers.Responses;

[assembly: LambdaGlobalProperties(GenerateMain = true)]
[assembly: LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<CustomSerializationContext>))]

namespace ImageServer;

public class Functions
{
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/{domain}")]
    public IHttpResult GetImages(string domain, ILambdaContext context) =>
        TryCatch(domain, context, () => ProcessImages(domain));

    private static IHttpResult ProcessImages(string? domain) => domain?.ToLowerInvariant() switch
    {
        null => ResultWithHeaders(ResponseType.BadResponse),
        "localhost" => ResultWithHeaders(ResponseType.GoodResponse, Images.LocalhostImages()),
        "cloudfront" => ResultWithHeaders(ResponseType.GoodResponse, Images.CloudFrontImages()),
        _ => ResultWithHeaders(ResponseType.NotFoundResponse)
    };

    private delegate IHttpResult GetImagesFunction();

    private static IHttpResult TryCatch(
        string? domain,
        ILambdaContext context,
        GetImagesFunction getImagesFunction)
    {
        try
        {
            context.Logger.LogInformation($"Get Request for {domain}");
            return getImagesFunction();
        }
        catch (Exception ex)
        {
            context.Logger.LogError(ex.Message);
            return ResultWithHeaders(ResponseType.ErrorResponse);
        }
    }

    private static IHttpResult ResultWithHeaders(ResponseType responseType, object? content = null)
    {
        IHttpResult result = responseType switch
        {
            ResponseType.GoodResponse => HttpResults.Ok(content),
            ResponseType.BadResponse => HttpResults.BadRequest(content),
            ResponseType.NotFoundResponse => HttpResults.NotFound(content),
            ResponseType.ErrorResponse => HttpResults.InternalServerError(content),
            _ => HttpResults.InternalServerError(content)
        };

        ResponseHeaders.DefaultHeaders
            .ForEach(h => result.AddHeader(h.Name, h.Value));

        return result;
    }
}
