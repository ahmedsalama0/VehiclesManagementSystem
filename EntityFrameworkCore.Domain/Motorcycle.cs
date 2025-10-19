using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public class Motorcycle: Vehicle
    {
        public bool? IsSafe { get; set; }
        public override void CalculateRentalFees()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Rent Fess for the Motorcycle is "  + 6.5 * 8 + 150);
            Console.WriteLine("----------------------------------");

        }
    }
}
