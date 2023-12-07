using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.MainWindow.user_control.editUserControls;

public partial class BuildingEditUserControl : UserControl
{
    public BuildingEditUserControl()
    {
        InitializeComponent();
    }

    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as BuildingEditViewModel)!).LastKeyEventArgs = e;
    }
}