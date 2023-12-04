using System;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class RoomTypeEditViewModel : ViewModelBase
{
    private long _id;
    private string _name;

    private readonly SearchUseCase _searchUseCase;
    private readonly RoomUseCase _roomUseCase;

    public ICommand DeleteCommand { get; }
    public EventHandler<RoomTypeEditViewModel> DeleteEvent;

    public RoomTypeEditViewModel(RoomUseCase roomUseCase, SearchUseCase searchUseCase)
    {
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddCommand = new RelayCommand<object>(AddExecute);

        _id = 0;
        _name = "Unknown";
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
    }

    public RoomTypeEditViewModel(long id, string name, RoomUseCase roomUseCase, SearchUseCase searchUseCase) :
        this(roomUseCase,
            searchUseCase)
    {
        _id = id;
        _name = name;
        _roomUseCase = roomUseCase;
        _searchUseCase = searchUseCase;
    }

    public ICommand AddCommand { get; }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    private async void AddExecute(object param)
    {
        try
        {
            if (_id == 0)
            {
                RoomType roomType = await _roomUseCase.CreateRoomType(new CreateRoomTypeRequest(Name));
                _id = roomType.Id;
            }
            else
            {
                DialogText = await _roomUseCase.UpdateRoomType(new UpdateRoomTypeRequest(_id, Name));
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
            await _roomUseCase.DeleteRoomType(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }
}