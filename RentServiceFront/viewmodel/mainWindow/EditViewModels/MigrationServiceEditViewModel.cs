using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.migrationService;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class MigrationServiceEditViewModel : ViewModelBase
{
    private long _id;
    private string _name;
    private string _address;
    private List<AddressPart> _addressParts;
    private bool _isComboBoxOpen;
    private string _addressQuery;
    private ObservableCollection<AddressViewModel> _addresses;
    private readonly SearchUseCase _searchUseCase;
    private AddressViewModel _selectedAddress;
    private readonly MigrationServiceUseCase _migrationServiceUseCase;
    private KeyEventArgs _lastKeyEventArgs;
    public ICommand DeleteCommand { get; }
    public EventHandler<MigrationServiceEditViewModel> DeleteEvent;
    private ObservableCollection<PassportTableItemViewModel> _passports;

    public MigrationServiceEditViewModel(MigrationServiceUseCase migrationServiceUseCase, SearchUseCase searchUseCase)
    {
        _addressParts = new List<AddressPart>();
        _passports = new ObservableCollection<PassportTableItemViewModel>();
        _addresses = new ObservableCollection<AddressViewModel>();
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddressSearchCommand = new RelayCommand<KeyEventArgs>(AddressSearchExecute);
        AddCommand = new RelayCommand<object>(AddExecute, AddCanExecute);

        _id = 0;
        _name = "Unknown";
        _migrationServiceUseCase = migrationServiceUseCase;
        _searchUseCase = searchUseCase;
    }

    private bool AddCanExecute(object arg)
    {
        return !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Address) && _selectedAddress != null;
    }

    public MigrationServiceEditViewModel(long id, string name, string address, List<AddressPart> addressParts,
        MigrationServiceUseCase migrationServiceUseCase, SearchUseCase searchUseCase) : this(migrationServiceUseCase,
        searchUseCase)
    {
        _addressParts = addressParts;
        _id = id;
        _name = name;
        _address = address;
        AddressQuery = _address;
        _migrationServiceUseCase = migrationServiceUseCase;
        _searchUseCase = searchUseCase;
    }
    
    public async Task InitializePassports()
    {
        List<Passport> passports = await _migrationServiceUseCase.getMigrationServicePassports(_id);
        foreach (Passport passport in passports)
        {
            string fullName =
                $"{passport.FirstName} {passport.LastName} {((!String.IsNullOrEmpty(passport.Surname)) ? passport.Surname : "")}";
            PassportTableItemViewModel vm = new PassportTableItemViewModel(passport.Id, fullName, passport.DateOfBirth,
                passport.DateOfIssue, $"{passport.Number} {passport.Series}", passport.Gender,
                passport.PlaceOfBirth.Value, passport.IssuedBy.Name);
            _passports.Add(vm);
        }
    }

    public ICommand AddCommand { get; }

    public ObservableCollection<PassportTableItemViewModel> Passports
    {
        get => _passports;
        set
        {
            _passports = value;
            OnPropertyChange(nameof(Passports));
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

    public ObservableCollection<AddressViewModel> Addresses
    {
        get => _addresses;
        set
        {
            _addresses = value;
            OnPropertyChange(nameof(Addresses));
        }
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

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChange(nameof(Address));
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

    public ICommand AddressSearchCommand { get; }

    public AddressViewModel SelectedAddress
    {
        get => _selectedAddress;
        set
        {
            _selectedAddress = value;
            OnPropertyChange(nameof(SelectedAddress));
            Address = _selectedAddress.Name;
            AddressQuery = _selectedAddress.Name;
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

    private async void AddExecute(object param)
    {
        try
        {
            if (_id == 0)
            {
                MigrationService migrationService = await _migrationServiceUseCase.createMigrationService(
                    new CreateMigrationServiceRequest(Name, SelectedAddress.Name, SelectedAddress.AddressParts));
                _id = migrationService.Id;
            }
            else
            {
                DialogText = await _migrationServiceUseCase.updateMigrationService(
                    new UpdateMigrationServiceRequest(_id, Name,
                        (SelectedAddress != null) ? SelectedAddress.Name : _address,
                        (SelectedAddress != null) ? SelectedAddress.AddressParts : _addressParts));
            }

            ShowDialogCommand.Execute(this);
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
            ShowDialogCommand.Execute(this);
        }
    }

    private async void DeleteExecute(object param)
    {
        if (_id != 0)
        {
            await _migrationServiceUseCase.deleteMigrationService(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }
}