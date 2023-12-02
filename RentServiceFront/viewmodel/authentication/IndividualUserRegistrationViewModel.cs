using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.request.Address;
using RentServiceFront.domain.model.request.passport;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.viewmodel.authentication;

public class IndividualUserRegistrationViewModel : ViewModelBase
{
    private string _fullname;
    private DateTime _dateOfBirth;
    private DateTime _dateOfIssue;
    private string _numberSeries;
    private string _number;
    private string _series;
    private Gender _gender;
    private readonly RegistrationViewModel _registrationViewModel;
    private AuthenticationUseCase _authenticationUseCase;
    private readonly SearchUseCase _searchUseCase;
    private List<AddressViewModel> _addresses;
    private List<MigrationServiceViewModel> _migrationServices;
    private MigrationServiceViewModel _selectedMigrationService;   
    private string _addressQuery;
    private AddressViewModel _selectedAddress;
    
    public ICommand GoBackCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand AddressSearchCommand { get; }

    public IndividualUserRegistrationViewModel(RegistrationViewModel vm, AuthenticationUseCase authenticationUseCase,
        SearchUseCase searchUseCase)
    {
        DateOfBirth = System.DateTime.Now;
        DateOfIssue = System.DateTime.Now;
        _addresses = new List<AddressViewModel>();
        _selectedAddress = new AddressViewModel("", new List<AddressPart>());
        GoBackCommand = new RelayCommand(GoBackExecute);
        RegisterCommand = new RelayCommand(RegisterExecute);
        AddressSearchCommand = new RelayCommand(AddressSearchExecute);
        _migrationServices = new List<MigrationServiceViewModel>();
        _authenticationUseCase = authenticationUseCase;
        _searchUseCase = searchUseCase;
        _registrationViewModel = vm;
        InitMigrationServices();
    }

    private async Task InitMigrationServices()
    {
        List<MigrationService> migrationServices = await _searchUseCase.searchForMigrationServices();
        foreach (MigrationService service in migrationServices)
            _migrationServices.Add(new MigrationServiceViewModel(service.Id, service.Name));
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
    public List<MigrationServiceViewModel> MigrationServices
    {
        get => _migrationServices;
        set
        {
            _migrationServices = value;
            OnPropertyChange(nameof(MigrationService));
        }
    }
    

    public List<AddressViewModel> Addresses
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
            AddressQuery = value.Name;
            OnPropertyChange(nameof(SelectedAddress));
        }
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

    public string Fullname
    {
        get => _fullname;
        set
        {
            _fullname = value;
            OnPropertyChange(nameof(Fullname));
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
            ParseNumberSeries(_numberSeries);
            OnPropertyChange(nameof(NumberSeries));
        }
    }

    public string Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChange(nameof(Number));
        }
    }

    public string Series
    {
        get => _series;
        set
        {
            _series = value;
            OnPropertyChange(nameof(Series));
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

    


    private void ParseNumberSeries(string numberSeries)
    {
        string[] split = numberSeries.Split(" ");
        Number = split[0];
        Series = split[1];
    }

    private void GoBackExecute(object parameter)
    {
        RaiseViewModelRequested(_registrationViewModel);
    }

    private async void RegisterExecute(object parameter)
    {
        try
        {
            RegisterRequest registerRequest = _registrationViewModel.CreateRegisterRequest();

            string[] fullname = Fullname.Split(" ");
            string firstName = fullname[0];
            string lastName = fullname[1];
            string? surname = (fullname.Length == 2) ? null : fullname[2];

            AddPassportRequest addPassportRequest = new AddPassportRequest(registerRequest.Username, firstName,
                lastName,
                surname, DateOfBirth, DateOfIssue, SelectedMigrationService.Id, Number, Series,
                new CreateAddressRequest(SelectedAddress.Name, SelectedAddress.AddressParts), Gender);
            
            await _authenticationUseCase.RegisterIndividualUser(
                new RegisterIndividualRequest(registerRequest, addPassportRequest));

            DialogText = "Registration completed";
        }
        catch (Exception e)
        {
            DialogText = e.Message;
        }

        ShowDialogCommand.Execute(this);
    }

    private async void AddressSearchExecute(object parameter)
    {
        List<Address> addresses = await _searchUseCase.searchAddresses(AddressQuery, 5);
        Addresses.Clear();

        foreach (Address address in addresses)
            Addresses.Add(new AddressViewModel(address.Value, address.AddressParts));
    }

    private bool AddressSearchCanExecute(object parameter)
    {
        return !String.IsNullOrEmpty(AddressQuery);
    }

    
}