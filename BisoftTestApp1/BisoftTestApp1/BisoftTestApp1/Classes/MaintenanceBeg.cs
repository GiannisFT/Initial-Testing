using System;
using System.Collections.Generic;
using System.Text;

namespace BisoftTestApp1.Classes
{
    class MaintenanceBeg
    {
        public string BatteriCheckInfo { get; set; }
        public bool BatteriCheckOK { get; set; }
        public string BrakeCheckInfo { get; set; }
        public bool BrakeCheckOK { get; set; }
        public int CarPreSalesId { get; set; }
        public string CleanCheckInfo { get; set; }
        public bool CleanCheckOK { get; set; }
        public string GearboxCheckInfo { get; set; }
        public bool GearboxCheckOK { get; set; }
        public string TyreCheckInfo { get; set; }
        public bool TyreCheckOK { get; set; }
        public int PerformedById { get; set; }
        public DateTime PerformedDate { get; set; }
    }
}
