using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class UserInfoDTO
    {
        /// <summary>
        /// Id của user
        /// </summary>
        public Guid Id { get; set; }

        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        /// <summary>
        /// Status user lock = true or unlock = false
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Danh sách các Role của User
        /// </summary>
        public IList<string> Roles { get; set; }
    }
}