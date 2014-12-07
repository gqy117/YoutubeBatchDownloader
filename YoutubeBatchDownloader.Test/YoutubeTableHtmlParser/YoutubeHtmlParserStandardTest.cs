using Microsoft.Practices.Unity;

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
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class YoutubeHtmlParserStandardTest : YoutubeHtmlParserTest<YoutubeHtmlParserStandard>
    {
        #region Properties
        protected YoutubeHtmlParserStandard YoutubeHtmlParserStandard { get; set; }
        protected const string FileParseGenerateStandardTest = "YoutubeTableHtmlParser\\GenerateStandard.txt";
        protected string GenerateStandardTxtTest { get; set; }
        #endregion

        #region Init
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            InitGenerateStandardTxtTest();
        }

        protected override void InitCurrentYoutubeHtmlPaser()
        {
            YoutubeHtmlParserStandard = Container.Resolve<YoutubeHtmlParserStandard>();
            this.CurrentYoutubeHtmlPaser = YoutubeHtmlParserStandard;
        }

        private void InitGenerateStandardTxtTest()
        {
            GenerateStandardTxtTest = FileReader.ReadString(FileParseGenerateStandardTest);
        }
        #endregion

        [TestMethod]
        public void ConvertTest()
        {
            // Arrange
            string expected = GenerateStandardTxtTest;
            string youtubeHtmlString = ParseTableTestHtml;

            // Act
            string actual = this.CurrentYoutubeHtmlPaser.Convert(youtubeHtmlString);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ConvertWithStartPositionTest()
        {
            // Arrange
            string expected = GenerateStandardTxtTest;
            string youtubeHtmlString = ParseTableTestHtml;
            int startPosition = 1;

            // Act
            string actual = this.CurrentYoutubeHtmlPaser.Convert(youtubeHtmlString, startPosition);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
