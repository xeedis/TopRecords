using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TopRecords.WPF.Client;
using TopRecords.WPF.Model;

namespace TopRecords.WPF.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ITopRecordsClient _topRecordsClient;
    public ObservableCollection<CD> CDs { get; }

    public MainViewModel(ITopRecordsClient topRecordsClient)
    {
        _topRecordsClient = topRecordsClient;
        CDs = new ObservableCollection<CD>();
    }

    public async Task FetchData()
    {
        try
        {
            var catalog = await _topRecordsClient.GetCdCatalog();
            CDs.Clear();
            foreach (var cd in catalog.CDs)
            {
                CDs.Add(cd);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}