using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TopRecords.WPF.Client;
using TopRecords.WPF.View;

namespace TopRecords.WPF;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient(TopRecordsEndpoints.ClientName);
        services.AddScoped<ITopRecordsClient, TopRecordsClient>();
        services.AddSingleton<MainWindow>();
        
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}