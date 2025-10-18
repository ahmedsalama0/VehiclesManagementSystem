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
    }
}
