namespace YoutubeBatchDownloader
{
    partial class YoutubeDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInputHtml = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInputHtml
            // 
            this.textBoxInputHtml.Location = new System.Drawing.Point(59, 55);
            this.textBoxInputHtml.MaxLength = 0;
            this.textBoxInputHtml.Multiline = true;
            this.textBoxInputHtml.Name = "textBoxInputHtml";
            this.textBoxInputHtml.Size = new System.Drawing.Size(412, 524);
            this.textBoxInputHtml.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(670, 55);
            this.textBoxOutput.MaxLength = 0;
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(412, 524);
            this.textBoxOutput.TabIndex = 1;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(532, 306);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // YoutubeDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 715);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxInputHtml);
            this.Name = "YoutubeDownloader";
            this.Text = "Youtube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputHtml;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonConvert;
    }
}

