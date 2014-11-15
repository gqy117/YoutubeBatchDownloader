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
    public class YoutubeHtmlParserTest : TestBase
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
