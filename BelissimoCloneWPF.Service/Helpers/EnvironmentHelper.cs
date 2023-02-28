using System.IO;

namespace BelissimoCloneWPF.Service.Helpers
{
    public static class EnvironmentHelper
    {
        public static string WebRootPath { get; set; }
        public static string FilePath => Path.Combine(WebRootPath, "images");
    }
}
