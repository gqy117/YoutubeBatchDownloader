using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeBatchDownloader.Service;

namespace YoutubeBatchDownloader
{
    public partial class YoutubeDownloader : Form
    {
        private readonly YoutubeTableHtmlParser YoutubeTableHtmlParser;
        public YoutubeDownloader()
        {
            InitializeComponent();
            this.YoutubeTableHtmlParser = new YoutubeTableHtmlParser();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            var videoList = YoutubeTableHtmlParser.ParseTable(textBoxInputHtml.Text);
            videoList = YoutubeTableHtmlParser.RemoveInvalidCharacters(videoList);
            string vbsString = YoutubeTableHtmlParser.GenerateThunderVbs(videoList);
            textBoxOutput.Text = vbsString;
            Clipboard.SetText(vbsString, TextDataFormat.Html);
        }
    }
}
