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
        protected IGenerator CurrentGenerator { get; set; }
        #endregion

        #region Init
        [InjectionMethod]
        public virtual void Init(RegexHelper regexHelper, TableParser tableParser)
        {
            this.RegexHelper = regexHelper;
            this.TableParser = tableParser;
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
            var videoList = this.TableParser.ParseTable<TVideo>(youtubeHtml);
            videoList = this.RegexHelper.RemoveInvalidCharacters(videoList);

            return videoList;
        }
    }
}
