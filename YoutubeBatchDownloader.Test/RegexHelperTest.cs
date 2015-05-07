namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using YoutubeBatchDownloader.Model;

    [TestClass]
    public class RegexHelperTest
    {
        private RegexHelper RegexHelper { get; set; }

        [TestInitialize]
        public void Init()
        {
            RegexHelper = new RegexHelper();
        }

        [TestMethod]
        public void RemoveInvalidCharactersTest()
        {
            // Arrange
            IList<Video> expected = new List<Video>()
            {
                new VideoVBS() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "'Starcraft2" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "!Starcraft3" },
            };

            // Act
            IList<Video> input = new List<Video>()
            {
                new VideoVBS() { Id = "nDS-56QYIb4", Title = ":Starcraft1" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "'Starcraft2" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "!Starcraft3" },
            };
            IList<Video> actual = this.RegexHelper.RemoveInvalidCharacters(input);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
