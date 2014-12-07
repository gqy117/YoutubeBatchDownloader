using System.ComponentModel.Design;

namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using YoutubeBatchDownloader.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class YoutubeHtmlParserTest<TYoutubeHtmlPaser> : TestBase
    {
        #region Properties

        protected virtual TYoutubeHtmlPaser CurrentYoutubeHtmlPaser { get; set; }

        #endregion

        #region Init
        public override void Init()
        {
            base.Init();
            InitGenerateThunderTest();
        }

        protected abstract void InitGenerateThunderTest();
        #endregion
    }
}
