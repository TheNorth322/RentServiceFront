using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class BanksMenuViewModel : ViewModelBase
{
    private ObservableCollection<BankEditViewModel> _banks;
    private BankEditViewModel _selectedBank;
    private BankUseCase _bankUseCase;
    private SearchUseCase _searchUseCase;
    private SecureDataStorage _secureDataStorage;

    public BanksMenuViewModel(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _banks = new ObservableCollection<BankEditViewModel>();
        AddBankCommand = new RelayCommand<object>(AddBankExecute);
        _bankUseCase = new BankUseCase(new BankRequest(_secureDataStorage));
        _searchUseCase = new SearchUseCase(new SearchRequest(_secureDataStorage));
    }

    public ICommand AddBankCommand { get; }

    public ObservableCollection<BankEditViewModel> Banks
    {
        get => _banks;
        set
        {
            _banks = value;
            OnPropertyChange(nameof(Banks));
        }
    }

    public BankEditViewModel SelectedBank
    {
        get => _selectedBank;
        set
        {
            _selectedBank = value;
            OnPropertyChange(nameof(SelectedBank));
        }
    }

    private void AddBankExecute(object parameter)
    {
        BankEditViewModel vm = new BankEditViewModel(_bankUseCase);
        vm.DeleteEvent += OnDeleteEvent;
        _banks.Add(vm);
        OnPropertyChange(nameof(Banks));
    }

    public async Task InitializeBanks()
    {
        _banks.Clear();
        List<Bank> banks = await _bankUseCase.getBanks();
        
        foreach (Bank bank in banks)
        {
            BankEditViewModel vm = new BankEditViewModel(bank.Id, bank.Name, _bankUseCase);
            vm.DeleteEvent += OnDeleteEvent;
            _banks.Add(vm);
        }
    }

    private void OnDeleteEvent(object? sender, BankEditViewModel vm)
    {
        vm.DeleteEvent -= OnDeleteEvent;
        if (Banks.Remove(vm))
        {
            DialogText = "Migration service deleted successfully";
            ShowDialogCommand.Execute(null);
        }
    }
}