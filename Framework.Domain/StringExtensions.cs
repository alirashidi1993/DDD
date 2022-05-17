using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public static class StringExtensions
    {
        public static TimeSpan ConvertToTimeSpan(this string time)
        {
            var hour = time.Split(':')[0];
            var minute = time.Split(':')[1];
            hour = hour.Substring(0, 1) == "0" ? hour.Substring(1, 1) : hour;

            return TimeSpan.FromHours(int.Parse(hour)) + TimeSpan.FromMinutes(int.Parse(minute));
        }
    }
}
