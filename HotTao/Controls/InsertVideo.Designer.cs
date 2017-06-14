namespace HotTao.Controls
{
    partial class InsertVideo
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
            this.components = new System.ComponentModel.Container();
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.btnStartUpdate = new System.Windows.Forms.Button();
            this.btnOpenUrl = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.openInsertVideo = new System.Windows.Forms.OpenFileDialog();
            this.hotPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.lbPath);
            this.hotPanel1.Controls.Add(this.btnStartUpdate);
            this.hotPanel1.Controls.Add(this.btnOpenUrl);
            this.hotPanel1.Controls.Add(this.panel7);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(332, 180);
            this.hotPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "仅支持GIF、MP4格式，最大20M";
            // 
            // lbPath
            // 
            this.lbPath.Location = new System.Drawing.Point(16, 86);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(304, 24);
            this.lbPath.TabIndex = 58;
            this.lbPath.Text = "未选择文件";
            this.lbPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPath.Click += new System.EventHandler(this.btnOpenUrl_Click);
            // 
            // btnStartUpdate
            // 
            this.btnStartUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartUpdate.FlatAppearance.BorderSize = 0;
            this.btnStartUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnStartUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUpdate.ForeColor = System.Drawing.Color.White;
            this.btnStartUpdate.Location = new System.Drawing.Point(99, 131);
            this.btnStartUpdate.Name = "btnStartUpdate";
            this.btnStartUpdate.Size = new System.Drawing.Size(111, 23);
            this.btnStartUpdate.TabIndex = 57;
            this.btnStartUpdate.Text = "开始上传";
            this.btnStartUpdate.UseVisualStyleBackColor = false;
            this.btnStartUpdate.Click += new System.EventHandler(this.btnStartUpdate_Click);
            // 
            // btnOpenUrl
            // 
            this.btnOpenUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenUrl.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.FlatAppearance.BorderSize = 0;
            this.btnOpenUrl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnOpenUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenUrl.ForeColor = System.Drawing.Color.White;
            this.btnOpenUrl.Location = new System.Drawing.Point(15, 49);
            this.btnOpenUrl.Name = "btnOpenUrl";
            this.btnOpenUrl.Size = new System.Drawing.Size(111, 23);
            this.btnOpenUrl.TabIndex = 57;
            this.btnOpenUrl.Text = "选择视频文件";
            this.btnOpenUrl.UseVisualStyleBackColor = false;
            this.btnOpenUrl.Click += new System.EventHandler(this.btnOpenUrl_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel7.Controls.Add(this.lbTitle);
            this.panel7.Controls.Add(this.pbClose);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(331, 28);
            this.panel7.TabIndex = 9;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(7, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(65, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "上传短视频";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(310, 7);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(13, 13);
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // openInsertVideo
            // 
            this.openInsertVideo.Filter = "MP4文件|*.mp4;*.gif";
            // 
            // InsertVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 180);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InsertVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "验券";
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.OpenFileDialog openInsertVideo;
        private System.Windows.Forms.Button btnOpenUrl;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Button btnStartUpdate;
        private System.Windows.Forms.Label label1;
    }
}