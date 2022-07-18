using DiWpfApp.StartupHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfLib;


namespace DiWpfApp;

public partial class App : Application
{
    public static  IHost? AppHost { get; private set; }
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((services) =>
            {
                services.AddGenericAbstractFactory<IDataAccess , DataAccess>();
                services.AddSingleton<MainWindow>();
                services.AddFormFactory<ChildForm>();
                services.AddFormFactory<ThirdForm>();
                services.AddTransient<IDataAccess,DataAccess>();

            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startForm = AppHost?.Services.GetRequiredService<MainWindow>();

        if (startForm == null) return;

        startForm.Show();
            
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();

        base.OnExit(e);
    }
}