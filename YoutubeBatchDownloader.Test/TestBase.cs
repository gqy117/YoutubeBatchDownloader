namespace YoutubeBatchDownloader.Test
{
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Service;
    using YoutubeBatchDownloader.Service.ThunderVBS;
    using YoutubeBatchDownloader.Utility;

    [TestClass]
    [Ignore]
    public abstract class TestBase
    {
        #region Properties
        protected IUnityContainer Container { get; set; }
        protected YoutubeHtmlParser YoutubeTableHtmlParser { get; set; }
        protected ThunderVBSGenerator ThunderVBSGenerator { get; set; }
        protected TableParser TableParser { get; set; }
        protected ThunderVBSTemplate ThunderVBSTemplate { get; set; }
        protected FileReader FileReader { get; set; }
        protected string GenerateThunderVbsTestvbs { get; set; }
        protected string ParseTableTestHtml { get; set; }
        protected const string FileParseTableTest = "YoutubeTableHtmlParserTest\\ParseTableTest.html";
        protected const string FileGenerateThunderVbsTest = "YoutubeTableHtmlParserTest\\GenerateThunderVbsTest.vbs";
        #endregion

        #region Constructors
        [TestInitialize]
        public void Init()
        {
            InitUnityContainer();
            ResolveClasses();
            InitGenerateThunderVbsTestvbs();
            InitParseTableTestHtml();
        }

        protected virtual void ResolveClasses()
        {
            YoutubeTableHtmlParser = Container.Resolve<YoutubeHtmlParser>();
            ThunderVBSGenerator = Container.Resolve<ThunderVBSGenerator>();
            TableParser = Container.Resolve<TableParser>();
            ThunderVBSTemplate = Container.Resolve<ThunderVBSTemplate>();
            FileReader = Container.Resolve<FileReader>();
        }

        protected virtual void InitUnityContainer()
        {
            Container = new UnityContainer();
            UnityRegister.RegisterTypes(Container);
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
