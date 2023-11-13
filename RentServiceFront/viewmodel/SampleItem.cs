using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MaterialDesignThemes.Wpf;

namespace RentServiceFront.viewmodel;

public class SampleItem : ViewModelBase
{
    public string? Title { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
    private object? _notification = null;

    public ViewModelBase _viewModel { get; set; }
      
    public object? Notification
    {
        get { return _notification; }
        set { SetProperty(ref _notification, value); }
    }
    
    protected virtual bool SetProperty<T>(ref T member, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(member, value))
        {
            return false;
        }

        member = value;
        OnPropertyChange(propertyName);
        return true;
    } 
}