using System;
using RentServiceFront.domain.enums;

namespace RentServiceFront.viewmodel;

public class PassportViewModel : ViewModelBase
{
    private string _fullName;
    private DateTime _dateOfBirth;
    private DateTime _dateOfIssue;  
    private string _issuedBy;
    private string _numberSeries;
    private Gender _gender;
    private string _placeOfBirth;
    
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string IssuedBy { get; set; } 
    public string NumberSeries { get; set; }
    public Gender Gender { get; set; }
    public string PlaceOfBirth { get; set; }

}