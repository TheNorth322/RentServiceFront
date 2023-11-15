﻿using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RentServiceFront.view.Authentication.view;
using RentServiceFront.viewmodel;

namespace RentServiceFront
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new LogInView(new LogInViewModel());
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}