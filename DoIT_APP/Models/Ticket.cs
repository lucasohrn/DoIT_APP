using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIT_APP.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; }
    }
}
