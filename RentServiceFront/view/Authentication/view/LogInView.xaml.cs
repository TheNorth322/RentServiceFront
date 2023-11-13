using System.Windows;
using RentServiceFront.viewmodel;

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