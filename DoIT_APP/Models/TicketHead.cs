using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIT_APP.Models
{
    public class TicketHead
    {
        public int TicketHeadId { get; set; }
        public string TicketHeadName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; }
        public int ProjectId { get; set; }
    }
}
