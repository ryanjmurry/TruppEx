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
            ViewData["LifeEventTypeID"] = lifeEventTypeID;
            return View();
        }

        public IActionResult Date(DateTime? startDate, DateTime? endDate)
        {
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;
            return View();
        }
    }
}
