using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public class Truck: Vehicle
    {
        public string? TruckColor { get; set; }

        public override void CalculateRentalFees()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Rent Fees for the truck = " + 8100 * 1.3);
            Console.WriteLine("----------------------------------");

        }
    }
}
