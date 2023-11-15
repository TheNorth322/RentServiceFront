using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel;

namespace RentServiceFront.view.Authentication.user_control;

public partial class RegistrationUserControl : UserControl
{
    public RegistrationUserControl()
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
}