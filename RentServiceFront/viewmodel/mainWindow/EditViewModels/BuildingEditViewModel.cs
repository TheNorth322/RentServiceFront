using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;
using RentServiceFront.domain.model.request.migrationService;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class BuildingEditViewModel : ViewModelBase
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
    private readonly BuildingUseCase _buildingUseCase;
    private KeyEventArgs _lastKeyEventArgs;
    public ICommand DeleteCommand { get; }
    public EventHandler<BuildingEditViewModel> DeleteEvent;
    private string _telephone;
    private int _floorCount;
    private ObservableCollection<BuildingRoomListItemViewModel> _rooms;
    public BuildingEditViewModel(BuildingUseCase buildingUseCase, SearchUseCase searchUseCase)
    {
        _addressParts = new List<AddressPart>();
        _addresses = new ObservableCollection<AddressViewModel>();
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddressSearchCommand = new RelayCommand<KeyEventArgs>(AddressSearchExecute);
        AddCommand = new RelayCommand<object>(AddExecute, AddCanExecute);
        _rooms = new ObservableCollection<BuildingRoomListItemViewModel>();
        
        _id = 0;
        _name = "Unknown";
        _buildingUseCase = buildingUseCase;
        _searchUseCase = searchUseCase;
    }

    private bool AddCanExecute(object arg)
    {
        return !String.IsNullOrEmpty(Name) && _floorCount != 0 && !String.IsNullOrEmpty(Telephone) && SelectedAddress != null;
    }

    public BuildingEditViewModel(long id, string name, int floorCount, string telephone, string address, List<AddressPart> addressParts,
        BuildingUseCase buildingUseCase, SearchUseCase searchUseCase) : this(buildingUseCase,
        searchUseCase)
    {
        _addressParts = addressParts;
        _id = id;
        _name = name;
        _address = address;
        _floorCount = floorCount;
        _telephone = telephone;
        AddressQuery = _address;
        _buildingUseCase = buildingUseCase;
        _searchUseCase = searchUseCase;
    }

    public ICommand AddCommand { get; }

    public string Telephone
    {
        get => _telephone;
        set
        {
            _telephone = value;
            OnPropertyChange(nameof(Telephone));
        }
    }

    public int FloorCount
    {
        get => _floorCount;
        set
        {
            _floorCount = value;
            OnPropertyChange(nameof(FloorCount));
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
            _addressParts = _selectedAddress.AddressParts;
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

    public ObservableCollection<BuildingRoomListItemViewModel> Rooms
    {
        get => _rooms;
        set
        {
            _rooms = value;
            OnPropertyChange(nameof(Rooms));
        }
    }

    public async Task InitializeRooms()
    {
        List<Room> rooms = await _buildingUseCase.getBuildingRooms(_id);
        
        _rooms.Clear(); 
        foreach (Room room in rooms)
        {
            List<RoomTypeViewModel> roomTypes = getTypes(room);
            BuildingRoomListItemViewModel vm = new BuildingRoomListItemViewModel(room.IsTelephone, room.Area, room.Number, room.Floor, room.Price, room.Description, roomTypes);
            _rooms.Add(vm); 
        }
    }

    private List<RoomTypeViewModel> getTypes(Room room)
    {
        List<RoomTypeViewModel> roomTypes = new List<RoomTypeViewModel>();
        
        foreach (RoomType roomType in room.Types)
        {
            RoomTypeViewModel vm = new RoomTypeViewModel(roomType.Id, roomType.Text);
            roomTypes.Add(vm);
        }

        return roomTypes;
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
                Building building = await _buildingUseCase.createBuilding(new CreateBuildingRequest(Name, SelectedAddress.Name, SelectedAddress.AddressParts, FloorCount, Telephone));
                _id = building.Id;
                DialogText = "Здание было успешно добавлено";
            }
            else
            {
                await _buildingUseCase.updateBuilding(
                    new UpdateBuildingRequest(_id, Name, Address, _addressParts, FloorCount, Telephone));
                DialogText = "Здание было успешно обновлено";
            }

            ShowDialogCommand.Execute(this);
        }
        catch (Exception e)
        {
            DialogText = "Здание не было добавлено";
            ShowDialogCommand.Execute(this);
        }
    }

    private async void DeleteExecute(object param)
    {
        if (_id != 0)
        {
            await _buildingUseCase.deleteBuilding(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }
}