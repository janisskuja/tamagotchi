using System.IO;

namespace TamaDomain
{
    public static class Constants
    {
        private static string DBPath = Path.Combine(
                    Windows.Storage.ApplicationData.Current.LocalFolder.Path, "metrotama.db");

        public static string DbPath
        {
            get { return DBPath; }
            set { DBPath = value; }
        }
    }
}
