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

    public class YoutubeHtmlParserStandard : YoutubeHtmlParser<VideoStandard>, IYoutubeHtmlParser
    {
        #region Properties
        public string SaveAsFileName
        {
            get { return "YoutubeDownload.txt"; }
        }
        private StandardTxtGenerator StandardTxtGenerator { get; set; } 
        #endregion

        #region Init
        [InjectionMethod]
        public void Init(StandardTxtGenerator standardTxtGenerator)
        {
            StandardTxtGenerator = standardTxtGenerator;
        }
        #endregion

        #region Convert
        public override string Convert(string youtubeHtmlString)
        {
            var videoList = ConvertVideoList(youtubeHtmlString);
            string vbsString = StandardTxtGenerator.GenerateTxt(videoList);

            return vbsString;
        }

        public string Convert(string youtubeHtmlString, int startPosition)
        {
            return Convert(youtubeHtmlString);
        }
        #endregion
    }
}
