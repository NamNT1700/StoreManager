using Entities.Models;
using System.Collections.Generic;

namespace Entities.DataTransferObjects.EmployeesDTO
{
    public class EmployeesDto
    {
        public int EmployeeId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
        public string Extension { get; set; }

        public string Email { get; set; }
        public int OfficeId { get; set; }
        public string ReportsTo { get; set; }
        public string JobTitle { get; set; }
        public Offices Offices { get; set; }
        public Employees EmployeesBoss { get; set; }
        public ICollection<Employees> EmployeesOfMine { get; set; }
        public ICollection<Customers> Customers { get; set; }

    }
}
