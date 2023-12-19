using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.viewmodel.mainWindow;

public class PassportMenuViewModel : ViewModelBase
{
    private ObservableCollection<PassportViewModel> _passports;
    private PassportViewModel _selectedPassport;
    private readonly UserUseCase _userUseCase;
    private readonly SearchUseCase _searchUseCase;
    private readonly PassportUseCase _passportUseCase; 
    private readonly SecureDataStorage _secureDataStorage;

    public PassportMenuViewModel(UserUseCase userUseCase, SearchUseCase searchUseCase, PassportUseCase passportUseCase, SecureDataStorage secureDataStorage)
    {
        AddPassportCommand = new RelayCommand<object>(AddPassportExecute);
        _passports = new ObservableCollection<PassportViewModel>();
        _userUseCase = userUseCase;
        _searchUseCase = searchUseCase;
        _passportUseCase = passportUseCase;
        _secureDataStorage = secureDataStorage;
    }

    public ObservableCollection<PassportViewModel> Passports
    {
        get => _passports;
        set
        {
            _passports = value;
            OnPropertyChange(nameof(Passports));
        }
    }

    public ICommand AddPassportCommand { get; }


    public PassportViewModel SelectedPassport
    {
        get => _selectedPassport;
        set
        {
            _selectedPassport = value;
            OnPropertyChange(nameof(SelectedPassport));
        }
    }

    private void AddPassportExecute(object parameter)
    {
        PassportViewModel vm = new PassportViewModel(0,"0",  _userUseCase, _searchUseCase, _passportUseCase, _secureDataStorage);
        vm.DeleteEvent += OnDeleteEvent;
        _passports.Add(vm);
        OnPropertyChange(nameof(Passports));
    }

    public async Task InitializePassports()
    {
        _passports.Clear();
        IndividualUser user = await _userUseCase.getUserIndividualInfo(_secureDataStorage.Username);
        List<Passport> passports = user.Passports;

        foreach (Passport passport in passports)
        {
            PassportViewModel vm = new PassportViewModel(passport.Id,$"{passport.Number} {passport.Series}", _userUseCase, _searchUseCase, _passportUseCase, _secureDataStorage);
            vm.DeleteEvent += OnDeleteEvent;
            _passports.Add(vm);
        }
    }

    private void OnDeleteEvent(object? sender, PassportViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (Passports.Remove(vm))
        {
            DialogText = "Migration service deleted successfully";
            ShowDialogCommand.Execute(null);
        }
    }
}