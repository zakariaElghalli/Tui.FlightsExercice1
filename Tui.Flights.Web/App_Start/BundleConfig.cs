using System.Web.Optimization;

namespace Tui.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/toastr.min.css",
                "~/Content/Site.less"));
           bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/tui.js"));  
        }

       
    }
}