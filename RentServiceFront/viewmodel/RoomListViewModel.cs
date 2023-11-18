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
    private int _price;
    private double _area;
    private const int _maxPrice = 100000;
    private const int _minPrice = 10000;
    private const double _maxArea = 1000.0f;
    private double _minArea = 30.0f;

    public RoomListViewModel(RoomUseCase roomUseCase)
    {
        _roomUseCase = roomUseCase ?? throw new ArgumentException("Room use case can't be null");
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
        
        for(int i = 0; i < 7; i++)
        {
            RoomListItemViewModel roomListItemViewModel =
                new RoomListItemViewModel(2, "asdasd", "asdasdads", 2, 2, 2, 2, _roomTypes);
            roomListItemViewModel.ViewModelRequested += OnViewModelChanged;
            _roomListItemViewModels.Add(roomListItemViewModel);
        }

        foreach (var vm in _roomListItemViewModels)
        {
            vm.ViewModelRequested += OnViewModelChanged;
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

    public double Area
    {
        get => _area;
        set
        {
            _area = value;
            OnPropertyChange(nameof(Area));
        }
    }

    public double MaxArea
    {
        get => _maxArea;
    }

    public double MinArea
    {
        get => _minArea;
    }

    public int MaxPrice
    {
        get => _maxPrice;
    }

    public int MinPrice
    {
        get => _minPrice;
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

    private void OnViewModelChanged(object? sender, ViewModelBase vm)
    {
        RaiseViewModelRequested(vm);
    }
}