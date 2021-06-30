using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class Patient
    {
        
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int PatientID { get; set; }

        public int LoginId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [ForeignKey("LoginId")]
        public virtual LoginTable LoginTable { get; set; }
    }
}