namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanges1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Orthopaedics', 'Orthopedic surgeons use surgical means to treat musculoskeletal trauma, infections, tumors. We believe in the best.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Ears Nose Throat', 'They are gentle. And are trained to handle kids as well as adults.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Physiology', 'Physiotherapists work through physical therapies such as exercise, and manipulation of bones, joints and muscle tissues.')");
            Sql("INSERT INTO dbo.Departments(DeptName , Description) VALUES ('Neurology', 'A medical speciality dealing with disorders of the nervous system. It deals with the diagnosis and treatment of all categories of disease.')");

        }

        public override void Down()
        {
        }
    }
}
