using Video.Pages.Services;
using System.Collections.Generic;

namespace Video.Pages.Models
{
    public class AppModel
    {
        public ResourceAdapter Resources { get; } = new ResourceAdapter();
        public string Environment { get; set; }

        public bool IsProduction
        {
            get
            {
                if (Environment != null && Environment == "Production")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string PageTitle { get; set; }
        public string PageMetaDescription { get; set; }

        public string Title { get; set; }
        public string TitleSub { get; set; }
        public string AppURL { get; set; }
        public AudioVedioApps App { get; set; }
        public string AppName { get; set; }
        public string AppRoute { get; set; }
        public bool UploadAndRedirect { get; set; }
        public bool ShowViewerButton { get; set; }
        public ExtensionModel ExtensionModel { get; set; }
        public OverviewModel OverviewModel { get; set; }
        public HowToModel HowToModel { get; set; }
        public CanonicalModel CanonicalModel { get; set; }
        public OtherFeaturesModel OtherFeaturesModel { get; set; }
        public List<AnotherApp> OtherApps { get; set; }
        public List<string> SaveAsOptions { get; set; }
        public JSOptionsModel JSOptions { get; set; }
        public List<string> StructuralDataJson { get; set; }
        public string EmailTo { get; set; }

        public string ResourcesFromApp(string key)
        {
            return Resources[App.ToString() + key];
        }
    }
}