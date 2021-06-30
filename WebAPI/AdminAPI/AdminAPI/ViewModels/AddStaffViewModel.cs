using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminAPI.ViewModels
{
    public class AddStaffViewModel
    {
        [Key]
        public int StaffID { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public string Designation { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }


        public string Highest_Qualification { get; set; }

        public double? Salary { get; set; }

        public string Department { get; set; }
    }
}