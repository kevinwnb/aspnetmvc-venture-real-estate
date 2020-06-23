namespace MockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentModificationsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agent", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agent", "LastName");
        }
    }
}
