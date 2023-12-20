using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using RentServiceFront.domain.authentication.use_case;
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
    private ObservableCollection<AgreementRoomViewModel> _rooms;
    private AgreementUseCase _agreementUseCase;
    public AgreementViewModel(long id, long registrationNumber, PaymentFrequency paymentFrequency, string additionalConditions, 
        int fine, DateTime startsFrom, DateTime lastsTo, ObservableCollection<AgreementRoomViewModel> rooms, AgreementUseCase agreementUseCase)
    {
        GeneratePDFCommand = new RelayCommand<object>(GeneratePDFExecute);
        _id = id;
        _registrationNumber = registrationNumber;
        _paymentFrequency = paymentFrequency;
        _additionalConditions = additionalConditions;
        _fine = fine;
        _startsFrom = startsFrom;
        _lastsTo = lastsTo;
        _rooms = rooms;
        _agreementUseCase = agreementUseCase;
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

    public ObservableCollection<AgreementRoomViewModel> Rooms
    {
        get => _rooms;
        set
        {
            _rooms = value;
            OnPropertyChange(nameof(Rooms));
        }
    }
    public ICommand GeneratePDFCommand { get; }
    
    public async void GeneratePDFExecute(object param)
    {
        try
        {
            if (_id == 0) return;

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Сохранить PDF файл"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var filePath = saveFileDialog.FileName;
                DialogText = await _agreementUseCase.generateAgreementPdf(_id, filePath);
            }
            
            ShowDialogCommand.Execute(null);
        }
        catch (Exception e)
        {
            DialogText = "Не удалось сформировать документ.";
            ShowDialogCommand.Execute(null); 
        }
    }
}
