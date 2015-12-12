namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeView
    {
        public int StartPosition { get; set; }

        public string YouTubeHtml { get; set; }

        public int ConvertMethod { get; set; }
    }
}