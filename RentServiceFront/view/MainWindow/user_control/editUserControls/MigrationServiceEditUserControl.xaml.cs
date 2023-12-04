using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class MigrationServiceEditUserControl : UserControl
{
    public MigrationServiceEditUserControl()
    {
        InitializeComponent();
    }


    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as MigrationServiceEditViewModel)!).LastKeyEventArgs = e;
    }
}