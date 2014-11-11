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
    public class YoutubeTableHtmlParserTest
    {
        private YoutubeTableHtmlParser YoutubeTableHtmlParser { get; set; }
        [TestInitialize]
        public void Init()
        {
            YoutubeTableHtmlParser = new YoutubeTableHtmlParser();
        }

        [TestMethod]
        public void ParseTableTest()
        {
            // Arrange
            #region expected
            IList<Video> expected = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft 2: Toby Sucks at Gaming - Part 1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft 2: Toby Sucks at Gaming - Part 2"},
            };
            #endregion
            #region input
            string input;
            using (StreamReader sr = new StreamReader("YoutubeTableHtmlParserTest\\ParseTableTest.html"))
            {
                input = sr.ReadToEnd();
            }
            #endregion

            // Act
            IList<Video> actual = this.YoutubeTableHtmlParser.ParseTable(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void RemoveInvalidCharactersTest()
        {
            // Arrange
            IList<Video> expected = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft2"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft3"},
            };

            // Act
            IList<Video> input = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = ":Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "'Starcraft2"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "!Starcraft3"},
            };
            IList<Video> actual = this.YoutubeTableHtmlParser.RemoveInvalidCharacters(input);

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GenerateThunderVbsTest()
        {
            // Arrange
            string expected;
            using (StreamReader sr = new StreamReader("YoutubeTableHtmlParserTest\\GenerateThunderVbsTest.vbs"))
            {
                expected = sr.ReadToEnd();
            }

            // Act
            IList<Video> input = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft2"},
            };
            string actual = this.YoutubeTableHtmlParser.GenerateThunderVbs(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
