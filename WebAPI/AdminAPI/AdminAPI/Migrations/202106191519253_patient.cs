namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "LoginTable_LoginId", "dbo.LoginTables");
            DropIndex("dbo.Patients", new[] { "LoginTable_LoginId" });
            RenameColumn(table: "dbo.Patients", name: "LoginTable_LoginId", newName: "LoginId");
            AddColumn("dbo.Patients", "Email", c => c.String());
            AddColumn("dbo.Patients", "Password", c => c.String());
            AlterColumn("dbo.Patients", "LoginId", c => c.Int(nullable: true));
            CreateIndex("dbo.Patients", "LoginId");
            AddForeignKey("dbo.Patients", "LoginId", "dbo.LoginTables", "LoginId", cascadeDelete: true);
            DropColumn("dbo.Patients", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Gender", c => c.String());
            DropForeignKey("dbo.Patients", "LoginId", "dbo.LoginTables");
            DropIndex("dbo.Patients", new[] { "LoginId" });
            AlterColumn("dbo.Patients", "LoginId", c => c.Int());
            DropColumn("dbo.Patients", "Password");
            DropColumn("dbo.Patients", "Email");
            RenameColumn(table: "dbo.Patients", name: "LoginId", newName: "LoginTable_LoginId");
            CreateIndex("dbo.Patients", "LoginTable_LoginId");
            AddForeignKey("dbo.Patients", "LoginTable_LoginId", "dbo.LoginTables", "LoginId");
        }
    }
}
