using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityConfigurationSample.DTO
{
    public class UserResDTO
    {
        public string Id { get; set; }
        public string AccsessToken { get; set; }
        public IList<string> Roles { get; set; }
    }
}
