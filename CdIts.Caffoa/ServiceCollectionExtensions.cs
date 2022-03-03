using Microsoft.Extensions.DependencyInjection;

namespace Caffoa;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaffoaFactory<T1, T2>(this IServiceCollection services)
        where T2 : class, ICaffoaFactory<T1>
    {
        return services.AddScoped<ICaffoaFactory<T1>, T2>();
    }

    public static IServiceCollection AddCaffoaFactory<T1, T2>(this IServiceCollection services,
        Func<IServiceProvider, T2> implementationFactory) where T2 : class, ICaffoaFactory<T1>
    {
        return services.AddScoped<ICaffoaFactory<T1>, T2>(implementationFactory);
    }

    public static IServiceCollection AddCaffoaConverter<T>(this IServiceCollection services)
        where T : class, ICaffoaConverter
    {
        return services.AddScoped<ICaffoaConverter, T>();
    }

    public static IServiceCollection AddCaffoaConverter<T>(this IServiceCollection services,
        Func<IServiceProvider, T> implementationFactory) where T : class, ICaffoaConverter
    {
        return services.AddScoped<ICaffoaConverter, T>(implementationFactory);
    }

    public static IServiceCollection AddCaffoaErrorHandler<T>(this IServiceCollection services)
        where T : class, ICaffoaErrorHandler
    {
        return services.AddScoped<ICaffoaErrorHandler, T>();
    }

    public static IServiceCollection AddCaffoaErrorHandler<T>(this IServiceCollection services,
        Func<IServiceProvider, T> implementationFactory) where T : class, ICaffoaErrorHandler
    {
        return services.AddScoped<ICaffoaErrorHandler, T>(implementationFactory);
    }

    public static IServiceCollection AddCaffoaJsonParser<T>(this IServiceCollection services)
        where T : class, ICaffoaJsonParser
    {
        return services.AddScoped<ICaffoaJsonParser, T>();
    }

    public static IServiceCollection AddCaffoaJsonParser<T>(this IServiceCollection services,
        Func<IServiceProvider, T> implementationFactory) where T : class, ICaffoaJsonParser
    {
        return services.AddScoped<ICaffoaJsonParser, T>(implementationFactory);
    }

    public static IServiceCollection AddCaffoaResultHandler<T>(this IServiceCollection services)
        where T : class, ICaffoaResultHandler
    {
        return services.AddScoped<ICaffoaResultHandler, T>();
    }

    public static IServiceCollection AddCaffoaResultHandler<T>(this IServiceCollection services,
        Func<IServiceProvider, T> implementationFactory) where T : class, ICaffoaResultHandler
    {
        return services.AddScoped<ICaffoaResultHandler, T>(implementationFactory);
    }
}
