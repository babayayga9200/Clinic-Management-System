namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(),
                        PatientID = c.Int(),
                        Date = c.DateTime(),
                        Appointment_Status = c.Int(),
                        Bill_Amount = c.Double(),
                        Bill_Status = c.String(maxLength: 10),
                        DoctorNotification = c.Int(),
                        PatientNotification = c.Int(),
                        FeedbackStatus = c.Int(),
                        Disease = c.String(maxLength: 100),
                        Progress = c.String(maxLength: 100),
                        Prescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AppointID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(maxLength: 11),
                        Address = c.String(maxLength: 40),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.String(nullable: false, maxLength: 1),
                        DeptNo = c.Int(nullable: false),
                        Charges_Per_Visit = c.Double(nullable: false),
                        MonthlySalary = c.Double(),
                        ReputeIndex = c.Double(),
                        Patients_Treated = c.Int(nullable: false),
                        Qualification = c.String(nullable: false, maxLength: 100),
                        Specialization = c.String(maxLength: 100),
                        Work_Experience = c.Int(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Departments", t => t.DeptNo, cascadeDelete: true)
                .Index(t => t.DeptNo);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptNo = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DeptNo);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.String(),
                        LoginTable_LoginId = c.Int(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.LoginTables", t => t.LoginTable_LoginId)
                .Index(t => t.LoginTable_LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "LoginTable_LoginId", "dbo.LoginTables");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "DeptNo", "dbo.Departments");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "LoginTable_LoginId" });
            DropIndex("dbo.Doctors", new[] { "DeptNo" });
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Departments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
