namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Gender", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Gender", c => c.String(nullable: false, maxLength: 1));
        }
    }
}
