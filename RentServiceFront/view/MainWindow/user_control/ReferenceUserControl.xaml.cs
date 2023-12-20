using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class ReferenceUserControl : UserControl
{
    public ReferenceUserControl()
    {
        InitializeComponent();
    }

    private async void ReferenceUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (this.DataContext as ReferenceViewModel)?.InitializeBuildings()!;
    }
}