using Microsoft.Win32;

namespace RentServiceFront.viewmodel;

public class LogInWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public LogInWindowViewModel()
    {
        _currentViewModel = new LogInViewModel();
        _currentViewModel.ViewModelRequested += OnViewModelChanged;
    }
    public LogInWindowViewModel(ViewModelBase vm)
    {
        _currentViewModel = vm;
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

    private void OnViewModelChanged(object? sender, ViewModelBase e)
    {
        CurrentViewModel = e;
    }
}