using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public enum CarType {
        Sedan,
        Hatcback,
        Coupe,
        SUV,
        Sportscars,
        Jeep
    }

    public class Car: Vehicle
    {
        public CarType? Type { get; set; } 
    }
}
