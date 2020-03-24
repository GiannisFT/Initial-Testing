using BisoftTestApp1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BisoftTestApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ShellNav();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
