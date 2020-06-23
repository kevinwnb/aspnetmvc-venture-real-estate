namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingModificationsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "AgentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Listing", "StreetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Listing", "Municipality", c => c.String(nullable: false));
            AlterColumn("dbo.Listing", "Province", c => c.String(nullable: false));
            CreateIndex("dbo.Listing", "AgentId");
            AddForeignKey("dbo.Listing", "AgentId", "dbo.Agent", "AgentId", cascadeDelete: true);
            DropColumn("dbo.Listing", "ListingAgent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Listing", "ListingAgent", c => c.Int(nullable: false));
            DropForeignKey("dbo.Listing", "AgentId", "dbo.Agent");
            DropIndex("dbo.Listing", new[] { "AgentId" });
            AlterColumn("dbo.Listing", "Province", c => c.String());
            AlterColumn("dbo.Listing", "Municipality", c => c.String());
            AlterColumn("dbo.Listing", "StreetAddress", c => c.String());
            DropColumn("dbo.Listing", "AgentId");
        }
    }
}
