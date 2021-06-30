namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otherstaffchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OtherStaffs", "LoginID", c => c.Int(nullable: false));
            AddColumn("dbo.OtherStaffs", "DeptNo", c => c.Int(nullable: false));
            CreateIndex("dbo.OtherStaffs", "LoginID");
            CreateIndex("dbo.OtherStaffs", "DeptNo");
            AddForeignKey("dbo.OtherStaffs", "DeptNo", "dbo.Departments", "DeptNo", cascadeDelete: true);
            AddForeignKey("dbo.OtherStaffs", "LoginID", "dbo.LoginTables", "LoginId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OtherStaffs", "LoginID", "dbo.LoginTables");
            DropForeignKey("dbo.OtherStaffs", "DeptNo", "dbo.Departments");
            DropIndex("dbo.OtherStaffs", new[] { "DeptNo" });
            DropIndex("dbo.OtherStaffs", new[] { "LoginID" });
            DropColumn("dbo.OtherStaffs", "DeptNo");
            DropColumn("dbo.OtherStaffs", "LoginID");
        }
    }
}
