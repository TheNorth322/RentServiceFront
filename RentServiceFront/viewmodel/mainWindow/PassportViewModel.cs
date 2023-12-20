using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Address;
using RentServiceFront.domain.model.request.passport;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow;

public class PassportViewModel : ViewModelBase
{
    private long _id;
    private string _fullName;
    private DateTime _dateOfBirth;
    private DateTime _dateOfIssue;
    private string _numberSeries;
    private Gender _gender;

    private string _addressQuery;

    private ObservableCollection<AddressViewModel> _addresses;
    private AddressViewModel _selectedAddress;
    private KeyEventArgs _lastKeyEventArgs;
    private SearchUseCase _searchUseCase;
    private UserUseCase _userUseCase;
    private SecureDataStorage _secureDataStorage;
    private PassportUseCase _passportUseCase;
    private bool _isComboBoxOpen;
    private ObservableCollection<MigrationServiceViewModel> _migrationServices;
    private MigrationServiceViewModel _selectedMigrationService;

    public PassportViewModel(long id, string numberSeries, UserUseCase userUseCase, SearchUseCase searchUseCase,
        PassportUseCase passportUseCase, SecureDataStorage secureDataStorage)
    {
        AddCommand = new RelayCommand<object>(AddExecute);
        DeleteCommand = new RelayCommand<object>(DeleteExecute);

        _id = id;
        NumberSeries = numberSeries;
        _addresses = new ObservableCollection<AddressViewModel>();
        _migrationServices = new ObservableCollection<MigrationServiceViewModel>();
        AddressSearchCommand = new RelayCommand<object>(AddressSearchExecute);

        _searchUseCase = searchUseCase;
        _userUseCase = userUseCase;
        _passportUseCase = passportUseCase;
        _secureDataStorage = secureDataStorage;
    }

    public async Task InitializeMigrationServices()
    {
        _migrationServices.Clear();
        List<MigrationService> migrationServices = await _searchUseCase.searchForMigrationServices();
        foreach (MigrationService service in migrationServices)
            _migrationServices.Add(new MigrationServiceViewModel(service.Id, service.Name));
    }

    public async Task InitializePassportInformation()
    {
        if (_id == 0) return;
        Passport passport = await _passportUseCase.getPassportById(_id);
        FullName =
            $"{passport.FirstName} {passport.LastName} {((!String.IsNullOrEmpty(passport.Surname)) ? passport.Surname : "")}";
        DateOfBirth = passport.DateOfBirth;
        DateOfIssue = passport.DateOfIssue;
        SelectedMigrationService =
            new MigrationServiceViewModel(passport.IssuedBy.Id, passport.IssuedBy.Name);
        NumberSeries = $"{passport.Number} {passport.Series}";
        SelectedAddress = new AddressViewModel(passport.PlaceOfBirth.Value, passport.PlaceOfBirth.AddressParts);
        AddressQuery = passport.PlaceOfBirth.Value;
        Gender = passport.Gender;
    }

    public string AddressQuery
    {
        get => _addressQuery;
        set
        {
            _addressQuery = value;
            OnPropertyChange(nameof(AddressQuery));
        }
    }

    public string FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChange(nameof(FullName));
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChange(nameof(DateOfBirth));
        }
    }

    public DateTime DateOfIssue
    {
        get => _dateOfIssue;
        set
        {
            _dateOfIssue = value;
            OnPropertyChange(nameof(DateOfIssue));
        }
    }

    public string NumberSeries
    {
        get => _numberSeries;
        set
        {
            _numberSeries = value;
            OnPropertyChange(nameof(NumberSeries));
        }
    }

    public Gender Gender
    {
        get => _gender;
        set
        {
            _gender = value;
            OnPropertyChange(nameof(Gender));
        }
    }

    public ObservableCollection<AddressViewModel> Addresses
    {
        get => _addresses;
        set
        {
            _addresses = value;
            OnPropertyChange(nameof(Addresses));
        }
    }

    public AddressViewModel SelectedAddress
    {
        get => _selectedAddress;
        set
        {
            _selectedAddress = value;
            OnPropertyChange(nameof(SelectedAddress));
        }
    }

    public KeyEventArgs LastKeyEventArgs
    {
        get { return _lastKeyEventArgs; }
        set
        {
            if (_lastKeyEventArgs != value)
            {
                _lastKeyEventArgs = value;
                OnPropertyChange(nameof(LastKeyEventArgs));
            }
        }
    }


    private async void AddressSearchExecute(object parameter)
    {
        if (LastKeyEventArgs != null && LastKeyEventArgs.Key == Key.Enter)
        {
            List<Address> addresses = await _searchUseCase.searchAddresses(AddressQuery, 5);
            Addresses.Clear();

            foreach (Address address in addresses)
                Addresses.Add(new AddressViewModel(address.Value, address.AddressParts));
            IsComboBoxOpen = !IsComboBoxOpen;
        }
    }

    public bool IsComboBoxOpen
    {
        get => _isComboBoxOpen;
        set
        {
            _isComboBoxOpen = value;
            OnPropertyChange(nameof(IsComboBoxOpen));
        }
    }

    public ICommand AddressSearchCommand { get; }

    public ObservableCollection<MigrationServiceViewModel> MigrationServices
    {
        get => _migrationServices;
        set
        {
            _migrationServices = value;
            OnPropertyChange(nameof(MigrationServices));
        }
    }

    public MigrationServiceViewModel SelectedMigrationService
    {
        get => _selectedMigrationService;
        set
        {
            _selectedMigrationService = value;
            OnPropertyChange(nameof(SelectedMigrationService));
        }
    }

    private async void AddExecute(object? param)
    {
        if (_id == 0)
        {
            string[] fullNameParts = FullName.Split(" ");
            string? surname = fullNameParts.Length == 2 ? null : fullNameParts[2];
            string[] numberSericeParts = NumberSeries.Split(" ");

            await _passportUseCase.addPassport(new AddPassportRequest(
                    _secureDataStorage.Username,
                    fullNameParts[0],
                    fullNameParts[1],
                    surname,
                    _dateOfBirth,
                    _dateOfIssue,
                    _selectedMigrationService.Id,
                    numberSericeParts[0],
                    numberSericeParts[1],
                    new CreateAddressRequest(_selectedAddress.Name, _selectedAddress.AddressParts),
                    _gender
                )
            );
        }
        else
        {
            string[] fullNameParts = FullName.Split(" ");
            string? surname = fullNameParts[2] ?? null;
            string[] numberSericeParts = NumberSeries.Split(" ");

            Passport passport = await _passportUseCase.updatePassport(new UpdatePassportRequest(
                    _id,
                    _secureDataStorage.Username,
                    fullNameParts[0],
                    fullNameParts[1],
                    surname,
                    _dateOfBirth,
                    _dateOfIssue,
                    _selectedMigrationService.Id,
                    numberSericeParts[0],
                    numberSericeParts[1],
                    new CreateAddressRequest(_selectedAddress.Name, _selectedAddress.AddressParts),
                    _gender
                )
            );

            _id = passport.Id;
        }
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public EventHandler<PassportViewModel> DeleteEvent { get; set; }

    private async void DeleteExecute(object parameter)
    {
        if (_id != 0)
        {
            await _passportUseCase.deletePassport(_secureDataStorage.Username, _id);
        }
         
        DeleteEvent?.Invoke(this, this);
    }
}