using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using BisoftTestApp1.ViewModels.BaseClass;
using ServiceReference1;
using Xamarin.Forms;

namespace BisoftTestApp1.ViewModels.Maintenance
{
    class MaintenanceLagerVM : ViewModelBase
    {
        #region ServiceReference
        public Service1Client DbContext { get; set; }
        #endregion

        #region Commands
        public ICommand InsertLagerCommand { get; set; }
        public ICommand CancelCommand => new Command(async () => await ShellNav.Current.Navigation.PopAsync());
        #endregion


        #region Constractors
        public MaintenanceLagerVM()
        {
            InsertLagerCommand = new HelpClasses.DelegateCommand(TryInsertMaintenanceLagerData, CanTryInsertMaintenanceLagerData);
        }
        #endregion


        #region Properties

        #region Battery
        private string txt_battery;
        public string Text_battery
        {
            get { return txt_battery; }
            set
            {
                if (txt_battery == value)
                    return;
                txt_battery = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_battery"));
            }
        }

        private bool box_batteryOK;
        private bool box_batteryNotOK;
        public bool IsBatteryOKChecked
        {
            get { return box_batteryOK; }
            set
            {
                box_batteryOK = value;
                if (box_batteryOK)
                    IsBatteryNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBatteryOKChecked"));
            }
        }
        public bool IsBatteryNotOKChecked
        {
            get { return box_batteryNotOK; }
            set
            {
                box_batteryNotOK = value;
                if (box_batteryNotOK)
                    IsBatteryOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBatteryNotOKChecked"));
            }
        }
        public bool BatteryCheck
        {
            get { return IsBatteryOKChecked; }
            set
            {
                if (IsBatteryOKChecked == false)
                    IsBatteryNotOKChecked = value;
            }
        }
        private Color _batteryCheckedColor;
        public Color BatteryCheckedColor
        {
            get { return _batteryCheckedColor; }
            set
            {
                if (_batteryCheckedColor == null)
                    return;
                _batteryCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BatteryCheckedColor"));
            }
        }
        #endregion

        #region Tyres
        private string txt_tyres;
        public string Text_tyres
        {
            get { return txt_tyres; }
            set
            {
                if (txt_tyres == value)
                    return;
                txt_tyres = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_tyres"));
            }
        }

        private bool box_tyresOK;
        private bool box_tyresNotOK;
        public bool IsTyresOKChecked
        {
            get { return box_tyresOK; }
            set
            {
                box_tyresOK = value;
                if (box_tyresOK)
                    IsTyresNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsTyresOKChecked"));
            }
        }
        public bool IsTyresNotOKChecked
        {
            get { return box_tyresNotOK; }
            set
            {
                box_tyresNotOK = value;
                if (box_tyresNotOK)
                    IsTyresOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsTyresNotOKChecked"));
            }
        }
        public bool TyresCheck
        {
            get { return IsTyresOKChecked; }
            set
            {
                if (IsTyresOKChecked == false)
                    IsTyresNotOKChecked = value;
            }
        }
        private Color _tyresCheckedColor;
        public Color TyresCheckedColor
        {
            get { return _tyresCheckedColor; }
            set
            {
                if (_tyresCheckedColor == null)
                    return;
                _tyresCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TyresCheckedColor"));
            }
        }
        #endregion

        #region Brakes
        private string txt_brakediscs;
        public string Text_brakediscs
        {
            get { return txt_brakediscs; }
            set
            {
                if (txt_brakediscs == value)
                    return;
                txt_brakediscs = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_brakediscs"));
            }
        }

        private bool box_brakediscsOK;
        private bool box_brakediscsNotOK;
        public bool IsBrakeDiscsOKChecked
        {
            get { return box_brakediscsOK; }
            set
            {
                box_brakediscsOK = value;
                if (box_brakediscsOK)
                    IsBrakeDiscsNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBrakeDiscsOKChecked"));
            }
        }
        public bool IsBrakeDiscsNotOKChecked
        {
            get { return box_brakediscsNotOK; }
            set
            {
                box_brakediscsNotOK = value;
                if (box_brakediscsNotOK)
                    IsBrakeDiscsOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBrakeDiscsNotOKChecked"));
            }
        }
        public bool BrakeDiscsCheck
        {
            get { return IsBrakeDiscsOKChecked; }
            set
            {
                if (IsBrakeDiscsOKChecked == false)
                    IsBrakeDiscsNotOKChecked = value;
            }
        }
        private Color _brakediscsCheckedColor;
        public Color BrakeDiscsCheckedColor
        {
            get { return _brakediscsCheckedColor; }
            set
            {
                if (_brakediscsCheckedColor == null)
                    return;
                _brakediscsCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BrakeDiscsCheckedColor"));
            }
        }
        #endregion

        #endregion

        #region Methods

        public void TryInsertMaintenanceLagerData(object param)
        {
            if (CheckBatteryValues() && CheckTyresValues() && CheckBrakeDiscsValues())
            {

            }
        }
        public bool CanTryInsertMaintenanceLagerData(object param)
        {
            return true;
        }
        private bool CheckBatteryValues()
        {
            bool isValid = true;

            if (IsBatteryOKChecked == false && IsBatteryNotOKChecked == false)
            {
                isValid = false;
                BatteryCheckedColor = Color.Red;
            }
            else if (IsBatteryNotOKChecked == true && string.IsNullOrWhiteSpace(Text_battery))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                BatteryCheckedColor = Color.Red;
            }
            else
                BatteryCheckedColor = Color.Default;
            return isValid;
        }

        private bool CheckTyresValues()
        {
            bool isValid = true;

            if (IsTyresOKChecked == false && IsTyresNotOKChecked == false)
            {
                isValid = false;
                TyresCheckedColor = Color.Red;
            }
            else if (IsTyresNotOKChecked == true && string.IsNullOrWhiteSpace(Text_tyres))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                TyresCheckedColor = Color.Red;
            }
            else
                TyresCheckedColor = Color.Default;
            return isValid;
        }

        private bool CheckBrakeDiscsValues()
        {
            bool isValid = true;

            if (IsBrakeDiscsOKChecked == false && IsBrakeDiscsNotOKChecked == false)
            {
                isValid = false;
                BrakeDiscsCheckedColor = Color.Red;
            }
            else if (IsBrakeDiscsNotOKChecked == true && string.IsNullOrWhiteSpace(Text_brakediscs))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                BrakeDiscsCheckedColor = Color.Red;
            }
            else
                BrakeDiscsCheckedColor = Color.Default;
            return isValid;
        }
        #endregion
    }
}
