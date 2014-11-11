namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class YoutubeTableHtmlParser
    {
        private const string DataTitle = "data-title=\"([^\\\"]+)\"";
        private const string DataVideo = "data-video-id=\"([^\"]+)\"";
        private const string ThunderCreateObject = "Set ThunderAgent = CreateObject(\"ThunderAgent.Agent\")";
        private const string ThunderCommitTask = "Call ThunderAgent.CommitTasks()";

        private const int TitleFirstIdGroupPosition = 3;
        private const int TitleFirstTitleGroupPosition = 1;

        private const int VideoFirstIdGroupPosition = 4;
        private const int VideoFirstTitleGroupPosition = 6;

        private readonly RegexHelper RegexHelper;

        public YoutubeTableHtmlParser()
        {
            RegexHelper = new RegexHelper();
        }

        public IList<Video> ParseTable(string input)
        {
            string dataTitleFirst = String.Format("{0}(.*){1}", DataTitle, DataVideo);
            string dataVideoFirst = String.Format("{0}(.*){1}", DataVideo, DataTitle);
            string regexExpressionString = String.Format("{0}|{1}", dataTitleFirst, dataVideoFirst);

            IList<Video> listVideo = new List<Video>();
            int idGroupPosition;
            int titleGroupPosition;

            foreach (Match match in Regex.Matches(input, regexExpressionString, RegexOptions.IgnoreCase))
            {
                if (IsTitleFirst(match.Groups))
                {
                    idGroupPosition = TitleFirstIdGroupPosition;
                    titleGroupPosition = TitleFirstTitleGroupPosition;
                }
                else
                {
                    idGroupPosition = VideoFirstIdGroupPosition;
                    titleGroupPosition = VideoFirstTitleGroupPosition;
                }
                listVideo.Add(new Video()
                {
                    Id = match.Groups[idGroupPosition].Value,
                    Title = match.Groups[titleGroupPosition].Value,
                });
            }

            return listVideo;
        }

        private bool IsTitleFirst(GroupCollection groupCollection)
        {
            return groupCollection[1].Length != 0;
        }

        public IList<Video> RemoveInvalidCharacters(IList<Video> input)
        {
            foreach (var video in input)
            {
                video.Title = RegexHelper.ReplaceColon(video.Title);
                video.Title = RegexHelper.ReplaceExclamatoryMark(video.Title);
                video.Title = RegexHelper.ReplaceSingleQuotes(video.Title);
            }
            return input;
        }

        public string GenerateThunderVbs(IList<Video> input)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ThunderCreateObject);

            if (input != null && input.Count > 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    result.AppendLine(String.Format("Call ThunderAgent.AddTask(\"{0}\",\"{1}\",\"\",\"\",\"\",1,0,10)", input[i].DownloadUrl, (i + 1).ToString("000") + input[i].FileName));
                }
            }

            result.Append(ThunderCommitTask);

            return result.ToString();
        }
    }
}
