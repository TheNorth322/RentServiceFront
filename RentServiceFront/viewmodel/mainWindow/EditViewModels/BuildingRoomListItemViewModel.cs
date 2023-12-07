using System.Collections.Generic;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class BuildingRoomListItemViewModel : ViewModelBase
{
    private bool _isTelephone;
    private double _area;
    private int _number;
    private int _floor;
    private int _price;
    private string _description;
    private List<RoomTypeViewModel> _roomTypes;
    
    public BuildingRoomListItemViewModel(bool isTelephone, double area, int number, int floor, int price, string description, List<RoomTypeViewModel> roomTypes)
    {
        _isTelephone = isTelephone;
        _area = area;
        _number = number;
        _floor = floor;
        _price = price;
        _description = description;
        _roomTypes = roomTypes;
    }

    public bool IsTelephone
    {
        get => _isTelephone;
        set
        {
            _isTelephone = value;
            OnPropertyChange(nameof(IsTelephone));
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
    
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChange(nameof(Description));
        }
    }

    public List<RoomTypeViewModel> RoomTypes
    {
        get => _roomTypes;
        set
        {
            _roomTypes = value;
            OnPropertyChange(nameof(RoomTypes));
        }
    }
}