﻿using System;
using Barometer_App.Models;
using Prism;
using Prism.Ioc;
using Barometer_App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Barometer_App
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            User user = User.GetCustomer();

            try
            {
                user.UserToken = Application.Current.Properties["Token"] as string;
                user.UserName = Application.Current.Properties["Username"] as string;
            }
            catch(Exception e) { }

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<Signup>();
            containerRegistry.RegisterForNavigation<About>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<DrinkList>();
            containerRegistry.RegisterForNavigation<BarList>();
            containerRegistry.RegisterForNavigation<BarEdit>();
            containerRegistry.RegisterForNavigation<DetailedBar>();
            containerRegistry.RegisterForNavigation<BarRating>();
            containerRegistry.RegisterForNavigation<BarSignup>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<Events>();
            containerRegistry.RegisterForNavigation<DetailedBarEdit>();
            containerRegistry.RegisterForNavigation<BarEditsMenu>();
        }
    }
}
