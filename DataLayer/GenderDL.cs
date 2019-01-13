using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GenderDL:BasicMethods<Gender>
    {
        public GenderDL(EmployeeDbModel DbContext) : base(DbContext)
        {

        }
    }
}
