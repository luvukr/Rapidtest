using DataLayer;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GenderBL
    {
        public List<Gender> GetGenders()
        {
            List<Gender> list = null;
            try
            {
                EmployeeDbModel dBModel = new EmployeeDbModel();

                list = new GenderDL(dBModel).GetAll().ToList();

            }
            catch (Exception e)
            {

                throw e;

            }
            return list;
        }


    }
}
