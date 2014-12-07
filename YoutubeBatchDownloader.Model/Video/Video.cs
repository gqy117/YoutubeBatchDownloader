namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Video
    {
        #region Properties
        protected abstract string BaseUrl { get; }

        protected virtual string DefaultExtension
        {
            get { return ".mp4"; }
        } 
        #endregion

        public Video()
        {
        }

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
