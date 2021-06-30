using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAPI.ViewModels
{
    public class BillViewModel
    {
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public double Amount { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Prescription { get; set; }
    }
}