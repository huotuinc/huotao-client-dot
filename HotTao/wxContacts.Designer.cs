namespace HotTao
{
    partial class wxContacts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wxContacts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNickName = new System.Windows.Forms.Label();
            this.pbHeadImg = new System.Windows.Forms.PictureBox();
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtSearch = new System.Windows.Forms.RichTextBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtSendLog = new System.Windows.Forms.RichTextBox();
            this.dgvWeChatList = new System.Windows.Forms.DataGridView();
            this.ShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImg)).BeginInit();
            this.hotPanel1.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.hotGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.txtNickName);
            this.panel1.Controls.Add(this.pbHeadImg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 643);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // txtNickName
            // 
            this.txtNickName.ForeColor = System.Drawing.Color.White;
            this.txtNickName.Location = new System.Drawing.Point(3, 84);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(86, 80);
            this.txtNickName.TabIndex = 1;
            this.txtNickName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbHeadImg
            // 
            this.pbHeadImg.Location = new System.Drawing.Point(15, 12);
            this.pbHeadImg.Name = "pbHeadImg";
            this.pbHeadImg.Size = new System.Drawing.Size(60, 60);
            this.pbHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHeadImg.TabIndex = 0;
            this.pbHeadImg.TabStop = false;
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.button1);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Controls.Add(this.picClose);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.dgvWeChatList);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(889, 640);
            this.hotPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(860, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 3);
            this.button1.TabIndex = 42;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.picClose_Click);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.txtSearch);
            this.hotGroupBox1.Location = new System.Drawing.Point(94, 1);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(222, 40);
            this.hotGroupBox1.TabIndex = 41;
            this.hotGroupBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtSearch.Location = new System.Drawing.Point(3, 17);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtSearch.Size = new System.Drawing.Size(216, 20);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.Text = "";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(858, 5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 27;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtSendLog);
            this.hotGroupBox2.Location = new System.Drawing.Point(323, 31);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(560, 604);
            this.hotGroupBox2.TabIndex = 40;
            this.hotGroupBox2.TabStop = false;
            this.hotGroupBox2.Text = "日志";
            // 
            // txtSendLog
            // 
            this.txtSendLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtSendLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtSendLog.Location = new System.Drawing.Point(3, 17);
            this.txtSendLog.Name = "txtSendLog";
            this.txtSendLog.ReadOnly = true;
            this.txtSendLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtSendLog.Size = new System.Drawing.Size(554, 584);
            this.txtSendLog.TabIndex = 26;
            this.txtSendLog.Text = "";
            // 
            // dgvWeChatList
            // 
            this.dgvWeChatList.AllowUserToAddRows = false;
            this.dgvWeChatList.AllowUserToDeleteRows = false;
            this.dgvWeChatList.AllowUserToResizeColumns = false;
            this.dgvWeChatList.AllowUserToResizeRows = false;
            this.dgvWeChatList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvWeChatList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWeChatList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWeChatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWeChatList.ColumnHeadersVisible = false;
            this.dgvWeChatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowName,
            this.UserName});
            this.dgvWeChatList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvWeChatList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvWeChatList.Location = new System.Drawing.Point(91, 48);
            this.dgvWeChatList.MultiSelect = false;
            this.dgvWeChatList.Name = "dgvWeChatList";
            this.dgvWeChatList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWeChatList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWeChatList.RowHeadersVisible = false;
            this.dgvWeChatList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvWeChatList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWeChatList.RowTemplate.Height = 23;
            this.dgvWeChatList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvWeChatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeChatList.Size = new System.Drawing.Size(225, 589);
            this.dgvWeChatList.TabIndex = 10;
            // 
            // ShowName
            // 
            this.ShowName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShowName.DataPropertyName = "ShowName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.ShowName.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShowName.HeaderText = "ShowName";
            this.ShowName.MinimumWidth = 50;
            this.ShowName.Name = "ShowName";
            this.ShowName.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // toolsRefresh
            // 
            this.toolsRefresh.Name = "toolsRefresh";
            this.toolsRefresh.Size = new System.Drawing.Size(136, 22);
            this.toolsRefresh.Text = "刷新通讯录";
            this.toolsRefresh.Click += new System.EventHandler(this.toolsRefresh_Click);
            // 
            // wxContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wxContacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信通讯录";
            this.Load += new System.EventHandler(this.wxContacts_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImg)).EndInit();
            this.hotPanel1.ResumeLayout(false);
            this.hotGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.hotGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbHeadImg;
        private Controls.module.HotPanel hotPanel1;
        private System.Windows.Forms.DataGridView dgvWeChatList;
        private Controls.module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtSendLog;
        private System.Windows.Forms.PictureBox picClose;
        private Controls.module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.RichTextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsRefresh;
        private System.Windows.Forms.Label txtNickName;
    }
}