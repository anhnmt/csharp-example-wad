using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace csharp_example_wad.Models
{
    internal sealed class Configuration : DbMigrationsConfiguration<csharp_example_wad.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "csharp_example_wad.Models.ApplicationDbContext";
        }

        protected override void Seed(csharp_example_wad.Models.ApplicationDbContext context)
        {
            context.CustomerTypes.AddOrUpdate(x => x.TypeId,
                new CustomerType()
                {
                    TypeId = 1,
                    TypeName = "Vip",
                },
                new CustomerType()
                {
                    TypeId = 2,
                    TypeName = "Normal",
                }
            );

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer()
                {
                    Id = "C0001",
                    FullName = "Nguyễn Văn A",
                    Address = "Hà Nội",
                    Phone = "0123456789",
                    Gender = true,
                    TypeId = 1,
                },
                new Customer()
                {
                    Id = "C0002",
                    FullName = "Trần Thị B",
                    Address = "TP.HCM",
                    Phone = "0987654321",
                    Gender = false,
                    TypeId = 2,
                }
            );
        }
    }
}