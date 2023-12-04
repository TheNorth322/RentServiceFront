using System;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using AuthenticationRequest = RentServiceFront.domain.model.request.AuthenticationRequest;

namespace RentServiceFront.viewmodel.authentication;

public class LogInViewModel : ViewModelBase
{
    private string _username;
    private string _password;
    private SecureDataStorage _secureDataStorage;
    private AuthenticationUseCase _authenticationUseCase;  
    
    public ICommand ResetPasswordCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand LogInCommand { get; }

    public LogInViewModel(SecureDataStorage secureDataStorage)
    {
        RegisterCommand = new RelayCommand<object>(RegisterExecute);
        ResetPasswordCommand = new RelayCommand<object>(ResetPasswordExecute);
        LogInCommand = new RelayCommand<object>(LogInExecute, LogInCanExecute);
        _secureDataStorage = secureDataStorage;
        _authenticationUseCase =
            new AuthenticationUseCase(new data.authentication.api_request.AuthenticationRequest(_secureDataStorage));
    }
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChange(nameof(Username));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChange(nameof(Password));
        }
    }

    private void ResetPasswordExecute(object parameter)
    {
        EnterEmailViewModel resetPasswordViewModel = new EnterEmailViewModel(this, _authenticationUseCase);
        RaiseViewModelRequested(resetPasswordViewModel);
    }

    private void RegisterExecute(object parameter)
    {
        RegistrationViewModel registrationViewModel = new RegistrationViewModel(this, _authenticationUseCase, _secureDataStorage);
        RaiseViewModelRequested(registrationViewModel);
    }

    private async void LogInExecute(object parameter)
    {
        try
        {
            AuthenticationRequest request = new AuthenticationRequest(Username, Password);
            var response = await _authenticationUseCase.LoginUser(request);
            OnLoginSuccess?.Invoke();
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong"; 
            OnShowDialog(this);   
        }
    }

    private bool LogInCanExecute(object parameter)
    {
        return true;
    }
    
    public Action OnLoginSuccess { get; set; }  
}