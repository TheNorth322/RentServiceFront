using System;
using System.Collections.Generic;
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

    private string _addressQuery;
    private List<AddressViewModel> _addresses;
    private SearchUseCase _searchUseCase;
    private AddressViewModel _selectedAddress;
    private MigrationServiceUseCase _migrationServiceUseCase;

    public MigrationServiceEditViewModel()
    {
        _addressParts = new List<AddressPart>();
        AddressSearchCommand = new RelayCommand(AddressSearchExecute);
        AddCommand = new RelayCommand(AddExecute);
        _id = 0;
        _name = "Unknown";
    }

    public MigrationServiceEditViewModel(long id, string name, string address, List<AddressPart> addressParts) : this()
    {
        _addressParts = addressParts;
        _id = id;
        _name = name;
        _address = address;
    }
    
    public ICommand AddCommand { get; }

    public List<AddressViewModel> Addresses
    {
        get => _addresses;
        set
        {
            _addresses = value;
            OnPropertyChange(nameof(Address));
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
            OnPropertyChange(nameof(_address));
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
            AddressQuery = value.Name;
            OnPropertyChange(nameof(SelectedAddress));
        }
    }

    private async void AddressSearchExecute(object parameter)
    {
        List<Address> addresses = await _searchUseCase.searchAddresses(AddressQuery, 5);
        Addresses.Clear();

        foreach (Address address in addresses)
            Addresses.Add(new AddressViewModel(address.Value, address.AddressParts));
    }

    private async void AddExecute(object parameter)
    {
        try
        {
            if (_id == 0)
            {
                DialogText = await _migrationServiceUseCase.createMigrationService(
                    new CreateMigrationServiceRequest(Name, SelectedAddress.Name, SelectedAddress.AddressParts));
            }
            else
            {
                DialogText = await _migrationServiceUseCase.updateMigrationService(
                    new UpdateMigrationServiceRequest(_id, Name, (SelectedAddress != null) ? SelectedAddress.Name : _address,
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

    private async void DeleteExecute(object parameter)
    {
        DialogText = await _migrationServiceUseCase.deleteMigrationService(_id);
        //TODO      
    }
}