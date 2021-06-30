namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherStaff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherStaffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(maxLength: 11),
                        Address = c.String(maxLength: 30),
                        Designation = c.String(nullable: false, maxLength: 15),
                        Gender = c.String(nullable: false, maxLength: 1),
                        BirthDate = c.DateTime(storeType: "date"),
                        Highest_Qualification = c.String(maxLength: 50),
                        Salary = c.Double(),
                    })
                .PrimaryKey(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherStaffs");
        }
    }
}
