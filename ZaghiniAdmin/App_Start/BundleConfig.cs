using System.Web;
using System.Web.Optimization;

namespace ZaghiniAdmin
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        //"~/Scripts/echarts.simple.min.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/menus.js",
                        //"~/Scripts/OSChart.js",
                        "~/Scripts/sweetalert2.js",
                        //"~/Scripts/VisitsChart.js",
                        "~/Scripts/tinymce.min.js",
                        "~/Scripts/AjaxCalls.js",
                        "~/Scripts/site.js"
                        //"~/Scripts/theme.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/jquery-ui.theme.min.css",
                      "~/Content/sweetalert2.min.css"//,
                      //"~/Content/content.inline.min",
                      //"~/Content/content.min",
                      //"~/Content/content.mobile.min",
                      //"~/Content/skin.min",
                      //"~/Content/skin.mobile.min"
                      ));
        }
    }
}
