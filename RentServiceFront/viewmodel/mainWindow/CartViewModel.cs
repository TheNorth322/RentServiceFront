using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.enums;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.viewmodel.mainWindow;

public class CartViewModel : ViewModelBase
{
    private ObservableCollection<UserRoomViewModel> _userRoomViewModels;
    private string _additionalConditions;
    private PaymentFrequency _paymentFrequency;

    private AgreementUseCase _agreementUseCase;
    private UserUseCase _userUseCase;
    private SecureDataStorage _secureDataStorage;
    public ICommand CreateAgreementCommand { get; }

    public CartViewModel(AgreementUseCase agreementUseCase, SecureDataStorage secureDataStorage,
        UserUseCase userUseCase)
    {
        _paymentFrequency = PaymentFrequency.MONTHLY;
        _userRoomViewModels = new ObservableCollection<UserRoomViewModel>();
        _secureDataStorage = secureDataStorage;
        _userUseCase = userUseCase;
        CreateAgreementCommand = new RelayCommand<object>(CreateAgreementExecute);
        _agreementUseCase = agreementUseCase;
    }

    public ObservableCollection<UserRoomViewModel> UserRoomViewModels
    {
        get => _userRoomViewModels;
        set
        {
            _userRoomViewModels = value;
            OnPropertyChange(nameof(UserRoomViewModels));
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

    public PaymentFrequency PaymentFrequency
    {
        get => _paymentFrequency;
        set
        {
            _paymentFrequency = value;
            OnPropertyChange(nameof(PaymentFrequency));
        }
    }

    public async Task InitializeUserRooms()
    {
        try
        {
            _userRoomViewModels.Clear();
            List<UserRoom> userRooms = await _userUseCase.getUserRooms(_secureDataStorage.Username);
            foreach (UserRoom userRoom in userRooms)
            {
                UserRoomViewModel vm = new UserRoomViewModel(userRoom.RoomId, userRoom.StartOfRent, userRoom.EndOfRent,
                    new RoomUseCase(new RoomRequest(_secureDataStorage)));
                vm.InitializeRoom();
                vm.DeleteRoomEvent += OnDeleteRoomEvent;
                _userRoomViewModels.Add(vm);
            }
        }
        catch (Refit.ApiException ex)
        {
            DialogText = ex.Content;
            ShowDialogCommand.Execute(null );
        } 
    }

    private async void OnDeleteRoomEvent(object? param, UserRoomViewModel vm)
    {
        try
        {
            DialogText = await _userUseCase.deleteUserRoom(_secureDataStorage.Username, vm.RoomId);
            vm.DeleteRoomEvent -= OnDeleteRoomEvent;
            _userRoomViewModels.Remove(vm);
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
        }

        ShowDialogCommand.Execute(null);
    }

    private async void CreateAgreementExecute(object param)
    {
        try
        {
            DialogText = await _agreementUseCase.createAgreement(new CreateAgreementRequest(_secureDataStorage.Username,
                _paymentFrequency, _additionalConditions));
        }
        catch (Exception e)
        {
            DialogText = "Something went wrong";
        }

        ShowDialogCommand.Execute(null);
    }
}