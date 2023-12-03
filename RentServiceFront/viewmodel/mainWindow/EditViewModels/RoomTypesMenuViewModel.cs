using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class RoomTypesMenuViewModel : ViewModelBase
{
    private ObservableCollection<RoomTypeEditViewModel> _roomTypes;
    private RoomTypeEditViewModel _selectedRoomType;
    private RoomUseCase _roomUseCase;
    private SearchUseCase _searchUseCase;
    private SecureDataStorage _secureDataStorage;

    public RoomTypesMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _roomTypes = new ObservableCollection<RoomTypeEditViewModel>();
        AddRoomTypeCommand = new RelayCommand(AddRoomTypeExecute);
        _roomUseCase = new RoomUseCase(new RoomRequest(_secureDataStorage));
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
        InitializeRoomTypes();
    }

    public ICommand AddRoomTypeCommand { get; }

    public ObservableCollection<RoomTypeEditViewModel> RoomTypes
    {
        get => _roomTypes;
        set
        {
            _roomTypes = value;
            OnPropertyChange(nameof(RoomTypes));
        }
    }

    public RoomTypeEditViewModel SelectedRoomType
    {
        get => _selectedRoomType;
        set
        {
            _selectedRoomType = value;
            OnPropertyChange(nameof(SelectedRoomType));
        }
    }

    private void AddRoomTypeExecute(object parameter)
    {
        RoomTypeEditViewModel vm = new RoomTypeEditViewModel(_roomUseCase, _searchUseCase);
        vm.DeleteEvent += OnDeleteEvent;
        _roomTypes.Add(vm);
        OnPropertyChange(nameof(RoomTypes));
    }

    private async Task InitializeRoomTypes()
    {
        List<RoomType> roomTypes = await _roomUseCase.GetAllTypes();

        foreach (RoomType type in roomTypes)
        {
            RoomTypeEditViewModel vm = new RoomTypeEditViewModel(type.Id, type.Text, _roomUseCase, _searchUseCase);
            vm.DeleteEvent += OnDeleteEvent;
            _roomTypes.Add(vm);
        }
    }

    private void OnDeleteEvent(object? sender, RoomTypeEditViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (RoomTypes.Remove(vm))
        {
            DialogText = "Migration service deleted successfully";
            ShowDialogCommand.Execute(null);
        }
    }
}