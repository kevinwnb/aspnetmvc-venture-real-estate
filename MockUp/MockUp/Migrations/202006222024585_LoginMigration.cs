namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Login", "RoleId", "dbo.Role");
            DropIndex("dbo.Login", new[] { "RoleId" });
            DropTable("dbo.Login");
        }
    }
}
