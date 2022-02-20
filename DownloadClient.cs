using HtmlAgilityPack;
using System;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;

namespace DownloadWeb
{
    public class DownloadClient
    {
        /// <summary>
        /// This method recursively traverse and get all the links in WebPage
        /// and Download each link asynchronously
        /// </summary>
        public void ExtractUrlFromWeb()
        {
            Console.WriteLine(WebResource.Extractinglinks);
            var web = new HtmlWeb();
            var htmlSnippet = web.Load(WebResource.WebUrl);
            const string regPattern = @"a href=""(?<link>.+?)""";
            Regex regex = new Regex(regPattern, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = regex.Matches(htmlSnippet.ParsedText);
            foreach (Match match in matchCollection)
            {
                string fileName = match.Groups["link"].ToString();

                var documentObject = new DocumentObject
                {
                    TargetFolder = WebResource.LocalDirectory + fileName,
                    SourceUrl = WebResource.WebUrl + fileName
                };
                DownloadFileAsync(documentObject);
            }
        }

        /// <summary>
        /// This method is to download each url asynchronously and save it specified local folder
        /// </summary>
        /// <param name="documentObject"></param>
        private void DownloadFileAsync(DocumentObject documentObject)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileAsync(new Uri(documentObject.SourceUrl), documentObject.TargetFolder);
            // wait for the current thread to complete, since the an async action will be on a new thread.
            while (webClient.IsBusy) { }
        }

        /// <summary>
        /// This is event which get raised on DownloadProgressChanged of WebClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // print progress of download.
            Console.WriteLine(WebResource.DownloadStatus, e.ProgressPercentage);
        }

        /// <summary>
        /// This is event which get raised on DownloadFileCompleted of WebClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // display completion status.
            Console.WriteLine(e.Error != null ? e.Error.Message : WebResource.DownloadCompleted);
        }
    }
}