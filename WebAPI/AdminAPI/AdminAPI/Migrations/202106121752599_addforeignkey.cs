namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeignkey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Doctors", "LoginId");
            AddForeignKey("dbo.Doctors", "LoginId", "dbo.LoginTables", "LoginId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "LoginId", "dbo.LoginTables");
            DropIndex("dbo.Doctors", new[] { "LoginId" });
        }
    }
}
