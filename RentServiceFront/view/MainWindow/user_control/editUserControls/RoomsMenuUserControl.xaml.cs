using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class RoomsMenuUserControl : UserControl
{
    public RoomsMenuUserControl()
    {
        InitializeComponent();
    }

    private async void RoomsMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as RoomsMenuViewModel)?.InitializeRooms()!;
    }
}