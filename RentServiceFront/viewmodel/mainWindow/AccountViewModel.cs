using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class AccountViewModel : ViewModelBase 
{
    private string _username;
    private string _email;
    private string _phoneNumber;
    private bool _emailVerified;
    private Role _role;

    private SecureDataStorage _secureDataStorage;
    private List<AgreementViewModel> _agreements;
    private ViewModelBase _currentViewModel;
    private UserUseCase _userUseCase;

    public async Task InitializeInfo()
    {
        User user = await _userUseCase.getUserByUsername(_secureDataStorage.Username);
        Username = user.Username;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        EmailVerified = user.EmailVerified;
        Role = user.Role;
        
        switch (Role)
        {
            case Role.ENTITY:
                await InitializeEntityInfo();
                break;
            case Role.INDIVIDUAL:
                await InitializeIndividualInfo();
                break;
        }
    }

    private async Task InitializeIndividualInfo()
    {
        IndividualUser user = await _userUseCase.getUserIndividualInfo(_secureDataStorage.Username);

        List<PassportViewModel> passports = new List<PassportViewModel>();
        foreach (Passport passport in user.Passports)
        {
            passports.Add(new PassportViewModel(passport.FirstName, passport.LastName, passport.Surname,
                passport.DateOfBirth, passport.DateOfIssue, passport.MigrationService.Name, passport.Number,
                passport.Series, passport.Gender, passport.PlaceOfBirth));
        }

        CurrentViewModel = new IndividualViewModel(passports);
    }

    private async Task InitializeEntityInfo()
    {
        EntityUser user = await _userUseCase.getUserEntityInfo(_secureDataStorage.Username);
        EntityViewModel entityViewModel = new EntityViewModel(user.Name, user.SupervisorFirstName,
            user.SupervisorLastName, user.SupervisorSurname, user.Address.Value, user.Bank.Name, user.ItnNumber,
            user.CheckingAccount);
        CurrentViewModel = entityViewModel;
    }

    public AccountViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _userUseCase = new UserUseCase(new UserRequest(_secureDataStorage));
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

    public bool EmailVerified
    {
        get => _emailVerified;
        set
        {
            _emailVerified = value;
            OnPropertyChange(nameof(EmailVerified));
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

    public List<AgreementViewModel> Agreements
    {
        get => _agreements;
        set
        {
            _agreements = value;
            OnPropertyChange(nameof(Agreements));
        }
    }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}