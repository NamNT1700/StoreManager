using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("employees")]
    public class Employees
    {
        [Required(ErrorMessage = "Employees Number is required")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Extension is required")]
        public string Extension { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "OfficeCode is required")]
        public int OfficeIdFK { get; set; }
        [Required(ErrorMessage = "Reports to some one is required")]
        public string ReportsTo { get; set; }
        [Required(ErrorMessage = "JobTitle is required")]
        public string JobTitle { get; set; }
        virtual public Offices Offices { get; set; }
        virtual public Employees EmployeesBoss { get; set; }
        virtual public ICollection<Employees> EmployeesOfMine { get; set; }
        public ICollection<Customers> Customers { get; set; }
    }
}
