namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VideoStandard : Video
    {
        protected override string BaseUrl
        {
            get { return "http://www.youtube.com/watch?v="; }
        }
    }
}