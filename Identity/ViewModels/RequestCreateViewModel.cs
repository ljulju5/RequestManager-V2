using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.ViewModels
{
    public class RequestCreateViewModel
    {
        public string RequestName { get; set; }
        public Department? Department { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DateAccepted { get; set; }
    }
}
