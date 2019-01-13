using BL;
using DBEntities;
using RapiddAssignment.Models;
using RapiddAssignment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapiddAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                
                
                var employees= new EmployeeBL().GetEmployees()
                    .Select(x => new EmployeeDisplayModel
                    {
                        EmpId = x.EmpId,
                        Address = x.Address,
                        IsActive = x.IsActive,
                        PerAdd = x.PerAdd,
                        DOB = x.DOB,
                        DOJ = x.DOJ,
                        DOL = x.DOL,
                        Email = x.Email,
                        EmpLocation = x.EmployeeLocation.LocationValue,
                        EmpLocationId = x.EmpLocation,
                        EmpName = x.EmpName,
                        EmpPosition = x.EmployeePosition.PositionValue,
                        EmpPositionId = x.EmpPosition,
                        Experience = x.Experience,
                        Languages = x.Languages,
                        PhoneNo = x.PhoneNo,
                        IsMale=x.IsMale

                    }).ToList();
                ViewBag.Employees = employees;
            }
            catch (Exception e)
            {
                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;

            }

            return View();
        }


        // GET: Employee/Details/5
        public ActionResult Details(Guid id)
        {
            EmployeeDisplayModel formattedEmployee = null;
            try
            {
                var employee = new EmployeeBL().GetEmployee(id);
                formattedEmployee=new EmployeeDisplayModel
                    {
                        EmpId = employee.EmpId,
                        Address = employee.Address,
                        IsActive = employee.IsActive,
                        PerAdd = employee.PerAdd,
                        DOB = employee.DOB,
                        DOJ = employee.DOJ,
                        DOL = employee.DOL,
                        Email = employee.Email,
                        EmpLocation = employee.EmployeeLocation.LocationValue,
                        EmpLocationId = employee.EmpLocation,
                        EmpName = employee.EmpName,
                        EmpPosition = employee.EmployeePosition.PositionValue,
                        EmpPositionId = employee.EmpPosition,
                        Experience = employee.Experience,
                        Languages = employee.Languages,
                        PhoneNo = employee.PhoneNo,
                        IsMale=employee.IsMale
                        
                    };

            }
            catch (Exception e)
            {

                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;
            }
            return View(formattedEmployee);

        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            try
            {
                var positions = new PositionBL().GetPositions().ToDictionary(x => x.PositionId, x => x.PositionValue);
                ViewBag.Positions = positions;
                var locations = new LocationBL().GetLocations().ToDictionary(x => x.LocationId, x => x.LocationValue);
                ViewBag.Locations = locations;
            }
            catch (Exception e)
            {

                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;
            }
            
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var employee = new Employee
                {
                    EmpName = collection["EmpName"],
                    DOB = Convert.ToDateTime(collection["DOB"]),
                    EmpLocation = Convert.ToInt32(collection["EmpLocationId"]),
                    Address = collection["Address"],
                    PhoneNo = collection["PhoneNo"],
                    IsActive = true,
                    DOJ = Convert.ToDateTime(collection["DOJ"]),
                    EmpPosition = Convert.ToInt32(collection["EmpPositionId"]),
                    Email = collection["Email"],
                    Languages = collection["Languages"],
                    GenderId = 1,
                    PerAdd = collection["PerAdd"],
                    IsMale = Convert.ToBoolean(collection["IsMale"].Split(',')[0])
                };
                
                if (collection["DOL"] != "")
                    employee.DOL = Convert.ToDateTime(collection["DOL"]);
                if (collection["Experience"] != "")
                    employee.Experience = Convert.ToDecimal(collection["Experience"]);
                var res = new EmployeeBL().AddEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;
                var positions = new PositionBL().GetPositions().ToDictionary(x => x.PositionId, x => x.PositionValue);
                ViewBag.Positions = positions;
                var locations = new LocationBL().GetLocations().ToDictionary(x => x.LocationId, x => x.LocationValue);
                ViewBag.Locations = locations;
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            EmployeeDisplayModel formattedEmployee = null;
            try
            {
                var positions = new PositionBL().GetPositions().ToDictionary(x => x.PositionId, x => x.PositionValue);
                ViewBag.Positions = positions;
                var locations = new LocationBL().GetLocations().ToDictionary(x => x.LocationId, x => x.LocationValue);
                ViewBag.Locations = locations;

                var employee = new EmployeeBL().GetEmployee(id);
                formattedEmployee = new EmployeeDisplayModel
                {
                    EmpId = employee.EmpId,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    PerAdd = employee.PerAdd,
                    DOB = employee.DOB,
                    DOJ = employee.DOJ,
                    DOL = employee.DOL,
                    Email = employee.Email,
                    EmpLocation = employee.EmployeeLocation.LocationValue,
                    EmpLocationId = employee.EmpLocation,
                    EmpName = employee.EmpName,
                    EmpPosition = employee.EmployeePosition.PositionValue,
                    EmpPositionId = employee.EmpPosition,
                    Experience = employee.Experience,
                    Languages = employee.Languages,
                    PhoneNo = employee.PhoneNo,
                    IsMale = employee.IsMale
                };
            }
            catch (Exception e)
            {

                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;
            }
            
                
             return View(formattedEmployee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                var existingEmployee = new EmployeeBL().GetEmployee(id);
                var updatedEmployee = new Employee();
                updatedEmployee.EmpId = existingEmployee.EmpId;
                updatedEmployee.EmpName = existingEmployee.EmpName;
                updatedEmployee.DOB = Convert.ToDateTime(collection["DOB"]);
                updatedEmployee.EmpLocation = Convert.ToInt32(collection["EmpLocationId"]);
                updatedEmployee.Address= collection["Address"];
                updatedEmployee.PhoneNo = collection["PhoneNo"];
                updatedEmployee.IsActive = Convert.ToBoolean(collection["IsActive"].Split(',')[0]);
                updatedEmployee.DOJ = Convert.ToDateTime(collection["DOJ"]);
                if(collection["DOL"]!="")
                    updatedEmployee.DOL = Convert.ToDateTime(collection["DOL"]);
                if (collection["Experience"] != "")
                    updatedEmployee.Experience = Convert.ToDecimal(collection["Experience"]);
                updatedEmployee.EmpPosition = Convert.ToInt32(collection["EmpPositionId"]);

                updatedEmployee.Email = collection["Email"];
                updatedEmployee.Languages = collection["Languages"];
                updatedEmployee.GenderId = existingEmployee.GenderId;
                updatedEmployee.PerAdd = collection["PerAdd"];
                updatedEmployee.IsMale = Convert.ToBoolean(collection["IsMale"].Split(',')[0]);
                // TODO: Add update logic here
                var updateResult = new EmployeeBL().UpdateEmployee(updatedEmployee);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                EmployeeDisplayModel formattedEmployee = null;

                var message = ExceptionHandler.GetExceptionMessageFormatted(e);
                ViewBag.Error = message;
                var positions = new PositionBL().GetPositions().ToDictionary(x => x.PositionId, x => x.PositionValue);
                ViewBag.Positions = positions;
                var locations = new LocationBL().GetLocations().ToDictionary(x => x.LocationId, x => x.LocationValue);
                ViewBag.Locations = locations;

                var employee = new EmployeeBL().GetEmployee(id);
                formattedEmployee = new EmployeeDisplayModel
                {
                    EmpId = employee.EmpId,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    PerAdd = employee.PerAdd,
                    DOB = employee.DOB,
                    DOJ = employee.DOJ,
                    DOL = employee.DOL,
                    Email = employee.Email,
                    EmpLocation = employee.EmployeeLocation.LocationValue,
                    EmpLocationId = employee.EmpLocation,
                    EmpName = employee.EmpName,
                    EmpPosition = employee.EmployeePosition.PositionValue,
                    EmpPositionId = employee.EmpPosition,
                    Experience = employee.Experience,
                    Languages = employee.Languages,
                    PhoneNo = employee.PhoneNo
                };
                return View(formattedEmployee);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var deleteResult = new EmployeeBL().DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
