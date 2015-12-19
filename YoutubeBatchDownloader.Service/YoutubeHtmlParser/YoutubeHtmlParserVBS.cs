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

    public class YoutubeHtmlParserVBS : YoutubeHtmlParser, IYoutubeHtmlParser
    {
        #region Properties
        public string SaveAsFileName
        {
            get { return "y.vbs"; }
        }
        #endregion

        #region Init
        [InjectionMethod]
        public void Init(ThunderVBSGenerator thunderVBSGenerator)
        {
            this.CurrentGenerator = thunderVBSGenerator;
        }
        #endregion

        #region Methods

        protected override Video CreateSingleVideo()
        {
            return new VideoVBS();
        }

        #endregion
    }
}