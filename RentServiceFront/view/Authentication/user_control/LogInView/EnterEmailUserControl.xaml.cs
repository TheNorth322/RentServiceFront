using System.Windows;
using System.Windows.Controls;

namespace RentServiceFront.view.Authentication.user_control;

public partial class EnterEmailUserControl : UserControl
{
    public EnterEmailUserControl()
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