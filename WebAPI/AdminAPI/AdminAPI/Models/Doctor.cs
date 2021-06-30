using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int DoctorID { get; set; }

        public int LoginId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }


        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public int DeptNo { get; set; }

        public string DeptName { get; set; }

        public string Email { get; set; }

        public double Charges_Per_Visit { get; set; }

        public double? MonthlySalary { get; set; }

        public double? ReputeIndex { get; set; }

        public int Patients_Treated { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }

        [StringLength(100)]
        public string Specialization { get; set; }

        public int? Work_Experience { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual HashSet<Appointment> Appointments { get; set; }

       [ForeignKey("DeptNo")]
       public virtual Department Department { get; set; }

       [ForeignKey("LoginId")]
       public virtual LoginTable LoginTable { get; set; }


    }
}