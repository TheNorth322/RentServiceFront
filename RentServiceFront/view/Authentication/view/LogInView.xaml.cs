using System.Windows;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.view.Authentication.view;

public partial class LogInView : Window
{
    public LogInView()
    {
        InitializeComponent();
    }

    public LogInView(ViewModelBase vm)
    {
        this.DataContext = new LogInWindowViewModel(vm);
        InitializeComponent();
    }
}