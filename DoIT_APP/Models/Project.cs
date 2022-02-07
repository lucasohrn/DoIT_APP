using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIT_APP.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
    }
}
