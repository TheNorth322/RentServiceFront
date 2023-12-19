using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class PassportMenuUserControl : UserControl
{
    public PassportMenuUserControl()
    {
        InitializeComponent();
    }

    private async void PassportMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as PassportMenuViewModel)?.InitializePassports()!;
    }
}