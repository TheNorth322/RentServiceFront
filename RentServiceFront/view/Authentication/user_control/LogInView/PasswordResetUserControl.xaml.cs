using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel;

namespace RentServiceFront.view.Authentication.user_control;

public partial class PasswordResetUserControl : UserControl
{
    public PasswordResetUserControl()
    {
        InitializeComponent();
    }

    private void PasswordBox_OnNewPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
            ((dynamic)this.DataContext).NewPassword = ((PasswordBox)sender).Password;
    }

    private void PasswordBox_OnNewPasswordVerifiedChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
            ((dynamic)this.DataContext).NewPasswordVerified = ((PasswordBox)sender).Password;
    }
}