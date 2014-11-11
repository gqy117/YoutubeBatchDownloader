using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YoutubeBatchDownloader.Service;

namespace YoutubeBatchDownloaderWeb.Controllers
{
    public class YouTubeController : Controller
    {
        private readonly YoutubeTableHtmlParser YoutubeTableHtmlParser;
        private const string VbsFileName = "y.vbs";

        public YouTubeController()
        {
            YoutubeTableHtmlParser = new YoutubeTableHtmlParser();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Convert(string youTubeHtml)
        {
            string vbsString = YoutubeTableHtmlParser.Convert(youTubeHtml);

            var byteArray = Encoding.ASCII.GetBytes(vbsString);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", "y.vbs");   
        }
    }
}