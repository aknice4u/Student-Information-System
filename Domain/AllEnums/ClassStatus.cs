using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AllEnums
{
    class eClassStatus
    {
        public Cstatus classstatus { get; set; }

    }

    public enum Cstatus : int
    {
        Inactive = 0,
        Active = 1,
        
    }
}
