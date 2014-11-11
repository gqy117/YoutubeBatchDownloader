namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            return RemoveString(input,ExclamatoryMark);
        }
        
        private string RemoveString(string input, string removedMark)
        {
            return input.Replace(removedMark, String.Empty);
        }
    }
}
