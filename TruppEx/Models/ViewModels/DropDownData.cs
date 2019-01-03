using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruppEx.Models.ViewModels
{
    public class DropDownData
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<LifeEventType> LifeEventTypes { get; set; }
    }
}
