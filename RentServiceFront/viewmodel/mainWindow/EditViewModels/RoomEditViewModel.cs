using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class RoomEditViewModel : ViewModelBase
{
    private long _id;
    private long _buildingId;
    private bool _telephone;
    private double _area;
    private int _number;
    private int _floor;
    private int _price;
    private string _description;
    private ObservableCollection<RoomTypeViewModel> _roomTypes;
    private ObservableCollection<RoomTypeViewModel> _thisRoomTypes;
    private ObservableCollection<RoomImageViewModel> _roomImages;

    private bool _isComboBoxOpen;
    private readonly SearchUseCase _searchUseCase;
    private readonly RoomUseCase _roomUseCase;
    private KeyEventArgs _lastKeyEventArgs;
    public ICommand DeleteCommand { get; }
    public EventHandler<RoomEditViewModel> DeleteEvent;

    public RoomEditViewModel(RoomUseCase roomUseCase, SearchUseCase searchUseCase)
    {
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddCommand = new RelayCommand<object>(AddExecute);

        _id = 0;
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
    }

    public RoomEditViewModel(long id, long buildingId, bool telephone, double area, int number, int floor, int price,
        string description,
        ObservableCollection<RoomTypeViewModel> thisRoomTypes, ObservableCollection<RoomImageViewModel> roomImages,
        RoomUseCase roomUseCase, SearchUseCase searchUseCase) : this(roomUseCase,
        searchUseCase)
    {
        _id = id;
        _buildingId = buildingId;
        _telephone = telephone;
        _area = area;
        _number = number;
        _floor = floor;
        _price = price;
        _description = description;
        _thisRoomTypes = thisRoomTypes;
        _roomImages = roomImages;
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
    }

    public bool Telephone
    {
        get => _telephone;
        set
        {
            _telephone = value;
            OnPropertyChange(nameof(Telephone));
        }
    }

    public double Area
    {
        get => _area;
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChange(nameof(Number));
        }
    }

    public int Floor
    {
        get => _floor;
        set
        {
            _floor = value;
            OnPropertyChange(nameof(Floor));
        }
    }

    public int Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChange(nameof(Price));
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChange(nameof(Description));
        }
    }

    public ICommand AddCommand { get; }

    public bool IsComboBoxOpen
    {
        get => _isComboBoxOpen;
        set
        {
            _isComboBoxOpen = value;
            OnPropertyChange(nameof(IsComboBoxOpen));
        }
    }

    public KeyEventArgs LastKeyEventArgs
    {
        get { return _lastKeyEventArgs; }
        set
        {
            if (_lastKeyEventArgs != value)
            {
                _lastKeyEventArgs = value;
                OnPropertyChange(nameof(LastKeyEventArgs));
            }
        }
    }

    private async void InitializeTypes()
    {
        _roomTypes.Clear();
        List<RoomType> roomTypes = await _roomUseCase.GetAllTypes();

        foreach (RoomType roomType in roomTypes)
        {
            RoomTypeViewModel vm = new RoomTypeViewModel(roomType.Id, roomType.Text);
            _roomTypes.Add(vm);
        }
    }

    private List<RoomType> getTypeIds()
    {
        List<RoomType> typeIds = new List<RoomType>();
        foreach (RoomTypeViewModel roomTypeViewModel in _thisRoomTypes)
            typeIds.Add(new RoomType(roomTypeViewModel.Id, roomTypeViewModel.Text));
        return typeIds;
    }

    private List<RoomImage> getRoomImages()
    {
        List<RoomImage> roomImages = new List<RoomImage>();
        foreach (RoomImageViewModel roomImageViewModel in _roomImages)
            roomImages.Add(new RoomImage(roomImageViewModel.Id, roomImageViewModel.Url));
        return roomImages;
    }

    private async void AddExecute(object param)
    {
        try
        {
            List<RoomType> types = getTypeIds();
            List<RoomImage> roomImages = getRoomImages();
            
            if (_id == 0)
            {
                Room room = await _roomUseCase.CreateRoom(new CreateRoomRequest(_buildingId, _telephone, _area, _number,
                    _floor, _price, _description, types, roomImages));

                _id = room.Id;
                DialogText = "Room was successfully created";
            }
            else
            {
                DialogText = await _roomUseCase.UpdateRoom(
                    new UpdateRoomRequest(_id, _buildingId, _telephone, _area, _number,
                        _floor, _price, _description, types, roomImages));
            }

            ShowDialogCommand.Execute(this);
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
            ShowDialogCommand.Execute(this);
        }
    }

    private async void DeleteExecute(object param)
    {
        if (_id != 0)
        {
            await _roomUseCase.DeleteRoom(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }
}