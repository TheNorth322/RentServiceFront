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
    private AuthenticationUseCase _authenticationUseCase;  
    
    public ICommand ResetPasswordCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand LogInCommand { get; }

    public LogInViewModel(SecureDataStorage secureDataStorage)
    {
        RegisterCommand = new RelayCommand(RegisterExecute);
        ResetPasswordCommand = new RelayCommand(ResetPasswordExecute);
        LogInCommand = new RelayCommand(LogInExecute, LogInCanExecute);
        _authenticationUseCase =
            new AuthenticationUseCase(new data.authentication.api_request.AuthenticationRequest(secureDataStorage));
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
        RegistrationViewModel registrationViewModel = new RegistrationViewModel(this, _authenticationUseCase);
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
        }
    }

    private bool LogInCanExecute(object parameter)
    {
        return true;
    }
    
    public Action OnLoginSuccess { get; set; }  
}