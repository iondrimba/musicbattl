using System.Web.Optimization;

namespace MusicBattlWebAPI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles( BundleCollection bundles )
        {
           BundleTable.EnableOptimizations = true;

           //bundles.Add(new ScriptBundle("~/bundles/site").Include(
           //             "~/Scripts/vendors/jquery-1.9.1.min.js",
           //             "~/Scripts/vendors/fastclick.js",
           //             "~/Scripts/vendors/handlebars.min.js",
           //             "~/Scripts/vendors/sha1.min.js",
           //             "~/Scripts/vendors/codebird.min.js",
           //             "~/Scripts/vendors/underscore.min.js",
           //             "~/Scripts/vendors/backbone.min.js",
           //             "~/Scripts/vendors/toastr.min.js",
           //             "~/Scripts/vendors/sdk.min.js",
           //             "~/Scripts/vendors/browserDetection.min.js",                        
           //             "~/Scripts/vendors/moment.min.js",                        

           //             "~/Scripts/gsap/plugins/CSSPlugin.js",
           //             "~/Scripts/gsap/easing/EasePack.js",
           //             "~/Scripts/gsap/TweenLite.min.js",
           //             "~/Scripts/gsap/jquery.gsap.min.js",
                        
           //             "~/Scripts/plugins/jquery.fileupload.min.js",
           //             "~/Scripts/plugins/jquery.mask.min.js",
           //             "~/Scripts/plugins/jquery.ui.widget.min.js",
           //             "~/Scripts/plugins/jquery.validate.min.js",
           //             "~/Scripts/plugins/validationHelper.min.js",
           //             "~/Scripts/plugins/plugins.min.js",
           //             "~/Scripts/plugins/dough.min.js",                        
                        
           //             "~/Scripts/utils.min.js",                   
           //             "~/Scripts/jquery.signalR-2.2.0.min.js"
           //             ));
            
        }
    }
}