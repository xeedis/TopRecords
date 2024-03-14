using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TopRecords.WPF.Model;

public class CD : INotifyPropertyChanged
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Country { get; set; }
    public string Company { get; set; }
    public decimal Price { get; set; }
    public string Year { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}