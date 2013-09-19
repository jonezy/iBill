using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace iBill {
  public class BundleConfig {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles) {

      bundles.Add(new ScriptBundle("~/bundles/base-js").Include(
        "~/Public/js/vendor/jquery-1.9.2.min.js",
        "~/Public/js/vendor/bootstrap.min.js"));

      bundles.Add(new StyleBundle("~/Public/css/base-css").Include(
        "~/Public/css/vendor/bootstrap.min.css",
        "~/Public/css/iBill.css"));
    }
  }
}