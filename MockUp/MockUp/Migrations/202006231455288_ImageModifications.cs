namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Image", "ListingId", "dbo.Listing");
            DropIndex("dbo.Image", new[] { "ListingId" });
            AddColumn("dbo.Image", "Path", c => c.String());
            AlterColumn("dbo.Image", "ListingId", c => c.Int());
            CreateIndex("dbo.Image", "ListingId");
            AddForeignKey("dbo.Image", "ListingId", "dbo.Listing", "ListingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ListingId", "dbo.Listing");
            DropIndex("dbo.Image", new[] { "ListingId" });
            AlterColumn("dbo.Image", "ListingId", c => c.Int(nullable: false));
            DropColumn("dbo.Image", "Path");
            CreateIndex("dbo.Image", "ListingId");
            AddForeignKey("dbo.Image", "ListingId", "dbo.Listing", "ListingId", cascadeDelete: true);
        }
    }
}
