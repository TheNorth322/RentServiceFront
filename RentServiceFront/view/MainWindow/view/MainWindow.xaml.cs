using System;
using System.Collections.Generic;
using System.Windows;
using MaterialDesignThemes.Wpf;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;
using RentServiceFront.viewmodel.mainWindow;

namespace RentServiceFront.view.Authentication.view;

public partial class MainWindow : Window
{
    public event EventHandler<Window> WindowRequested;

    public MainWindow(SecureDataStorage secureDataStorage)
    {
        List<SampleItem> sampleItems = InitializeTopBarMenu(secureDataStorage);
        MainViewModel vm = new MainViewModel(sampleItems);
        vm.OnExitCommand += OnExitCommand;
        this.DataContext = vm;
        InitializeComponent();
    }

    public MainWindow(MainViewModel vm, SecureDataStorage secureDataStorage)
    {
        List<SampleItem> sampleItems = InitializeTopBarMenu(secureDataStorage);
        vm.SampleItems = sampleItems;
        this.DataContext = vm;

        InitializeComponent();
    }

    private List<SampleItem> InitializeTopBarMenu(SecureDataStorage secureDataStorage)
    {
        List<SampleItem> sampleItems = new List<SampleItem>();

        sampleItems.Add(new SampleItem("Home", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(secureDataStorage)))));
        sampleItems.Add(new SampleItem("Account", PackIconKind.Account, PackIconKind.Account,
            new AccountViewModel()));
        sampleItems.Add(new SampleItem("Cart", PackIconKind.Cart, PackIconKind.Cart,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(secureDataStorage)))));
        sampleItems.Add(new SampleItem("Settings", PackIconKind.Cog, PackIconKind.Cog,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(secureDataStorage)))));

        return sampleItems;
    }

    private void OnExitCommand()
    {
        WindowRequested?.Invoke(this, new LogInView(new LogInViewModel(new SecureDataStorage())));
        Close();
    }
}