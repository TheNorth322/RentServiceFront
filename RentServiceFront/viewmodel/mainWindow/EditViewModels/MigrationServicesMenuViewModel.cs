using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class MigrationServicesMenuViewModel : ViewModelBase
{
    private ObservableCollection<MigrationServiceEditViewModel> _migrationServices;
    private MigrationServiceEditViewModel _selectedMigrationService;
    private MigrationServiceUseCase _migrationServiceUseCase;
    private SearchUseCase _searchUseCase;
    private SecureDataStorage _secureDataStorage;
    
    public MigrationServicesMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _migrationServices = new ObservableCollection<MigrationServiceEditViewModel>();
        AddMigrationServiceCommand = new RelayCommand(AddMigrationServiceExecute);
        _migrationServiceUseCase = new MigrationServiceUseCase(new MigrationServiceRequest(_secureDataStorage));
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
        InitializeMigrationServices();
    }

    public ICommand AddMigrationServiceCommand { get; }

    public ObservableCollection<MigrationServiceEditViewModel> MigrationServices
    {
        get => _migrationServices;
        set
        {
            _migrationServices = value;
            OnPropertyChange(nameof(MigrationServices));
        }
    }

    public MigrationServiceEditViewModel SelectedMigrationService
    {
        get => _selectedMigrationService;
        set
        {
            _selectedMigrationService = value;
            OnPropertyChange(nameof(SelectedMigrationService));
        }
    }

    private void AddMigrationServiceExecute(object parameter)
    {
        MigrationServiceEditViewModel vm = new MigrationServiceEditViewModel(_migrationServiceUseCase, _searchUseCase);
        vm.DeleteEvent += OnDeleteEvent;
        _migrationServices.Add(vm);
        OnPropertyChange(nameof(MigrationServices));
    }

    private async Task InitializeMigrationServices()
    {
        List<MigrationService> migrationServices = await _migrationServiceUseCase.getMigrationServices();
        
        foreach (MigrationService migrationService in migrationServices)
        {
            MigrationServiceEditViewModel vm = new MigrationServiceEditViewModel(migrationService.Id,
                migrationService.Name,
                migrationService.Address.Value, migrationService.Address.AddressParts, _migrationServiceUseCase, _searchUseCase);
            vm.DeleteEvent += OnDeleteEvent;
            MigrationServices.Add(vm);
        }
    }

    private void OnDeleteEvent(object? sender, MigrationServiceEditViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (MigrationServices.Remove(vm))
        {
            DialogText = "Migration service deleted successfully";
            ShowDialogCommand.Execute(null);
        }
    }
}