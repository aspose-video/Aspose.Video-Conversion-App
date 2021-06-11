using System.Collections.Generic;

namespace Video.Pages.Models
{
    public class OtherAppsModel
    {
        public string OtherAppsTitle { get; set; }
        public IEnumerable<AnotherApp> OtherApps { get; set; }
    }
}