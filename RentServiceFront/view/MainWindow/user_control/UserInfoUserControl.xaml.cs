using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class UserInfoUserControl : UserControl
{
    public UserInfoUserControl()
    {
        InitializeComponent();
    }

    private async void UserInfoUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as UserViewModel)?.InitializeUserInfo()!;
    }
}