using System;
using System.Collections.Generic;
using System.Text;

namespace BisoftTestApp1.Classes
{
    class CarPresalesMaintenance
    {
        public int Id { get; set; }
        public string KeyCabinet { get; set; }
        public string Parking { get; set; }
        public string RegNr { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int MaintenanceFormId { get; set; }
        public string FullName { get {return Fname + " " + Lname; } }
    }
}
