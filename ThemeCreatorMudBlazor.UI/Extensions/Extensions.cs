using MudBlazor;
using MudBlazor.Extensions.Components;
namespace ThemeCreatorMudBlazor.UI.Extensions
{
    public class Extensions
    {
        /// <summary>
        /// Return the current MudBlazor version
        /// </summary>
        public static string MudBlazorVersion => typeof(MudButton).Assembly.GetName().Version?.ToString() ?? string.Empty;
        /// <summary>
        /// Return the last server date of ThemeCreator.js in the wwwroot/js folder
        /// </summary>
        public static string ThemeCreatorJsVersion =>
            File.GetLastWriteTime(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "js", "ThemeCreator.js"))
                .ToString("yyyyMMddHHmmss");
        /// <summary>
        /// Return the last server date of app.css in the wwwroot folder
        /// </summary>
        public static string AppCssVersion =>
            File.GetLastWriteTime(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "app.css"))
                .ToString("yyyyMMddHHmmss");
        public static string AppToolTipExtensionVersion =>
            File.GetLastWriteTime(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "css", "tooltip-extensions.min.css"))
                .ToString("yyyyMMddHHmmss");
        /// <summary>
        /// Return the current MudEx version
        /// </summary>
        public static string MudExVersion => typeof(MudExDialog).Assembly.GetName().Version?.ToString() ?? string.Empty;
    }
}
