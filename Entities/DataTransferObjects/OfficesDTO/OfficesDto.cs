using Entities.DataTransferObjects.EmployeesDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.OfficesDTO
{
    public class OfficesDto
    {

        public int OfficeId { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Guid PostalCode { get; set; }
        public string Territory { get; set; }
        //[JsonIgnore]
        public ICollection<EmployeeInfoDto> Employees { get; set; }
    }
}
