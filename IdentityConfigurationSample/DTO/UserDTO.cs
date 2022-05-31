using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityConfigurationSample.DTO
{
    public class UserDTO
    {
        public virtual string Username { get; set; }
        public virtual string Phonenumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string Id { get; set; }
    }
}
