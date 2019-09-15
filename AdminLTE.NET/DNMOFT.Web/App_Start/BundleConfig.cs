using System.Web;
using System.Web.Optimization;

namespace DNMOFT.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/AdminLTE/adminlte.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/fontawesome.css",
                      "~/Content/css/adminlte.css",
                      "~/Content/site.css"));
        }
    }
}
