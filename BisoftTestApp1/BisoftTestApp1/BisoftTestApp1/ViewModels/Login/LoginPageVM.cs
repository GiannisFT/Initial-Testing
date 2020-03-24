using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using BisoftTestApp1.ViewModels;
using BisoftTestApp1.ViewModels.BaseClass;
using BisoftTestApp1.Views;
using ServiceReference1;
using Xamarin.Essentials;
using Xamarin.Forms;
using BisoftTestApp1.Classes;

namespace BisoftTestApp1.ViewModels.Login
{
    public class LoginPageVM : ViewModelBase
    {
        #region Commands

        public ICommand LoginCommand { get; set; }
        #endregion

        #region Properties

        #region Username

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username == value)
                    return;
                _username = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Username"));

            }
        }

        #endregion

        #region Password

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password == value)
                    return;
                _password = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Password"));

            }
        }

        #endregion

        #region UserName

        private string _employeeName;
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                if (_employeeName == value)
                    return;
                _employeeName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EmployeeName"));

            }
        }

        #endregion

        #region EmployeeId

        private int _employeeId;
        public int EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                if (_employeeId == value)
                    return;
                _employeeId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EmployeeId"));

            }
        }

        #endregion

        #region Ucid

        private string _ucid;
        public string Ucid
        {
            get { return _ucid; }
            set
            {
                if (_ucid == value)
                    return;
                _ucid = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ucid"));
            }
        }
        #endregion

        #endregion

        #region Constructors

        public LoginPageVM()
        {
            LoginCommand = new HelpClasses.DelegateCommand(TryLoginEmployee, CanTryLoginEmployee);
            
        }
        #endregion

        #region Methods

        #region Open function Document

        public void TryLoginEmployee(object param)
        {
            try
            {

                Service1Client context = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);

                var emp = context.LoginEmployee(Username, Password, Ucid);
                
                Preferences.Set("UcidValue", Ucid);
                Preferences.Set("UsernameValue", Username);
                Preferences.Set("PasswordValue", Password);
                Preferences.Set("EmployeeIdValue", emp.Id);
                Preferences.Set("OfficeIdValue", emp.OfficeId);
                Preferences.Set("CompanyId", emp.CompanyId);
                Preferences.Set("EmpNameValue", emp.FName + " " + emp.LName);

                if (string.IsNullOrWhiteSpace(emp.Message))
                {
                    Shell.Current.GoToAsync("///main/presale_maint");
                }
                else
                    EmployeeName = emp.Message;

            }
            catch (Exception ex)
            {
               
            }
        }

        private bool CanTryLoginEmployee(object param)
        {
            return true;
        }
        
        #endregion
        #endregion
    }
}
