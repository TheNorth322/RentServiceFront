using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class CartUserControl : UserControl
{
    public CartUserControl()
    {
        InitializeComponent();
    }

    private async void CartUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as CartViewModel)?.InitializeUserRooms()!;
    }
}