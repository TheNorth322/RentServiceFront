using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel.authentication;

public class EnterEmailViewModel : ViewModelBase
{
   private string _email;
   private AuthenticationUseCase _authenticationUseCase;
   private ViewModelBase _previousVm;
   public ICommand GoBackCommand { get; }
   public ICommand ResetPasswordCommand { get; }
   
   public EnterEmailViewModel(ViewModelBase previousVm, AuthenticationUseCase _authenticationUseCase)
   {
      _previousVm = previousVm;
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
      RaiseViewModelRequested(_previousVm);
   }

   private async void ResetPasswordExecute(object parameter)
   {
      await _authenticationUseCase.ForgotPassword(Email);               
      EnterTokenViewModel enterTokenViewModel = new EnterTokenViewModel(this, _authenticationUseCase);
      RaiseViewModelRequested(enterTokenViewModel); 
   }
}