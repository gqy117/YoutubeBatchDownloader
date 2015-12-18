namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using AngleSharp.Parser.Html;
    using CsQuery;
    using YoutubeBatchDownloader.Model;

    public abstract class YoutubeHtmlParser
    {
        #region Properties

        protected RegexHelper RegexHelper { get; set; }

        protected IGenerator CurrentGenerator { get; set; }

        protected HtmlParser HtmlParser { get; set; }
        #endregion

        #region Init
        [InjectionMethod]
        public virtual void Init(
            RegexHelper regexHelper, 
            [Dependency("DefaultHtmlParser")]
            HtmlParser htmlParser)
        {
            this.RegexHelper = regexHelper;
            this.HtmlParser = htmlParser;
        }
        #endregion

        #region Convert
        #region Convert
        public virtual string Convert(string youtubeHtmlString)
        {
            var videoList = this.ConvertVideoList(youtubeHtmlString);
            string vbsString = this.CurrentGenerator.Generate(videoList);

            return vbsString;
        }

        public virtual string Convert(string youtubeHtmlString, int startPosition)
        {
            var videoList = this.ConvertVideoList(youtubeHtmlString);
            string vbsString = this.CurrentGenerator.Generate(videoList, startPosition);

            return vbsString;
        }
        #endregion
        #endregion

        protected IList<Video> ConvertVideoList(string youtubeHtml)
        {
            var videoList = this.ParseTable(youtubeHtml);
            videoList = this.RegexHelper.RemoveInvalidCharacters(videoList);

            return videoList;
        }

        private const string DATATITLE = "data-title";

        private const string DATAVIDEO = "data-video-id";

        protected abstract Video CreateSingleVideo();

        protected IList<Video> ParseTable(string youtubeHtml)
        {
            IList<Video> listVideo = new List<Video>();

            var dom = this.HtmlParser.Parse(youtubeHtml);

            var allTrs = dom.QuerySelectorAll("tr");

            foreach (var tr in allTrs)
            {
                var video = this.CreateSingleVideo();

                video.Id = tr.Attributes.GetNamedItem(YoutubeHtmlParser.DATAVIDEO).Value;
                video.Title = tr.Attributes.GetNamedItem(YoutubeHtmlParser.DATATITLE).Value;

                listVideo.Add(video);
            }

            return listVideo;
        }
    }
}