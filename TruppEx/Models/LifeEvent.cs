using System;
namespace TruppEx.Models
{
    public class LifeEvent
    {
        public int LifeEventID { get; set; }
        public int EmployeeID { get; set; }
        public int LifeEventTypeID { get; set; }
        public DateTime EventDate { get; set; }

        //initially thought I would use navigation properties
        public Employee Employee { get; set; }
        public LifeEventType LifeEventType { get; set; }
    }
}
