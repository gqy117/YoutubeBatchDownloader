﻿namespace YoutubeBatchDownloader.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YoutubeBatchDownloader.Service;
    using Utility;
    using Utility.UnityRegister;

    [TestClass]
    [Ignore]
    public abstract class TestBase
    {
        #region Properties
        protected IUnityContainer Container { get; set; }
        protected ThunderVBSGenerator ThunderVBSGenerator { get; set; }
        protected FileReader FileReader { get; set; }
        protected string GenerateThunderVbsTestvbs { get; set; }
        protected string GenerateThunderVbsTestvbsStartPosition2 { get; set; }
        protected string ParseTableTestHtml { get; set; }
        protected const string FileParseTableTest = "YoutubeTableHtmlParser\\ParseTableTest.html";
        protected const string FileGenerateThunderVbsTest = "YoutubeTableHtmlParser\\GenerateThunderVbsTest.vbs";
        protected const string FileGenerateThunderVbsTestStartPosition2 = "YoutubeTableHtmlParser\\GenerateThunderVbsTestStartPosition2.vbs";
        #endregion

        #region Constructors
        [TestInitialize]
        public virtual void Init()
        {
            InitUnityContainer();
            ResolveClasses();
            InitGenerateThunderVbsTestvbs();
            InitParseTableTestHtml();
        }

        protected virtual void ResolveClasses()
        {
            ThunderVBSGenerator = Container.Resolve<ThunderVBSGenerator>();
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
            GenerateThunderVbsTestvbsStartPosition2 = FileReader.ReadString(FileGenerateThunderVbsTestStartPosition2);
        }
        #endregion
    }
}
