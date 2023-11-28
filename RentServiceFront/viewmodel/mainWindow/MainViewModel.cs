using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RentServiceFront.viewmodel.mainWindow;

public class MainViewModel : ViewModelBase
{
    private List<SampleItem> _sampleItems;
    private SampleItem _selectedItem;
    private ViewModelBase _currentViewModel;
    public ICommand ExitCommand { get; }
    public MainViewModel(List<SampleItem> sampleItems)
    {
        ExitCommand = new RelayCommand(ExitCommandExecute);
        SampleItems = sampleItems;
        _selectedItem = sampleItems[0];
        _currentViewModel = _selectedItem.ViewModel;
        _currentViewModel.ViewModelRequested += OnViewModelChanged;
    }
    
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel.ViewModelRequested -= OnViewModelChanged; 
            _currentViewModel = value;
            _currentViewModel.ViewModelRequested += OnViewModelChanged; 
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }

    public List<SampleItem> SampleItems
    {
        get => _sampleItems;
        set
        {
            _sampleItems = value;
            OnPropertyChange(nameof(SampleItems));
        }
    }

    public SampleItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            CurrentViewModel = _selectedItem.ViewModel;
            OnPropertyChange(nameof(SelectedItem));
        }
    }
    
    private void OnViewModelChanged(object? sender, ViewModelBase e)
    {
        CurrentViewModel = e;
        _selectedItem = null;
        OnPropertyChange(nameof(SelectedItem));
    }

    private void ExitCommandExecute(object param)
    {
        OnExitCommand?.Invoke();
    }
    
    public Action OnExitCommand { get; set; } 
}