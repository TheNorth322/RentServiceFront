using System;
using System.Windows.Input;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomImageViewModel : ViewModelBase
{
    private long _id;
    private string _url;
    public EventHandler<RoomImageViewModel> DeleteRoomImageRequest { get; set; }

    public RoomImageViewModel(long id, string url)
    {
        _id = id;
        _url = url;
        DeleteImageCommand = new RelayCommand<object>(DeleteImageExecute);
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
     
    public ICommand DeleteImageCommand { get; }

    private void DeleteImageExecute(object param)
    {
       DeleteRoomImageRequest?.Invoke(this, this); 
    }
}