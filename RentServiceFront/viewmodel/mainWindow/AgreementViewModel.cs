using System;
using System.Collections.Generic;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class AgreementViewModel : ViewModelBase
{
    private long _id;
    private long _registrationNumber;
    private PaymentFrequency _paymentFrequency;
    private string _additionalConditions;
    private int _fine;
    private DateTime _startsFrom;
    private DateTime _lastsTo;
    private List<AgreementRoomViewModel> _rooms;

    public AgreementViewModel(long registrationNumber, PaymentFrequency paymentFrequency, string additionalConditions, 
        int fine, DateTime startsFrom, DateTime lastsTo, List<AgreementRoomViewModel> rooms)
    {
        _registrationNumber = registrationNumber;
        _paymentFrequency = paymentFrequency;
        _additionalConditions = additionalConditions;
        _fine = fine;
        _startsFrom = startsFrom;
        _lastsTo = lastsTo;
        _rooms = rooms;
    }
    
    public long RegistrationNumber
    {
        get => _registrationNumber;
        set
        {
            _registrationNumber = value;
            OnPropertyChange(nameof(RegistrationNumber));
        }
    }

    public PaymentFrequency PaymentFrequency
    {
        get => _paymentFrequency;
        set
        {
            _paymentFrequency = value;
            OnPropertyChange(nameof(PaymentFrequency));
        }
    }

    public string AdditionalConditions
    {
        get => _additionalConditions;
        set
        {
            _additionalConditions = value;
            OnPropertyChange(nameof(AdditionalConditions));
        }
    }

    public int Fine
    {
        get => _fine;
        set
        {
            _fine = value;
            OnPropertyChange(nameof(Fine));
        }
    }

    public DateTime StartsFrom
    {
        get => _startsFrom;
        set
        {
            _startsFrom = value;
            OnPropertyChange(nameof(StartsFrom));
        }
    }

    public DateTime LastsTo
    {
        get => _lastsTo;
        set
        {
            _lastsTo = value;
            OnPropertyChange(nameof(LastsTo));
        }
    }

    public List<AgreementRoomViewModel> Rooms
    {
        get => _rooms;
        set
        {
            _rooms = value;
            OnPropertyChange(nameof(Rooms));
        }
    }
}
