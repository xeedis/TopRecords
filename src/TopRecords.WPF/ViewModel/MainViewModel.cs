using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using Newtonsoft.Json;
using TopRecords.WPF.Client;
using TopRecords.WPF.Model;

namespace TopRecords.WPF.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ITopRecordsClient _topRecordsClient;
    public ObservableCollection<CD> CDs { get; set; }

    public MainViewModel(ITopRecordsClient topRecordsClient)
    {
        _topRecordsClient = topRecordsClient;
        CDs = new ObservableCollection<CD>();
    }

    public async Task FetchData()
    {
        var catalog = await _topRecordsClient.GetCdCatalog();
        CDs.Clear();
        foreach (var cd in catalog.CDs)
        {
            CDs.Add(cd);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}