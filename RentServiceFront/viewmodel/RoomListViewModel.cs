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
        /*List<RoomType> roomTypes = _roomUseCase.GetAllTypes().Result;
        
        foreach (var type in roomTypes)
            _roomTypes.Add(new RoomTypeViewModel(type.Id, type.Text));*/
        _roomListItemViewModels = new List<RoomListItemViewModel>();
        _roomTypes = new List<RoomTypeViewModel>();
        _roomTypes.Add(new RoomTypeViewModel(2, "Лоджия"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Склад"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Склад"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Склад"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Бар"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Пиво"));
        _roomTypes.Add(new RoomTypeViewModel(2, "Водка"));
        
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2, _roomTypes));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2, _roomTypes));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2, _roomTypes));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2));
        _roomListItemViewModels.Add(new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2, _roomTypes));

        foreach (var vm in _roomListItemViewModels)
        {
            vm.ViewModelRequested += OnViewModelChanged;
        }
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

    private void OnViewModelChanged(object? sender, ViewModelBase vm)
    {
        RaiseViewModelRequested(vm);
    }
}