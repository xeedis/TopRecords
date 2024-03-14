using System.Windows;
using System.Windows.Controls;
using TopRecords.WPF.Client;
using TopRecords.WPF.ViewModel;

namespace TopRecords.WPF.View;

public partial class MainWindow : Window
{

    private MainViewModel viewModel;

    public MainWindow(ITopRecordsClient topRecordsClient)
    {
        viewModel = new MainViewModel(topRecordsClient);
        DataContext = viewModel;
        CreateUi();
    }

    private void CreateUi()
    {
        Button fetchButton = new Button
        {
            Content = "Pobierz dane",
            Width = 100,
            Height = 30,
            Margin = new Thickness(10)
        };
        fetchButton.Click += async (sender, e) => await viewModel.FetchData();

        DataGrid dataGrid = new DataGrid
        {
            Margin = new Thickness(10),
            AutoGenerateColumns = true,
            ItemsSource = viewModel.CDs
        };

        StackPanel stackPanel = new StackPanel();
        stackPanel.Children.Add(fetchButton);
        stackPanel.Children.Add(dataGrid);

        Content = stackPanel;
    }
}