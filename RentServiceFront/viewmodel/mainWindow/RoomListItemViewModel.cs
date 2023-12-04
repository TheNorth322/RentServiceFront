using System.Collections.Generic;
using System.Windows.Input;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomListItemViewModel : ViewModelBase
{
    private string _address;
    private string _description;
    private int _floor;
    private int _number;
    private int _price;
    private int _area;
    private List<RoomTypeViewModel> _roomTypeViewModels;

    public ICommand OpenRoomViewCommand { get; }

    public RoomListItemViewModel(long id, string address, string description, int floor, int number, int price,
        int area, List<RoomTypeViewModel> roomTypeViewModels = null)
    {
        OpenRoomViewCommand = new RelayCommand<object>(OpenRoomViewExecute);
        Id = id;
        Address = address;
        Description = description;
        Floor = floor;
        Number = number;
        Price = price;
        Area = area;
        _roomTypeViewModels = roomTypeViewModels;
    }


    public long Id { get; set; }

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

    public int Area
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
        RoomViewModel roomViewModel = new RoomViewModel(Id, Address, Description, new List<RoomImageViewModel>(), Price,
            RoomTypeViewModels, Number, Floor, Area, new BuildingViewModel());
        RaiseViewModelRequested(roomViewModel);
    }
}