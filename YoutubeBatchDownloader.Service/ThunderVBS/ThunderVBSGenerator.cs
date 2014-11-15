namespace YoutubeBatchDownloader.Service
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
