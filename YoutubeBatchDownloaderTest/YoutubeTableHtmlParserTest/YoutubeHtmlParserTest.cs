namespace YoutubeBatchDownloaderTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using YoutubeBatchDownloader.Model;
    using System.IO;

    [TestClass]
    public class YoutubeHtmlParserTest : HtmlParserTestBase
    {
        [TestMethod]
        public void ConvertTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;
            string input = ParseTableTestHtml;

            // Act
            string actual = this.YoutubeTableHtmlParser.Convert(input);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

    }
}
