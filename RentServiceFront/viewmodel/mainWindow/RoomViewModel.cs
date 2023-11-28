using System.Collections.Generic;
using System.Windows.Input;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomViewModel : ViewModelBase
{
    private long _id;
    private string _address;
    private string _description;
    private List<RoomImageViewModel> _images;
    private int _price;
    private List<RoomTypeViewModel> _types;
    private int _number;
    private int _floor;
    private int _area;
    private BuildingViewModel _building;

    public ICommand AddToCartCommand { get; }

    public RoomViewModel()
    {
        AddToCartCommand = new RelayCommand(AddToCartExecute);
    }

    public RoomViewModel(long id, string address, string description, List<RoomImageViewModel> images, int price,
        List<RoomTypeViewModel> types, int number, int floor, int area, BuildingViewModel building)
    {
        _id = id;
        _address = address;
        _description = description;
        _images = images;
        _price = price;
        _types = types;
        _number = number;
        _floor = floor;
        _area = area;
        _building = building;
        _images = new List<RoomImageViewModel>();
        _images.Add(new RoomImageViewModel(1,
            "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"));
        _images.Add(new RoomImageViewModel(1,
            "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/310px-Placeholder_view_vector.svg.pngr.com/docs/assets/img/elementor-placeholder-image.png"));
        _images.Add(new RoomImageViewModel(1,
            "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"));
        _images.Add(new RoomImageViewModel(1,
            "https://t4.ftcdn.net/jpg/00/97/58/97/360_F_97589769_t45CqXyzjz0KXwoBZT9PRaWGHRk5hQqQ.jpg"));
        _images.Add(new RoomImageViewModel(1,
            "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/310px-Placeholder_view_vector.svg.pngr.com/docs/assets/img/elementor-placeholder-image.png"));
        AddToCartCommand = new RelayCommand(AddToCartExecute);
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

    public List<RoomTypeViewModel> Types
    {
        get { return _types; }
        set
        {
            _types = value;
            OnPropertyChange(nameof(Types));
        }
    }

    public List<RoomImageViewModel> Images
    {
        get { return _images; }
        set
        {
            _images = value;
            OnPropertyChange(nameof(Images));
        }
    }

    public int Area
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

    private void AddToCartExecute(object param)
    {
    }
}