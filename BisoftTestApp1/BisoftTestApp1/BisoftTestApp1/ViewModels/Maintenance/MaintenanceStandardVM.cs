using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using BisoftTestApp1.ViewModels.BaseClass;
using ServiceReference1;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BisoftTestApp1.ViewModels.Maintenance
{
    class MaintenanceStandardVM : ViewModelBase
    {
        #region ServiceReference
        public Service1Client DbContext { get; set; }
        #endregion

        #region Commands
        public ICommand InsertStandardCommand { get; set; }
        public ICommand CancelCommand => new Command(async () => await ShellNav.Current.Navigation.PopAsync());
        public ICommand SelectPic { get; set; }
        #endregion

        #region Constructors
        public MaintenanceStandardVM()
        {

        }
        public MaintenanceStandardVM(int carpresalesId)
        {
            IniCarPreSalesId = carpresalesId;
            InsertStandardCommand = new HelpClasses.DelegateCommand(TryInsertMaintenanceStandardData, CanTryInsertMaintenanceStandardData);
            SelectPic = new Command(UploadFile);
        }
        #endregion

        #region Properties

        public int IniCarPreSalesId { get; set; }

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

        #region Information
        private string txt_info;
        public string Text_info
        {
            get { return txt_info; }
            set
            {
                if (txt_info == value)
                    return;
                txt_info = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text_info"));
            }
        }
        #endregion

        #region Upload File
        
        #endregion

        #endregion

        #region Methods

        public void TryInsertMaintenanceStandardData(object param)
        {
            if (true)
            {
                DbContext = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);

                CarPreSalesMaintenaceStandardData standardData = new CarPreSalesMaintenaceStandardData();
                standardData.PerformedDate = selectedDate;
                standardData.PerformedById = empId;
                //standardData.DocPath =
                standardData.CarPreSalesId = IniCarPreSalesId;

                //DbContext.InsertCarPreSalesmaintenanceStandard(uname, pword, ucid, standardData);
                Shell.Current.Navigation.PopAsync();
            }
        }
        public bool CanTryInsertMaintenanceStandardData(object param)
        {
            return true;
        }
        public void UploadFile()
        {
            //string[] temp = file.Path.Split('/');
            //string[] tempName = temp[temp.Length - 1].Split('.');
            //string filename = tempName[0];

            //string foldername = DateTime.Now.ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToString("H-mm-ss");
            //string filepath = "Files/InternalControl/" + Application.Current.Properties["CompanyId"].ToString() + "/" + Application.Current.Properties["OfficeId"].ToString() + "/" + foldername + "/" + temp[temp.Length - 1];
            //var content = new MultipartFormDataContent();
            //Uri host = new Uri("http://www.bisoft.se/Bisoft/receiver.ashx");
            //UriBuilder ub = new UriBuilder(host)
            //{
            //    Query = string.Format("filename={0}", filepath)
            //};

            //Stream data = file.GetStream();

            //WebClient c = new WebClient();
            //c.OpenWriteCompleted += (sender, e) =>
            //{
            //    PushData(data, e.Result);
            //    e.Result.Close();
            //    data.Close();

            //    PhotoCls photo = new PhotoCls
            //    {
            //        Name = filename,
            //        Path = filepath
            //    };

            //    AddedPhotos.Add(photo);
            //};
            //c.OpenWriteAsync(ub.Uri);
        }
        private void PushData(Stream input, Stream output)
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        #endregion
    }
}