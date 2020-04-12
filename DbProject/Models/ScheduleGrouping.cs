using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbProject.Models {
    //This type exists just to avoid using anonymous types
    public class ScheduleGrouping {
        public string Semester { get; set; }
        public string StudentId { get; set; }
    }
}
