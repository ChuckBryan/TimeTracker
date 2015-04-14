namespace TimeTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntryLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryLogs",
                c => new
                    {
                        EntryLogId = c.Int(nullable: false, identity: true),
                        Duration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Project = c.String(),
                    })
                .PrimaryKey(t => t.EntryLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntryLogs");
        }
    }
}
