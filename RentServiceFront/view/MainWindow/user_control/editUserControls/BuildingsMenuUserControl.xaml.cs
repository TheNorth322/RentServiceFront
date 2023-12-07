using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class BuildingsMenuUserControl : UserControl
{
    public BuildingsMenuUserControl()
    {
        InitializeComponent();
    }

    private async void BuildingsMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as BuildingsMenuViewModel)?.InitializeBuildings()!;
    }
}