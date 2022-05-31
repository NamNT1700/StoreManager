using IdentityServer4.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Even
{
    public class LicenseServiceFailure: Event
    {
        public LicenseServiceFailure(string error)
       : base(EventCategories.Authentication,
               "License is null",
               EventTypes.Failure,
               EventIds.UnhandledException,
               error)
        {
        }
    }
}
