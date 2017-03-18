namespace HotTao
{
    partial class ImportGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportGoods));
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.lktemplate = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtpath = new System.Windows.Forms.RichTextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.uploadFile = new System.Windows.Forms.OpenFileDialog();
            this.hotPanel1.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.lktemplate);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.bgPanel);
            this.hotPanel1.Controls.Add(this.btnStartImport);
            this.hotPanel1.Controls.Add(this.btnUploadFile);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(561, 350);
            this.hotPanel1.TabIndex = 20;
            // 
            // lktemplate
            // 
            this.lktemplate.AutoSize = true;
            this.lktemplate.Location = new System.Drawing.Point(469, 91);
            this.lktemplate.Name = "lktemplate";
            this.lktemplate.Size = new System.Drawing.Size(77, 12);
            this.lktemplate.TabIndex = 42;
            this.lktemplate.TabStop = true;
            this.lktemplate.Text = "查看导入模板";
            this.lktemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lktemplate_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 41;
            this.label1.Text = "详细日志：";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.txtpath);
            this.hotGroupBox1.Location = new System.Drawing.Point(12, 32);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(354, 40);
            this.hotGroupBox1.TabIndex = 40;
            this.hotGroupBox1.TabStop = false;
            // 
            // txtpath
            // 
            this.txtpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtpath.Location = new System.Drawing.Point(3, 17);
            this.txtpath.Multiline = false;
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtpath.Size = new System.Drawing.Size(348, 20);
            this.txtpath.TabIndex = 26;
            this.txtpath.Text = "";
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.rtbMsg);
            this.hotGroupBox2.Location = new System.Drawing.Point(12, 106);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(538, 232);
            this.hotGroupBox2.TabIndex = 35;
            this.hotGroupBox2.TabStop = false;
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.rtbMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.rtbMsg.Location = new System.Drawing.Point(3, 17);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbMsg.Size = new System.Drawing.Size(532, 212);
            this.rtbMsg.TabIndex = 26;
            this.rtbMsg.Text = "";
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.bgPanel.Controls.Add(this.lbTitle);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(561, 28);
            this.bgPanel.TabIndex = 21;
            this.bgPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.bgPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.bgPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(7, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(53, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "导入数据";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(534, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // btnStartImport
            // 
            this.btnStartImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartImport.FlatAppearance.BorderSize = 0;
            this.btnStartImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnStartImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartImport.ForeColor = System.Drawing.Color.White;
            this.btnStartImport.Location = new System.Drawing.Point(464, 40);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(86, 32);
            this.btnStartImport.TabIndex = 20;
            this.btnStartImport.Text = "开始导入";
            this.btnStartImport.UseVisualStyleBackColor = false;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnUploadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnUploadFile.FlatAppearance.BorderSize = 0;
            this.btnUploadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnUploadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnUploadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadFile.ForeColor = System.Drawing.Color.White;
            this.btnUploadFile.Location = new System.Drawing.Point(372, 40);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(86, 32);
            this.btnUploadFile.TabIndex = 20;
            this.btnUploadFile.Text = "选择数据源";
            this.btnUploadFile.UseVisualStyleBackColor = false;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // ImportGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 350);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportGoods";
            this.Load += new System.EventHandler(this.ImportGoods_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox2.ResumeLayout(false);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.module.HotPanel hotPanel1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private Controls.module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private Controls.module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.RichTextBox txtpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog uploadFile;
        private System.Windows.Forms.LinkLabel lktemplate;
    }
}