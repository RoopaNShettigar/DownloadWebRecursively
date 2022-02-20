using System.IO;

namespace DownloadWeb
{
    public class Program
    {
        public static void Main()
        {
            CreateTargetDefaultFolder();
            DownloadClient downloadManager = new DownloadClient();
            downloadManager.ExtractUrlFromWeb();
        }

        /// <summary>
        /// This Method is to create target default folder in local disk to save the downloaded files
        /// </summary>
        private static void CreateTargetDefaultFolder()
        {
            string folderName = WebResource.LocalDirectory;
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }
    }
}