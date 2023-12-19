using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.mainWindow;

public class AgreementMenuViewModel : ViewModelBase
{
    private ObservableCollection<AgreementViewModel> _agreements;
    private AgreementViewModel _selectedAgreement;
    private UserUseCase _userUseCase;
    private SecureDataStorage _secureDataStorage;

    public AgreementMenuViewModel(UserUseCase userUseCase, SecureDataStorage secureDataStorage)
    {
        _agreements = new ObservableCollection<AgreementViewModel>();
        _userUseCase = userUseCase;
        _secureDataStorage = secureDataStorage;
    }

    public async Task InitializeAgreements()
    {
        List<Agreement> agreements = await _userUseCase.getUserAgreements(_secureDataStorage.Username);
        foreach (Agreement agreement in agreements)
        {
            _agreements.Add(new AgreementViewModel(agreement.Id, agreement.RegistrationNumber,
                agreement.PaymentFrequency,
                agreement.AdditionalConditions, agreement.Fine, agreement.StartsFrom, agreement.LastsTo,
                GetAgreementRooms(agreement)));
        }
    }

    private ObservableCollection<AgreementRoomViewModel> GetAgreementRooms(Agreement agreement)
    {
        ObservableCollection<AgreementRoomViewModel>
            agreementRooms = new ObservableCollection<AgreementRoomViewModel>();

        foreach (AgreementRoom agreementRoom in agreement.Rooms)
        {
            agreementRooms.Add(new AgreementRoomViewModel(agreementRoom.Id, agreementRoom.Room.Building.Address.Value,
                agreementRoom.PurposeOfRent, agreementRoom.StartOfRent, agreementRoom.EndOfRent, agreementRoom.RentAmount));
        }

        return agreementRooms;
    }

    public ObservableCollection<AgreementViewModel> Agreements
    {
        get => _agreements;
        set
        {
            _agreements = value;
            OnPropertyChange(nameof(Agreements));
        }
    }

    public AgreementViewModel SelectedAgreement
    {
        get => _selectedAgreement;
        set
        {
            _selectedAgreement = value;
            OnPropertyChange(nameof(SelectedAgreement));
        }
    }
}