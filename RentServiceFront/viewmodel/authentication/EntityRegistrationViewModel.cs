using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request;

namespace RentServiceFront.viewmodel.authentication;

public class EntityRegistrationViewModel : ViewModelBase
{
    private string _name;
    private string _supervisorFullname;
    private string _address;
    private Bank _bank;
    private string _checkingAccount;
    private string _itnNumber;
    private RegistrationViewModel _registrationViewModel;
    private AuthenticationUseCase _authenticationUseCase;
    
    public ICommand GoBackCommand { get; }

    public EntityRegistrationViewModel(RegistrationViewModel vm, AuthenticationUseCase authenticationUseCase)
    {
        GoBackCommand = new RelayCommand(GoBackExecute);
        _authenticationUseCase = authenticationUseCase;
        _registrationViewModel = vm;
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    public string SupervisorFullname
    {
        get => _supervisorFullname;
        set
        {
            _supervisorFullname = value;
            OnPropertyChange(nameof(SupervisorFullname));
        }
    }

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChange(nameof(Address));
        }
    }

    public Bank Bank
    {
        get => _bank;
        set
        {
            _bank = value;
            OnPropertyChange(nameof(Bank));
        }
    }

    public string CheckingAccount
    {
        get => _checkingAccount;
        set
        {
            _checkingAccount = value;
            OnPropertyChange(nameof(CheckingAccount));
        }
    }

    public string ItnNumber
    {
        get => _itnNumber;
        set
        {
            _itnNumber = value;
            OnPropertyChange(nameof(ItnNumber));
        }
    }

    private void GoBackExecute(object parameter)
    {
        RaiseViewModelRequested(_registrationViewModel);
    }

    private async void RegisterExecute(object parameter)
    {
        RegisterRequest registerRequest = _registrationViewModel.CreateRegisterRequest();
        string[] fullname = _supervisorFullname.Split(" ");
        string firstName = fullname[0];
        string lastName = fullname[1];
        string surname = (fullname.Length == 2) ? null : fullname[2];
        
        await _authenticationUseCase.RegisterEntityUser(new RegisterEntityRequest(registerRequest, Name, firstName, lastName, surname,Address, Bank.Id, CheckingAccount, ItnNumber));
    }
}