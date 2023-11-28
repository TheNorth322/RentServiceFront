using System;
using RentServiceFront.domain.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class PassportViewModel : ViewModelBase
{
    private string _fullName;
    private DateTime _dateOfBirth;
    private DateTime _dateOfIssue;
    private string _issuedBy;
    private string _numberSeries;
    private Gender _gender;
    private string _placeOfBirth;
    
    public PassportViewModel(string fullName, DateTime dateOfBirth, DateTime dateOfIssue, string issuedBy,
        string numberSeries, Gender gender, string placeOfBirth)
    {
        _fullName = fullName;
        _dateOfBirth = dateOfBirth;
        _dateOfIssue = dateOfIssue;
        _issuedBy = issuedBy;
        _numberSeries = numberSeries;
        _gender = gender;
        _placeOfBirth = placeOfBirth;
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

    public string IssuedBy
    {
        get => _issuedBy;
        set
        {
            _issuedBy = value;
            OnPropertyChange(nameof(IssuedBy));
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

    public string PlaceOfBirth
    {
        get => _placeOfBirth;
        set
        {
            _placeOfBirth = value;
            OnPropertyChange(nameof(PlaceOfBirth));
        }
    }
}
