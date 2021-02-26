﻿using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/jquery/jquery-{version}.js",
                      "~/Scripts/jquery/jquery.validate*",
                      "~/Scripts/bootstrap/bootstrap.min.js",
                      "~/Scripts/bootstrap/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js",
                      "~/Scripts/bootstrap/bootstrap-datetimepicker/bootstrap-datetimepicker.zh-TW.js",
                      "~/Scripts/modernizr/modernizr-*",
                      "~/Scripts/Main.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap/bootstrap.min.css",
                      "~/Content/bootstrap/bootstrap-theme.min.css",
                      "~/Content/bootstrap/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css",
                      "~/Content/site.css",
                      "~/Content/Main.min.css",
                      "~/Content/pace-themes/orange/pace-theme-loading-bar.css"));

            //bundles.Add(new ScriptBundle("~/bundles/pace").Include(
            //          "~/Scripts/pace.js"));
        }
    }
}
