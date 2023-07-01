using Microsoft.Extensions.DependencyInjection;
using UkiChat.Core;
using UkiChat.Extensions;

namespace UkiChat.Configuration;

public static class DIConfig
{
    public static ServiceProvider Init()
    {
        var services = ConfigureServices();
        return services.BuildServiceProvider();
    }
    
    private static IServiceCollection ConfigureServices()
    {
        return new ServiceCollection()
            .AddByAttribute<ServiceAttribute>();
    }
}