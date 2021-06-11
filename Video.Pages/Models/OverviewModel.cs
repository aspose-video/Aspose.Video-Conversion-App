using System.Collections.Generic;

namespace Video.Pages.Models
{
    public class OverviewModel
    {
        public string OverviewTitle { get; set; }
        public string RawHtmlOverview { get; set; }

        public List<string> AppFeatures { get; set; }

    }
}