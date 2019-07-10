using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreRazorPageAndJqueryDataTable.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Ward { get; set; }

        public string District { get; set; }
    }
}
