using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class RoomTypesMenuUserControl : UserControl
{
    public RoomTypesMenuUserControl()
    {
        InitializeComponent();
    }

    private async void RoomTypesMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as RoomTypesMenuViewModel)?.InitializeRoomTypes()!;
    }
}