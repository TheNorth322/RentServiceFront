using System.Collections.Generic;
using System.Windows.Input;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel;

public class RoomViewModel : ViewModelBase
{
    private string _address;
    public ICommand AddToCartCommand { get; }

    public RoomViewModel()
    {
        AddToCartCommand = new RelayCommand(AddToCartExecute);
    }
    
    public string Address
    {
        get { return _address; }
        set { _address = value; OnPropertyChange(nameof(Address)); }
    }

    private string _description;
    public string Description
    {
        get { return _description; }
        set { _description = value; OnPropertyChange(nameof(Description)); }
    }

    private int _price;
    public int Price
    {
        get { return _price; }
        set { _price = value; OnPropertyChange(nameof(Price)); }
    }

    private List<RoomTypeViewModel> _types;
    public List<RoomTypeViewModel> Types
    {
        get { return _types; }
        set { _types = value; OnPropertyChange(nameof(Types)); }
    }

    private List<RoomImageViewModel> _images;
    public List<RoomImageViewModel> Images
    {
        get { return _images; }
        set { _images = value; OnPropertyChange(nameof(Images)); }
    }

    private int _area;
    public int Area
    {
        get { return _area; }
        set { _area = value; OnPropertyChange(nameof(Area)); }
    }

    private int _floor;
    public int Floor
    {
        get { return _floor; }
        set { _floor = value; OnPropertyChange(nameof(Floor)); }
    }

    private Building _building;
    public Building Building
    {
        get { return _building; }
        set { _building = value; OnPropertyChange(nameof(Building)); }
    }

    private int _number;
    public int Number
    {
        get { return _number; }
        set { _number = value; OnPropertyChange(nameof(Number)); }
    }

    private void AddToCartExecute(object param)
    {
        
    }
}
