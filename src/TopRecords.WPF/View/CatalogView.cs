using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TopRecords.WPF.ViewModel;

namespace TopRecords.WPF.View;

public class CatalogView : Window
{
    private DataGrid dataGrid;
    private CatalogViewModel viewModel;

    public CatalogView()
    {
        viewModel = new CatalogViewModel();
        DataContext = viewModel;
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        Title = "Katalog CD";
        Height = 350;
        Width = 525;
        
        Grid grid = new Grid();
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); 
        grid.RowDefinitions.Add(new RowDefinition()); 

        Content = grid;
        
        Button loadButton = new Button
        {
            Content = "Pobierz",
            Height = 30,
            Width = 80,
            Margin = new Thickness(10)
        };
        loadButton.Command = viewModel.LoadDataCommand;
        Grid.SetRow(loadButton, 0); 
        grid.Children.Add(loadButton);
        
        dataGrid = new DataGrid
        {
            Margin = new Thickness(10),
            AutoGenerateColumns = false,
        };
        Grid.SetRow(dataGrid, 1); 
        grid.Children.Add(dataGrid);
        
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Tytuł", Binding = new Binding("Title") });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Artysta", Binding = new Binding("Artist") });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Kraj", Binding = new Binding("Country") });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Firma", Binding = new Binding("Company") });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Rok", Binding = new Binding("Year") });

        var opt = viewModel.CDs;
        dataGrid.ItemsSource = viewModel.CDs;
    }
}
