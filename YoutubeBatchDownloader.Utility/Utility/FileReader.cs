﻿namespace YoutubeBatchDownloader.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileReader
    {
        public string ReadString(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }
    }
}