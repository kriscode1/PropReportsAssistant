//Extensions class for extension methods

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropReportsAssistant
{
    public static class Extensions
    {
        public static string ToStringCustom(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}