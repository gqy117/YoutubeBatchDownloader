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
        #endregion

        #region Init
        [InjectionMethod]
        public void Init(StandardTxtGenerator standardTxtGenerator)
        {
            CurrentGenerator = standardTxtGenerator;
        }
        #endregion
    }
}
