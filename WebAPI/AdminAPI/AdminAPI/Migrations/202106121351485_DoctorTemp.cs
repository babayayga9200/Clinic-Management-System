namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorTemp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Department");
        }
    }
}
