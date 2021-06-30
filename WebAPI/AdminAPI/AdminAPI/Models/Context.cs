using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class Context:DbContext
    {
        public Context():base("name=defaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<LoginTable> loginTables { get; set; }
        public virtual DbSet<Doctor> doctors { get; set; }
        public virtual DbSet<Appointment> appointments { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Patient> patients { get; set; }
        public virtual DbSet<OtherStaff> otherStaff { get; set; }
        public virtual DbSet<Bill> bills { get; set; }
    }

    
}