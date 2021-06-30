using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAPI.ViewModels
{
    public class AddDoctorViewModel
    {

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }

        public double? MonthlySalary { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Department { get; set; }

        public string Qualification { get; set; }

        public double Charges_Per_Visit { get; set; }

        public string Address { get; set; }

        public string Specialization { get; set; }

        public int? Work_Experience { get; set; }

        //public double? ReputeIndex { get; set; }

        //public int Patients_Treated { get; set; }







    }
}