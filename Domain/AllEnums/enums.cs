using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AllEnums
{
    class enums
    {
        public status dropstatus { get; set; } 
              
    }

    public enum status: int
    {
        Inactive = 0,
        Active = 1,
        Widrawn = 2,
        graduated = 3
    }
}
