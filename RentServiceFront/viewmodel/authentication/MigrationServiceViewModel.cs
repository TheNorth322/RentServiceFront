namespace RentServiceFront.viewmodel.authentication;

public class MigrationServiceViewModel : ViewModelBase
{
    private long _id;
    private string _name;

    public MigrationServiceViewModel(long id, string name)
    {
        _id = id;
        _name = name;
    }

    public long Id
    {
        get => _id;
        set
        {
            _id = value;
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