using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace UkiChat.Extensions;

public static class ConfigExtensions
{
    private static readonly Assembly Assembly = typeof(ConfigExtensions).Assembly;
    
    public static IServiceCollection AddByAttribute<T>(this IServiceCollection services)
        where T : Attribute
    {
        (from type in Assembly.GetTypes()
                where type.IsDefined(typeof(T), false)
                select type).ToList()
            .ForEach(type =>
            {
                var interfaceName = $"I{type.Name}";
                var iface = type.GetInterface(interfaceName)!;
                services.AddSingleton(iface, type);
            });

        return services;
    }
}