using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{

    public partial class Appointment
    {

        [Key]
        public int AppointID { get; set; }

        public int? DoctorID { get; set; }

        public string DoctorName { get; set; }

        public int? PatientID { get; set; }

        public DateTime? Date { get; set; }

        public int? Appointment_Status { get; set; }

        public double? Bill_Amount { get; set; }

        [StringLength(10)]
        public string Bill_Status { get; set; }

        public int? DoctorNotification { get; set; }

        public int? PatientNotification { get; set; }

        

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }



    }
}