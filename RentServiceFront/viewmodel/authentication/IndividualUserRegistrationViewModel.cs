using System;
using System.Collections.Generic;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request;
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
    private string _placeOfBirth;
    private MigrationService _migrationService;
    private RegistrationViewModel _registrationViewModel;
    private AuthenticationUseCase _authenticationUseCase;
    private SearchUseCase _searchUseCase;
    private List<AddressViewModel> _addresses;
    private string _addressQuery;
    public ICommand GoBackCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand AddressSearchCommand { get; }

    public IndividualUserRegistrationViewModel(RegistrationViewModel vm, AuthenticationUseCase authenticationUseCase, SearchUseCase searchUseCase)
    {
        DateOfBirth = System.DateTime.Now;
        DateOfIssue = System.DateTime.Now;
        GoBackCommand = new RelayCommand(GoBackExecute);
        RegisterCommand = new RelayCommand(RegisterExecute);
        AddressSearchCommand = new RelayCommand(AddressSearchExecute);
        _authenticationUseCase = authenticationUseCase;
        _searchUseCase = searchUseCase; 
        _registrationViewModel = vm;
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

    public string PlaceOfBirth
    {
        get => _placeOfBirth;
        set
        {
            _placeOfBirth = value;
            OnPropertyChange(nameof(PlaceOfBirth));
        }
    }

    private MigrationService MigrationService
    {
        get => _migrationService;
        set
        {
            _migrationService = value;
            OnPropertyChange(nameof(MigrationService));
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
        /*RegisterRequest registerRequest = _registrationViewModel.CreateRegisterRequest();
        
        string[] fullname = Fullname.Split(" ");
        string firstName = fullname[0];
        string lastName = fullname[1];
        string surname = (fullname.Length == 2) ? null : fullname[2];
        
        AddPassportRequest addPassportRequest = new AddPassportRequest(registerRequest.Username, firstName, lastName, surname, DateOfBirth, DateOfIssue, MigrationService.Id, Number, Series, PlaceOfBirth, Gender.MALE);
        
        await _authenticationUseCase.RegisterIndividualUser(new RegisterIndividualRequest(registerRequest, addPassportRequest));*/
    }

    private async void AddressSearchExecute(object parameter)
    {
        List<Address> addresses = await _searchUseCase.searchAddresses(new SearchAddressesRequest(AddressQuery, 5));
        _addresses.Clear();
        
        foreach (Address address in addresses)
            _addresses.Add(new AddressViewModel(address.Name, address.FiasId));
    }  
}