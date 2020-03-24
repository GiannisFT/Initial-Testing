﻿using BisoftTestApp1.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace BisoftTestApp1
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellNav : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public ShellNav()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("login", typeof(LoginPage));
            routes.Add("presale_maint", typeof(CarPresalesMaintenance));
            routes.Add("control", typeof(ControlPage));
            routes.Add("maintenance", typeof(Maintenance));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("login"));
    }
}