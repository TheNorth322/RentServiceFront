using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class RoomEditUserControl : UserControl
{
    public RoomEditUserControl()
    {
        InitializeComponent();
    }

    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as RoomEditViewModel)!).LastKeyEventArgs = e;
    }

    private void RoomEditUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        ((DataContext as RoomEditViewModel)!).InitializeTypes();
    }
}