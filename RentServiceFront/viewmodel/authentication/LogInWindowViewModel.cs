using System;
using RentServiceFront.data.secure;

namespace RentServiceFront.viewmodel.authentication;

public class LogInWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public LogInWindowViewModel(SecureDataStorage secureDataStorage)
    {
        LogInViewModel logInViewModel = new LogInViewModel(secureDataStorage);
        logInViewModel.OnLoginSuccess += OpenMainWindow; 
        _currentViewModel = logInViewModel;
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
            
            if (_currentViewModel.GetType() == typeof(LogInViewModel))
                (_currentViewModel as LogInViewModel).OnLoginSuccess += OpenMainWindow;  
            
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }

    private void OpenMainWindow()
    {
        OpenMainWindowRequest?.Invoke();    
    }
    
    private void OnViewModelChanged(object? sender, ViewModelBase e)
    {
        CurrentViewModel = e;
    }
    
    public Action OpenMainWindowRequest { get; set; }
}