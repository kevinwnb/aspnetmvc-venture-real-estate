namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role");
        }
    }
}
