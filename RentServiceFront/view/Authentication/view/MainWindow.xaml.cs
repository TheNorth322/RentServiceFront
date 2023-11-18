using System.Collections.Generic;
using System.Windows;
using MaterialDesignThemes.Wpf;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.viewmodel;

namespace RentServiceFront.view.Authentication.view;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        List<SampleItem> sampleItems = InitializeTopBarMenu();
        MainViewModel vm = new MainViewModel(sampleItems);
        this.DataContext = vm;
        InitializeComponent();
    }

    public MainWindow(MainViewModel vm)
    {
        List<SampleItem> sampleItems = InitializeTopBarMenu();
        vm.SampleItems = sampleItems;
        this.DataContext = vm;

        InitializeComponent();
    }

    private List<SampleItem> InitializeTopBarMenu()
    {
        List<SampleItem> sampleItems = new List<SampleItem>();

        sampleItems.Add(new SampleItem("Home", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));
        sampleItems.Add(new SampleItem("Account", PackIconKind.Account, PackIconKind.Account,
            new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));
        sampleItems.Add(new SampleItem("Cart", PackIconKind.Cart, PackIconKind.Cart,
            new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));
        sampleItems.Add(new SampleItem("Settings", PackIconKind.Cog, PackIconKind.Cog,
            new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));
        sampleItems.Add(new SampleItem("Exit", PackIconKind.ExitToApp, PackIconKind.ExitToApp,
            new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));

        return sampleItems;
    }
}