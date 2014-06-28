using System.Web;
using System.Web.Optimization;

namespace AIM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/charisma").Include(

                        // transition / effect library
                        "~/Script/bootstrap-transition.js",
                // alert enhancer library
                        "~/Script/bootstrap-alert.js",
                // modal / dialog library
                        "~/Script/bootstrap-modal.js",
                // custom dropdown library
                        "~/Script/bootstrap-dropdown.js",
                // scrolspy library
                        "~/Script/bootstrap-scrollspy.js",
                // library for creating tabs
                        "~/Script/bootstrap-tab.js",
                // library for advanced tooltip
                        "~/Script/bootstrap-tooltip.js",
                // popover effect library
                        "~/Script/bootstrap-popover.js",
                // button enhancer library
                        "~/Script/bootstrap-button.js",
                // accordion library (optional, not used in demo)
                        "~/Script/bootstrap-collapse.js",
                // carousel slideshow library (optional, not used in demo)
                        "~/Script/bootstrap-carousel.js",
                // autocomplete library
                        "~/Script/bootstrap-typeahead.js",
                // tour library
                        "~/Script/bootstrap-tour.js",
                // calander plugin
                        "~/Script/fullcalendar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/excanvas").Include(
                // library for cookie management
                        "~/Script/jquery.cookie.js",
                // jQuery
                        "~/Script/jquery-1.7.2.min.js",
                // jQuery UI
                        "~/Script/jquery-ui-1.8.21.custom.min.js",
                // data table plugin
                        "~/Script/jquery.dataTables.min.js",

                        // chart libraries start
                        "~/Script/excanvas.js",
                        "~/Script/jquery.flot.min.js",
                        "~/Script/jquery.flot.pie.min.js",
                        "~/Script/jquery.flot.stack.js",
                        "~/Script/jquery.flot.resize.min.js",
                // chart libraries end

                        // select or dropdown enhancer
                        "~/Script/jquery.chosen.min.js",
                // checkbox, radio, and file input styler
                        "~/Script/jquery.uniform.min.js",
                // plugin for gallery image view
                        "~/Script/jquery.colorbox.min.js",
                // rich text editor library
                        "~/Script/jquery.cleditor.min.js",
                // notification plugin
                        "~/Script/jquery.noty.js",
                // file manager library
                        "~/Script/jquery.elfinder.min.js",
                // star rating plugin
                        "~/Script/jquery.raty.min.js",
                // for iOS style toggle switch
                        "~/Script/jquery.iphone.toggle.js",
                // autogrowing textarea plugin
                        "~/Script/jquery.autogrow-textarea.js",
                // multiple file upload plugin
                        "~/Script/jquery.uploadify-3.1.min.js",
                // history.js for cross-browser state change on ajax
                        "~/Script/jquery.history.js",
                // application script for Charisma demo
                        "~/Script/charisma.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap-cerulean.css",
                      "~/Content/bootstrap-classic.css",
                      //"~/Content/bootstrap-classic.min.css",
                      //"~/Content/bootstrap-cyborg.css",
                      //"~/Content/bootstrap-journal.css",
                      //"~/Content/bootstrap-redy.css",
                      //"~/Content/bootstrap-simplex.css",
                      //"~/Content/bootstrap-slate.css",
                      //"~/Content/bootstrap-spacelab.css",
                      //"~/Content/bootstrap-united.css",
                      "~/Content/bootstrap-responsive.css",
                      //"~/Content/bootstrap-responsive.min.css",
                      "~/Content/charisma-app.css",
                      "~/Content/jquery-ui-1.8.21.custom.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/fullcalendar.print.css",
                      "~/Content/chosen.css",
                      "~/Content/uniform.default.css",
                      "~/Content/colorbox.css",
                      "~/Content/jquery.cleditor.css",
                      "~/Content/jquery.noty.css",
                      "~/Content/noty_theme_default.css",
                      "~/Content/elfinder.min.css",
                      "~/Content/elfinder.theme.css",
                      "~/Content/jquery.iphone.toggle.css",
                      "~/Content/opa-icons.css",
                      "~/Content/uploadify.css"
                      ));
        }
    }
}
