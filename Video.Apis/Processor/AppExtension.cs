using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Apis.Processor
{
    public static class AppExtension
    {
        public static string FormatPageName(this string pageName) {
            return pageName.Replace("/", "").Replace(@"\", "").Replace("<","").Replace(">", "");
        }
    }
}
