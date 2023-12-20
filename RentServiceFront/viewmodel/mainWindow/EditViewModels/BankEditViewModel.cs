using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.bank;
using RentServiceFront.domain.model.request.migrationService;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class BankEditViewModel : ViewModelBase
{
    private long _id;
    private string _name;

    private readonly BankUseCase _bankUseCase;
    private ObservableCollection<EntityListItemViewModel> _entityViewModels;
    public ICommand DeleteCommand { get; }
    public EventHandler<BankEditViewModel> DeleteEvent;

    public BankEditViewModel(BankUseCase bankUseCase)
    {
        _entityViewModels = new ObservableCollection<EntityListItemViewModel>();
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddCommand = new RelayCommand<object>(AddExecute, AddCanExecute);

        _id = 0;
        _name = "Unknown";
        _bankUseCase = bankUseCase;
    }

    public ObservableCollection<EntityListItemViewModel> Entities
    {
        get => _entityViewModels;
        set
        {
            _entityViewModels = value;
            OnPropertyChange(nameof(Entities));
        }
    }
    public async void InitializeEntities()
    {
        List<EntityUser> entities = await _bankUseCase.getAllEntityUserInBank(_id);
        foreach (EntityUser entity in entities)
        {
            string fullName =
                $"{entity.SupervisorFirstName} {entity.SupervisorLastName} {(String.IsNullOrEmpty(entity.SupervisorSurname) ? "" : entity.SupervisorSurname)}";
            _entityViewModels.Add(new EntityListItemViewModel(entity.Name, fullName, entity.Address.Value,
                entity.Bank.Name, entity.CheckingAccount, entity.ItnNumber));
        }
    }

    private bool AddCanExecute(object arg)
    {
        return !String.IsNullOrEmpty(Name);
    }

    public BankEditViewModel(long id, string name, BankUseCase bankUseCase) :
        this(bankUseCase)
    {
        _id = id;
        _name = name;
        _bankUseCase = bankUseCase;
    }

    public ICommand AddCommand { get; }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    private async void AddExecute(object parameter)
    {
        try
        {
            if (_id == 0)
            {
                Bank bank = await _bankUseCase.createBank(new CreateBankRequest(Name));
                _id = bank.Id;
            }
            else
            {
                DialogText = await _bankUseCase.updateBank(new UpdateBankRequest(_id, Name));
            }

            ShowDialogCommand.Execute(this);
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
            ShowDialogCommand.Execute(this);
        }
    }

    private async void DeleteExecute(object parameter)
    {
        if (_id != 0)
        {
            await _bankUseCase.deleteBank(_id);
        }

        DeleteEvent?.Invoke(this, this);
    }
}