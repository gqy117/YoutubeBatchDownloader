namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using YoutubeBatchDownloader.Model;

    public class StandardTxtGenerator : IGenerator
    {
        public string Generate(IList<Video> videoList)
        {
            return Generate(videoList, default(int));
        }

        public string Generate(IList<Video> videoList, int startPosition)
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
