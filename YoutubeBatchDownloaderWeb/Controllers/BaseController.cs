namespace YoutubeBatchDownloaderWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        protected const string DownloadFileTextPlain = "text/plain";

        protected virtual FileStreamResult File(string fileContent,string fileDownloadName)
        {
            var byteArray = Encoding.ASCII.GetBytes(fileContent);
            var stream = new MemoryStream(byteArray);

            return File(stream, DownloadFileTextPlain, fileDownloadName);
        }
    }
}