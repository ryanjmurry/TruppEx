using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruppEx.Data;
using TruppEx.Models;
using TruppEx.Models.ViewModels;

namespace TruppEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly TruppContext _context;

        public HomeController(TruppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DropDownData viewModel = new DropDownData
            {
                Employees = _context.Employees.ToList(),
                LifeEventTypes = _context.LifeEventTypes.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Employee(int employeeID)
        {
            EmployeeData employeeData = new EmployeeData
            {
                LifeEventTypes = from le in _context.LifeEvents
                                 join lt in _context.LifeEventTypes on le.LifeEventTypeID equals lt.LifeEventTypeID
                                 where le.EmployeeID == employeeID
                                 select lt,
                LifeEvents = from le in _context.LifeEvents
                             join lt in _context.LifeEventTypes on le.LifeEventTypeID equals lt.LifeEventTypeID
                             where le.EmployeeID == employeeID
                             select le,
                Employees = from ee in _context.Employees
                            where ee.EmployeeID == employeeID
                            select ee
            };
            return View(employeeData);
        }

        public IActionResult Type(int lifeEventTypeID)
        {
            EmployeeData employeeData = new EmployeeData
            {
                LifeEvents = from le in _context.LifeEvents
                             join ee in _context.Employees on le.EmployeeID equals ee.EmployeeID
                             where le.LifeEventTypeID == lifeEventTypeID
                             select le,
                Employees = from le in _context.LifeEvents
                            join ee in _context.Employees on le.EmployeeID equals ee.EmployeeID
                            where le.LifeEventTypeID == lifeEventTypeID
                            select ee,
                LifeEventTypes = from lt in _context.LifeEventTypes
                                 where lt.LifeEventTypeID == lifeEventTypeID
                                 select lt
            };
            return View(employeeData);
        }

        public IActionResult Date(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = new DateTime();
            }
            if (endDate == null)
            {
                endDate = DateTime.Now;
            }
            EmployeeData employeeData = new EmployeeData
            {
                LifeEvents = from le in _context.LifeEvents
                             join ee in _context.Employees on le.EmployeeID equals ee.EmployeeID
                             join lt in _context.LifeEventTypes on le.LifeEventTypeID equals lt.LifeEventTypeID
                             where le.EventDate >= startDate && le.EventDate <= endDate
                             select le,
                LifeEventTypes = from le in _context.LifeEvents
                                 join ee in _context.Employees on le.EmployeeID equals ee.EmployeeID
                                 join lt in _context.LifeEventTypes on le.LifeEventTypeID equals lt.LifeEventTypeID
                                 where le.EventDate >= startDate && le.EventDate <= endDate
                                 select lt,
                Employees = from le in _context.LifeEvents
                            join ee in _context.Employees on le.EmployeeID equals ee.EmployeeID
                            join lt in _context.LifeEventTypes on le.LifeEventTypeID equals lt.LifeEventTypeID
                            where le.EventDate >= startDate && le.EventDate <= endDate
                            select ee
            };

            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;
            return View(employeeData);
        }
    }
}