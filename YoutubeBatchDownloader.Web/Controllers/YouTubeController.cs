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
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service;

    public class YouTubeController : BaseController
    {
        private YoutubeHtmlParserVBS YoutubeTableHtmlParserVBS { get; set; }
        private YoutubeHtmlParserStandard YoutubeHtmlParserStandard { get; set; }
        private IYoutubeHtmlParser YoutubeHtmlParser { get; set; }
        private IList<IYoutubeHtmlParser> IListYoutubeHtmlParser { get; set; }

        [InjectionMethod]
        public void Init(YoutubeHtmlParserVBS youtubeHtmlParserVBS, YoutubeHtmlParserStandard youtubeHtmlParserStandard)
        {
            YoutubeTableHtmlParserVBS = youtubeHtmlParserVBS;
            YoutubeHtmlParserStandard = youtubeHtmlParserStandard;

            IListYoutubeHtmlParser = new List<IYoutubeHtmlParser>()
            {
                YoutubeTableHtmlParserVBS,
                YoutubeHtmlParserStandard
            };
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Convert(HomeView homeView)
        {
            YoutubeHtmlParser = IListYoutubeHtmlParser[homeView.ConvertMethod];

            string vbsString = YoutubeHtmlParser.Convert(homeView.YouTubeHtml, homeView.StartPosition);

            return File(vbsString, YoutubeHtmlParser.SaveAsFileName);
        }
    }
}