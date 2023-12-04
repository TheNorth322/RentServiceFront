using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class MigrationServicesMenuUserControl : UserControl
{
    public MigrationServicesMenuUserControl()
    {
        InitializeComponent();
    }

    private async void MigrationServicesMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as MigrationServicesMenuViewModel)?.InitializeMigrationServices()!;
    }
}