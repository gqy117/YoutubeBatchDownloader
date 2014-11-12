namespace YoutubeBatchDownloaderWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using YoutubeBatchDownloader.Service;

    public class YouTubeController : BaseController
    {
        private readonly YoutubeTableHtmlParser YoutubeTableHtmlParser;
        private const string VbsFileName = "y.vbs";
        private const string DownloadFileTextPlain = "text/plain";

        public YouTubeController()
        {
            YoutubeTableHtmlParser = new YoutubeTableHtmlParser();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Convert(string youTubeHtml)
        {
            string vbsString = YoutubeTableHtmlParser.Convert(youTubeHtml);

            return File(vbsString, VbsFileName);
        }
    }
}