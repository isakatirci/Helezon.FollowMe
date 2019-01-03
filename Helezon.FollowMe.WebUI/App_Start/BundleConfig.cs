using System.Web;
using System.Web.Optimization;

namespace Helezon.FollowMe.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));





            StyleBundle styleBundle1 = new StyleBundle("~/Content/jQuery-File-Upload");
            styleBundle1.Include(
                  "~/Content/global/plugins/fancybox/source/jquery.fancybox.css"
                , "~/Content/global/plugins/jquery-file-upload/blueimp-gallery/blueimp-gallery.min.css"
                , "~/Content/global/plugins/jquery-file-upload/css/jquery.fileupload.css"
                , "~/Content/global/plugins/jquery-file-upload/css/jquery.fileupload-ui.css");
            bundles.Add(styleBundle1);


            ScriptBundle scriptBndl = new ScriptBundle("~/bundles/Blueimp-Gallerry2");

            scriptBndl.Include(
                                "~/Content/global/plugins/fancybox/source/jquery.fancybox.pack.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/vendor/tmpl.min.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/vendor/load-image.min.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js"
                              , "~/Content/global/plugins/jquery-file-upload/blueimp-gallery/jquery.blueimp-gallery.min.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.iframe-transport.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-process.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-image.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-audio.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-video.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-validate.js"
                              , "~/Content/global/plugins/jquery-file-upload/js/jquery.fileupload-ui.js");
                              


            //Add the bundle into BundleCollection
            bundles.Add(scriptBndl);

            BundleTable.EnableOptimizations = true;


        }
    }
}
