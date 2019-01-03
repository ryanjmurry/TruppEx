using System;
using System.Collections.Generic;

namespace TruppEx.Models.ViewModels
{
    public class EmployeeData
    {
        public IEnumerable<LifeEventType> LifeEventTypes { get; set; }
        public IEnumerable<LifeEvent> LifeEvents { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
