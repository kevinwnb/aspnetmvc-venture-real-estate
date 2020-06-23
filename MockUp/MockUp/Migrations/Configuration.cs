namespace MockUp.Migrations
{
    using MockUp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MockUp.Models.VentureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MockUp.Models.VentureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            //context.Roles.Add(new Role()
            //{
            //    Name = "Manager"
            //});
            //context.Roles.Add(new Role()
            //{
            //    Name = "Agent"
            //});
            //context.Roles.Add(new Role()
            //{
            //    Name = "Broker"
            //});
            //context.Roles.Add(new Role()
            //{
            //    Name = "Customer"
            //});
            //context.Roles.Add(new Role()
            //{
            //    Name = "Employee"
            //});

            //context.Logins.Add(new Login()
            //{
            //    Username = "kevinwnb",
            //    Password = "secret",
            //    RoleId = 5
            //});
        }
    }
}
