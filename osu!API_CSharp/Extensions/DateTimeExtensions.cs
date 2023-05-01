using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Utils
{
    public static class DateTimeExtensions
    {
        public static string FormatMySQL(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
