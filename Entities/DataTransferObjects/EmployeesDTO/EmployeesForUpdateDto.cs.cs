﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.EmployeesDTO
{
    public class EmployeesForUpdateDto
    {
        //[Required(ErrorMessage = "Last name is required")]
        //public string LastName { get; set; }
        //[Required(ErrorMessage = "First name is required")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "Extension is required")]
        //public string Extension { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //public string Email { get; set; }
        ////[Required(ErrorMessage = "OfficeCode is required")]
        ////public string OfficeCode { get; set; }
        //[Required(ErrorMessage = "Reports to some one is required")]
        //public string ReportsTo { get; set; }
        //[Required(ErrorMessage = "JobTitle is required")]
        //public string JobTitle { get; set; }


        //[Required(ErrorMessage = "OfficeCode is required")]
        //public string OfficeCode { get; set; }
        public Offices Offices { get; set; }
        //public int EmployeesNumber { get; set; }
    }
}
