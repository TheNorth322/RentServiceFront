using System.Collections.Generic;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.client;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.view.Authentication.view;
using RentServiceFront.viewmodel;

namespace RentServiceFront
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow(new MainViewModel(new RoomListViewModel(new RoomUseCase(new RoomRequest("asd")))));
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}