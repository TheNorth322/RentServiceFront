using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.view.Authentication.user_control;

public partial class IndividualUserRegistrationUserControl : UserControl
{
    public IndividualUserRegistrationUserControl()
    {
        InitializeComponent();
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        {
            ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
        }
    }

    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as IndividualUserRegistrationViewModel)!).LastKeyEventArgs = e;
    }

    private async void IndividualUserRegistrationUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await ((DataContext as IndividualUserRegistrationViewModel)!).InitMigrationServices();
    }
}