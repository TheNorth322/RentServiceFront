using System.Windows;
using System.Windows.Controls;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class BankEditUserControl : UserControl
{
    public BankEditUserControl()
    {
        InitializeComponent();
    }

    private void BankEditUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        (DataContext as BankEditViewModel)?.InitializeEntities();
    }
}