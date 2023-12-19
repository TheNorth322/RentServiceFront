using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class PassportUserControl : UserControl
{
    public PassportUserControl()
    {
        InitializeComponent();
    }

    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as PassportViewModel)!).LastKeyEventArgs = e;
    }

    private async void PassportUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as PassportViewModel).InitializePassportInformation();
    }
}