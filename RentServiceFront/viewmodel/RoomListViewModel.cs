using System;
using System.Collections.Generic;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel;

public class RoomListViewModel : ViewModelBase
{
    private List<RoomListItemViewModel> _roomListItemViewModels;
    private List<RoomTypeViewModel> _roomTypes;
    private RoomUseCase _roomUseCase;
    
    public ICommand OnItemClickedCommand { get; }
    public RoomListViewModel(RoomUseCase roomUseCase)
    {
        _roomUseCase = roomUseCase ?? throw new ArgumentException("Room use case can't be null");
        OnItemClickedCommand = new RelayCommand(ItemClickedExecute); 
        List<RoomType> roomTypes = _roomUseCase.GetAllTypes().Result;
        
        foreach (var type in roomTypes)
            _roomTypes.Add(new RoomTypeViewModel(type.Id, type.Text));
    }

    public List<RoomTypeViewModel> RoomTypes
    {
        get => _roomTypes;
        set
        {
            _roomTypes = value;
            OnPropertyChange(nameof(RoomTypes));
        }
    }

    public List<RoomListItemViewModel> RoomListItemViewModels
    {
        get => _roomListItemViewModels;
        set
        {
            _roomListItemViewModels = value;
            OnPropertyChange(nameof(RoomListItemViewModels));
        }
    }

    private void ItemClickedExecute(object param)
    {
        RoomViewModel roomViewModel = new RoomViewModel(); 
        RaiseViewModelRequested(roomViewModel); 
    } 
}