namespace YoutubeBatchDownloader.Test
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
    public class TableParserTest : TestBase
    {
        [TestMethod]
        public void ParseTableTest()
        {
            // Arrange
            IList<Video> expected = new List<Video>()
            {
                new Video(){ Id = "nDS-56QYIb4", Title = "Starcraft1"},
                new Video(){ Id = "ElwN1KP0EZk", Title = "Starcraft2"},
            };

            string input = ParseTableTestHtml;

            // Act
            IList<Video> actual = this.TableParser.ParseTable(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
