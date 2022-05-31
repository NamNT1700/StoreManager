using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Product
    {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public ICollection<ProductClaim> ProductClaims { get; set; }
        public Guid UserPreferenceSettingsId { get; set; }
        virtual public UserPreferenceSettings UserPreferenceSettings {get; set;}
    }
}