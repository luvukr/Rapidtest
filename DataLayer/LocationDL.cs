using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LocationDL:BasicMethods<EmployeeLocation>
    {
        public LocationDL(EmployeeDbModel DbContext) : base(DbContext)
        {

        }
    }
}
