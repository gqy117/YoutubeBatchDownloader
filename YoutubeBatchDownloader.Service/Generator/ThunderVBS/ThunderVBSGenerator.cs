namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Antlr3.ST;
    using Microsoft.Practices.Unity;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.Generator.ThunderVBS;

    public class ThunderVBSGenerator : IGenerator
    {
        private StringTemplate ThunderVBSTemplate { get; set; }

        [InjectionMethod]
        public void Init(ThunderVBSTemplate thunderVBSTemplate)
        {
            StringTemplateGroup templates = new StringTemplateGroup("ThunderVBS", @"Generator\ThunderVBS");

            this.ThunderVBSTemplate = templates.GetInstanceOf("ThunderVBSTemplate");
        }

        public string Generate(IList<Video> input)
        {
            return Generate(input, 1);
        }

        public string Generate(IList<Video> input, int startPosition)
        {
            SetFileNameWithPrefix(input, startPosition);

            this.ThunderVBSTemplate.SetAttribute("ListVideo", input);

            return this.ThunderVBSTemplate.ToString();
        }

        private void SetFileNameWithPrefix(IList<Video> listVideo, int startPosition)
        {
            for (int i = 0; i < listVideo.Count; i++)
            {
                listVideo[i].FileNameWithPrefix = GetFileName(listVideo[i].FileName, i, startPosition);
            }
        }

        private string GetFileName(string fileName, int i, int startPosition)
        {
            string prefix = (startPosition + i).ToString("000");

            return prefix + fileName;
        }
    }
}
