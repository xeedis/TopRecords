using System.Configuration;
using System.Data;
using System.Windows;
using TopRecords.WPF.View;

namespace TopRecords.WPF;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        CatalogView mainWindow = new CatalogView();
        
        mainWindow.Show();
    }
}