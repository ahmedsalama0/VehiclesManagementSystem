using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityframeworkCore.Data
{
    public class VehicleDbContext: DbContext
    {
        //DbSets
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "VehicleDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Car>().HasData(
            //      new Car
            //      {
            //          Id = 98,
            //          Brand = "Brand1",
            //          Model = "Model1",
            //          Year = 1901,
            //          MaxSpeed = 101,
            //          Type = CarType.Sedan
            //      },
            //    new Car
            //    {
            //        Id = 99,
            //        Brand = "Brand2",
            //        Model = "Model2",
            //        Year = 1902,
            //        MaxSpeed = 102,
            //        Type = CarType.Jeep
            //    },
            //    new Car
            //    {
            //        Id = 97001,
            //        Brand = "Brand3",
            //        Model = "Model3",
            //        Year = 1903,
            //        MaxSpeed = 103,
            //        Type = CarType.SUV
            //    }
            //    );
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
