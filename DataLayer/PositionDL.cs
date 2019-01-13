using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PositionDL:BasicMethods<EmployeePosition>
    {
        public PositionDL(EmployeeDbModel DbContext) : base(DbContext)
        {

        }
    }
}
