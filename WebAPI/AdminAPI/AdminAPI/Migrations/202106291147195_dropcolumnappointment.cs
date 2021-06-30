namespace AdminAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumnappointment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "FeedbackStatus");
            DropColumn("dbo.Appointments", "Disease");
            DropColumn("dbo.Appointments", "Progress");
            DropColumn("dbo.Appointments", "Prescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Prescription", c => c.String(maxLength: 100));
            AddColumn("dbo.Appointments", "Progress", c => c.String(maxLength: 100));
            AddColumn("dbo.Appointments", "Disease", c => c.String(maxLength: 100));
            AddColumn("dbo.Appointments", "FeedbackStatus", c => c.Int());
        }
    }
}
