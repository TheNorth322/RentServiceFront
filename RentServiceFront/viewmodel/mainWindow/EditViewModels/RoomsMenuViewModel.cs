using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class RoomsMenuViewModel : ViewModelBase
{
    private ObservableCollection<RoomEditViewModel> _rooms;
    private RoomEditViewModel _selectedRoom;
    private RoomUseCase _roomUseCase;
    private SearchUseCase _searchUseCase;
    private SecureDataStorage _secureDataStorage;

    public RoomsMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _rooms = new ObservableCollection<RoomEditViewModel>();
        AddRoomCommand = new RelayCommand<object>(AddRoomExecute);
        _roomUseCase = new RoomUseCase(new RoomRequest(_secureDataStorage));
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
    }

    public ICommand AddRoomCommand { get; }

    public ObservableCollection<RoomEditViewModel> Rooms
    {
        get => _rooms;
        set
        {
            _rooms = value;
            OnPropertyChange(nameof(Rooms));
        }
    }

    public RoomEditViewModel SelectedRoom
    {
        get => _selectedRoom;
        set
        {
            _selectedRoom = value;
            OnPropertyChange(nameof(SelectedRoom));
        }
    }

    private void AddRoomExecute(object param)
    {
        RoomEditViewModel vm = new RoomEditViewModel(_roomUseCase, _searchUseCase);
        vm.DeleteEvent += OnDeleteEvent;
        _rooms.Add(vm);
        OnPropertyChange(nameof(Rooms));
    }

    public async Task InitializeRooms()
    {
        _rooms.Clear();
        List<Room> rooms = await _roomUseCase.GetRooms();

        foreach (Room room in rooms)
        {
             
            RoomEditViewModel vm = new RoomEditViewModel(room.Id, new BuildingViewModel(room.Building.Id, room.Building.Address.Value,room.Building.Name), room.IsTelephone, room.Area,
                room.Number, room.Floor, room.Price, room.Description, getRoomTypes(room), getRoomImageViewModels(room), _roomUseCase, _searchUseCase);
            vm.DeleteEvent += OnDeleteEvent;
            _rooms.Add(vm);
        }
    }

    private ObservableCollection<RoomTypeViewModel> getRoomTypes(Room room)
    {
        ObservableCollection<RoomTypeViewModel> roomTypes = new ObservableCollection<RoomTypeViewModel>();
        foreach (RoomType roomType in room.Types)
            roomTypes.Add(new RoomTypeViewModel(roomType.Id, roomType.Text));
        return roomTypes;
    }

    private ObservableCollection<RoomImageViewModel> getRoomImageViewModels(Room room)
    {
        ObservableCollection<RoomImageViewModel> roomImages = new ObservableCollection<RoomImageViewModel>();
        foreach (RoomImage roomImage in room.Images)
            roomImages.Add(new RoomImageViewModel(roomImage.Id, roomImage.Url));
        return roomImages;
    }
    
    private void OnDeleteEvent(object? sender, RoomEditViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (_rooms.Remove(vm))
        {
            DialogText = "Комната была успешно удалена";
            ShowDialogCommand.Execute(null);
        }
    }
}