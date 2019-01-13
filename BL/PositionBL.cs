using DataLayer;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PositionBL
    {
        public List<EmployeePosition> GetPositions()
        {
            List<EmployeePosition> list = null;
            try
            {
                EmployeeDbModel dBModel = new EmployeeDbModel();

                list = new PositionDL(dBModel).GetAll().ToList();

            }
            catch (Exception e)
            {

                throw e;

            }
            return list;
        }
    }
}
