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

    public abstract class YoutubeHtmlParser
    {
        #region Properties

        protected RegexHelper RegexHelper { get; set; }

        protected IGenerator CurrentGenerator { get; set; }
        #endregion

        #region Init
        [InjectionMethod]
        public virtual void Init(RegexHelper regexHelper)
        {
            this.RegexHelper = regexHelper;
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

        private const string DATATITLE = "data-title=\"([^\\\"]+)\"";

        private const string DATAVIDEO = "data-video-id=\"([^\"]+)\"";

        private ISequence GroupPosition { get; set; }

        protected abstract Video CreateSingleVideo();

        protected IList<Video> ParseTable(string youtubeHtml)
        {
            string dataTitleFirst = String.Format("{0}(.*){1}", DATATITLE, DATAVIDEO);
            string dataVideoFirst = String.Format("{0}(.*){1}", DATAVIDEO, DATATITLE);
            string regexExpressionString = String.Format("{0}|{1}", dataTitleFirst, dataVideoFirst);

            IList<Video> listVideo = new List<Video>();

            foreach (Match match in Regex.Matches(youtubeHtml, regexExpressionString, RegexOptions.IgnoreCase))
            {
                this.SetGroupPosition(match.Groups);

                var video = this.CreateSingleVideo();
                video.Id = match.Groups[GroupPosition.IdGroupPosition].Value;
                video.Title = match.Groups[GroupPosition.TitleGroupPosition].Value;

                listVideo.Add(video);
            }

            return listVideo;
        }

        private void SetGroupPosition(GroupCollection groupCollection)
        {
            if (groupCollection[1].Length != 0)
            {
                this.GroupPosition = new TitleFirstSequence();
            }
            else
            {
                this.GroupPosition = new VideoFirstSequence();
            }
        }
    }
}