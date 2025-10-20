using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityframeworkCore.Data.Cnonfigurations
{
    internal class MotorcycleConfigurations:IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.HasData(
                new Motorcycle()
                {
                    Id = 5,
                    Brand = "MotorcycleBrand1",
                    Model = "MotorcycleModel1",
                    Year = 2005,
                    MaxSpeed = 240,
                },
                new Motorcycle()
                {
                    Id = 6,
                    Brand = "MotorcycleBrand2",
                    Model = "MotorcycleModel2",
                    Year = 1974,
                    MaxSpeed = 180,
                },
                new Motorcycle()
                {
                    Id = 7,
                    Brand = "MotorcycleBrand3",
                    Model = "MotorcycleModel3",
                    Year = 1992,
                    MaxSpeed = 220,                }
                );

        }
    }
}
