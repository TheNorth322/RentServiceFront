namespace RentServiceFront.viewmodel;

public class RoomImageViewModel : ViewModelBase
{
    private long _id;
    private string _url;

    public RoomImageViewModel(long id, string url)
    {
        _id = id;
        _url = url;
    }
    
    public long Id { get; set; }
    
    public string Url
    {
        get => _url;
        set
        {
            _url = value;
            OnPropertyChange(nameof(Url));
        }
    }
}