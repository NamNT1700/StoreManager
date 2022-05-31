using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class UserPreferenceSettingsDTO
    {
        public string UserGuid { get; set; }
        public string Settings { get; set; }
        public Guid ProductId { get; set; }
    }
    public class UserPreferenceSettingsUpdateDTO
    {
        public string Settings { get; set; }
    }
}
