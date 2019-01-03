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

        public IActionResult Details(int? employeeID, int? lifeEventTypeID, DateTime? startDate, DateTime? endDate)
        {
            ViewData["EmployeeID"] = employeeID != null ? employeeID.Value : 100;
            ViewData["LifeEventTypeID"] = lifeEventTypeID != null ? lifeEventTypeID.Value : 100;
            ViewData["StartDate"] = startDate != null ? startDate.Value : DateTime.Now;
            ViewData["EndDate"] = endDate != null ? endDate.Value : DateTime.Now;
            return View();
        }
    }
}
