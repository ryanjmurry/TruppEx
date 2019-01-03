using System;
using System.Collections.Generic;
namespace TruppEx.Models
{

    public class LifeEventType
    {
        public int LifeEventTypeID { get; set; }
        public string Type { get; set; }

        public ICollection<LifeEvent> LifeEvents { get; set; }
    }
}
