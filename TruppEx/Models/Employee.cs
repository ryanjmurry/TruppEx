using System;
using System.Collections.Generic;

namespace TruppEx.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }

        public ICollection<LifeEvent> LifeEvents { get; set; }
    }
}
