namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.ThunderVBS;

    public class ThunderVBSGenerator
    {
        private ThunderVBSTemplate ThunderVBSTemplate { get; set; }

        [InjectionMethod]
        public void Init(ThunderVBSTemplate thunderVBSTemplate)
        {
            ThunderVBSTemplate = thunderVBSTemplate;
        }

        public string GenerateThunderVbs(IList<Video> input)
        {
            return ThunderVBSTemplate.TransformText(input);
        }
    }
}
