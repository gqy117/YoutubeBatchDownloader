namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TitleFirstSequence : ISequence
    {
        public int IdGroupPosition
        {
            get
            {
                return 3;
            }
        }

        public int TitleGroupPosition
        {
            get
            {
                return 1;
            }
        }
    }
}
