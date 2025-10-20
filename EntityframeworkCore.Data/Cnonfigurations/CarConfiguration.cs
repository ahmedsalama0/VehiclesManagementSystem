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
    internal class CarConfiguration:IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car()
                {
                    Id = 10,
                    Brand = "CarBrand1",
                    Model = "CarModel1",
                    Year = 1901,
                    MaxSpeed = 101,
                    Type = CarType.Sedan
                },
                new Car()
                {
                    Id = 11,
                    Brand = "CarBrand2",
                    Model = "CarModel2",
                    Year = 1902,
                    MaxSpeed = 102,
                    Type = CarType.Jeep
                },
                new Car()
                {
                    Id = 12,
                    Brand = "CarBrand3",
                    Model = "CarModel3",
                    Year = 1903,
                    MaxSpeed = 103,
                    Type = CarType.SUV
                }
                );
        }
    }
}
