namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using YoutubeBatchDownloader.Service;
    using YoutubeBatchDownloader.Model;

    [TestClass]
    public class ThunderVBSGeneratorTest : TestBase
    {
        [TestMethod]
        public void GenerateThunderVbsTest()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbs;

            // Act
            IList<Video> input = new List<Video>()
            {
                new VideoVBS() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
            };
            string actual = this.ThunderVBSGenerator.GenerateThunderVbs(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GenerateThunderVbsTest_ShouldSetNumberStartFrom002_WhenStartPositionIs2()
        {
            // Arrange
            string expected = GenerateThunderVbsTestvbsStartPosition2;
            int startPosition = 2;

            // Act
            IList<Video> input = new List<Video>()
            {
                new VideoVBS() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
            };
            string actual = this.ThunderVBSGenerator.GenerateThunderVbs(input, startPosition);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
