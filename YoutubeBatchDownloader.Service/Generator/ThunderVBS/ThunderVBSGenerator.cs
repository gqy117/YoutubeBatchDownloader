namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.Generator.ThunderVBS;

    public class ThunderVBSGenerator : IGenerator
    {
        private ThunderVBSTemplate ThunderVBSTemplate { get; set; }

        [InjectionMethod]
        public void Init(ThunderVBSTemplate thunderVBSTemplate)
        {
            this.ThunderVBSTemplate = thunderVBSTemplate;
        }

        public string Generate(IList<Video> input)
        {
            return this.ThunderVBSTemplate.TransformText(input);
        }

        public string Generate(IList<Video> input, int startPosition)
        {
            return this.ThunderVBSTemplate.TransformText(input, startPosition);
        }
    }
}
