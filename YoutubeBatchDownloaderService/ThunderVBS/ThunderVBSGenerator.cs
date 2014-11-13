namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.ThunderVBS;

    public class ThunderVBSGenerator
    {
        public string GenerateThunderVbs(IList<Video> input)
        {
            ThunderVBSTemplate vbsTemplate = new ThunderVBSTemplate(input);

            return vbsTemplate.TransformText();
        }
    }
}
