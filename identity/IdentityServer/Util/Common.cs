using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Util
{
    public static class Common
    {
        public static long ToUnixTimestamp(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = date.ToUniversalTime().Subtract(epoch);
            return time.Ticks / TimeSpan.TicksPerSecond;
        }
    }
}
