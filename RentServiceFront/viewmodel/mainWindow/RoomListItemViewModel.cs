using System.Collections.Generic;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomListItemViewModel : ViewModelBase
{
    private string _address;
    private string _description;
    private int _floor;
    private int _number;
    private int _price;
    private double _area;
    private List<RoomTypeViewModel> _roomTypeViewModels;
    private long _id;
    private RoomUseCase _roomUseCase;
    public ICommand OpenRoomViewCommand { get; }

    public RoomListItemViewModel(long id, string address, string description, int floor, int number, int price,
        double area, RoomUseCase roomUseCase, List<RoomTypeViewModel> roomTypeViewModels = null)
    {
        OpenRoomViewCommand = new RelayCommand<object>(OpenRoomViewExecute);
        _id = id;
        Address = address;
        Description = description;
        Floor = floor;
        Number = number;
        Price = price;
        Area = area;
        _roomTypeViewModels = roomTypeViewModels;
        _roomUseCase = roomUseCase;
    }



    public List<RoomTypeViewModel> RoomTypeViewModels
    {
        get => _roomTypeViewModels;
        set
        {
            _roomTypeViewModels = value;
            OnPropertyChange(nameof(RoomTypeViewModels));
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

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChange(nameof(Description));
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

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChange(nameof(Number));
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

    public double Area
    {
        get => _area;
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }

    private void OpenRoomViewExecute(object param)
    {
        RoomViewModel roomViewModel = new RoomViewModel(_id, _roomUseCase);
        RaiseViewModelRequested(roomViewModel);
    }
}