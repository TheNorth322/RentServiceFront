using System;
using System.Windows.Input;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class EntityViewModel : ViewModelBase
{
    private string _name;
    private string _supervisorFullname;
    private string _address;
    private string _bankName;
    private string _checkingAccount;
    private string _itnNumber;
    
    public EntityViewModel(string name, string supervisorFirstName, string supervisorLastName, string supervisorSurname, string address, string bankName, string itnNumber,
        string checkingAccount)
    {
        _name = name;
        _supervisorFullname = $"{supervisorFirstName} {supervisorLastName} {((!String.IsNullOrEmpty(supervisorSurname)) ? supervisorSurname : "")}";
        _address = address;
        _bankName = bankName;
        _itnNumber = itnNumber;
        _checkingAccount = checkingAccount;
    }
    
    public string Name
    {
        get => _name;
        set
        {
            Name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    public string SupervisorFullName
    {
        get => _supervisorFullname;
        set
        {
            _supervisorFullname = value;
            OnPropertyChange(nameof(SupervisorFullName));
        }
    }

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChange(nameof(Address));
        }
    }

    public string BankName
    {
        get => _bankName;
        set
        {
            _bankName = value;
            OnPropertyChange(nameof(BankName));
        }
    }

    public string ItnNumber
    {
        get => _itnNumber;
        set
        {
            _itnNumber = value;
            OnPropertyChange(nameof(ItnNumber));
        }
    }

    public string CheckingAccount
    {
        get => _checkingAccount;
        set
        {
            _checkingAccount = value;
            OnPropertyChange(nameof(CheckingAccount));
        }
    }
}