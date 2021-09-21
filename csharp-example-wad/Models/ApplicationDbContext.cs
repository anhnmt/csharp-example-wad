using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace csharp_example_wad.Models
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext() : base("name=DBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }

        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}