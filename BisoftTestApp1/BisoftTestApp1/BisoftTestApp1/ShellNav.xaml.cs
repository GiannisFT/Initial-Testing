using BisoftTestApp1.Views;
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
            routes.Add("presale_maint", typeof(CarPresalesMaintenancePage));
            routes.Add("maintenance_beg", typeof(MaintenanceBegForm));
            routes.Add("maintenance_lager", typeof(MaintenanceLagerForm));
            routes.Add("maintenance_standard", typeof(MaintenanceStandardForm));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        public ICommand ExecuteLogout => new Command(async () => await Navigation.PushAsync(new LoginPage()));
    }
}