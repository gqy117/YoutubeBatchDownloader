namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.ThunderVBS;

    [TestClass]
    public class ThunderVBSPartialTest : TestBase
    {
        [TestMethod]
        public void GenerateThunderVbsTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;

            IList<Video> input = new List<Video>()
            {
                new Video() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new Video() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
            };

            // Act
            string actual = ThunderVBSTemplate.TransformText(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GenerateThunderVbsTest_ShouldExcludeFirstRecord_WhenStartPositionIs2()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbsStartPosition2;
            int startPosition = 2;

            IList<Video> input = new List<Video>()
            {
                new Video() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new Video() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
            };

            // Act
            string actual = ThunderVBSTemplate.TransformText(input, startPosition);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
