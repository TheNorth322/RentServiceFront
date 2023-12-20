using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class ReferenceViewModel : ViewModelBase
{
    private RoomUseCase _roomUseCase;
    private BuildingUseCase _buildingUseCase;
    private SecureDataStorage _secureDataStorage;

    private BuildingViewModel _selectedBuildingViewModel;
    private ObservableCollection<BuildingViewModel> _buildings;
    private ObservableCollection<RoomViewModel> _availableRooms;
    private ObservableCollection<RoomViewModel> _availableRoomsInBuilding;
    private ObservableCollection<RoomViewModel> _rentalRoomsInBuildigns;

    public ICommand GetAvailableRoomsCommand { get; }
    public ICommand GetAvailableRoomsInBuildingCommand { get; }
    public ICommand GetOccupiedRoomsCommand { get; }

    public async Task InitializeBuildings()
    {
        _buildings.Clear();
        List<Building> buildings = await _buildingUseCase.getBuildings();
        foreach (Building building in buildings)
        {
            _buildings.Add(new BuildingViewModel(building.Id, building.Address.Value, building.Name));
        }
    }

    public ObservableCollection<BuildingViewModel> Buildings
    {
        get => _buildings;
        set
        {
            _buildings = value;
            OnPropertyChange(nameof(Buildings));
        }
    }

    public BuildingViewModel SelectedBuildingViewModel
    {
        get => _selectedBuildingViewModel;
        set
        {
            _selectedBuildingViewModel = value;
            OnPropertyChange(nameof(SelectedBuildingViewModel));
        }
    }

    public ObservableCollection<RoomViewModel> AvailableRooms
    {
        get => _availableRooms;
        set
        {
            _availableRooms = value;
            OnPropertyChange(nameof(AvailableRooms));
        }
    }

    public ObservableCollection<RoomViewModel> AvailableRoomsInBuilding
    {
        get => _availableRoomsInBuilding;
        set
        {
            _availableRoomsInBuilding = value;
            OnPropertyChange(nameof(AvailableRoomsInBuilding));
        }
    }

    public ObservableCollection<RoomViewModel> RentalRoomsInBuildings
    {
        get => _rentalRoomsInBuildigns;
        set
        {
            _rentalRoomsInBuildigns = value;
            OnPropertyChange(nameof(RentalRoomsInBuildings));
        }
    }

    public ReferenceViewModel(RoomUseCase roomUseCase, SecureDataStorage secureDataStorage,
        BuildingUseCase buildingUseCase)
    {
        GetAvailableRoomsInBuildingCommand = new RelayCommand<object>(GetAvailableRoomsInBuildingExecute, GetCanExecute);
        GetAvailableRoomsCommand = new RelayCommand<object>(GetAvailableRoomsExecute);
        GetOccupiedRoomsCommand = new RelayCommand<object>(GetOccupiedRoomsExecute);

        _buildings = new ObservableCollection<BuildingViewModel>();
        _availableRooms = new ObservableCollection<RoomViewModel>();
        _availableRoomsInBuilding = new ObservableCollection<RoomViewModel>();
        _rentalRoomsInBuildigns = new ObservableCollection<RoomViewModel>();

        _roomUseCase = roomUseCase;
        _secureDataStorage = secureDataStorage;
        _buildingUseCase = buildingUseCase;
    }

    private bool GetCanExecute(object arg)
    {
        return !(_selectedBuildingViewModel == null);
    }


    private async void GetAvailableRoomsExecute(object? param)
    {
        _availableRooms.Clear();
        List<Room> availableRooms = await _roomUseCase.GetAvailableRooms();
        foreach (Room room in availableRooms)
        {
            RoomViewModel vm = new RoomViewModel(room.Id, _roomUseCase, _secureDataStorage);
            await vm.InitializeRoom();
            _availableRooms.Add(vm);
        }
    }

    private async void GetAvailableRoomsInBuildingExecute(object? param)
    {
        _availableRoomsInBuilding.Clear();
        List<Room> availableRoomsInBuilding =
            await _roomUseCase.GetAvailableRoomsInBuilding(_selectedBuildingViewModel.Id);
        foreach (Room room in availableRoomsInBuilding)
        {
            RoomViewModel vm = new RoomViewModel(room.Id, _roomUseCase, _secureDataStorage);
            await vm.InitializeRoom();
            _availableRoomsInBuilding.Add(vm);
        }
    }

    private async void GetOccupiedRoomsExecute(object? param)
    {
        _rentalRoomsInBuildigns.Clear();
        List<Room> occupiedRooms = await _roomUseCase.GetRoomInBuildingWithRentals();
        foreach (Room room in occupiedRooms)
        {
            RoomViewModel vm = new RoomViewModel(room.Id, _roomUseCase, _secureDataStorage);
            await vm.InitializeRoom();
            _rentalRoomsInBuildigns.Add(vm);
        }
    }
}