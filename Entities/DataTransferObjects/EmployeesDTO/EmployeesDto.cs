using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.EmployeesDTO
{
    public class EmployeesDto
    {

        
        public int EmployeeNumber { get; set; }
      
        public string LastName { get; set; }
       
        public string FirstName { get; set; }
      
        public string Extension { get; set; }
       
        public string Email { get; set; }
        
        public string OfficeCode { get; set; }
       
        public string ReportsTo { get; set; }
       
        public string JobTitle { get; set; }

       
       
        public Offices Offices { get; set; }
       
    }
}
