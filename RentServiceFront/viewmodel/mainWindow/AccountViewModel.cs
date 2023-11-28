using System;
using System.Collections.Generic;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class AccountViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _phoneNumber;
    private bool _emailVerified;
    private Role _role;
    private List<AgreementViewModel> _agreements;
    private ViewModelBase _currentViewModel;

    public AccountViewModel()
    {
        _username = "TheNorth";
        _email = "lol_danchik@bk.ru";
        _phoneNumber = "+79930028973";
        _emailVerified = true;
        _role = Role.INVIDIDUAL;
        _agreements = new List<AgreementViewModel>();
        List<AgreementRoomViewModel> rooms = new List<AgreementRoomViewModel>();
        rooms.Add(new AgreementRoomViewModel(1, "asdasdd", "asdasdasd", DateTime.Now, DateTime.Now, 2222));
        rooms.Add(new AgreementRoomViewModel(2, "asdasdd", "asdasdasd", DateTime.Now, DateTime.Now, 2222));
        rooms.Add(new AgreementRoomViewModel(3, "asdasdd", "asdasdasd", DateTime.Now, DateTime.Now, 2222));
        rooms.Add(new AgreementRoomViewModel(4, "asdasdd", "asdasdasd", DateTime.Now, DateTime.Now, 2222));
        
        _agreements.Add(new AgreementViewModel(1, PaymentFrequency.MONTHLY, "asdasdasdasd", 24, DateTime.Now,
            DateTime.Now, rooms));
        _agreements.Add(new AgreementViewModel(2, PaymentFrequency.MONTHLY, "asdasdasdasd", 24, DateTime.Now,
            DateTime.Now, rooms));
        _agreements.Add(new AgreementViewModel(3, PaymentFrequency.MONTHLY, "asdasdasdasd", 24, DateTime.Now,
            DateTime.Now, rooms));
        _agreements.Add(new AgreementViewModel(4, PaymentFrequency.MONTHLY, "asdasdasdasd", 24, DateTime.Now,
            DateTime.Now, rooms));
        
        /*List<PassportViewModel> passports = new List<PassportViewModel>();
        passports.Add(new PassportViewModel("Горшков Данил Сергеевич", DateTime.Now, DateTime.Now, "asdasdasd", "123123123", Gender.MALE, "asdasdasdads"));
        passports.Add(new PassportViewModel("Горшков Данил Сергеевич", DateTime.Now, DateTime.Now, "asdasdasd", "123123123", Gender.MALE, "asdasdasdads"));
        passports.Add(new PassportViewModel("Горшков Данил Сергеевич", DateTime.Now, DateTime.Now, "asdasdasd", "123123123", Gender.MALE, "asdasdasdads"));
        passports.Add(new PassportViewModel("Горшков Данил Сергеевич", DateTime.Now, DateTime.Now, "asdasdasd", "123123123", Gender.MALE, "asdasdasdads"));
        _currentViewModel = new IndividualViewModel(passports);*/
        _currentViewModel = new EntityViewModel("ShadowShiftStudio", "Горшков Данил Сергеевич", "asdasdasd", "Тинькофф", "1233", "asdasdasd");
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