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
        private RegexHelper RegexHelper;
        private ThunderVBSGenerator ThunderVBSGenerator;
        private TableParser TableParser;

        #region Init
        [InjectionMethod]
        public void Init(RegexHelper regexHelper, ThunderVBSGenerator thunderVBSGenerator, TableParser tableParser)
        {
            RegexHelper = regexHelper;
            ThunderVBSGenerator = thunderVBSGenerator;
            TableParser = tableParser;
        } 
        #endregion

        public string Convert(string input)
        {
            var videoList = TableParser.ParseTable(input);
            videoList = RegexHelper.RemoveInvalidCharacters(videoList);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList);

            return vbsString;
        }

        public string Convert(string input, int startPosition)
        {
            var videoList = TableParser.ParseTable(input);
            videoList = RegexHelper.RemoveInvalidCharacters(videoList);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList, startPosition);

            return vbsString;
        }
    }
}
