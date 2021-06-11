namespace Video.Pages.Services
{
    public class PageConfig
    {
        public static string PageUrl;
        public static string ApiUrl;
        static PageConfig() {
            PageUrl = "/video/";
            ApiUrl = "/video/{0}/api/";
        }
    }
}
