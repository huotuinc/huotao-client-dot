﻿namespace HotTaoMonitoring.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvWeChatList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weChatIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editListen = new System.Windows.Forms.DataGridViewLinkColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsAllListen = new System.Windows.Forms.ToolStripMenuItem();
            this.dataContent = new System.Windows.Forms.DataGridView();
            this.MsgTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotReadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgSendUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMsgTitle = new System.Windows.Forms.Label();
            this.lbTabWeChat = new System.Windows.Forms.Label();
            this.lbTabWeChatListen = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsClearListen = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hotPanelWeChatList = new HotTaoMonitoring.module.HotPanel(this.components);
            this.hotPanelSearch = new HotTaoMonitoring.module.HotPanel(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContent)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.hotPanelWeChatList.SuspendLayout();
            this.hotPanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWeChatList
            // 
            this.dgvWeChatList.AllowUserToAddRows = false;
            this.dgvWeChatList.AllowUserToDeleteRows = false;
            this.dgvWeChatList.AllowUserToResizeColumns = false;
            this.dgvWeChatList.AllowUserToResizeRows = false;
            this.dgvWeChatList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(231)))));
            this.dgvWeChatList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWeChatList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvWeChatList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWeChatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWeChatList.ColumnHeadersVisible = false;
            this.dgvWeChatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.weChatIcon,
            this.ShowName,
            this.UserName,
            this.editListen});
            this.dgvWeChatList.ContextMenuStrip = this.menuStrip;
            this.dgvWeChatList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvWeChatList.Location = new System.Drawing.Point(3, 47);
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
            this.dgvWeChatList.RowTemplate.Height = 61;
            this.dgvWeChatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeChatList.Size = new System.Drawing.Size(231, 614);
            this.dgvWeChatList.TabIndex = 11;
            this.dgvWeChatList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWeChatList_CellClick);
            this.dgvWeChatList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
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
            // weChatIcon
            // 
            this.weChatIcon.HeaderText = "weChatIcon";
            this.weChatIcon.Name = "weChatIcon";
            this.weChatIcon.ReadOnly = true;
            this.weChatIcon.Width = 50;
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsRefresh,
            this.toolsAllListen});
            this.menuStrip.Name = "contextMenuStrip1";
            this.menuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // toolsRefresh
            // 
            this.toolsRefresh.Name = "toolsRefresh";
            this.toolsRefresh.Size = new System.Drawing.Size(124, 22);
            this.toolsRefresh.Text = "刷新列表";
            this.toolsRefresh.Click += new System.EventHandler(this.toolsRefresh_Click);
            // 
            // toolsAllListen
            // 
            this.toolsAllListen.Name = "toolsAllListen";
            this.toolsAllListen.Size = new System.Drawing.Size(124, 22);
            this.toolsAllListen.Text = "一键监控";
            this.toolsAllListen.Click += new System.EventHandler(this.toolsAllListen_Click);
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
            this.MsgTime,
            this.MsgNickName,
            this.MsgShowName,
            this.MsgContent,
            this.NotReadCount,
            this.MsgSendUser,
            this.MsgStatus,
            this.MsgText,
            this.MsgUserName,
            this.edit});
            this.dataContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dataContent.Location = new System.Drawing.Point(317, 53);
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
            this.dataContent.Size = new System.Drawing.Size(631, 610);
            this.dataContent.TabIndex = 11;
            this.dataContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataContent_CellClick);
            this.dataContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // MsgTime
            // 
            this.MsgTime.HeaderText = "MsgTime";
            this.MsgTime.Name = "MsgTime";
            this.MsgTime.ReadOnly = true;
            this.MsgTime.Width = 70;
            // 
            // MsgNickName
            // 
            this.MsgNickName.HeaderText = "MsgNickName";
            this.MsgNickName.Name = "MsgNickName";
            this.MsgNickName.ReadOnly = true;
            // 
            // MsgShowName
            // 
            this.MsgShowName.HeaderText = "MsgShowName";
            this.MsgShowName.Name = "MsgShowName";
            this.MsgShowName.ReadOnly = true;
            this.MsgShowName.Width = 120;
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
            this.NotReadCount.Width = 50;
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
            this.MsgStatus.Width = 50;
            // 
            // MsgText
            // 
            this.MsgText.HeaderText = "MsgText";
            this.MsgText.Name = "MsgText";
            this.MsgText.ReadOnly = true;
            this.MsgText.Visible = false;
            // 
            // MsgUserName
            // 
            this.MsgUserName.HeaderText = "MsgUserName";
            this.MsgUserName.Name = "MsgUserName";
            this.MsgUserName.Visible = false;
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
            this.edit.Visible = false;
            this.edit.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.lbMsgTitle);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(314, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 52);
            this.panel2.TabIndex = 13;
            // 
            // lbMsgTitle
            // 
            this.lbMsgTitle.AutoSize = true;
            this.lbMsgTitle.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsgTitle.Location = new System.Drawing.Point(20, 17);
            this.lbMsgTitle.Name = "lbMsgTitle";
            this.lbMsgTitle.Size = new System.Drawing.Size(89, 19);
            this.lbMsgTitle.TabIndex = 2;
            this.lbMsgTitle.Text = "消息列表";
            // 
            // lbTabWeChat
            // 
            this.lbTabWeChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(176)))));
            this.lbTabWeChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChat.ForeColor = System.Drawing.Color.White;
            this.lbTabWeChat.Location = new System.Drawing.Point(0, 20);
            this.lbTabWeChat.Name = "lbTabWeChat";
            this.lbTabWeChat.Size = new System.Drawing.Size(77, 60);
            this.lbTabWeChat.TabIndex = 14;
            this.lbTabWeChat.Text = "微信\r\n\r\n群聊";
            this.lbTabWeChat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTabWeChat.Click += new System.EventHandler(this.lbTabWeChat_Click);
            // 
            // lbTabWeChatListen
            // 
            this.lbTabWeChatListen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbTabWeChatListen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChatListen.ForeColor = System.Drawing.Color.White;
            this.lbTabWeChatListen.Location = new System.Drawing.Point(0, 80);
            this.lbTabWeChatListen.Name = "lbTabWeChatListen";
            this.lbTabWeChatListen.Size = new System.Drawing.Size(77, 60);
            this.lbTabWeChatListen.TabIndex = 14;
            this.lbTabWeChatListen.Text = "已监\r\n\r\n控群";
            this.lbTabWeChatListen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTabWeChatListen.Click += new System.EventHandler(this.lbTabWeChatListen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsClearListen});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // toolsClearListen
            // 
            this.toolsClearListen.Name = "toolsClearListen";
            this.toolsClearListen.Size = new System.Drawing.Size(148, 22);
            this.toolsClearListen.Text = "一键移除监控";
            this.toolsClearListen.Click += new System.EventHandler(this.toolsClearListen_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtSearch.Size = new System.Drawing.Size(217, 27);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Text = "";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.lbTabWeChat);
            this.panel1.Controls.Add(this.lbTabWeChatListen);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 664);
            this.panel1.TabIndex = 15;
            // 
            // hotPanelWeChatList
            // 
            this.hotPanelWeChatList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(231)))));
            this.hotPanelWeChatList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanelWeChatList.Controls.Add(this.hotPanelSearch);
            this.hotPanelWeChatList.Controls.Add(this.dgvWeChatList);
            this.hotPanelWeChatList.Location = new System.Drawing.Point(77, 0);
            this.hotPanelWeChatList.Name = "hotPanelWeChatList";
            this.hotPanelWeChatList.Size = new System.Drawing.Size(236, 664);
            this.hotPanelWeChatList.TabIndex = 16;
            // 
            // hotPanelSearch
            // 
            this.hotPanelSearch.BackColor = System.Drawing.Color.White;
            this.hotPanelSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanelSearch.Controls.Add(this.txtSearch);
            this.hotPanelSearch.Location = new System.Drawing.Point(9, 9);
            this.hotPanelSearch.Name = "hotPanelSearch";
            this.hotPanelSearch.Size = new System.Drawing.Size(217, 27);
            this.hotPanelSearch.TabIndex = 0;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "weChatIcon";
            this.dataGridViewImageColumn1.Image = global::HotTaoMonitoring.Properties.Resources._default;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // ListenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotPanelWeChatList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataContent);
            this.Name = "ListenForm";
            this.Size = new System.Drawing.Size(950, 664);
            this.Load += new System.EventHandler(this.ListenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeChatList)).EndInit();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataContent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.hotPanelWeChatList.ResumeLayout(false);
            this.hotPanelSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWeChatList;
        private System.Windows.Forms.RichTextBox txtSearch;
        private System.Windows.Forms.DataGridView dataContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMsgTitle;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsRefresh;
        private System.Windows.Forms.Label lbTabWeChat;
        private System.Windows.Forms.Label lbTabWeChatListen;
        private System.Windows.Forms.ToolStripMenuItem toolsAllListen;
        private System.Windows.Forms.ContextMenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsClearListen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgShowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotReadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgSendUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgText;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgUserName;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.Panel panel1;
        private module.HotPanel hotPanelWeChatList;
        private module.HotPanel hotPanelSearch;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn weChatIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewLinkColumn editListen;
    }
}
