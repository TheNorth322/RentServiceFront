using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class BanksMenuUserControl : UserControl
{
    public BanksMenuUserControl()
    {
        InitializeComponent();
    }

    private async void BanksMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as BanksMenuViewModel)?.InitializeBanks()!;
    }
}