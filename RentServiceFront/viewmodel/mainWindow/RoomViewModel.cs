using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomViewModel : ViewModelBase
{
    private long _id;
    private string _address;
    private string _description;
    private int _price;
    private int _number;
    private int _floor;
    private double _area;
    
    private string _purposeOfRent;
    private DateTime _startOfRent;
    private DateTime _endOfRent;

    private SecureDataStorage _secureDataStorage;
    private ObservableCollection<RoomTypeViewModel> _types;
    private ObservableCollection<RoomImageViewModel> _images;
    private BuildingViewModel _building;
    private RoomUseCase _roomUseCase;

    public ICommand AddToCartCommand { get; }

    public RoomViewModel(long id, RoomUseCase roomUseCase, SecureDataStorage secureDataStorage)
    {
        _id = id;
        _secureDataStorage = secureDataStorage;
        _roomUseCase = roomUseCase;
        StartOfRent = System.DateTime.Now;
        EndOfRent = System.DateTime.Now;
        _types = new ObservableCollection<RoomTypeViewModel>();
        _images = new ObservableCollection<RoomImageViewModel>();
        AddToCartCommand = new RelayCommand<object>(AddToCartExecute, AddToCartCanExecute);
    }

    private bool AddToCartCanExecute(object arg)
    {
        return (_startOfRent < _endOfRent) && !String.IsNullOrEmpty(_purposeOfRent);
    }

    public string Address
    {
        get { return _address; }
        set
        {
            _address = value;
            OnPropertyChange(nameof(Address));
        }
    }

    public string Description
    {
        get { return _description; }
        set
        {
            _description = value;
            OnPropertyChange(nameof(Description));
        }
    }

    public int Price
    {
        get { return _price; }
        set
        {
            _price = value;
            OnPropertyChange(nameof(Price));
        }
    }

    public DateTime StartOfRent
    {
        get => _startOfRent;
        set
        {
            _startOfRent = value;
            OnPropertyChange(nameof(StartOfRent));
        }
    }

    public DateTime EndOfRent
    {
        get => _endOfRent;
        set
        {
            _endOfRent = value;
            OnPropertyChange(nameof(EndOfRent));
        }
    }
    
    public ObservableCollection<RoomTypeViewModel> Types
    {
        get { return _types; }
        set
        {
            _types = value;
            OnPropertyChange(nameof(Types));
        }
    }

    public ObservableCollection<RoomImageViewModel> Images
    {
        get { return _images; }
        set
        {
            _images = value;
            OnPropertyChange(nameof(Images));
        }
    }

    public double Area
    {
        get { return _area; }
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }


    public int Floor
    {
        get { return _floor; }
        set
        {
            _floor = value;
            OnPropertyChange(nameof(Floor));
        }
    }

    public BuildingViewModel Building
    {
        get { return _building; }
        set
        {
            _building = value;
            OnPropertyChange(nameof(Building));
        }
    }


    public int Number
    {
        get { return _number; }
        set
        {
            _number = value;
            OnPropertyChange(nameof(Number));
        }
    }

    public string PurposeOfRent
    {
        get => _purposeOfRent;
        set
        {
            _purposeOfRent = value;
            OnPropertyChange(nameof(PurposeOfRent));
        }
    }

    private async void AddToCartExecute(object param)
    {
        try
        {
           DialogText = await _roomUseCase.AddRoomToCart(new AddRoomToCartRequest(_secureDataStorage.Username, _id, _startOfRent,
                _endOfRent, _purposeOfRent));
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
        }
        ShowDialogCommand.Execute(null);
    }

    public async Task InitializeRoom()
    {
        Room room = await _roomUseCase.GetRoomById(_id);

        Description = room.Description;
        Price = room.Price;
        Number = room.Number;
        Floor = room.Floor;
        Area = room.Area;
        
        InitializeRoomImagesByRoom(room);
        InitializeRoomTypesByRoom(room);
        InitializeBuildingByRoom(room); 
    }

    private void InitializeRoomImagesByRoom(Room room)
    {
        foreach (RoomImage roomImage in room.Images)
        {
            RoomImageViewModel vm = new RoomImageViewModel(roomImage.Id, roomImage.Url);
            _images.Add(vm);
        }
    }

    private void InitializeRoomTypesByRoom(Room room)
    {
        foreach (RoomType roomType in room.Types)
        {
            RoomTypeViewModel vm = new RoomTypeViewModel(roomType.Id, roomType.Text);
            _types.Add(vm);
        }
    }

    private void InitializeBuildingByRoom(Room room)
    {
        _building = new BuildingViewModel(room.Building.Id, room.Building.Address.Value, room.Building.Name);
        Address = _building.Address;
    }
}