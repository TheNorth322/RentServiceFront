using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.view.Authentication.user_control;

public partial class EntityRegistrationUserControl : UserControl
{
    public EntityRegistrationUserControl()
    {
        InitializeComponent();
    }

    private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        ((DataContext as EntityRegistrationViewModel)!).LastKeyEventArgs = e;
    }

    private async void EntityRegistrationUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as EntityRegistrationViewModel)?.InitializeBanks()!;
    }
}