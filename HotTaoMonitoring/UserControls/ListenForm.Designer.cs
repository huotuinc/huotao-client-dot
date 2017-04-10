namespace HotTaoMonitoring.UserControls
{
    partial class ListenForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvWeChatList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dataContent = new System.Windows.Forms.DataGridView();
            this.MsgContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotReadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgSendUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.MsgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbTabWeChat = new System.Windows.Forms.Label();
            this.lbTabWeChatListen = new System.Windows.Forms.Label();
            this.hotGroupBox1 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.txtSearch = new System.Windows.Forms.RichTextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editListen = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContent)).BeginInit();
            this.panel2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.ID,
            this.ShowName,
            this.UserName,
            this.editListen});
            this.dgvWeChatList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvWeChatList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvWeChatList.Location = new System.Drawing.Point(3, 68);
            this.dgvWeChatList.MultiSelect = false;
            this.dgvWeChatList.Name = "dgvWeChatList";
            this.dgvWeChatList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWeChatList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWeChatList.RowHeadersVisible = false;
            this.dgvWeChatList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvWeChatList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWeChatList.RowTemplate.Height = 23;
            this.dgvWeChatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeChatList.Size = new System.Drawing.Size(214, 536);
            this.dgvWeChatList.TabIndex = 11;
            this.dgvWeChatList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWeChatList_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // toolsRefresh
            // 
            this.toolsRefresh.Name = "toolsRefresh";
            this.toolsRefresh.Size = new System.Drawing.Size(124, 22);
            this.toolsRefresh.Text = "刷新列表";
            this.toolsRefresh.Click += new System.EventHandler(this.toolsRefresh_Click);
            // 
            // dataContent
            // 
            this.dataContent.AllowUserToAddRows = false;
            this.dataContent.AllowUserToDeleteRows = false;
            this.dataContent.AllowUserToResizeColumns = false;
            this.dataContent.AllowUserToResizeRows = false;
            this.dataContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataContent.ColumnHeadersVisible = false;
            this.dataContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MsgContent,
            this.NotReadCount,
            this.MsgShowName,
            this.MsgSendUser,
            this.MsgStatus,
            this.MsgText,
            this.MsgNickName,
            this.edit,
            this.MsgUserName});
            this.dataContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dataContent.Location = new System.Drawing.Point(222, 37);
            this.dataContent.MultiSelect = false;
            this.dataContent.Name = "dataContent";
            this.dataContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataContent.RowHeadersVisible = false;
            this.dataContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dataContent.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataContent.RowTemplate.Height = 23;
            this.dataContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataContent.Size = new System.Drawing.Size(664, 567);
            this.dataContent.TabIndex = 11;
            this.dataContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataContent_CellClick);
            // 
            // MsgContent
            // 
            this.MsgContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.MsgContent.DefaultCellStyle = dataGridViewCellStyle6;
            this.MsgContent.HeaderText = "内容";
            this.MsgContent.MinimumWidth = 50;
            this.MsgContent.Name = "MsgContent";
            this.MsgContent.ReadOnly = true;
            // 
            // NotReadCount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NotReadCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.NotReadCount.HeaderText = "NotReadCount";
            this.NotReadCount.Name = "NotReadCount";
            this.NotReadCount.ReadOnly = true;
            this.NotReadCount.Width = 80;
            // 
            // MsgShowName
            // 
            this.MsgShowName.HeaderText = "MsgShowName";
            this.MsgShowName.Name = "MsgShowName";
            this.MsgShowName.ReadOnly = true;
            this.MsgShowName.Visible = false;
            // 
            // MsgSendUser
            // 
            this.MsgSendUser.HeaderText = "MsgSendUser";
            this.MsgSendUser.Name = "MsgSendUser";
            this.MsgSendUser.ReadOnly = true;
            this.MsgSendUser.Visible = false;
            // 
            // MsgStatus
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MsgStatus.DefaultCellStyle = dataGridViewCellStyle8;
            this.MsgStatus.HeaderText = "MsgStatus";
            this.MsgStatus.Name = "MsgStatus";
            this.MsgStatus.ReadOnly = true;
            this.MsgStatus.Visible = false;
            this.MsgStatus.Width = 50;
            // 
            // MsgText
            // 
            this.MsgText.HeaderText = "MsgText";
            this.MsgText.Name = "MsgText";
            this.MsgText.ReadOnly = true;
            this.MsgText.Visible = false;
            // 
            // MsgNickName
            // 
            this.MsgNickName.HeaderText = "MsgNickName";
            this.MsgNickName.Name = "MsgNickName";
            this.MsgNickName.ReadOnly = true;
            this.MsgNickName.Visible = false;
            // 
            // edit
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "回复";
            this.edit.DefaultCellStyle = dataGridViewCellStyle9;
            this.edit.HeaderText = "回复";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Text = "回复";
            this.edit.Width = 50;
            // 
            // MsgUserName
            // 
            this.MsgUserName.HeaderText = "MsgUserName";
            this.MsgUserName.Name = "MsgUserName";
            this.MsgUserName.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label19);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(222, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 36);
            this.panel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label3.Location = new System.Drawing.Point(531, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "未读消息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label5.Location = new System.Drawing.Point(616, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "操作";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(11, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "消息内容";
            // 
            // lbTabWeChat
            // 
            this.lbTabWeChat.BackColor = System.Drawing.Color.White;
            this.lbTabWeChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChat.Location = new System.Drawing.Point(0, 0);
            this.lbTabWeChat.Name = "lbTabWeChat";
            this.lbTabWeChat.Size = new System.Drawing.Size(109, 35);
            this.lbTabWeChat.TabIndex = 14;
            this.lbTabWeChat.Text = "微信群聊列表";
            this.lbTabWeChat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTabWeChat.Click += new System.EventHandler(this.lbTabWeChat_Click);
            // 
            // lbTabWeChatListen
            // 
            this.lbTabWeChatListen.BackColor = System.Drawing.Color.Silver;
            this.lbTabWeChatListen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChatListen.Location = new System.Drawing.Point(109, 0);
            this.lbTabWeChatListen.Name = "lbTabWeChatListen";
            this.lbTabWeChatListen.Size = new System.Drawing.Size(109, 35);
            this.lbTabWeChatListen.TabIndex = 14;
            this.lbTabWeChatListen.Text = "已监控群";
            this.lbTabWeChatListen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTabWeChatListen.Click += new System.EventHandler(this.lbTabWeChatListen_Click);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.txtSearch);
            this.hotGroupBox1.Location = new System.Drawing.Point(2, 29);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(216, 38);
            this.hotGroupBox1.TabIndex = 12;
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
            this.txtSearch.Size = new System.Drawing.Size(210, 18);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Text = "";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 35;
            // 
            // ShowName
            // 
            this.ShowName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShowName.DataPropertyName = "ShowName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.ShowName.DefaultCellStyle = dataGridViewCellStyle2;
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
            // editListen
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "监控";
            this.editListen.DefaultCellStyle = dataGridViewCellStyle3;
            this.editListen.HeaderText = "editListen";
            this.editListen.Name = "editListen";
            this.editListen.ReadOnly = true;
            this.editListen.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editListen.Width = 40;
            // 
            // ListenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbTabWeChatListen);
            this.Controls.Add(this.lbTabWeChat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.hotGroupBox1);
            this.Controls.Add(this.dataContent);
            this.Controls.Add(this.dgvWeChatList);
            this.Name = "ListenForm";
            this.Size = new System.Drawing.Size(889, 607);
            this.Load += new System.EventHandler(this.ListenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataContent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWeChatList;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.RichTextBox txtSearch;
        private System.Windows.Forms.DataGridView dataContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsRefresh;
        private System.Windows.Forms.Label lbTabWeChat;
        private System.Windows.Forms.Label lbTabWeChatListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotReadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgShowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgSendUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgText;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgNickName;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewLinkColumn editListen;
    }
}
