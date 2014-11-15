namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using FluentAssertions;
    using YoutubeBatchDownloader.Model;

    [TestClass]
    public class FileReaderTest : TestBase
    {
        [TestMethod]
        public void ReadStringTest()
        {
            // Arrange
            string expected = "1";
            string fileName = "Utility\\FileReaderTest.txt";

            // Act
            string actual = FileReader.ReadString(fileName);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
