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
        public void ReplaceColonTest()
        {
            // Arrange
            var expected = "data-video-id=\"gVTKR8JzX1E\" data-title=\"Starcraft 2 - Random Murloc Impression - Toby Sucks at Gaming - Part 6\"";
            var input = "data-video-id=\"gVTKR8JzX1E\" data-title=\"Starcraft 2: - Random Murloc Impression - Toby Sucks at Gaming - Part 6\"";

            // Act
            string actual = this.RegexHelper.ReplaceColon(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ReplaceSingleQuotesTest()
        {
            // Arrange
            var expected = "data-video-id=\"nSxuy1Op3bQ\" data-title=\"Starcraft 2 - Dont Let The Goose Burn - Toby Sucks at Gaming - Part 14\"";
            var input = "data-video-id=\"nSxuy1Op3bQ\" data-title=\"Starcraft 2 - Don't Let The Goose Burn - Toby Sucks at Gaming - Part 14\"";

            // Act
            string actual = this.RegexHelper.ReplaceSingleQuotes(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ReplaceExclamatoryMarkTest()
        {
            // Arrange
            var expected = "data-video-id=\"i1TdZhxp6hw\" data-title=\"Starcraft 2 - LAVA - Part 20 (Toby Sucks at Gaming)\"";
            var input = "data-video-id=\"i1TdZhxp6hw\" data-title=\"Starcraft 2 - LAVA! - Part 20 (Toby Sucks at Gaming)\"";

            // Act
            string actual = this.RegexHelper.ReplaceExclamatoryMark(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void RemoveInvalidCharactersTest()
        {
            // Arrange
            IList<Video> expected = new List<Video>()
            {
                new Video() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new Video() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
                new Video() { Id = "ElwN1KP0EZk", Title = "Starcraft3" },
            };

            // Act
            IList<Video> input = new List<Video>()
            {
                new Video() { Id = "nDS-56QYIb4", Title = ":Starcraft1" },
                new Video() { Id = "ElwN1KP0EZk", Title = "'Starcraft2" },
                new Video() { Id = "ElwN1KP0EZk", Title = "!Starcraft3" },
            };
            IList<Video> actual = this.RegexHelper.RemoveInvalidCharacters(input);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
