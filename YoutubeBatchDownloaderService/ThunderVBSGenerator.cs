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
        private const string ThunderAddTask = "Call ThunderAgent.AddTask(\"{0}\",\"{1}\",\"\",\"\",\"\",1,0,10)";
        private const string ThunderCommitTask = "Call ThunderAgent.CommitTasks()";

        private int StartPosition = 1;
        private bool DoesAddPrefix = true;

        public string GenerateThunderVbs(IList<Video> input)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ThunderCreateObject);

            if (input != null && input.Count > 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    result.AppendLine(String.Format(ThunderAddTask, input[i].DownloadUrl, GetFileName(input[i].FileName, i)));
                }
            }

            result.Append(ThunderCommitTask);

            return result.ToString();
        }

        private string GetFileName(string fileName, int i)
        {
            string prefix = DoesAddPrefix ? (StartPosition + i).ToString("000") : String.Empty;

            return prefix + fileName;
        }
    }
}
