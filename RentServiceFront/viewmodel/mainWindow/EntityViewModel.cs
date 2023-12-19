using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class EntityViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _phoneNumber;
    private Role _role;
        
    private string _name;
    private string _supervisorFullname;
    private string _address;
    private string _bankName;
    private string _checkingAccount;
    private string _itnNumber;

    private UserUseCase _userUseCase;
    private SecureDataStorage _secureDataStorage;
    public EntityViewModel(UserUseCase userUseCase, SecureDataStorage secureDataStorage)
    {
        _userUseCase = userUseCase;
        _secureDataStorage = secureDataStorage; 
    }

    public async Task InitializeUserInfo()
    {
        User user = await _userUseCase.getUserByUsername(_secureDataStorage.Username);
        _username = user.Username;
        _email = user.Email;
        _phoneNumber = user.PhoneNumber;
        _role = user.Role;
        await InitializeEntityInfo();
    }

    private async Task InitializeEntityInfo()
    {
        EntityUser user = await _userUseCase.getUserEntityInfo(_secureDataStorage.Username);
        _name = user.Name;
        _supervisorFullname = $"{user.SupervisorFirstName} {user.SupervisorLastName} {((!String.IsNullOrEmpty(user.SupervisorSurname)) ? user.SupervisorSurname : "")}";
        _address = user.Address.Value;
        _bankName = user.Bank.Name;
        _checkingAccount = user.CheckingAccount;
        _itnNumber = user.ItnNumber;
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
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChange(nameof(PhoneNumber));
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

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChange(nameof(Username));
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            Name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    public string SupervisorFullName
    {
        get => _supervisorFullname;
        set
        {
            _supervisorFullname = value;
            OnPropertyChange(nameof(SupervisorFullName));
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

    public string BankName
    {
        get => _bankName;
        set
        {
            _bankName = value;
            OnPropertyChange(nameof(BankName));
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

    public string CheckingAccount
    {
        get => _checkingAccount;
        set
        {
            _checkingAccount = value;
            OnPropertyChange(nameof(CheckingAccount));
        }
    }
}