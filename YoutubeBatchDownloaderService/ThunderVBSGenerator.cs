namespace YoutubeBatchDownloader.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using YoutubeBatchDownloader.Model;

    public class ThunderVBSGenerator
    {
        private const string ThunderCreateObject = "Set ThunderAgent = CreateObject(\"ThunderAgent.Agent\")";
        private const string ThunderCommitTask = "Call ThunderAgent.CommitTasks()";
        private int StartPosition = 1;

        public string GenerateThunderVbs(IList<Video> input)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ThunderCreateObject);

            if (input != null && input.Count > 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    result.AppendLine(String.Format("Call ThunderAgent.AddTask(\"{0}\",\"{1}\",\"\",\"\",\"\",1,0,10)", input[i].DownloadUrl, (StartPosition + i).ToString("000") + input[i].FileName));
                }
            }

            result.Append(ThunderCommitTask);

            return result.ToString();
        }
    }
}
