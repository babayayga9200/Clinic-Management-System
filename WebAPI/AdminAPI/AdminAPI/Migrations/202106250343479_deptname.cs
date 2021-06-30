namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DeptName", c => c.String());

        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "DeptName");
        }
    }
}
