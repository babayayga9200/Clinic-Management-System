using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public double Amount { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Prescripton { get; set; }
    }
}
