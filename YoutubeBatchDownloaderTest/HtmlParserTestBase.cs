namespace YoutubeBatchDownloaderTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Service;

    [TestClass]
    [Ignore]
    public abstract class HtmlParserTestBase
    {
        #region Properties
        protected YoutubeHtmlParser YoutubeTableHtmlParser { get; set; }
        protected ThunderVBSGenerator ThunderVBSGenerator { get; set; }
        protected TableParser TableParser { get; set; }
        protected string GenerateThunderVbsTestvbs { get; set; }
        protected string ParseTableTestHtml { get; set; }
        protected const string FileParseTableTest = "YoutubeTableHtmlParserTest\\ParseTableTest.html";
        protected const string FileGenerateThunderVbsTest = "YoutubeTableHtmlParserTest\\GenerateThunderVbsTest.vbs";
        #endregion

        #region Constructors
        [TestInitialize]
        public void Init()
        {
            YoutubeTableHtmlParser = new YoutubeHtmlParser();
            ThunderVBSGenerator = new ThunderVBSGenerator();
            TableParser = new TableParser();
            InitGenerateThunderVbsTestvbs();
            InitParseTableTestHtml();
        }

        protected virtual void InitParseTableTestHtml()
        {
            ParseTableTestHtml = FileReader.ReadString(FileParseTableTest);
        }

        protected virtual void InitGenerateThunderVbsTestvbs()
        {
            GenerateThunderVbsTestvbs = FileReader.ReadString(FileGenerateThunderVbsTest);
        }
        #endregion
    }
}
