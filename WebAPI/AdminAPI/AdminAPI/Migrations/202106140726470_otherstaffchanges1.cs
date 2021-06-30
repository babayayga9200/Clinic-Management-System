namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otherstaffchanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OtherStaffs", "DeptNo", "dbo.Departments");
            DropIndex("dbo.OtherStaffs", new[] { "DeptNo" });
            AlterColumn("dbo.OtherStaffs", "BirthDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OtherStaffs", "BirthDate", c => c.DateTime(storeType: "date"));
            CreateIndex("dbo.OtherStaffs", "DeptNo");
            AddForeignKey("dbo.OtherStaffs", "DeptNo", "dbo.Departments", "DeptNo", cascadeDelete: true);
        }
    }
}
