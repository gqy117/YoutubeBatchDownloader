namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service;

    [TestClass]
    public class YoutubeHtmlParserVBSTest : YoutubeHtmlParserTest
    {
        protected YoutubeHtmlParserVBS YoutubeHtmlParserVBS { get; set; }
        #region Init
        [TestInitialize]
        public override void Init()
        {
            base.Init();
        }

        protected override void InitCurrentYoutubeHtmlPaser()
        {
            YoutubeHtmlParserVBS = Container.Resolve<YoutubeHtmlParserVBS>();
            this.CurrentYoutubeHtmlPaser = YoutubeHtmlParserVBS;
        }
        #endregion

        [TestMethod]
        public void ConvertTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;
            string input = ParseTableTestHtml;

            // Act
            string actual = this.CurrentYoutubeHtmlPaser.Convert(input);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ConvertTest_ShouldSetFileNameStartFrom002_WhenStartPositionIs2()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbsStartPosition2;
            string input = ParseTableTestHtml;
            int startPosition = 2;

            // Act
            string actual = this.CurrentYoutubeHtmlPaser.Convert(input, startPosition);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
