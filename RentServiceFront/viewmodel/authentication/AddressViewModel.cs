namespace RentServiceFront.viewmodel.authentication;

public class AddressViewModel : ViewModelBase
{
    private string _name;
    private string _fiasId;

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