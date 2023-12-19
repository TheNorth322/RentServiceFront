using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class UserRoomViewModel : ViewModelBase
{
    public long RoomId { get; }
    private ObservableCollection<RoomTypeViewModel> _roomTypeViewModels;
    private string _address;
    private DateTime _startOfRent;
    private DateTime _endOfRent;
    private RoomUseCase _roomUseCase;

    public UserRoomViewModel(long roomId,
        DateTime startOfRent, DateTime endOfRent, RoomUseCase roomUseCase)
    {
        DeleteRoomCommand = new RelayCommand<object>(DeleteRoomExecute);
        _roomTypeViewModels = new ObservableCollection<RoomTypeViewModel>();
        RoomId = roomId;
        _startOfRent = startOfRent;
        _endOfRent = endOfRent;
        _roomUseCase = roomUseCase;
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

    public DateTime StartOfRent
    {
        get => _startOfRent;
        set
        {
            _startOfRent = value;
            OnPropertyChange(nameof(StartOfRent));
        }
    }

    public DateTime EndOfRent
    {
        get => _endOfRent;
        set
        {
            _endOfRent = value;
            OnPropertyChange(nameof(EndOfRent));
        }
    }
    public ObservableCollection<RoomTypeViewModel> RoomTypeViewModels
    {
        get => _roomTypeViewModels;
        set
        {
            _roomTypeViewModels = value;
            OnPropertyChange(nameof(RoomTypeViewModels));
        }
    }

    public async void InitializeRoom()
    {
        Room room = await _roomUseCase.GetRoomById(RoomId);
        Address = room.Building.Address.Value;
        InitializeRoomTypes(room);
    }

    private void InitializeRoomTypes(Room room)
    {
        foreach (RoomType roomType in room.Types)
            _roomTypeViewModels.Add(new RoomTypeViewModel(roomType.Id, roomType.Text)); 
    }
    public ICommand DeleteRoomCommand { get; }
    public EventHandler<UserRoomViewModel> DeleteRoomEvent { get; set; }

    private void DeleteRoomExecute(object param)
    {
        DeleteRoomEvent?.Invoke(this, this);
    }
}