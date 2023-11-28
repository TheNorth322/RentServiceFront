using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel.authentication;

public class PasswordResetViewModel : ViewModelBase
{
    private string _newPassword;
    private string _newPasswordVerified;
    private EnterTokenViewModel _enterTokenViewModel;
    private AuthenticationUseCase _authenticationUseCase; 
    public ICommand GoBackCommand { get; }
    public ICommand ResetPasswordCommand { get; }
    
    public PasswordResetViewModel(EnterTokenViewModel vm, AuthenticationUseCase authenticationUseCase)
    {
        GoBackCommand = new RelayCommand(GoBackExecute);
        _enterTokenViewModel = vm;
        _authenticationUseCase = authenticationUseCase;
    }
    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChange(nameof(NewPassword));
        }
    }

    public string NewPasswordVerified
    {
        get => _newPasswordVerified;
        set
        {
            _newPasswordVerified = value;
            OnPropertyChange(nameof(NewPasswordVerified));
        }
    }

    private void GoBackExecute(object parameter)
    {
        RaiseViewModelRequested(_enterTokenViewModel);
    }

    private async void ResetPasswordExecute(object parameter)
    {
        await _authenticationUseCase.ResetPassword(NewPassword, _enterTokenViewModel.PasswordResetToken);
    }
}