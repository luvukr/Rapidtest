using System;
using BL;
using DBEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLTest
{
    [TestClass]
    public class EmpBLTest
    {
        [TestMethod]
        public void AddEmployee()
        {
            Employee emp = new Employee
            {
                EmpName = "Sumit",
                GenderId = 1,
                DOB = new DateTime(),
                EmpLocation = 1,
                Address = "N/A",
                PhoneNo = "9048964042",
                IsActive = true,
                DOJ = DateTime.Now,
                EmpPosition = 1,
                Email = "abc@gmail.com"

            };
            Employee emp2 = new Employee
            {
                EmpName = "Sumit1",
                GenderId = 1,
                DOB = new DateTime(),
                EmpLocation = 1,
                Address = "N/A",
                PhoneNo = "9048984042",
                IsActive = true,
                DOJ = DateTime.Now,
                EmpPosition = 1,
                Email = "abc@gmail.com"

            };
            var res1= new EmployeeBL().AddEmployee(emp);

            var res = new EmployeeBL().AddEmployee(emp2);

        }

        [TestMethod]
        public void UpdateEmployee()
        {
            Employee emp = new Employee
            {
                EmpId = new Guid("00000000-0000-0000-0000-000000000000"),
                EmpName = "Sumit",
                GenderId = 1,
                DOB = new DateTime(),
                EmpLocation = 1,
                Address = "Address",
                PhoneNo = "9048964042",
                IsActive = true,
                DOJ = DateTime.Now,
                EmpPosition = 1,
                Email = "abc@gmail.com"

            };
            new EmployeeBL().UpdateEmployee(emp);

        }

        [TestMethod]
        public void GetEmployees()
        {

            var res = new EmployeeBL().GetEmployees();
        }

        [TestMethod]
        public void DeleteEmployees()
        {

            var res = new EmployeeBL().DeleteEmployee(new Guid("65160FE2-5E31-4E6D-B076-B8AF7D783F35"));
        }
    }
}
