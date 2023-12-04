using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel.authentication;

public class EnterTokenViewModel : ViewModelBase
{
    private string _passwordResetToken;
    private EnterEmailViewModel _enterEmailViewModel;
    private AuthenticationUseCase _authenticationUseCase;
    
    public ICommand VerifyPasswordResetTokenCommand { get; }
    
    public EnterTokenViewModel(EnterEmailViewModel vm, AuthenticationUseCase authenticationUseCase)
    {
        _enterEmailViewModel = vm;
        _authenticationUseCase = authenticationUseCase; 
        VerifyPasswordResetTokenCommand = new RelayCommand<object>(VerifyPasswordResetTokenExecute);
    }
    public string PasswordResetToken
    {
        get => _passwordResetToken;
        set
        {
            _passwordResetToken = value;
            OnPropertyChange(nameof(PasswordResetToken));
        }
    }

    private async void VerifyPasswordResetTokenExecute(object parameter)
    {
        await _authenticationUseCase.ValidatePasswordToken(PasswordResetToken);
        //TODO
        PasswordResetViewModel passwordResetViewModel = new PasswordResetViewModel(this, _authenticationUseCase);
        RaiseViewModelRequested(passwordResetViewModel); 
    } 
}