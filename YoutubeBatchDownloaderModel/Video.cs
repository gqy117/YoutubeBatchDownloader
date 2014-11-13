namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Video
    {
        private const string BaseUrl = "http://u.f-q.me/watch?v=";
        private const string DefaultExtension = ".mp4";

        public string Id { get; set; }
        public string Title { get; set; }
        public string DownloadUrl
        {
            get
            {
                return BaseUrl + Id;
            }
        }

        public string FileName
        {
            get
            {
                return Title + DefaultExtension;
            }
        }
        public string FileNameWithPrefix { get; set; }
    }
}
