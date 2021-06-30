namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeValidationForOtherStaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OtherStaffs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.OtherStaffs", "Phone", c => c.String(maxLength: 10));
            AlterColumn("dbo.OtherStaffs", "Address", c => c.String());
            AlterColumn("dbo.OtherStaffs", "Designation", c => c.String());
            AlterColumn("dbo.OtherStaffs", "Highest_Qualification", c => c.String());
            DropColumn("dbo.OtherStaffs", "Gender");
            //Sql("insert into dbo.patients('Name','Phone','Address','BirthDate')VALUES('ABC',9876543210,'CHENNAI','1996 - 04 - 04')");
            // Sql("insert into dbo.appointments('DoctorID','PatientID','Date') VALUES (5,1,2021 - 04 - 23 11:00:00.000)");
            


        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherStaffs", "Gender", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.OtherStaffs", "Highest_Qualification", c => c.String(maxLength: 50));
            AlterColumn("dbo.OtherStaffs", "Designation", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.OtherStaffs", "Address", c => c.String(maxLength: 30));
            AlterColumn("dbo.OtherStaffs", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.OtherStaffs", "Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
