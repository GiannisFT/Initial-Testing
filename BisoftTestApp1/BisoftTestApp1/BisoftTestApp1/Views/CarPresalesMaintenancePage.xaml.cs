using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using BisoftTestApp1.ViewModels.CarPresalesMaintenanceVM;
using BisoftTestApp1.Views;

namespace BisoftTestApp1.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarPresalesMaintenancePage : ContentPage
    {
        public CarPresalesMaintenancePage()
        {
            InitializeComponent();
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            off_picker.Focus();
        }

        private void off_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_picker.Text = off_picker.Items[off_picker.SelectedIndex];
        }

    }
}