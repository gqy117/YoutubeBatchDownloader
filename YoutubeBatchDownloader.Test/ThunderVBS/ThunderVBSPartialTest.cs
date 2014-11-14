namespace YoutubeBatchDownloader.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using System.IO;
    using System.Collections.Generic;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.ThunderVBS;

    [TestClass]
    public class ThunderVBSPartialTest : HtmlParserTestBase
    {
        [TestMethod]
        public void GenerateThunderVbsTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;

            IList<Video> input = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft2"},
            };

            // Act
            ThunderVBSTemplate vbsTemplate = new ThunderVBSTemplate(input);
            string actual = vbsTemplate.TransformText();

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
