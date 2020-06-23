using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MockUp.Models
{
    public class VentureContext : DbContext
    {
        public VentureContext() : base("VentureContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}