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
    internal class TruckConfigurations:IEntityTypeConfiguration<Truck>
    {

        public void Configure(EntityTypeBuilder<Truck> builder)
        {
                builder.HasData(new Truck()
                {
                    Id = 15,
                    Brand = "TruckBrand1",
                    Model = "TruckModel1",
                    Year = 2011,
                    MaxSpeed = 110,
                },
                new Truck()
                {
                    Id = 16,
                    Brand = "TruckBrand2",
                    Model = "TruckModel2",
                    Year = 2015,
                    MaxSpeed = 130,
                },
                new Truck()
                {
                    Id = 17,
                    Brand = "TruckBrand3",
                    Model = "TruckeModel3",
                    Year = 2025,
                    MaxSpeed = 135,
                }
            );
        }
    }
}
