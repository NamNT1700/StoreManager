using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Models
{
    public class UserPreferenceSettings
    {
        [Key]
        public Guid Guid { get; set; }
        public string UserGuid { get; set; }
        virtual public User User { get; set; }
        public string Settings { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
