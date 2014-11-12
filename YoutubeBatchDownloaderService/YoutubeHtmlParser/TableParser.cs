namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class TableParser
    {
        private const string DataTitle = "data-title=\"([^\\\"]+)\"";
        private const string DataVideo = "data-video-id=\"([^\"]+)\"";
        private ISequence GroupPosition { get; set; }

        public IList<Video> ParseTable(string input)
        {
            string dataTitleFirst = String.Format("{0}(.*){1}", DataTitle, DataVideo);
            string dataVideoFirst = String.Format("{0}(.*){1}", DataVideo, DataTitle);
            string regexExpressionString = String.Format("{0}|{1}", dataTitleFirst, dataVideoFirst);

            IList<Video> listVideo = new List<Video>();

            foreach (Match match in Regex.Matches(input, regexExpressionString, RegexOptions.IgnoreCase))
            {
                SetGroupPosition(match.Groups);

                listVideo.Add(new Video()
                {
                    Id = match.Groups[GroupPosition.IdGroupPosition].Value,
                    Title = match.Groups[GroupPosition.TitleGroupPosition].Value,
                });
            }

            return listVideo;
        }

        private void SetGroupPosition(GroupCollection groupCollection)
        {
            if (groupCollection[1].Length != 0)
            {
                GroupPosition = new TitleFirstSequence();
            }
            else
            {
                GroupPosition = new VideoFirstSequence();
            }
        }
    }
}
