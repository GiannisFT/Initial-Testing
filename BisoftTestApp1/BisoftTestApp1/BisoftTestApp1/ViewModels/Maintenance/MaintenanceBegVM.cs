﻿using BisoftTestApp1.ViewModels.BaseClass;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using BisoftTestApp1.Classes;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BisoftTestApp1.ViewModels.Maintenance
{
    class MaintenanceBegVM : ViewModelBase
    {
        #region ServiceReference
        public Service1Client DbContext { get; set; }
        #endregion

        #region Commands
        public ICommand InsertBegCommand { get; set; }
        public ICommand CancelCommand => new Command(async () => await ShellNav.Current.Navigation.PopAsync());
        #endregion

        #region properties

        #region Car Pre Sales Id

        public int IniCarPreSalesId { get; set; }
        #endregion

        #region Preferences

        string ucid = Preferences.Get("UcidValue", null);
        string uname = Preferences.Get("UsernameValue", null);
        string pword = Preferences.Get("PasswordValue", null);
        int offId = Preferences.Get("OfficeIdValue", 0);
        int empId = Preferences.Get("EmployeeIdValue", 0);
        int companyId = Preferences.Get("CompanyId", 0);
        string employeeName = Preferences.Get("EmpNameValue", null);
        public string EmpFullName { get { return employeeName; } set { } }

        #endregion

        #region Date
        private DateTime selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedDate"));
            }
        }
        #endregion

        #region Gearbox
        private string txt_gears;
        public string Text_gears
        {
            get { return txt_gears; }
            set
            {
                if (txt_gears == value)
                    return;
                txt_gears = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_gears"));
            }
        }

        private bool box_gearsOK;
        private bool box_gearsNotOK;
        public bool IsGearsOKChecked
        {
            get { return box_gearsOK; }
            set
            {
                box_gearsOK = value;
                if (box_gearsOK)
                    IsGearsNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsGearsOKChecked"));
            }
        }
        public bool IsGearsNotOKChecked
        {
            get { return box_gearsNotOK; }
            set
            {
                box_gearsNotOK = value;
                if (box_gearsNotOK)
                    IsGearsOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsGearsNotOKChecked"));
            }
        }
        public bool GearsCheck
        {
            get { return IsGearsOKChecked; }
            set
            {
                if (IsGearsOKChecked == false)
                    IsGearsNotOKChecked = value;
            }
        }

        private Color _gearsCheckedColor;
        public Color GearsCheckedColor
        {
            get { return _gearsCheckedColor; }
            set
            {
                if (_gearsCheckedColor == null)
                    return;
                _gearsCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GearsCheckedColor"));
            }
        }
        #endregion

        #region Clean
        private string txt_clean;
        public string Text_clean
        {
            get { return txt_clean; }
            set
            {
                if (txt_clean == value)
                    return;
                txt_clean = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_clean"));
            }
        }

        private bool box_cleanOK;
        private bool box_cleanNotOK;
        public bool IsCleanOKChecked
        {
            get { return box_cleanOK; }
            set
            {
                box_cleanOK = value;
                if (box_cleanOK)
                    IsCleanNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsCleanOKChecked"));
            }
        }
        public bool IsCleanNotOKChecked
        {
            get { return box_cleanNotOK; }
            set
            {
                box_cleanNotOK = value;
                if (box_cleanNotOK)
                    IsCleanOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsCleanNotOKChecked"));
            }
        }
        public bool CleanCheck
        {
            get { return IsCleanOKChecked; }
            set
            {
                if (IsCleanOKChecked == false)
                    IsCleanNotOKChecked = value;
            }
        }
        private Color _cleanCheckedColor;
        public Color CleanCheckedColor
        {
            get { return _cleanCheckedColor; }
            set
            {
                if (_cleanCheckedColor == null)
                    return;
                _cleanCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CleanCheckedColor"));
            }
        }
        #endregion

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

        #region Brakes
        private string txt_brakes;
        public string Text_brakes
        {
            get { return txt_brakes; }
            set
            {
                if (txt_brakes == value)
                    return;
                txt_brakes = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_brakes"));
            }
        }

        private bool box_brakesOK;
        private bool box_brakesNotOK;
        public bool IsBrakesOKChecked
        {
            get { return box_brakesOK; }
            set
            {
                box_brakesOK = value;
                if (box_brakesOK)
                    IsBrakesNotOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBrakesOKChecked"));
            }
        }
        public bool IsBrakesNotOKChecked
        {
            get { return box_brakesNotOK; }
            set
            {
                box_brakesNotOK = value;
                if (box_brakesNotOK)
                    IsBrakesOKChecked = false;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBrakesNotOKChecked"));
            }
        }
        public bool BrakesCheck
        {
            get { return IsBrakesOKChecked; }
            set
            {
                if (IsBrakesOKChecked == false)
                    IsBrakesNotOKChecked = value;
            }
        }
        private Color _brakesCheckedColor;
        public Color BrakesCheckedColor
        {
            get { return _brakesCheckedColor; }
            set
            {
                if (_brakesCheckedColor == null)
                    return;
                _brakesCheckedColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BrakesCheckedColor"));
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

        #endregion

        #region Constructors
        public MaintenanceBegVM()
        {
            GearsCheckedColor = Color.Black;
            CleanCheckedColor = Color.Black;
            BatteryCheckedColor = Color.Black;
            BrakesCheckedColor = Color.Black;
            TyresCheckedColor = Color.Black;
        }
        public MaintenanceBegVM(int carpresalesId)
        {
            GearsCheckedColor = Color.Black;
            CleanCheckedColor = Color.Black;
            BatteryCheckedColor = Color.Black;
            BrakesCheckedColor = Color.Black;
            TyresCheckedColor = Color.Black;
            IniCarPreSalesId = carpresalesId;
            InsertBegCommand = new HelpClasses.DelegateCommand(TryInsertMaintenanceBegData, CanTryInsertMaintenanceBegData);
        }

        #endregion

        #region Methods

        public void TryInsertMaintenanceBegData(object param)
        {
            if (CheckGearsValues() && CheckCleanValues() && CheckBatteryValues() && CheckBrakesValues() && CheckTyresValues())
            {
                DbContext = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);

                CarPreSalesMaintenaceBegData begdata = new CarPreSalesMaintenaceBegData();
                begdata.GearboxCheckOK = GearsCheck;
                begdata.GearboxCheckInfo = Text_gears;
                begdata.CleanCheckOK = CleanCheck;
                begdata.CleanCheckInfo = Text_clean;
                begdata.BatteriCheckOK = BatteryCheck;
                begdata.BatteriCheckInfo = Text_battery;
                begdata.BrakeCheckOK = BrakesCheck;
                begdata.BrakeCheckInfo = Text_brakes;
                begdata.TireCheckOK = TyresCheck;
                begdata.TireCheckInfo = Text_tyres;
                begdata.PerformedById = empId;
                begdata.PerformedDate = SelectedDate;
                begdata.CarPreSalesId = IniCarPreSalesId;

                //DbContext.InsertCarPreSalesmaintenanceBeg(uname, pword, ucid, begdata);
                ShellNav.Current.Navigation.PopAsync();
            }
        }

        private bool CanTryInsertMaintenanceBegData(object param)
        {
            return true;
        }
        private bool CheckGearsValues()
        {
            bool isValid = true;
            
            if (IsGearsOKChecked == false && IsGearsNotOKChecked == false)
            {
                isValid = false;
                GearsCheckedColor = Color.Red;
            }
            else if (IsGearsNotOKChecked == true && string.IsNullOrWhiteSpace(Text_gears))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                GearsCheckedColor = Color.Red;
            }
            else
                GearsCheckedColor = Color.Black;
            return isValid;
        }
        private bool CheckCleanValues()
        {
            bool isValid = true;

            if (IsCleanOKChecked == false && IsCleanNotOKChecked == false)
            {
                isValid = false;
                CleanCheckedColor = Color.Red;
            }
            else if (IsCleanNotOKChecked == true && string.IsNullOrWhiteSpace(Text_clean))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                CleanCheckedColor = Color.Red;
            }
            else
                CleanCheckedColor = Color.Black;
            return isValid;
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
                BatteryCheckedColor = Color.Black;
            return isValid;
        }
        private bool CheckBrakesValues()
        {
            bool isValid = true;

            if (IsBrakesOKChecked == false && IsBrakesNotOKChecked == false)
            {
                isValid = false;
                BrakesCheckedColor = Color.Red;
            }
            else if (IsBrakesNotOKChecked == true && string.IsNullOrWhiteSpace(Text_brakes))
            {
                isValid = false;
                Application.Current.MainPage.DisplayAlert("", "Beskrivningen få ej vara tom!", "OK");
                BrakesCheckedColor = Color.Red;
            }
            else
                BrakesCheckedColor = Color.Black;
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
                TyresCheckedColor = Color.Black;
            return isValid;
        }
        #endregion
    }
}
