using Amazon.Lambda.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace ImageServer;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    }
}
