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
        List<SampleItem> sampleItems = (_secureDataStorage.Role == Role.ADMIN)
            ? InitializeTopBarMenuForAdmin()
            : InitializeTopBarMenu();
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

        sampleItems.Add(new SampleItem("Главная", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage)));
        sampleItems.Add(new SampleItem("Аккаунт", PackIconKind.Account, PackIconKind.Account,
            new AccountViewModel(_secureDataStorage, InitializeAccountSampleItems())));
        sampleItems.Add(new SampleItem("Корзина", PackIconKind.Cart, PackIconKind.Cart,
            new CartViewModel(new AgreementUseCase(new AgreementRequest(_secureDataStorage)), _secureDataStorage,
                new UserUseCase(new UserRequest(_secureDataStorage)))));
        sampleItems.Add(new SampleItem("Справка", PackIconKind.BookOpenBlankVariant, PackIconKind.BookOpenBlankVariant,
            new ReferenceViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage, new BuildingUseCase(new BuildingRequest(_secureDataStorage)))));

        return sampleItems;
    }

    private List<SampleItem> InitializeEditSampleItems()
    {
        List<SampleItem> editSampelItems = new List<SampleItem>();
        editSampelItems.Add(new SampleItem("Банки", PackIconKind.Bank, PackIconKind.Bank,
            new BanksMenuViewModel(_secureDataStorage)));
        editSampelItems.Add(new SampleItem("Миграционные отделы", PackIconKind.Passport, PackIconKind.Passport,
            new MigrationServicesMenuViewModel(_secureDataStorage)));
        editSampelItems.Add(new SampleItem("Типы комнат", PackIconKind.StoreCog, PackIconKind.StoreCog,
            new RoomTypesMenuViewModel(_secureDataStorage)));
        editSampelItems.Add(new SampleItem("Здания", PackIconKind.OfficeBuilding, PackIconKind.OfficeBuilding,
            new BuildingsMenuViewModel(_secureDataStorage)));
        editSampelItems.Add(new SampleItem("Помещения", PackIconKind.Warehouse, PackIconKind.Warehouse,
            new RoomsMenuViewModel(_secureDataStorage)));
        return editSampelItems;
    }

    private List<SampleItem> InitializeAccountSampleItems()
    {
        List<SampleItem> accountSampelItems = new List<SampleItem>();
        if (_secureDataStorage.Role == Role.ENTITY)
        {
            accountSampelItems.Add(new SampleItem("Информация", PackIconKind.Info, PackIconKind.Info,
                new EntityViewModel(new UserUseCase(new UserRequest(_secureDataStorage)), _secureDataStorage)));
            accountSampelItems.Add(new SampleItem("Договоры", PackIconKind.Note, PackIconKind.Note,
                new AgreementMenuViewModel(new UserUseCase(new UserRequest(_secureDataStorage)),
                    new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage)));
        }
        else if (_secureDataStorage.Role == Role.INDIVIDUAL)
        {
            accountSampelItems.Add(new SampleItem("Информация", PackIconKind.Info, PackIconKind.Info,
                new UserViewModel(new UserUseCase(new UserRequest(_secureDataStorage)), _secureDataStorage)));
            accountSampelItems.Add(new SampleItem("Паспорта", PackIconKind.Passport, PackIconKind.Passport,
                new PassportMenuViewModel(new UserUseCase(new UserRequest(_secureDataStorage)),
                    new SearchUseCase(new SearchRequest(_secureDataStorage)),
                    new PassportUseCase(new PassportRequest(_secureDataStorage)), _secureDataStorage)));
            accountSampelItems.Add(new SampleItem("Договоры", PackIconKind.Note, PackIconKind.Note,
                new AgreementMenuViewModel(new UserUseCase(new UserRequest(_secureDataStorage)),
                    new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage)));
        }
        else if (_secureDataStorage.Role == Role.ADMIN)
        {
            accountSampelItems.Add(new SampleItem("Информация", PackIconKind.Info, PackIconKind.Info,
                new UserViewModel(new UserUseCase(new UserRequest(_secureDataStorage)), _secureDataStorage)));
        }

        return accountSampelItems;
    }

    private List<SampleItem> InitializeTopBarMenuForAdmin()
    {
        List<SampleItem> sampleItems = new List<SampleItem>();
        List<SampleItem> editSampleItems = InitializeEditSampleItems();

        sampleItems.Add(new SampleItem("Главная", PackIconKind.Home, PackIconKind.Home,
            new RoomListViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage)));
        sampleItems.Add(new SampleItem("Аккаунт", PackIconKind.Account, PackIconKind.Account,
            new AccountViewModel(_secureDataStorage, InitializeAccountSampleItems())));
        sampleItems.Add(new SampleItem("Редактирование", PackIconKind.DatabaseEdit, PackIconKind.DatabaseEdit,
            new DatabaseEditViewModel(_secureDataStorage, editSampleItems)));
        sampleItems.Add(new SampleItem("Справка", PackIconKind.BookOpenBlankVariant, PackIconKind.BookOpenBlankVariant,
            new ReferenceViewModel(new RoomUseCase(new RoomRequest(_secureDataStorage)), _secureDataStorage, new BuildingUseCase(new BuildingRequest(_secureDataStorage)))));

        return sampleItems;
    }

    private void OnExitCommand()
    {
        WindowRequested?.Invoke(this, new LogInView(new LogInWindowViewModel(_secureDataStorage), _secureDataStorage));
        Close();
    }
}