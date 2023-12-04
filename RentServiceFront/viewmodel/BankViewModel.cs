namespace RentServiceFront.viewmodel;

public class BankViewModel : ViewModelBase
{
    private long _id;
    private string _name;

    public BankViewModel(long id, string name)
    {
        _id = id;
        _name = name;
    }

    public long Id
    {
        get => _id;
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