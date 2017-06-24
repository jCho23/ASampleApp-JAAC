using System;
using System.IO;
namespace ASampleApp.Data
{
    public class FileAccessHelper
    {
        public FileAccessHelper()
        {
        }
#if __ANDROID__
        public static string GetLocalFilePath(string filename)
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(myPath, filename);
        }
#endif

#if __IOS__
		public static string GetLocalFilePath(string filename)
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string myLibraryFolder = System.IO.Path.Combine(myPath, "..", "Library");

            if (!System.IO.Directory.Exists(myLibraryFolder))
            {
                System.IO.Directory.CreateDirectory(myLibraryFolder);
            }

            return System.IO.Path.Combine(myLibraryFolder, filename);
        }
#endif

    }
}
