namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class YoutubeHtmlParser
    {
        private readonly RegexHelper RegexHelper;
        private readonly ThunderVBSGenerator ThunderVBSGenerator;
        private readonly TableParser TableParser;

        public YoutubeHtmlParser()
        {
            RegexHelper = new RegexHelper();
            ThunderVBSGenerator = new ThunderVBSGenerator();
            TableParser = new TableParser();
        }

        public string Convert(string input)
        {
            var videoList = TableParser.ParseTable(input);
            videoList = RegexHelper.RemoveInvalidCharacters(videoList);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList);

            return vbsString;
        }
    }
}
