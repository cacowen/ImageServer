using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json.Serialization;

namespace ImageServer;

[JsonSerializable(typeof(APIGatewayProxyRequest))]
[JsonSerializable(typeof(APIGatewayProxyResponse))]
[JsonSerializable(typeof(ImageResponse))]
[JsonSerializable(typeof(List<ImageResponse>))]
public partial class CustomSerializationContext : JsonSerializerContext
{
}
