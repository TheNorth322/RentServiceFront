using System;
using System.Windows.Input;

namespace RentServiceFront.viewmodel.mainWindow;

public class RoomTypeViewModel : ViewModelBase
{
    private long _id;
    private bool _isSelected;
    private string _text;
    public ICommand DeleteTypeCommand { get; }
    public EventHandler<RoomTypeViewModel> DeleteTypeRequest { get; set; }

    public RoomTypeViewModel(long id, string text)
    {
        Id = id;
        Text = text;
        IsSelected = false;
        DeleteTypeCommand = new RelayCommand<object>(DeleteTypeExecute);
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

    private void DeleteTypeExecute(object param)
    {
        DeleteTypeRequest?.Invoke(this, this);   
    }
}