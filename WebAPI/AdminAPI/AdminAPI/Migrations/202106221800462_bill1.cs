namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "PatientId");
        }
    }
}
