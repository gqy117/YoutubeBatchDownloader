namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class RegexHelper
    {
        private const string Colon = ":";
        private const string SingleQuotes = "'";
        private const string ExclamatoryMark = "!";

        public string ReplaceColon(string input)
        {
            return RemoveString(input, Colon);
        }

        public string ReplaceSingleQuotes(string input)
        {
            return RemoveString(input, SingleQuotes);
        }

        public string ReplaceExclamatoryMark(string input)
        {
            return RemoveString(input, ExclamatoryMark);
        }

        private string RemoveString(string input, string removedMark)
        {
            return input.Replace(removedMark, String.Empty);
        }

        public IList<TVideo> RemoveInvalidCharacters<TVideo>(IList<TVideo> input) where TVideo : Video
        {
            foreach (var video in input)
            {
                video.Title = ReplaceColon(video.Title);
                video.Title = ReplaceExclamatoryMark(video.Title);
                video.Title = ReplaceSingleQuotes(video.Title);
            }
            return input;
        }
    }
}
