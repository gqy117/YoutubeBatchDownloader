namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.SqlServer.Server;

    public interface IYoutubeHtmlParser
    {
        string SaveAsFileName { get; }
        string Convert(string youtubeHtmlString);
        string Convert(string youtubeHtmlString, int startPosition);
    }
}
