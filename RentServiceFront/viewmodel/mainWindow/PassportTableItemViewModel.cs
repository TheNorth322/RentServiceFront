using System;
using RentServiceFront.domain.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class PassportTableItemViewModel : ViewModelBase
{
    private long _id;
    private string _fullName;
    private DateTime _dateOfBirth;
    private DateTime _dateOfIssue;
    private string _numberSeries;
    private Gender _gender;
    private string _address;
    private string _issuedBy;
    
    public PassportTableItemViewModel(long id, string fullName, DateTime dateOfBirth, DateTime dateOfIssue, string numberSeries, Gender gender, string address, string issuedBy)
    {
        _id = id;
        _fullName = fullName;
        _dateOfBirth = dateOfBirth;
        _dateOfIssue = dateOfIssue;
        _numberSeries = numberSeries;
        _gender = gender;
        _address = address;
        _issuedBy = issuedBy;
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

    public string IssuedBy
    {
        get => _issuedBy;
        set
        {
            _issuedBy = value;
            OnPropertyChange(nameof(IssuedBy));
        }
    }
    public string FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChange(nameof(FullName));
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChange(nameof(DateOfBirth));
        }
    }

    public DateTime DateOfIssue
    {
        get => _dateOfIssue;
        set
        {
            _dateOfIssue = value;
            OnPropertyChange(nameof(DateOfIssue));
        }
    }

    public string NumberSeries
    {
        get => _numberSeries;
        set
        {
            _numberSeries = value;
            OnPropertyChange(nameof(NumberSeries));
        }
    }

    public Gender Gender
    {
        get => _gender;
        set
        {
            _gender = value;
            OnPropertyChange(nameof(Gender));
        }
    }
}