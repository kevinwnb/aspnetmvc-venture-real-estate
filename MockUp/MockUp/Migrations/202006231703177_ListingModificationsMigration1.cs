namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingModificationsMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Listing", "CityArea", c => c.String(nullable: false));
            AlterColumn("dbo.Listing", "Summary", c => c.String(nullable: false));
            AlterColumn("dbo.Listing", "HeatingType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listing", "HeatingType", c => c.String());
            AlterColumn("dbo.Listing", "Summary", c => c.String());
            AlterColumn("dbo.Listing", "CityArea", c => c.String());
        }
    }
}
