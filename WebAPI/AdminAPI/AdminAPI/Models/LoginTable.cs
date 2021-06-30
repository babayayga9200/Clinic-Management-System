using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class LoginTable
    {
        [Key]
        public int LoginId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Type { get; set; }

        public LoginTable()
        {

        }

    }
}