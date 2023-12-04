using System;
using System.Collections.Generic;
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

    public ICommand DeleteCommand { get; }
    public EventHandler<BankEditViewModel> DeleteEvent;

    public BankEditViewModel(BankUseCase bankUseCase)
    {
        DeleteCommand = new RelayCommand<object>(DeleteExecute);
        AddCommand = new RelayCommand<object>(AddExecute);

        _id = 0;
        _name = "Unknown";
        _bankUseCase = bankUseCase;
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