using System;
using System.ComponentModel;
using System.Windows;

namespace RentServiceFront.viewmodel;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public event EventHandler<ViewModelBase> ViewModelRequested;

    protected virtual void OnPropertyChange(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void RaiseViewModelRequested(ViewModelBase viewModel)
    {
        ViewModelRequested?.Invoke(this, viewModel);
    }

    protected virtual void Dispose()
    {
    }
}