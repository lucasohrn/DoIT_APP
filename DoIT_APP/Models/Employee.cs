using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIT_APP.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
        public int DepartmentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
