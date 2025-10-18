using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
