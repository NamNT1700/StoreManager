using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserResetPassWord
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
    public class UserForceResetPassWord
    {
        public string Email { get; set; }
    }
}