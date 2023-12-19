using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.MainWindow.user_control;

public partial class AgreementMenuUserControl : UserControl
{
    public AgreementMenuUserControl()
    {
        InitializeComponent();
    }

    private async void AgreementMenuUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as AgreementMenuViewModel)?.InitializeAgreements()!;
    }
}