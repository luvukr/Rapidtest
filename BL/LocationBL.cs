using DataLayer;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LocationBL
    {
        public List<EmployeeLocation> GetLocations()
        {
            List<EmployeeLocation> list = null;
            try
            {
                EmployeeDbModel dBModel = new EmployeeDbModel();

                list = new LocationDL(dBModel).GetAll().ToList();
                
            }
            catch (Exception e)
            {

                throw e;

            }
            return list;
        }
    }
}
