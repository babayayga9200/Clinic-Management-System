namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "LoginId", c => c.Int(nullable: false));
            AddColumn("dbo.LoginTables", "doctor_DoctorID", c => c.Int());
            CreateIndex("dbo.LoginTables", "doctor_DoctorID");
            DropColumn("dbo.Doctors", "Password");
            DropColumn("dbo.Doctors", "ConfirmPassword");
            DropColumn("dbo.Doctors", "Gender");
            DropColumn("dbo.Doctors", "Department");
            //Sql("ALTER TABLE dbo.Doctors  WITH CHECK ADD CONSTRAINT [FK_LID] FOREIGN KEY([LoginId]) REFERENCES [dbo.LoginTables([LoginId]) ON UPDATE CASCADE");
            //Sql("ALTER TABLE dbo.Doctors CHECK CONSTRAINT [FK_LID]");
            //Sql("insert into dbo.Doctors(LoginId) select LoginId from dbo.LoginTables");
            //Sql("ALTER TABLE dbo.Doctors DROP CONSTRAINT [FK_LID] ");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Cardiology', 'We have the best heart specialists in town .Each one of them is very competent and experienced.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Orthopaedics', 'Orthopedic surgeons use surgical means to treat musculoskeletal trauma, infections, tumors. We believe in the best.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Ears Nose Throat', 'They are gentle. And are trained to handle kids as well as adults.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Physiology', 'Physiotherapists work through physical therapies such as exercise, and manipulation of bones, joints and muscle tissues.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Neurology', 'A medical speciality dealing with disorders of the nervous system. It deals with the diagnosis and treatment of all categories of disease.')");

        }

        public override void Down()
        {
            AddColumn("dbo.Doctors", "Department", c => c.String());
            AddColumn("dbo.Doctors", "Gender", c => c.String(maxLength: 1));
            AddColumn("dbo.Doctors", "ConfirmPassword", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Doctors", "Password", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.LoginTables", "doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.LoginTables", new[] { "doctor_DoctorID" });
            DropColumn("dbo.LoginTables", "doctor_DoctorID");
            DropColumn("dbo.Doctors", "LoginId");
        }
    }
}
