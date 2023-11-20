using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.request;

namespace RentServiceFront.viewmodel;

public class RegistrationViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _password;
    private string _phoneNumber;
    private Role _role;
    private AuthenticationUseCase _authenticationUseCase;
    private ViewModelBase _previousVm;
    public ICommand GoBackCommand { get; }
    public ICommand RegisterCommand { get; }

    public RegistrationViewModel(ViewModelBase previousVm, AuthenticationUseCase authenticationUseCase)
    {
        _previousVm = previousVm;
        GoBackCommand = new RelayCommand(GoBackExecute);
        RegisterCommand = new RelayCommand(RegisterExecute);
        _authenticationUseCase = authenticationUseCase;
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

    private void RegisterExecute(object parameter)
    {
        if (Role == Role.ENTITY)
            RaiseViewModelRequested(new EntityRegistrationViewModel(this, _authenticationUseCase));
        else if (Role == Role.INVIDIDUAL)
            RaiseViewModelRequested(new IndividualUserRegistrationViewModel(this, _authenticationUseCase));
    }
}