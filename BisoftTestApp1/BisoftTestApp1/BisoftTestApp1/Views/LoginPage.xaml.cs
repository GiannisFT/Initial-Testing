using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace BisoftTestApp1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            txt_ucid.Text = Preferences.Get("UcidValue", null);
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
