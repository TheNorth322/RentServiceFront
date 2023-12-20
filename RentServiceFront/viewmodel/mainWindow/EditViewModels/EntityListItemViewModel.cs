namespace RentServiceFront.viewmodel.mainWindow.EditViewModels;

public class EntityListItemViewModel : ViewModelBase
{
    private string _name;
    private string _supervisorFullname;
    private string _address;
    private string _bankName;
    private string _checkingAccount;
    private string _itnNumber;


    public EntityListItemViewModel(string name, string supervisorFullname, string address, string bankName,
        string checkingAccount, string itnNumber)
    {
        _name = name;
        _supervisorFullname = supervisorFullname;
        _address = address;
        _bankName = bankName;
        _checkingAccount = checkingAccount;
        _itnNumber = itnNumber;
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
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