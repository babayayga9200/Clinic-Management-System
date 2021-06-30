namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Phone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Phone", c => c.String(maxLength: 11));
        }
    }
}
