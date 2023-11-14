using System;
using System.Collections.Generic;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel;

public class RoomListViewModel : ViewModelBase
{
    private List<RoomTypeViewModel> _roomTypes;
    private RoomUseCase _roomUseCase;
    
    public RoomListViewModel(RoomUseCase roomUseCase)
    {
        _roomUseCase = roomUseCase ?? throw new ArgumentException("Room use case can't be null");
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
}