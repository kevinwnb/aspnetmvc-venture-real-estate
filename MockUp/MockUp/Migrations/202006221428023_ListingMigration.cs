namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "StreetAddress", c => c.String());
            AddColumn("dbo.Listing", "Municipality", c => c.String());
            AddColumn("dbo.Listing", "Province", c => c.String());
            AddColumn("dbo.Listing", "PostalCode", c => c.String());
            AddColumn("dbo.Listing", "SquareFeet", c => c.Int(nullable: false));
            AddColumn("dbo.Listing", "CityArea", c => c.String());
            AddColumn("dbo.Listing", "Summary", c => c.String());
            AddColumn("dbo.Listing", "HeatingType", c => c.String());
            AddColumn("dbo.Listing", "HasFireplace", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listing", "HasGarage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listing", "ListingAgent", c => c.Int(nullable: false));
            AddColumn("dbo.Listing", "ContractSigned", c => c.Boolean(nullable: false));
            DropColumn("dbo.Listing", "BuildingType");
            DropColumn("dbo.Listing", "Description");
            DropColumn("dbo.Listing", "SquareFeets");
            DropColumn("dbo.Listing", "HasParking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Listing", "HasParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listing", "SquareFeets", c => c.Int(nullable: false));
            AddColumn("dbo.Listing", "Description", c => c.String());
            AddColumn("dbo.Listing", "BuildingType", c => c.Int(nullable: false));
            DropColumn("dbo.Listing", "ContractSigned");
            DropColumn("dbo.Listing", "ListingAgent");
            DropColumn("dbo.Listing", "HasGarage");
            DropColumn("dbo.Listing", "HasFireplace");
            DropColumn("dbo.Listing", "HeatingType");
            DropColumn("dbo.Listing", "Summary");
            DropColumn("dbo.Listing", "CityArea");
            DropColumn("dbo.Listing", "SquareFeet");
            DropColumn("dbo.Listing", "PostalCode");
            DropColumn("dbo.Listing", "Province");
            DropColumn("dbo.Listing", "Municipality");
            DropColumn("dbo.Listing", "StreetAddress");
        }
    }
}
