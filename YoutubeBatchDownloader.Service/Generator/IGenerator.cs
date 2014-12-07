namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public interface IGenerator
    {
        string Generate(IList<Video> input);
        string Generate(IList<Video> input, int startPosition);
    }
}
