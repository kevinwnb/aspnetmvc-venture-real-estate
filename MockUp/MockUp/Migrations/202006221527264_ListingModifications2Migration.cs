namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingModifications2Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Approved = c.Boolean(nullable: false),
                        ListingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Listing", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ListingId", "dbo.Listing");
            DropIndex("dbo.Image", new[] { "ListingId" });
            DropTable("dbo.Image");
        }
    }
}
