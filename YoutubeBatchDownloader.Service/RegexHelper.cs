namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class RegexHelper
    {
        public IList<Video> RemoveInvalidCharacters(IList<Video> input)
        {
            foreach (var video in input)
            {
                video.Title = Path.GetInvalidFileNameChars().Aggregate(video.Title, (current, c) => current.Replace(c.ToString(), string.Empty));
            }

            return input;
        }
    }
}