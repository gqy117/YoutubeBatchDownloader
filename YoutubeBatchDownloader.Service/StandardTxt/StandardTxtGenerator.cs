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

    public class StandardTxtGenerator
    {
        public string GenerateTxt(IList<Video> videoList)
        {
            string youtubeString = String.Empty;

            if (videoList != null && videoList.Count > 0)
            {
                youtubeString = String.Join(Environment.NewLine, videoList.Select(x => x.DownloadUrl));
            }

            return youtubeString;
        }
    }
}
