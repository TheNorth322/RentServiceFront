using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class BuildingsMenuViewModel : ViewModelBase
{
    private ObservableCollection<BuildingEditViewModel> _buildings;
    private BuildingEditViewModel _selectedBuilding;
    private BuildingUseCase _buildingUseCase;
    private SearchUseCase _searchUseCase;
    private SecureDataStorage _secureDataStorage;

    public BuildingsMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _buildings = new ObservableCollection<BuildingEditViewModel>();
        AddBuildingCommand = new RelayCommand<object>(AddBuildingExecute);
        _buildingUseCase = new BuildingUseCase(new BuildingRequest(_secureDataStorage));
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
    }

    public ICommand AddBuildingCommand { get; }

    public ObservableCollection<BuildingEditViewModel> Buildings
    {
        get => _buildings;
        set
        {
            _buildings = value;
            OnPropertyChange(nameof(Buildings));
        }
    }

    public BuildingEditViewModel SelectedBuilding
    {
        get => _selectedBuilding;
        set
        {
            _selectedBuilding = value;
            OnPropertyChange(nameof(SelectedBuilding));
        }
    }

    private void AddBuildingExecute(object param)
    {
        BuildingEditViewModel vm = new BuildingEditViewModel(_buildingUseCase, _searchUseCase);
        vm.DeleteEvent += OnDeleteEvent;
        _buildings.Add(vm);
        OnPropertyChange(nameof(Buildings));
    }

    public async Task InitializeBuildings()
    {
        _buildings.Clear();
        List<Building> buildings = await _buildingUseCase.getBuildings();

        foreach (Building building in buildings)
        {
            BuildingEditViewModel vm = new BuildingEditViewModel(building.Id, building.Name, building.FloorCount,
                building.Telephone, building.Address.Value, building.Address.AddressParts, _buildingUseCase,
                _searchUseCase);
            await vm.InitializeRooms();
            vm.DeleteEvent += OnDeleteEvent;
            _buildings.Add(vm);
        }
    }

    private void OnDeleteEvent(object? sender, BuildingEditViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (Buildings.Remove(vm))
        {
            DialogText = "Migration service deleted successfully";
            ShowDialogCommand.Execute(null);
        }
    }
}