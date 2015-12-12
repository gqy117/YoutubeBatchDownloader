namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TableParserTest : TestBase
    {
        [TestMethod]
        public void ParseTableTest()
        {
            // Arrange
            IList<Video> expected = new List<Video>()
            {
                new VideoVBS() { Id = "nDS-56QYIb4", Title = "Starcraft1" },
                new VideoVBS() { Id = "ElwN1KP0EZk", Title = "Starcraft2" },
            };

            string input = ParseTableTestHtml;

            // Act
            IList<Video> actual = this.TableParser.ParseTable(input);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
