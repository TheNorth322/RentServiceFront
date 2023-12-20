using System;
using System.Windows.Input;
using RentServiceFront.domain.authentication.use_case;

namespace RentServiceFront.viewmodel.authentication;

public class EnterEmailViewModel : ViewModelBase
{
   private string _email;
   private AuthenticationUseCase _authenticationUseCase;
   private ViewModelBase _previousVm;
   private string _password;
   public ICommand GoBackCommand { get; }
   public ICommand ResetPasswordCommand { get; }
   
   public EnterEmailViewModel(ViewModelBase previousVm, AuthenticationUseCase _authenticationUseCase)
   {
      _previousVm = previousVm;
      GoBackCommand = new RelayCommand<object>(GoBackExecute);
      ResetPasswordCommand = new RelayCommand<object>(ResetPasswordExecute, ResetPasswordCanExecute);
      this._authenticationUseCase = _authenticationUseCase;
   }

   private bool ResetPasswordCanExecute(object arg)
   {
      return !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password);
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

   public string Password
   {
      get => _password;
      set
      {
         _password = value;
         OnPropertyChange(nameof(Password));
      }
   }
   private void GoBackExecute(object parameter)
   {
      RaiseViewModelRequested(_previousVm);
   }
   
   private async void ResetPasswordExecute(object parameter)
   {
      try
      {
         await _authenticationUseCase.ForgotPassword(Email, _password);
         RaiseViewModelRequested(_previousVm);
      }
      catch (Exception e)
      {
         DialogText = "Something went wrong";
         ShowDialogCommand.Execute(null);
      }
   }
}