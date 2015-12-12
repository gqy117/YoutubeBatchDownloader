namespace YoutubeBatchDownloader.Service.Generator.ThunderVBS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public partial class ThunderVBSTemplate
    {
        #region Properties
        private IList<Video> ListVideo { get; set; }
        private int StartPosition = 1;
        private bool DoesAddPrefix = true;

        private string FileName { get; set; }
        #endregion

        #region Transform
        public virtual string TransformText(IList<Video> listVideo)
        {
            this.ListVideo = listVideo;
            this.SetFileNameWithPrefix();

            return this.TransformText();
        }
        public virtual string TransformText(IList<Video> listVideo, int startPosition)
        {
            this.StartPosition = startPosition;

            return this.TransformText(listVideo);
        } 
        #endregion

        private void SetFileNameWithPrefix()
        {
            for (int i = 0; i < ListVideo.Count; i++)
            {
                this.ListVideo[i].FileNameWithPrefix = GetFileName(ListVideo[i].FileName, i);
            }
        }

        private string GetFileName(string fileName, int i)
        {
            string prefix = this.DoesAddPrefix ? (this.StartPosition + i).ToString("000") : String.Empty;

            return prefix + fileName;
        }
    }
}
