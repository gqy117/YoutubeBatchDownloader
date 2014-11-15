namespace YoutubeBatchDownloader.Win
{
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

    public partial class YoutubeDownloader : Form
    {
        private readonly YoutubeHtmlParser YoutubeHtmlParser;
        public YoutubeDownloader()
        {
            InitializeComponent();
            this.YoutubeHtmlParser = new YoutubeHtmlParser();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = YoutubeHtmlParser.Convert(textBoxInputHtml.Text);
            Clipboard.SetText(textBoxOutput.Text, TextDataFormat.Html);
        }
    }
}
