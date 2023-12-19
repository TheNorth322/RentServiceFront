using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;
using RentServiceFront.domain.model.request.Room;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class RoomEditViewModel : ViewModelBase
{
    private readonly RoomUseCase _roomUseCase;
    private readonly SearchUseCase _searchUseCase;


    private string _addressQuery;
    private double _area;
    private BuildingViewModel _building;
    private string _description;
    private int _floor;
    private long _id;
    private string _imageUrl;
    private bool _isComboBoxOpen;
    private KeyEventArgs _lastKeyEventArgs;
    private int _number;
    private int _price;
    private bool _telephone;

    private ObservableCollection<AddressViewModel> _addresses;
    private ObservableCollection<RoomImageViewModel> _roomImages;
    private ObservableCollection<RoomTypeViewModel> _roomTypes;
    private ObservableCollection<RoomTypeViewModel> _thisRoomTypes;

    private AddressViewModel _selectedAddress;
    private RoomTypeViewModel _selectedRoomType;
    public EventHandler<RoomEditViewModel> DeleteEvent;
    private int _fine;


    public RoomEditViewModel(RoomUseCase roomUseCase, SearchUseCase searchUseCase)
    {
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddCommand = new RelayCommand<object>(AddExecute);
        AddTypeCommand = new RelayCommand<object>(AddTypeExecute);
        AddImageCommand = new RelayCommand<object>(AddImageExecute);
        AddressSearchCommand = new RelayCommand<object>(AddressSearchExecute);
        AddBuildingCommand = new RelayCommand<object>(AddBuildingExecute);

        _roomImages = new ObservableCollection<RoomImageViewModel>();
        _thisRoomTypes = new ObservableCollection<RoomTypeViewModel>();
        _roomTypes = new ObservableCollection<RoomTypeViewModel>();
        _addresses = new ObservableCollection<AddressViewModel>();

        _id = 0;
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
    }

    public RoomEditViewModel(long id, BuildingViewModel buildingViewModel, bool telephone, double area, int number,
        int floor, int price,
        string description,
        ObservableCollection<RoomTypeViewModel> thisRoomTypes, ObservableCollection<RoomImageViewModel> roomImages,
        RoomUseCase roomUseCase, SearchUseCase searchUseCase) : this(roomUseCase,
        searchUseCase)
    {
        _id = id;
        _building = buildingViewModel;
        _addressQuery = _building.Address;
        Telephone = telephone;
        _area = area;
        _number = number;
        _floor = floor;
        _price = price;
        _description = description;
        _thisRoomTypes = thisRoomTypes;
        _roomImages = roomImages;
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
        SubscribeOnTypeDeletion();
        SubscribeOnImageDeletion();
    }

    private void SubscribeOnTypeDeletion()
    {
        foreach (RoomTypeViewModel roomType in _thisRoomTypes)
            roomType.DeleteTypeRequest += OnDeleteTypeRequest;
    }

    private void SubscribeOnImageDeletion()
    {
        foreach (RoomImageViewModel roomImage in _roomImages)
            roomImage.DeleteRoomImageRequest += OnDeleteImageRequest;
    }

    public ICommand DeleteCommand { get; }

    public ObservableCollection<RoomTypeViewModel> ThisRoomTypes
    {
        get => _thisRoomTypes;
        set
        {
            _thisRoomTypes = value;
            OnPropertyChange(nameof(ThisRoomTypes));
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

    public bool Telephone
    {
        get => _telephone;
        set
        {
            _telephone = value;
            OnPropertyChange(nameof(Telephone));
        }
    }

    public double Area
    {
        get => _area;
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChange(nameof(Number));
        }
    }

    public int Floor
    {
        get => _floor;
        set
        {
            _floor = value;
            OnPropertyChange(nameof(Floor));
        }
    }

    public int Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChange(nameof(Price));
        }
    }

    public int Fine
    {
        get => _fine;
        set
        {
            _fine = value;
            OnPropertyChange(nameof(Fine));
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChange(nameof(Description));
        }
    }

    public ICommand AddCommand { get; }

    public bool IsComboBoxOpen
    {
        get => _isComboBoxOpen;
        set
        {
            _isComboBoxOpen = value;
            OnPropertyChange(nameof(IsComboBoxOpen));
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

    public ObservableCollection<RoomTypeViewModel> RoomTypes
    {
        get => _roomTypes;
        set
        {
            _roomTypes = value;
            OnPropertyChange(nameof(RoomTypes));
        }
    }

    public RoomTypeViewModel SelectedRoomType
    {
        get => _selectedRoomType;
        set
        {
            _selectedRoomType = value;
            OnPropertyChange(nameof(SelectedRoomType));
        }
    }

    public ICommand AddTypeCommand { get; }

    public string ImageUrl
    {
        get => _imageUrl;
        set
        {
            _imageUrl = value;
            OnPropertyChange(nameof(ImageUrl));
        }
    }

    public ICommand AddImageCommand { get; }
    public ICommand AddressSearchCommand { get; }

    public string AddressQuery
    {
        get => _addressQuery;
        set
        {
            _addressQuery = value;
            OnPropertyChange(nameof(AddressQuery));
        }
    }

    public ICommand AddBuildingCommand { get; }

    public ObservableCollection<RoomImageViewModel> RoomImages
    {
        get => _roomImages;
        set
        {
            _roomImages = value;
            OnPropertyChange(nameof(RoomImages));
        }
    }

    private void AddImageExecute(object param)
    {
        foreach (RoomImageViewModel roomImage in _roomImages)
            if (roomImage.Url == _imageUrl)
                return;

        RoomImageViewModel vm = new RoomImageViewModel(0, _imageUrl);
        vm.DeleteRoomImageRequest += OnDeleteImageRequest;
        _roomImages.Add(vm);
    }

    public async void InitializeTypes()
    {
        _roomTypes.Clear();
        List<RoomType> roomTypes = await _roomUseCase.GetAllTypes();

        foreach (RoomType roomType in roomTypes)
        {
            RoomTypeViewModel vm = new RoomTypeViewModel(roomType.Id, roomType.Text);
            _roomTypes.Add(vm);
        }
    }

    private List<RoomType> getTypes()
    {
        List<RoomType> typeIds = new List<RoomType>();
        foreach (RoomTypeViewModel roomTypeViewModel in _thisRoomTypes)
            typeIds.Add(new RoomType(roomTypeViewModel.Id, roomTypeViewModel.Text));
        return typeIds;
    }

    private List<RoomImage> getRoomImages()
    {
        List<RoomImage> roomImages = new List<RoomImage>();
        foreach (RoomImageViewModel roomImageViewModel in _roomImages)
            roomImages.Add(new RoomImage(roomImageViewModel.Id, roomImageViewModel.Url));
        return roomImages;
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
            List<RoomType> types = getTypes();
            List<RoomImage> roomImages = getRoomImages();

            if (_id == 0)
            {
                Room room = await _roomUseCase.CreateRoom(new CreateRoomRequest(_building.Id, _telephone, _area,
                    _number,
                    _floor, _price, _fine, _description, types, roomImages));

                _id = room.Id;
                DialogText = "Room was successfully created";
            }
            else
            {
                DialogText = await _roomUseCase.UpdateRoom(
                    new UpdateRoomRequest(_id, _building.Id, _telephone, _area, _number,
                        _floor, _price, _fine, _description, types, roomImages));
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
            await _roomUseCase.DeleteRoom(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }

    private void AddTypeExecute(object param)
    {
        if (_thisRoomTypes.Contains(SelectedRoomType))
            return;

        SelectedRoomType.DeleteTypeRequest += OnDeleteTypeRequest;
        _thisRoomTypes.Add(SelectedRoomType);
    }

    private async void AddBuildingExecute(object param)
    {
        try
        {
            Building building =
                await _searchUseCase.getBuildingByAddress(new Address(SelectedAddress.Name,
                    SelectedAddress.AddressParts));
            _building = new BuildingViewModel(building.Id, building.Address.Value, building.Name);
            DialogText = "Building was added successfully";
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
        }

        ShowDialogCommand.Execute(null);
    }

    private void OnDeleteTypeRequest(object? sender, RoomTypeViewModel vm)
    {
        vm.DeleteTypeRequest -= OnDeleteTypeRequest;
        _thisRoomTypes.Remove(vm);
    }

    private void OnDeleteImageRequest(object? sender, RoomImageViewModel vm)
    {
        vm.DeleteRoomImageRequest -= OnDeleteImageRequest;
        _roomImages.Remove(vm);
    }
}