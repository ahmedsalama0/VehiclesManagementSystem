using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public class Motorcycle: Vehicle
    {
        public bool IsSafe { get; set; }
    }
}
