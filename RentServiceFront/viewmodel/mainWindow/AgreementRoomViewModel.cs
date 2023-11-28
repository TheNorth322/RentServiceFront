using System;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class AgreementRoomViewModel : ViewModelBase
{
    private long _id;
    private string _address;  
    private string _purposeOfRent;
    private DateTime _startOfRent;
    private DateTime _endOfRent;
    private int _rentAmount;
    
    public AgreementRoomViewModel(long id, string address, string purposeOfRent, DateTime startOfRent, DateTime endOfRent, int rentAmount)
    {
        _id = id;
        _address = address;
        _purposeOfRent = purposeOfRent;
        _startOfRent = startOfRent;
        _endOfRent = endOfRent;
        _rentAmount = rentAmount;
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
    public string PurposeOfRent
    {
        get => _purposeOfRent;
        set
        {
            _purposeOfRent = value;
            OnPropertyChange(nameof(PurposeOfRent));
        }
    }

    public DateTime StartOfRent
    {
        get => _startOfRent;
        set
        {
            _startOfRent = value;
            OnPropertyChange(nameof(StartOfRent));
        }
    }

    public DateTime EndOfRent
    {
        get => _endOfRent;
        set
        {
            _endOfRent = value;
            OnPropertyChange(nameof(EndOfRent));
        }
    }

    public int RentAmount
    {
        get => _rentAmount;
        set
        {
            _rentAmount = value;
            OnPropertyChange(nameof(RentAmount));
        }
    }
    
}