namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointadddoctorname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "DoctorName");
        }
    }
}
