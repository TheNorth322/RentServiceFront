using System.Threading.Tasks;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel;

public class UserViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _phoneNumber;
    private Role _role;

    private readonly UserUseCase _userUseCase;
    private readonly SecureDataStorage _secureDataStorage;

    public UserViewModel(UserUseCase userUseCase, SecureDataStorage secureDataStorage)
    {
        _userUseCase = userUseCase;
        _secureDataStorage = secureDataStorage;
    }

    public async Task InitializeUserInfo()
    {
        User user = await _userUseCase.getUserByUsername(_secureDataStorage.Username);
        Username = user.Username;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Role = user.Role;
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
}