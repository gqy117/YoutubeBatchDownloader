namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VideoVBS : Video
    {
        protected override string BaseUrl
        {
            get { return "http://u.f-q.me/watch?v="; }
        }
    }
}
