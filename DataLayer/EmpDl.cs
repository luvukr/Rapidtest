using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmpDl:BasicMethods<Employee>
    {
        private EmployeeDbModel dbModel;
        public EmpDl(EmployeeDbModel DbContext) : base(DbContext)
        {
            dbModel = DbContext;
        }



        public List<Employee> GetAllEmployees(string search, string draw, string order, string orderDir, int startRec, int pageSize, ref int recFiltered)
        {
            List<Employee> list = null;
            try
            {
                var data = dbModel.Employees .Include("EmployeeLocation").Include("EmployeePosition").AsQueryable();
                if (!string.IsNullOrWhiteSpace(search))
                {
                    try
                    {
                        data = data.Where(x => (x.EmpId.ToString().ToLower().Contains(search.Trim().ToLower())) ||
                        x.EmpName.ToLower().Contains(search.Trim().ToLower()) ||
                        x.EmpName.ToLower().Contains(search.Trim().ToLower()) ||
                                                x.PhoneNo.Contains(search.Trim().ToLower()));
                        //||
                        //(x.Warehouse!=null && x.Warehouse.WarehouseName.ToLower().Contains(search.Trim().ToLower())));
                    }

                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                try
                {
                    switch (order)
                    {
                        case "0":
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.EmpId) : data.OrderBy(x => x.EmpId);
                            break;
                        case "1":
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.EmpName) : data.OrderBy(x => x.EmpName);
                            break;
                        case "2":
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.Email) : data.OrderBy(x => x.Email);
                            break;
                        case "3":
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.DOJ) : data.OrderBy(x => x.DOJ);
                            break;
                        case "4":
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.PhoneNo) : data.OrderBy(x => x.PhoneNo);
                            break;
                        default:
                            data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(x => x.EmpName) : data.OrderBy(x => x.EmpName);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                recFiltered = data.Count();
                data = data.Skip(startRec).Take(pageSize);
                list = data.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

    }
}
