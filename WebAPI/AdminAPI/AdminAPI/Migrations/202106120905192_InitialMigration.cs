namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginTables",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Email = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginTables");
        }
    }
}
