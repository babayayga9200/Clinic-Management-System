namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Email");
        }
    }
}
