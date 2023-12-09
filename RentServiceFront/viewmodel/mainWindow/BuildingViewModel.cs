namespace RentServiceFront.viewmodel.mainWindow;

public class BuildingViewModel : ViewModelBase
{
    private long _id;
    private string _address;
    private string _name;

    public BuildingViewModel(long id, string address, string name)
    {
        _id = id;
        _address = address;
        _name = name;
    }
    
    public long Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChange(nameof(Id));
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

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChange(nameof(Name));
        }
    }
}