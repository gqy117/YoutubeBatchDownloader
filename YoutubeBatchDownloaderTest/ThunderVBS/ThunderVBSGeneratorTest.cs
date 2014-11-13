namespace YoutubeBatchDownloaderTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using System.IO;
    using System.Collections.Generic;
    using YoutubeBatchDownloader.Model;

    [TestClass]
    public class ThunderVBSGeneratorTest : HtmlParserTestBase
    {
        [TestMethod]
        public void GenerateThunderVbsTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;

            // Act
            IList<Video> input = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft2"},
            };
            string actual = this.ThunderVBSGenerator.GenerateThunderVbs(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
