using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using BisoftTestApp1.ViewModels;
using BisoftTestApp1.ViewModels.BaseClass;
using ServiceReference1;
using Xamarin.Essentials;
using BisoftTestApp1.ViewModels.Login;
using System.Collections.ObjectModel;
using BisoftTestApp1.Classes;
using BisoftTestApp1.Views;
using BisoftTestApp1.ViewModels.Maintenance;

namespace BisoftTestApp1.ViewModels.CarPresalesMaintenanceVM
{
    class CarPresalesMaintenanceVM : ViewModelBase
    {
        #region ServiceReference
        public Service1Client DbContext { get; set; }
        #endregion
        #region Commands
        public ICommand GetPresalesMaintenance { get; set; }
        #endregion

        #region Properties
        private ObservableCollection<CarPresalesMaintenance> allMaintenance;
        public ObservableCollection<CarPresalesMaintenance> AllMaintenance
        {
            get
            {
                return allMaintenance;
            }
            set
            {
                if (allMaintenance == value)
                    return;
                allMaintenance = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllMaintenance"));
            }
        }

      
        private ObservableCollection<Office> allOffices;
        public ObservableCollection<Office> AllOffices
        {
            get
            {
                return allOffices;
            }
            set
            {
                if (allOffices == value)
                    return;
                allOffices = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllOffices"));
            }
        }

        private Office selectedOffice;
        public Office SelectedOffice
        {
            get {return selectedOffice; }
            set
            {
                if (selectedOffice == value)
                    return;
                selectedOffice = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedOffice"));
                GetCarPresalesMaintenance(null);
            }
        }

        private CarPresalesMaintenance selectedMaintenance;
        public CarPresalesMaintenance SelectedMaintenance
        {
            get { return selectedMaintenance; }
            set
            {
                if (selectedMaintenance == value)
                    return;
                selectedMaintenance = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedMaintenance"));
                Collection_SelectedMaintenance();
            }
        }
        #region Preferences

        string ucid = Preferences.Get("UcidValue", null);
        string uname = Preferences.Get("UsernameValue", null);
        string pword = Preferences.Get("PasswordValue", null);
        int offId = Preferences.Get("OfficeIdValue", 0);
        int empId = Preferences.Get("EmployeeIdValue", 0);
        int companyId = Preferences.Get("CompanyId", 0);
        string employeeName = Preferences.Get("EmpNameValue", null);
        
        #endregion

        #endregion

        #region Constructors

        public CarPresalesMaintenanceVM()
        {
            GetPresalesMaintenance = new HelpClasses.DelegateCommand(GetCarPresalesMaintenance, CanTryGetCarPresalesMaintenance);
            GetOffices();
        }
        #endregion

        #region Methods

        public void GetCarPresalesMaintenance(object param)
        {
            DbContext = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
            
            var result = DbContext.GetCarPreSalesmaintenanceByOffice(uname, pword, ucid, SelectedOffice.Id, null);

            ObservableCollection<CarPresalesMaintenance> temp = new ObservableCollection<CarPresalesMaintenance>();
            foreach (CarPreSalesMaintenanceData row in result)
            {
                CarPresalesMaintenance cPM = new CarPresalesMaintenance();
                cPM.Id = row.Id;
                cPM.KeyCabinet = row.KeyCabinet;
                cPM.Parking = row.Parking;
                cPM.RegNr = row.RegNr;
                cPM.VehicleModel = row.VehicelModel;
                cPM.VehicleBrandId = row.VehicleBrandId;
                cPM.VehicleBrandName = row.VehicleBrandName;
                cPM.Color = row.CarPreSaleFlowGroupData.Color;
                cPM.Name = row.CarPreSaleFlowGroupData.Name;
                cPM.Fname = row.MaintenanceResponsible.FName;
                cPM.Lname = row.MaintenanceResponsible.LName;
                temp.Add(cPM);
            }
            AllMaintenance = new ObservableCollection<CarPresalesMaintenance>(temp);
        }

        private bool CanTryGetCarPresalesMaintenance(object param)
        {
            return true;
        }

        public void GetOffices()
        {
            DbContext = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
            var result = DbContext.GetOfficesByCompanyId(uname, pword, ucid, companyId);
            AllOffices = new ObservableCollection<Office>();
            foreach (OfficeData row in result)
            {
                Office off = new Office();
                off.Name = row.Name;
                off.Id = row.Id;
                AllOffices.Add(off);
            }
        }
        public void Collection_SelectedMaintenance()
        {
            foreach (var item in AllMaintenance)
            {
                if (SelectedMaintenance.Id == item.Id)
                {
                    Maintenance.MaintenanceBegVM context = new Maintenance.MaintenanceBegVM(SelectedMaintenance.Id);
                    MaintenanceBegForm form = new MaintenanceBegForm();
                    form.BindingContext = context;
                    ShellNav.Current.Navigation.PushAsync(form);
                    
                }
            }
        }
        #endregion
    }
}
