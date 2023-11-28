using System.Collections.Generic;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.view.Authentication.view;
using RentServiceFront.viewmodel;
using RentServiceFront.viewmodel.authentication;

namespace RentServiceFront
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LogInView logInView = new LogInView(new LogInViewModel(new SecureDataStorage()));
            MainWindow = logInView;
            MainWindow.Show();
            base.OnStartup(e);
            /*MainWindow mainWindow = new MainWindow(new SecureDataStorage());
            mainWindow.WindowRequested += OnWindowRequested;
            MainWindow = mainWindow; 
            MainWindow.Show();
            base.OnStartup(e);*/
        }

        private void OnWindowRequested(object? sender, Window window)
        {
            MainWindow = window;
            MainWindow.Show();
        }
    }
}