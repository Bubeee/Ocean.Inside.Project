// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ocean.Inside.Project
{
    using System.Web.Optimization;

    /// <summary>
    ///     The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include("~/js/core.js", "~/js/scripts.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap3js").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
            bundles.Add(
                new StyleBundle("~/bundles/bootstrap3").Include("~/Content/bootstrap.css", "~/Content/bootstrap-theme.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap4js").Include("~/css/Bootstrap4/js/bootstrap.js"));
            bundles.Add(
                new StyleBundle("~/bundles/bootstrap4").Include("~/css/Bootstrap4/css/bootstrap.css",
                    "~/css/Bootstrap4/css/bootstrap-grid.css", "~/css/Bootstrap4/css/bootstrap-reboot.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/vkapi").Include(
                    "~/js/openapi.js"));

            bundles.Add(
                new StyleBundle("~/bundles/styles").Include("~/css/fonts.css", "~/css/style.css", "~/css/custom_styles.css"));
        }
    }
}