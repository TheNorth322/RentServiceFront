namespace RentServiceFront.viewmodel;

public class RoomTypeViewModel : ViewModelBase
{
    private long _id;
    private bool _isSelected;
    private string _text;

    public RoomTypeViewModel(long id, string text)
    {
        Id = id;
        Text = text;
        IsSelected = false;
    }
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChange(nameof(IsSelected));
        }
    }

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChange(nameof(Text));
        }
    }
    
    public long Id { get; set; }
}