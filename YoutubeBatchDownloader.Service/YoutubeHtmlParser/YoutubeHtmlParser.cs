namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using YoutubeBatchDownloader.Model;

    public abstract class YoutubeHtmlParser<TVideo> where TVideo : Video, new()
    {
        #region Properties

        protected RegexHelper RegexHelper { get; set; }
        protected TableParser TableParser { get; set; }
        #endregion

        #region Init
        [InjectionMethod]
        public virtual void Init(RegexHelper regexHelper, TableParser tableParser)
        {
            RegexHelper = regexHelper;
            TableParser = tableParser;
        }
        #endregion

        #region Convert
        public abstract string Convert(string youtubeHtml);

        public abstract string Convert(string youtubeHtml, int startPosition);
        #endregion

        protected IList<Video> ConvertVideoList(string youtubeHtml)
        {
            var videoList = TableParser.ParseTable<TVideo>(youtubeHtml);
            videoList = RegexHelper.RemoveInvalidCharacters(videoList);

            return videoList;
        }
    }
}
