using System;
using System.Collections.Generic;

namespace TruppEx.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }

        //initially thought I would use navigation properties
        public ICollection<LifeEvent> LifeEvents { get; set; } 
    }
}
