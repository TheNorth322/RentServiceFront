using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class AccountUserControl : UserControl
{
    public AccountUserControl()
    {
        InitializeComponent();
    }

    private void AccountUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        (this.DataContext as AccountViewModel)?.InitializeInfo();
    }
}