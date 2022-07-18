using System;
using Microsoft.Extensions.DependencyInjection;

namespace DiWpfApp.StartupHelpers;
//builder.Services.AddTransient<ISample1, Sample1>();
//builder.Services.AddSingleton<Func<ISample1>>(x => () => x.GetService<ISample1>()!);

// builder.Services.AddAbstractFactory<ISample1, Sample1>();

public static class AbstractGenericFactoryExtension
{
    public static void AddGenericAbstractFactory<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddTransient<TInterface, TImplementation>();
        services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
        services.AddSingleton<IAbstractFactory<TInterface>, AbstractGenericFactory<TInterface>>();
    }
}

public class AbstractGenericFactory<T> : IAbstractFactory<T>
{
    private readonly Func<T> _factory;

    public AbstractGenericFactory(Func<T> factory)
    {
        _factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}


