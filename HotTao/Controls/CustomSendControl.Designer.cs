namespace HotTao.Controls
{
    partial class CustomSendControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtTempText = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.hotGroupBox3 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtPicPath = new System.Windows.Forms.RichTextBox();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.openFileVideo = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.hotGroupBox4 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtVideoPath = new System.Windows.Forms.RichTextBox();
            this.btnStartSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hotPanel1.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 606);
            this.hotPanel1.TabIndex = 0;
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.btnStartSend);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox4);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox3);
            this.hotGroupBox1.Controls.Add(this.button1);
            this.hotGroupBox1.Controls.Add(this.btnStartTask);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Controls.Add(this.label11);
            this.hotGroupBox1.Location = new System.Drawing.Point(6, 6);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(907, 593);
            this.hotGroupBox1.TabIndex = 34;
            this.hotGroupBox1.TabStop = false;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtTempText);
            this.hotGroupBox2.Location = new System.Drawing.Point(9, 39);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(888, 355);
            this.hotGroupBox2.TabIndex = 34;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtTempText
            // 
            this.txtTempText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtTempText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTempText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTempText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtTempText.Location = new System.Drawing.Point(3, 17);
            this.txtTempText.Name = "txtTempText";
            this.txtTempText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtTempText.Size = new System.Drawing.Size(882, 335);
            this.txtTempText.TabIndex = 26;
            this.txtTempText.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(12, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "自定义发送内容：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(407, -1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 33;
            this.label9.Text = "自定义发送";
            // 
            // btnStartTask
            // 
            this.btnStartTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.FlatAppearance.BorderSize = 0;
            this.btnStartTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnStartTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTask.ForeColor = System.Drawing.Color.White;
            this.btnStartTask.Location = new System.Drawing.Point(9, 409);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(79, 29);
            this.btnStartTask.TabIndex = 43;
            this.btnStartTask.Tag = "pic";
            this.btnStartTask.Text = "上传图片";
            this.btnStartTask.UseVisualStyleBackColor = false;
            this.btnStartTask.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.txtPicPath);
            this.hotGroupBox3.Location = new System.Drawing.Point(95, 400);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(392, 40);
            this.hotGroupBox3.TabIndex = 44;
            this.hotGroupBox3.TabStop = false;
            // 
            // txtPicPath
            // 
            this.txtPicPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtPicPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPicPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPicPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtPicPath.Location = new System.Drawing.Point(3, 17);
            this.txtPicPath.Multiline = false;
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.ReadOnly = true;
            this.txtPicPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPicPath.Size = new System.Drawing.Size(386, 20);
            this.txtPicPath.TabIndex = 26;
            this.txtPicPath.Text = "";
            // 
            // openFileImage
            // 
            this.openFileImage.Filter = "图像文件|*.jpg;*jpeg;*.png;*.bmp";
            // 
            // openFileVideo
            // 
            this.openFileVideo.Filter = "MP4文件|*.mp4;*.gif";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 29);
            this.button1.TabIndex = 43;
            this.button1.Tag = "video";
            this.button1.Text = "上传视频";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // hotGroupBox4
            // 
            this.hotGroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox4.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox4.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox4.Controls.Add(this.txtVideoPath);
            this.hotGroupBox4.Location = new System.Drawing.Point(94, 461);
            this.hotGroupBox4.Name = "hotGroupBox4";
            this.hotGroupBox4.Size = new System.Drawing.Size(393, 40);
            this.hotGroupBox4.TabIndex = 44;
            this.hotGroupBox4.TabStop = false;
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtVideoPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVideoPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVideoPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtVideoPath.Location = new System.Drawing.Point(3, 17);
            this.txtVideoPath.Multiline = false;
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtVideoPath.Size = new System.Drawing.Size(387, 20);
            this.txtVideoPath.TabIndex = 26;
            this.txtVideoPath.Text = "";
            // 
            // btnStartSend
            // 
            this.btnStartSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartSend.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnStartSend.FlatAppearance.BorderSize = 0;
            this.btnStartSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartSend.ForeColor = System.Drawing.Color.White;
            this.btnStartSend.Location = new System.Drawing.Point(803, 404);
            this.btnStartSend.Name = "btnStartSend";
            this.btnStartSend.Size = new System.Drawing.Size(91, 34);
            this.btnStartSend.TabIndex = 45;
            this.btnStartSend.Text = "开始发送";
            this.btnStartSend.UseVisualStyleBackColor = false;
            this.btnStartSend.Click += new System.EventHandler(this.btnStartSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "可选";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "可选";
            // 
            // CustomSendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotPanel1);
            this.Name = "CustomSendControl";
            this.Size = new System.Drawing.Size(920, 606);
            this.hotPanel1.ResumeLayout(false);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private module.HotGroupBox hotGroupBox1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtTempText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStartTask;
        private module.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.RichTextBox txtPicPath;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.OpenFileDialog openFileVideo;
        private System.Windows.Forms.Button button1;
        private module.HotGroupBox hotGroupBox4;
        private System.Windows.Forms.RichTextBox txtVideoPath;
        private System.Windows.Forms.Button btnStartSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
