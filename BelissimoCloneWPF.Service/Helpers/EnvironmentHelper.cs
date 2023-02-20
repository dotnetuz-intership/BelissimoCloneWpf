namespace BelissimoCloneWPF.Service.Helpers
{
    public static class EnvironmentHelper
    {
        public static string WebRootPath { get; set; }
        public static string ExcelRootPath => Path.Combine(WebRootPath, "excels");
        public static string FilePath => "images";
    }
}
