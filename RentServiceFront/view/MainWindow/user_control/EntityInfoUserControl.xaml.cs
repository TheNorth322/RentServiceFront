using System.Windows;
using System.Windows.Controls;
using RentServiceFront.domain.model.entity;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class EntityInfoUserControl : UserControl
{
    public EntityInfoUserControl()
    {
        InitializeComponent();
    }

    private async void EntityInfoUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as EntityViewModel)?.InitializeUserInfo()!;
    }
}