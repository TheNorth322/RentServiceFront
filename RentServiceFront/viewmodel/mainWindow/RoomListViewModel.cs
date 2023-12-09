using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomListViewModel : ViewModelBase
{
    private ObservableCollection<RoomListItemViewModel> _roomListItemViewModels;
    private ObservableCollection<RoomTypeViewModel> _roomTypes;
    private RoomUseCase _roomUseCase;
    private int _price;
    private double _area;
    private const int _maxPrice = 100000;
    private const int _minPrice = 10000;
    private const double _maxArea = 1000.0f;
    private double _minArea = 30.0f;

    public RoomListViewModel(RoomUseCase roomUseCase)
    {
        _roomUseCase = roomUseCase ?? throw new ArgumentException("Room use case can't be null");
        _roomListItemViewModels = new ObservableCollection<RoomListItemViewModel>();
        _roomTypes = new ObservableCollection<RoomTypeViewModel>();
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

    public double Area
    {
        get => _area;
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }

    public double MaxArea
    {
        get => _maxArea;
    }

    public double MinArea
    {
        get => _minArea;
    }

    public int MaxPrice
    {
        get => _maxPrice;
    }

    public int MinPrice
    {
        get => _minPrice;
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

    public ObservableCollection<RoomListItemViewModel> RoomListItemViewModels
    {
        get => _roomListItemViewModels;
        set
        {
            _roomListItemViewModels = value;
            OnPropertyChange(nameof(RoomListItemViewModels));
        }
    }

    private void OnViewModelChanged(object? sender, ViewModelBase vm)
    {
        RaiseViewModelRequested(vm);
    }

    public async Task InitializeRoomTypes()
    {
        _roomTypes.Clear();
        List<RoomType> roomTypes = await _roomUseCase.GetAllTypes();
        foreach (RoomType roomType in roomTypes)
            _roomTypes.Add(new RoomTypeViewModel(roomType.Id, roomType.Text));
    }

    public async Task InitializeRooms()
    {
        _roomListItemViewModels.Clear();
        List<Room> rooms = await _roomUseCase.GetRooms();
        foreach (Room room in rooms)
        {
            RoomListItemViewModel roomListItemViewModel = new RoomListItemViewModel(room.Id, room.Building.Address.Value, room.Description, room.Floor, room.Number, room.Price, room.Area, _roomUseCase, GetRoomTypesByRoom(room));
            roomListItemViewModel.ViewModelRequested += OnViewModelChanged; 
            _roomListItemViewModels.Add(roomListItemViewModel);
        }
    }

    private List<RoomTypeViewModel> GetRoomTypesByRoom(Room room)
    {
        List<RoomTypeViewModel> roomTypes = new List<RoomTypeViewModel>();
        foreach (RoomType roomType in room.Types)
            roomTypes.Add(new RoomTypeViewModel(roomType.Id, roomType.Text));
        return roomTypes;
    }
}