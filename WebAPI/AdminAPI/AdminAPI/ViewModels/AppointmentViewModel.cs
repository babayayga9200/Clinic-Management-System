using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAPI.ViewModels
{
    public class AppointmentViewModel
    {
       


        public DateTime? Date { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
    }
}