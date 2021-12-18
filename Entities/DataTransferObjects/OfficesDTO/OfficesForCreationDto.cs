﻿using Entities.DataTransferObjects.EmployeesDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.OfficesDTO
{
    public class OfficesForCreationDto
    {
        [Required(ErrorMessage = "OfficeCode is required")]
        public int OfficeId { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "PostalCode is required")]
        public Guid PostalCode { get; set; }
        [Required(ErrorMessage = "Territory is required")]
        public string Territory { get; set; }
    }
}
