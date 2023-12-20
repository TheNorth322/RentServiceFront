using System;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.request;

namespace RentServiceFront.viewmodel.authentication;

public class RegistrationViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _password;
    private string _phoneNumber;
    private Role _role;
    private AuthenticationUseCase _authenticationUseCase;
    public ViewModelBase _previousVm;
    public ICommand GoBackCommand { get; }
    public ICommand RegisterCommand { get; }
    private SecureDataStorage _secureDataStorage;

    public RegistrationViewModel(ViewModelBase previousVm, AuthenticationUseCase authenticationUseCase,
        SecureDataStorage secureDataStorage)
    {
        _previousVm = previousVm;
        GoBackCommand = new RelayCommand<object>(GoBackExecute);
        RegisterCommand = new RelayCommand<object>(RegisterExecute, RegisterCanExecute);
        _authenticationUseCase = authenticationUseCase;
        _secureDataStorage = secureDataStorage;
    }

    private bool RegisterCanExecute(object arg)
    {
        return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password) &&
               !String.IsNullOrEmpty(PhoneNumber);
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

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChange(nameof(Email));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChange(nameof(Username));
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChange(nameof(PhoneNumber));
        }
    }

    public Role Role
    {
        get => _role;
        set
        {
            _role = value;
            OnPropertyChange(nameof(Role));
        }
    }

    public RegisterRequest CreateRegisterRequest()
    {
        return new RegisterRequest(Username, Email, Password, PhoneNumber, Role);
    }

    private void GoBackExecute(object parameter)
    {
        RaiseViewModelRequested(_previousVm);
    }

    private async void RegisterExecute(object parameter)
    {
        if (Role == Role.ENTITY)
            RaiseViewModelRequested(new EntityRegistrationViewModel(this, _authenticationUseCase, _secureDataStorage));
        else if (Role == Role.INDIVIDUAL)
            RaiseViewModelRequested(new IndividualUserRegistrationViewModel(this, _authenticationUseCase,
                new SearchUseCase(new SearchRequest(new SecureDataStorage()))));
        else if (Role == Role.ADMIN)
        {
            try
            {
                await _authenticationUseCase.RegisterUser(this.CreateRegisterRequest());
                DialogText = "Registration successfull";
            }
            catch (Exception e)
            {
                DialogText = "Something went wrong";
            }

            OnShowDialog(null);
        }
    }
}