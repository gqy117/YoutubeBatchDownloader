namespace YoutubeBatchDownloader.Web.Controllers
{
    using Microsoft.Practices.Unity;
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
        private YoutubeHtmlParser YoutubeTableHtmlParser { get; set; }
        private const string VbsFileName = "y.vbs";

        [InjectionMethod]
        public void Init(YoutubeHtmlParser youtubeHtmlParser)
        {
            YoutubeTableHtmlParser = youtubeHtmlParser;
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