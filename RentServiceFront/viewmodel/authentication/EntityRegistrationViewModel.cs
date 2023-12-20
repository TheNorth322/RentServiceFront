using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.viewmodel.authentication;

public class EntityRegistrationViewModel : ViewModelBase
{
    private string _name;
    private string _supervisorFullname;
    private BankViewModel _selectedBank;
    private ObservableCollection<BankViewModel> _banks;
    private string _checkingAccount;
    private string _itnNumber;
    private RegistrationViewModel _registrationViewModel;
    private AuthenticationUseCase _authenticationUseCase;
    private KeyEventArgs _lastKeyEventArgs;
    private bool _isComboBoxOpen;
    private string _addressQuery;
    private ObservableCollection<AddressViewModel> _addresses;
    private AddressViewModel _selectedAddress;
    private string _address;
    private SearchUseCase _searchUseCase;
    private readonly SecureDataStorage _secureDataStorage;
    private readonly BankUseCase _bankUseCase;

    public ObservableCollection<AddressViewModel> Addresses
    {
        get => _addresses;
        set
        {
            _addresses = value;
            OnPropertyChange(nameof(Addresses));
        }
    }

    public BankViewModel SelectedBank
    {
        get => _selectedBank;
        set
        {
            _selectedBank = value;
            OnPropertyChange(nameof(SelectedBank));
        }
    }

    public ObservableCollection<BankViewModel> Banks
    {
        get => _banks;
        set
        {
            _banks = value;
            OnPropertyChange(nameof(Banks));
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

    public ICommand GoBackCommand { get; }

    public EntityRegistrationViewModel(RegistrationViewModel vm, AuthenticationUseCase authenticationUseCase,
        SecureDataStorage secureDataStorage)
    {
        GoBackCommand = new RelayCommand<object>(GoBackExecute);
        AddressSearchCommand = new RelayCommand<KeyEventArgs>(AddressSearchExecute);
        RegisterCommand = new RelayCommand<object>(RegisterExecute, RegisterCanExecute);

        _banks = new ObservableCollection<BankViewModel>();
        _addresses = new ObservableCollection<AddressViewModel>();

        _authenticationUseCase = authenticationUseCase;
        _secureDataStorage = secureDataStorage;
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
        _bankUseCase = new BankUseCase(new BankRequest(_secureDataStorage));
        _registrationViewModel = vm;
    }

    private bool RegisterCanExecute(object arg)
    {
        return !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(SupervisorFullname) &&
               !String.IsNullOrEmpty(ItnNumber) && !String.IsNullOrEmpty(CheckingAccount) && SelectedBank != null &&
               SelectedAddress != null && ValidateFullName();
    }

    private bool ValidateFullName()
    {
        return SupervisorFullname.Split(" ").Length >= 2;
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

    public string AddressQuery
    {
        get => _addressQuery;
        set
        {
            _addressQuery = value;
            OnPropertyChange(nameof(AddressQuery));
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
    public ICommand RegisterCommand { get; }

    private async void RegisterExecute(object parameter)
    {
        try
        {
            RegisterRequest registerRequest = _registrationViewModel.CreateRegisterRequest();
            string[] fullname = _supervisorFullname.Split(" ");
            string firstName = fullname[0];
            string lastName = fullname[1];
            string surname = (fullname.Length == 2) ? null : fullname[2];

            await _authenticationUseCase.RegisterEntityUser(new RegisterEntityRequest(registerRequest, Name, firstName,
                lastName, surname, SelectedAddress.Name, SelectedAddress.AddressParts, SelectedBank.Id, CheckingAccount,
                ItnNumber));
            RaiseViewModelRequested(_registrationViewModel._previousVm);
        }
        catch (Exception e)
        {
            DialogText = "Не удалось зарегистрироваться. Обратитесь в поддержку.";
            ShowDialogCommand.Execute(null);
        }
    }

    public async Task InitializeBanks()
    {
        Banks.Clear();
        List<Bank> banks = await _bankUseCase.getBanks();

        foreach (Bank bank in banks)
            _banks.Add(new BankViewModel(bank.Id, bank.Name));
    }
}