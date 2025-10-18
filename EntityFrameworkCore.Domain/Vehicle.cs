using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
       // public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        // public DateTime? Year { get; set; }
        public int? Year { get; set; }
        public int MaxSpeed { get; set; }

        public abstract void CalculateRentalFees();

        public override string ToString()
        {
            return $"The Vehicle Id = {Id}" +
                $"Model: {Model}" +
                $"Brand: {Brand}" +
                $"Year: {Year}";
        }
    }
}
