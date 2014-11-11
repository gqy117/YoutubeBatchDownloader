﻿namespace YoutubeBatchDownloaderTest
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
        private string GenerateThunderVbsTestvbs { get; set; }
        private string ParseTableTestHtml { get; set; }

        [TestInitialize]
        public void Init()
        {
            YoutubeTableHtmlParser = new YoutubeTableHtmlParser();
            InitGenerateThunderVbsTestvbs();
            InitParseTableTestHtml();
        }

        private void InitParseTableTestHtml()
        {
            using (StreamReader sr = new StreamReader("YoutubeTableHtmlParserTest\\ParseTableTest.html"))
            {
                ParseTableTestHtml = sr.ReadToEnd();
            }
        }

        private void InitGenerateThunderVbsTestvbs()
        {
            using (StreamReader sr = new StreamReader("YoutubeTableHtmlParserTest\\GenerateThunderVbsTest.vbs"))
            {
                GenerateThunderVbsTestvbs = sr.ReadToEnd();
            }
        }

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
            string expected = GenerateThunderVbsTestvbs;

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
