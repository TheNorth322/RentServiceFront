using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel;

public class EnterEmailViewModel : ViewModelBase
{
   private string _email;
   private AuthenticationUseCase _authenticationUseCase;
   public ICommand GoBackCommand { get; }
   public ICommand ResetPasswordCommand { get; }
   
   public EnterEmailViewModel(AuthenticationUseCase _authenticationUseCase)
   {
      GoBackCommand = new RelayCommand(GoBackExecute);
      ResetPasswordCommand = new RelayCommand(ResetPasswordExecute);
      this._authenticationUseCase = _authenticationUseCase;
   } 
   
   public string Email
   {
      get => _email;
      set
      {
         _email = value;
         OnPropertyChange(nameof(Email));
      }
   }

   private void GoBackExecute(object parameter)
   {
      LogInViewModel logInViewModel = new LogInViewModel();
      RaiseViewModelRequested(logInViewModel);
   }

   private async void ResetPasswordExecute(object parameter)
   {
      await _authenticationUseCase.ForgotPassword(Email);               
      EnterTokenViewModel enterTokenViewModel = new EnterTokenViewModel(this, _authenticationUseCase);
      RaiseViewModelRequested(enterTokenViewModel); 
   }
}