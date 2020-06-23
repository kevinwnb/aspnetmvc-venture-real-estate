namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        SIN = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(),
                        LoggedInUserName = c.String(nullable: false, maxLength: 20),
                        StreetAddress = c.String(nullable: false, maxLength: 30),
                        Municipality = c.String(nullable: false, maxLength: 30),
                        Province = c.String(nullable: false, maxLength: 30),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        HomePhoneNumber = c.String(nullable: false, maxLength: 10),
                        CellPhoneNumber = c.String(nullable: false, maxLength: 10),
                        OfficeEmail = c.String(nullable: false, maxLength: 150),
                        OfficePhoneNumber = c.String(nullable: false, maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.BuildingType",
                c => new
                    {
                        BuildingTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BuildingTypeId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        BirthDay = c.DateTime(nullable: false),
                        StreetAddress = c.String(nullable: false, maxLength: 25),
                        Municipality = c.String(nullable: false, maxLength: 25),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        CustomerProv = c.Int(nullable: false),
                        custCountry = c.Int(nullable: false),
                        HomePhone = c.String(maxLength: 15),
                        CellPhone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 150),
                        CheckId = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Listing",
                c => new
                    {
                        ListingId = c.Int(nullable: false, identity: true),
                        BuildingType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Baths = c.Int(nullable: false),
                        Beds = c.Int(nullable: false),
                        Description = c.String(),
                        SquareFeets = c.Int(nullable: false),
                        HasParking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Listing");
            DropTable("dbo.Customer");
            DropTable("dbo.BuildingType");
            DropTable("dbo.Agent");
        }
    }
}
