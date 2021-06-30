using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class OtherStaff
    {
        public OtherStaff()
        {

        }
        
            [Key]
            public int StaffID { get; set; }

            public int LoginID { get; set; }

            [Required]
            public string Name { get; set; }

            [StringLength(10)]
            public string Phone { get; set; }

            public string Address { get; set; }

            public string Designation { get; set; }


            [Column(TypeName = "date")]
            public DateTime BirthDate { get; set; }

            public string Highest_Qualification { get; set; }

            public double? Salary { get; set; }

            public int DeptNo { get; set; }

            public virtual LoginTable LoginTable { get; set;}
        }
    }
