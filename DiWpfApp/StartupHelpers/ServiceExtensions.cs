using System;
using Microsoft.Extensions.DependencyInjection;

namespace DiWpfApp.StartupHelpers;

public static class ServiceExtensions
{
    public static void AddFormFactory<TForm>(this IServiceCollection services) where TForm : class
    {
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
        services.AddSingleton<IAbstractFactory<TForm> , AbstractFactory<TForm>>();
    }
}