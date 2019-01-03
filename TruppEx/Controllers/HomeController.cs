using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruppEx.Data;
using TruppEx.Models;

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
            var viewModel = new DropDownData();
            viewModel.Employees = _context.Employees.ToList();
            viewModel.LifeEventTypes = _context.LifeEventTypes.ToList();
            return View(viewModel);
        }

        public IActionResult Employee(int employeeID)
        {
            ViewData["EmployeeID"] = employeeID;
            return View();
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
