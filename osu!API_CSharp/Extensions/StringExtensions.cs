using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Utils
{
    public static class StringExtensions
    {
        public static string AddUrlParameter(this string str, string key, string value, bool isFirstParameter = false)
        {
            str += (isFirstParameter ? "?" : "&") + $"{key}={value}";
            return str;
        }
    }
}
