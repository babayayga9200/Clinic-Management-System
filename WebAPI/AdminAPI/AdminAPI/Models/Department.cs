using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    
        public class Department
        {
            
            public Department()
            {
                Doctors = new HashSet<Doctor>();
            }

            [Key]
            public int DeptNo { get; set; }

            
            public string DeptName { get; set; }

            
            public string Description { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Doctor> Doctors { get; set; }
        }
    }