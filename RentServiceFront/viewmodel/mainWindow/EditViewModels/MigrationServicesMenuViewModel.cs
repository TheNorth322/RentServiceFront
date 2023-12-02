using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class MigrationServicesMenuViewModel : ViewModelBase
{
    private List<MigrationServiceEditViewModel> _migrationServices;
    private MigrationServiceEditViewModel _selectedMigrationService;
    private MigrationServiceUseCase _migrationServiceUseCase;

    public MigrationServicesMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _migrationServices = new List<MigrationServiceEditViewModel>();
        AddMigrationServiceCommand = new RelayCommand(AddMigrationServiceExecute);
        _migrationServiceUseCase = new MigrationServiceUseCase(new MigrationServiceRequest(secureDataStorage));
        InitializeMigrationServices();
    }

    public ICommand AddMigrationServiceCommand { get; }

    public List<MigrationServiceEditViewModel> MigrationServices
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
        MigrationServices.Add(new MigrationServiceEditViewModel());
    }

    private async Task InitializeMigrationServices()
    {
        List<MigrationService> migrationServices = await _migrationServiceUseCase.getMigrationServices();
        
        foreach (MigrationService migrationService in migrationServices)
        {
            MigrationServices.Add(new MigrationServiceEditViewModel(migrationService.Id, migrationService.Name,
                migrationService.Address.Value, migrationService.Address.AddressParts));
        }
    }
}