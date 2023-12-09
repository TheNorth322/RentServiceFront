using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class RoomUserControl : UserControl
{
    public RoomUserControl()
    {
        InitializeComponent();
    }

    private async void RoomUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as RoomViewModel)?.InitializeRoom()!;
    }
}