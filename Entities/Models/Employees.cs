using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("employees")]
    public class Employees
    {
        [Required(ErrorMessage = "Employees Number is required")]
        public int EmployeesNumber { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Extension is required")]
        public string Extension { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "OfficeCode is required")]
        public string OfficeCode { get; set; }
        [Required(ErrorMessage = "Reports to some one is required")]
        public string ReportsTo { get; set; }
        [Required(ErrorMessage = "JobTitle is required")]
        public string JobTitle { get; set; }

        [ForeignKey(nameof(Offices))]
        public string officeCode { get; set; }
        public Offices Offices { get; set; }
        [ForeignKey(nameof(Employees))]
        public int EmployeesNumber2 { get; set; }
        public Employees Employees2 { get; set; }
    }
}
