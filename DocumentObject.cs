namespace DownloadWeb
{
    /// <summary>
    /// This is an object which holds the data for downloading the WebSite
    /// </summary>
    public class DocumentObject
    {
        /// <summary>
        /// Target folder to save the downloaded files
        /// </summary>
        public  string TargetFolder { get; set; }

        /// <summary>
        /// Source Url to download the Website
        /// </summary>
        public string SourceUrl { get; set; }
    }
}
