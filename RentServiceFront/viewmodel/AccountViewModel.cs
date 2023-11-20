using System.Collections.Generic;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel;

public class AccountViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _phoneNumber;
    private bool _emailVerified;
    private Role _role;
    private List<AgreementViewModel> _agreements;
    private IndividualViewModel _individualViewModel;
    private EntityViewModel _entityViewModel;
    
    public AccountViewModel()
    {
        
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
}