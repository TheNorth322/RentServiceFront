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

namespace RentServiceFront
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new SecureDataStorage());
            mainWindow.WindowRequested += OnWindowRequested;
            MainWindow = mainWindow; 
            MainWindow.Show();
            base.OnStartup(e);
        }

        private void OnWindowRequested(object? sender, Window window)
        {
            MainWindow = window;
            MainWindow.Show();
        }
    }
}