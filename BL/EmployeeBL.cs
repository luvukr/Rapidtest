using DataLayer;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EmployeeBL
    {

        public bool AddEmployee(Employee emp)
        {
            bool addResult = false;
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {
                    emp.EmpId = Guid.NewGuid();//new EmpDl(dBModel).GenerateGUID();
                    var dlo = new EmpDl(dBModel).Add(emp);
                    dBModel.SaveChanges();
                }
                addResult = true;


            }
            catch (Exception e)
            {


                throw e;
            }
            return addResult;
        }


        public bool UpdateEmployee(Employee updatedEmployee)
        {
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {

                    var dlo = new EmpDl(dBModel).Update(updatedEmployee);
                    dBModel.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Employee GetEmployee(Guid id)
        {
            Employee res = null;
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {

                    res = new EmpDl(dBModel).FindEager(x=>x.EmpId==id, new List<string> { "EmployeeLocation", "EmployeePosition" }).FirstOrDefault();
                }
                if (res == null)
                    throw new Exception("User not found");
                else
                    return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = null;
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {
                    list = new EmpDl(dBModel).GetAllEager(new List<string> { "EmployeeLocation", "EmployeePosition" }).ToList();
                }
                return list;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Employee> GetAllEmployees(string search, string draw, string order, string orderDir, int startRec, int pageSize, ref int recFiltered)

        {

            List<Employee> list = null;
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {
                    list = new EmpDl(dBModel).GetAllEmployees(search, draw, order, orderDir, startRec, pageSize, ref recFiltered);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return list;
        }

        public bool DeleteEmployee(Guid id)
        {
            try
            {
                using (EmployeeDbModel dBModel = new EmployeeDbModel())
                {
                    var res = new EmpDl(dBModel).Get(id);
                    if (res == null)
                        throw new Exception("User not found");
                    var res1 = new EmpDl(dBModel).Remove(res);
                    dBModel.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //public Guid Generate(Guid g)
        //{
        //    bool isDuplicate = false;
        //    try
        //    {
        //        EmployeeDbModel dBModel = new EmployeeDbModel();

        //        isDuplicate = new EmpDl(dBModel).Any(x => x.EmpId.Equals(g));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return Guid
        //}
    }
}
