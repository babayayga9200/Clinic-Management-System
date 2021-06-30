namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PatientName = c.String(),
                        DoctorName = c.String(),
                        Amount = c.Double(nullable: false),
                        PurposeOfVisit = c.String(),
                        Prescripton = c.String(),
                    })
                .PrimaryKey(t => t.BillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
