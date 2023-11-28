using System;
using System.Windows;
using RentServiceFront.data.secure;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront.view.Authentication.view;

public partial class LogInView : Window
{
    private SecureDataStorage _secureDataStorage;
    public event EventHandler<Window> WindowRequested;
    
    public LogInView()
    {
        InitializeComponent();
    }

    public LogInView(LogInWindowViewModel vm, SecureDataStorage storage)
    {
        _secureDataStorage = storage;
        LogInWindowViewModel windowVm = vm;
        windowVm.OpenMainWindowRequest += OpenMainWindowExecute;
        this.DataContext = windowVm;
        InitializeComponent();
    }

    private void OpenMainWindowExecute()
    {
        WindowRequested?.Invoke(this, new MainWindow(_secureDataStorage));
        Close();
    }
}