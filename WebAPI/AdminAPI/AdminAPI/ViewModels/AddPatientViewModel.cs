using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAPI.ViewModels
{
   
        public class AddPatientViewModel
        {
            public string Name { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public DateTime BirthDate { get; set; }

            public string Address { get; set; }


        }
    }
