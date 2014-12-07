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

    public class YoutubeHtmlParserVBS : YoutubeHtmlParser<VideoVBS>
    {
        #region Properties
        private ThunderVBSGenerator ThunderVBSGenerator;
        #endregion

        #region Init
        [InjectionMethod]
        public void Init(ThunderVBSGenerator thunderVBSGenerator)
        {
            ThunderVBSGenerator = thunderVBSGenerator;
        }
        #endregion

        #region Convert
        public override string Convert(string youtubeHtmlString)
        {
            var videoList = ConvertVideoList(youtubeHtmlString);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList);

            return vbsString;
        }

        public string Convert(string youtubeHtmlString, int startPosition)
        {
            var videoList = ConvertVideoList(youtubeHtmlString);
            string vbsString = ThunderVBSGenerator.GenerateThunderVbs(videoList, startPosition);

            return vbsString;
        } 
        #endregion
    }
}
