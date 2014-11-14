namespace YoutubeBatchDownloader.Service.ThunderVBS
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

        public ThunderVBSTemplate(IList<Video> listVideo)
        {
            this.ListVideo = listVideo;
            SetFileNameWithPrefix();
        }

        private void SetFileNameWithPrefix()
        {
            for (int i = 0; i < ListVideo.Count; i++)
            {
                ListVideo[i].FileNameWithPrefix = GetFileName(ListVideo[i].FileName, i);
            }
        }

        private string GetFileName(string fileName, int i)
        {
            string prefix = DoesAddPrefix ? (StartPosition + i).ToString("000") : String.Empty;

            return prefix + fileName;
        }
    }
}
