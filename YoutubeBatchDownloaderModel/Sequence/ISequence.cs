namespace YoutubeBatchDownloader.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISequence
    {
        int IdGroupPosition { get; }
        int TitleGroupPosition { get; }
    }
}
