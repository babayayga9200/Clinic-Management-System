namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Password", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Doctors", "ConfirmPassword", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "ConfirmPassword");
            DropColumn("dbo.Doctors", "Password");
        }
    }
}
