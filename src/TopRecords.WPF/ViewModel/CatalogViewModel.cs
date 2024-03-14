using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using TopRecords.WPF.Commands;
using TopRecords.WPF.Model;

namespace TopRecords.WPF.ViewModel;

public class CatalogViewModel : INotifyPropertyChanged
{
    public ICommand LoadDataCommand { get; }

    private ObservableCollection<CD> _cds;
    public ObservableCollection<CD> CDs
    {
        get => _cds;
        set
        {
            _cds = value;
            OnPropertyChanged(nameof(CDs));
        }
    }

    public CatalogViewModel()
    {
        LoadDataCommand = new RelayCommand(async () => await LoadData());
    }

    public async Task LoadData()
    {
        using (var client = new HttpClient())
        {
            try
            {
                string url = "http://localhost:5062/catalogs";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Catalog catalog = JsonConvert.DeserializeObject<Catalog>(json);
                    
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CDs = new ObservableCollection<CD>(catalog.CDs);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}