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
        private SecureDataStorage _secureDataStorage;
          
        protected override void OnStartup(StartupEventArgs e)
        {
            _secureDataStorage = new SecureDataStorage();
            LogInView logInView = new LogInView(new LogInWindowViewModel(_secureDataStorage), _secureDataStorage);
            logInView.WindowRequested += OnWindowRequested;  
            MainWindow = logInView;
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