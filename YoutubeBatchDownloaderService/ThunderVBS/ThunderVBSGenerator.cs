namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;
    using YoutubeBatchDownloader.Service.ThunderVBS;

    public class ThunderVBSGenerator
    {
        private const string ThunderCreateObject = "Set ThunderAgent = CreateObject(\"ThunderAgent.Agent\")";
        private const string ThunderAddTask = "Call ThunderAgent.AddTask(\"{0}\",\"{1}\",\"\",\"\",\"\",1,0,10)";
        private const string ThunderCommitTask = "Call ThunderAgent.CommitTasks()";



        public string GenerateThunderVbs(IList<Video> input)
        {
            ThunderVBSTemplate page = new ThunderVBSTemplate(input);

            return page.TransformText();
        }
    }
}
