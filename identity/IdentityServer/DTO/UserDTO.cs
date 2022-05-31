using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }     
        public string Firstname { get; set; }
        public string CompanyName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}