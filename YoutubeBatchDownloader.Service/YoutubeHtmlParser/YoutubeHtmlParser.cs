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

    public class YoutubeHtmlParser
    {
        #region Properties
        private RegexHelper RegexHelper;
        private ThunderVBSGenerator ThunderVBSGenerator;
        private TableParser TableParser; 
        #endregion

        #region Init
        [InjectionMethod]
        public void Init(RegexHelper regexHelper, ThunderVBSGenerator thunderVBSGenerator, TableParser tableParser)
        {
            RegexHelper = regexHelper;
            ThunderVBSGenerator = thunderVBSGenerator;
            TableParser = tableParser;
        } 
        #endregion

        #region Convert
        public string Convert(string youtubeHtml)
        {
            var videoList = ConvertVideoList(youtubeHtml);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList);

            return vbsString;
        }

        public string Convert(string youtubeHtml, int startPosition)
        {
            var videoList = ConvertVideoList(youtubeHtml);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList, startPosition);

            return vbsString;
        } 
        #endregion

        protected IList<Video> ConvertVideoList(string youtubeHtml)
        {
            var videoList = TableParser.ParseTable(youtubeHtml);
            videoList = RegexHelper.RemoveInvalidCharacters(videoList);

            return videoList;
        }
    }
}
