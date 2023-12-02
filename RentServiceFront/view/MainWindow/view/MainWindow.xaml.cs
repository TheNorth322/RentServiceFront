using System;
using System.Collections.Generic;
using System.Windows;
using MaterialDesignThemes.Wpf;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;
using RentServiceFront.viewmodel.mainWindow;
using RentServiceFront.viewmodel.mainWindow.EditViewModels;

namespace RentServiceFront.view.Authentication.view;

public partial class MainWindow : Window
{
    public event EventHandler<Window> WindowRequested;
    private SecureDataStorage _secureDataStorage;

    public MainWindow(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        List<SampleItem> sampleItems = (_secureDataStorage.Role == Role.ADMIN) ? InitializeTopBarMenuForAdmin() : InitializeTopBarMenu();
        MainViewModel vm = new MainViewModel(sampleItems);
        vm.OnExitCommand += OnExitCommand;
        this.DataContext = vm;
        InitializeComponent();
    }

    public MainWindow(MainViewModel vm, SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        List<SampleItem> sampleItems = InitializeTopBarMenu();
        vm.SampleItems = sampleItems;
        this.DataContext = vm;

        InitializeComponent();
    }

    private List<SampleItem> InitializeTopBarMenu()
    {
        List<SampleItem> sampleItems = new List<SampleItem>();

        sampleItems.Add(new SampleItem("Home", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)))));
        sampleItems.Add(new SampleItem("Account", PackIconKind.Account, PackIconKind.Account,
            new AccountViewModel(_secureDataStorage)));
        sampleItems.Add(new SampleItem("Cart", PackIconKind.Cart, PackIconKind.Cart,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)))));
        sampleItems.Add(new SampleItem("Settings", PackIconKind.Cog, PackIconKind.Cog,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)))));

        return sampleItems;
    }

    private List<SampleItem> InitializeEditSampleItems()
    {
        List<SampleItem> editSampelItems = new List<SampleItem>();
        editSampelItems.Add(new SampleItem("Banks", PackIconKind.Bank, PackIconKind.Bank, new BanksEditViewModel()));
        editSampelItems.Add(new SampleItem("Migration Services", PackIconKind.Passport, PackIconKind.Passport, new MigrationServicesMenuViewModel(_secureDataStorage)));
        editSampelItems.Add(new SampleItem("Room types", PackIconKind.StoreCog, PackIconKind.StoreCog, new RoomTypesEditViewModel()));
        editSampelItems.Add(new SampleItem("Buildings", PackIconKind.OfficeBuilding, PackIconKind.OfficeBuilding, new BuildingEditViewModel()));
        return editSampelItems;
    }
    private List<SampleItem> InitializeTopBarMenuForAdmin()
    {
        List<SampleItem> sampleItems = new List<SampleItem>();
        List<SampleItem> editSampleItems = InitializeEditSampleItems();
        
        sampleItems.Add(new SampleItem("Home", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)))));
        sampleItems.Add(new SampleItem("Account", PackIconKind.Account, PackIconKind.Account,
            new AccountViewModel(_secureDataStorage)));
        sampleItems.Add(new SampleItem("Edit", PackIconKind.DatabaseEdit, PackIconKind.DatabaseEdit,
                    new DatabaseEditViewModel(_secureDataStorage, editSampleItems)));
        sampleItems.Add(new SampleItem("Settings", PackIconKind.Cog, PackIconKind.Cog,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)))));

        return sampleItems;
    }

    private void OnExitCommand()
    {
        WindowRequested?.Invoke(this, new LogInView(new LogInWindowViewModel(_secureDataStorage), _secureDataStorage));
        Close();
    }
}