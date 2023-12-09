using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class RoomListUserControl : UserControl
{
    public RoomListUserControl()
    {
        InitializeComponent();
    }

    private async void RoomListUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as RoomListViewModel)?.InitializeRoomTypes()!; 
        await (DataContext as RoomListViewModel)?.InitializeRooms()!; 
    }
}