namespace QQLogin
{
    partial class QQMainControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotPanel1 = new HotTaoControls.HotPanel(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hotGroupBox3 = new HotTaoControls.HotGroupBox(this.components);
            this.dgvMessageView = new System.Windows.Forms.DataGridView();
            this.MessageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageUrl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageUrl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeteleMessage = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmsToolsResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolReSend = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbEnableCustomTemplate = new System.Windows.Forms.CheckBox();
            this.ckbAutoSend = new System.Windows.Forms.CheckBox();
            this.hotGroupBox2 = new HotTaoControls.HotGroupBox(this.components);
            this.dgvContact = new System.Windows.Forms.DataGridView();
            this.QQFace = new System.Windows.Forms.DataGridViewImageColumn();
            this.GroupGid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAddListen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsUpdateAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.hotGroupBox1 = new HotTaoControls.HotGroupBox(this.components);
            this.btnLogoutQQ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbQQNickName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbQQAccount = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.hotPanel1.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageView)).BeginInit();
            this.cmsToolsResult.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
            this.cmsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.hotGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label4);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.hotGroupBox3);
            this.hotPanel1.Controls.Add(this.ckbEnableCustomTemplate);
            this.hotPanel1.Controls.Add(this.ckbAutoSend);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 607);
            this.hotPanel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(355, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "(启用则使用采集到的文案)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(81, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "(记得一定要启动任务计划)";
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.dgvMessageView);
            this.hotGroupBox3.Location = new System.Drawing.Point(5, 109);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(654, 493);
            this.hotGroupBox3.TabIndex = 15;
            this.hotGroupBox3.TabStop = false;
            this.hotGroupBox3.Text = "采集的数据";
            // 
            // dgvMessageView
            // 
            this.dgvMessageView.AllowUserToAddRows = false;
            this.dgvMessageView.AllowUserToDeleteRows = false;
            this.dgvMessageView.AllowUserToResizeColumns = false;
            this.dgvMessageView.AllowUserToResizeRows = false;
            this.dgvMessageView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvMessageView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMessageView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMessageView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMessageView.ColumnHeadersVisible = false;
            this.dgvMessageView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MessageCode,
            this.GroupName,
            this.MessageContent,
            this.MessageUrl1,
            this.MessageUrl2,
            this.MessageStatus,
            this.Status,
            this.DeteleMessage});
            this.dgvMessageView.ContextMenuStrip = this.cmsToolsResult;
            this.dgvMessageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessageView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvMessageView.Location = new System.Drawing.Point(3, 17);
            this.dgvMessageView.MultiSelect = false;
            this.dgvMessageView.Name = "dgvMessageView";
            this.dgvMessageView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessageView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMessageView.RowHeadersVisible = false;
            this.dgvMessageView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvMessageView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMessageView.RowTemplate.Height = 40;
            this.dgvMessageView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessageView.Size = new System.Drawing.Size(648, 473);
            this.dgvMessageView.TabIndex = 14;
            this.dgvMessageView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessageView_CellClick);
            this.dgvMessageView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessageView_CellMouseEnter);
            // 
            // MessageCode
            // 
            this.MessageCode.HeaderText = "MessageCode";
            this.MessageCode.Name = "MessageCode";
            this.MessageCode.ReadOnly = true;
            this.MessageCode.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "GroupName";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 70;
            // 
            // MessageContent
            // 
            this.MessageContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MessageContent.HeaderText = "MessageContent";
            this.MessageContent.Name = "MessageContent";
            this.MessageContent.ReadOnly = true;
            // 
            // MessageUrl1
            // 
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MessageUrl1.DefaultCellStyle = dataGridViewCellStyle1;
            this.MessageUrl1.HeaderText = "MessageUrl1";
            this.MessageUrl1.Name = "MessageUrl1";
            this.MessageUrl1.ReadOnly = true;
            // 
            // MessageUrl2
            // 
            this.MessageUrl2.HeaderText = "MessageUrl2";
            this.MessageUrl2.Name = "MessageUrl2";
            this.MessageUrl2.ReadOnly = true;
            // 
            // MessageStatus
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MessageStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.MessageStatus.HeaderText = "MessageStatus";
            this.MessageStatus.Name = "MessageStatus";
            this.MessageStatus.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // DeteleMessage
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "删除";
            this.DeteleMessage.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeteleMessage.HeaderText = "删除";
            this.DeteleMessage.Name = "DeteleMessage";
            this.DeteleMessage.ReadOnly = true;
            this.DeteleMessage.Width = 50;
            // 
            // cmsToolsResult
            // 
            this.cmsToolsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolReSend});
            this.cmsToolsResult.Name = "cmsToolsResult";
            this.cmsToolsResult.Size = new System.Drawing.Size(125, 26);
            this.cmsToolsResult.Opening += new System.ComponentModel.CancelEventHandler(this.cmsToolsResult_Opening);
            // 
            // toolReSend
            // 
            this.toolReSend.Name = "toolReSend";
            this.toolReSend.Size = new System.Drawing.Size(124, 22);
            this.toolReSend.Text = "手动处理";
            this.toolReSend.Click += new System.EventHandler(this.toolReSend_Click);
            // 
            // ckbEnableCustomTemplate
            // 
            this.ckbEnableCustomTemplate.AutoSize = true;
            this.ckbEnableCustomTemplate.Location = new System.Drawing.Point(236, 81);
            this.ckbEnableCustomTemplate.Name = "ckbEnableCustomTemplate";
            this.ckbEnableCustomTemplate.Size = new System.Drawing.Size(120, 16);
            this.ckbEnableCustomTemplate.TabIndex = 16;
            this.ckbEnableCustomTemplate.Text = "启用QQ自定义文案";
            this.ckbEnableCustomTemplate.UseVisualStyleBackColor = true;
            // 
            // ckbAutoSend
            // 
            this.ckbAutoSend.AutoSize = true;
            this.ckbAutoSend.Location = new System.Drawing.Point(13, 81);
            this.ckbAutoSend.Name = "ckbAutoSend";
            this.ckbAutoSend.Size = new System.Drawing.Size(72, 16);
            this.ckbAutoSend.TabIndex = 16;
            this.ckbAutoSend.Text = "自动跟发";
            this.ckbAutoSend.UseVisualStyleBackColor = true;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.picLoading);
            this.hotGroupBox2.Controls.Add(this.dgvContact);
            this.hotGroupBox2.Location = new System.Drawing.Point(664, 7);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(253, 596);
            this.hotGroupBox2.TabIndex = 14;
            this.hotGroupBox2.TabStop = false;
            this.hotGroupBox2.Text = "QQ群";
            // 
            // dgvContact
            // 
            this.dgvContact.AllowUserToAddRows = false;
            this.dgvContact.AllowUserToDeleteRows = false;
            this.dgvContact.AllowUserToResizeColumns = false;
            this.dgvContact.AllowUserToResizeRows = false;
            this.dgvContact.BackgroundColor = System.Drawing.Color.White;
            this.dgvContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContact.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvContact.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContact.ColumnHeadersVisible = false;
            this.dgvContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QQFace,
            this.GroupGid,
            this.GroupTitle});
            this.dgvContact.ContextMenuStrip = this.cmsTools;
            this.dgvContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContact.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvContact.Location = new System.Drawing.Point(3, 17);
            this.dgvContact.MultiSelect = false;
            this.dgvContact.Name = "dgvContact";
            this.dgvContact.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContact.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvContact.RowHeadersVisible = false;
            this.dgvContact.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvContact.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvContact.RowTemplate.Height = 60;
            this.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContact.Size = new System.Drawing.Size(247, 576);
            this.dgvContact.TabIndex = 13;
            this.dgvContact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContact_CellClick);
            this.dgvContact.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContact_CellEndEdit);
            this.dgvContact.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContact_CellMouseEnter);
            this.dgvContact.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContact_CellMouseLeave);
            // 
            // QQFace
            // 
            this.QQFace.HeaderText = "QQFace";
            this.QQFace.Image = global::QQLogin.Properties.Resources.qqgroup;
            this.QQFace.Name = "QQFace";
            this.QQFace.ReadOnly = true;
            this.QQFace.Width = 50;
            // 
            // GroupGid
            // 
            this.GroupGid.HeaderText = "GroupGid";
            this.GroupGid.Name = "GroupGid";
            this.GroupGid.ReadOnly = true;
            this.GroupGid.Visible = false;
            // 
            // GroupTitle
            // 
            this.GroupTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GroupTitle.DefaultCellStyle = dataGridViewCellStyle6;
            this.GroupTitle.HeaderText = "GroupTitle";
            this.GroupTitle.Name = "GroupTitle";
            this.GroupTitle.ReadOnly = true;
            // 
            // cmsTools
            // 
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddListen,
            this.toolsUpdateAlias});
            this.cmsTools.Name = "cmsTools";
            this.cmsTools.Size = new System.Drawing.Size(125, 48);
            this.cmsTools.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTools_Opening);
            // 
            // toolAddListen
            // 
            this.toolAddListen.Name = "toolAddListen";
            this.toolAddListen.Size = new System.Drawing.Size(124, 22);
            this.toolAddListen.Text = "添加监控";
            this.toolAddListen.Click += new System.EventHandler(this.toolAddListen_Click);
            // 
            // toolsUpdateAlias
            // 
            this.toolsUpdateAlias.Name = "toolsUpdateAlias";
            this.toolsUpdateAlias.Size = new System.Drawing.Size(124, 22);
            this.toolsUpdateAlias.Text = "修改别名";
            this.toolsUpdateAlias.Click += new System.EventHandler(this.toolsUpdateAlias_Click);
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoading.Image = global::QQLogin.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(3, 17);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(247, 576);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 14;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.btnLogoutQQ);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.lbQQNickName);
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.lbQQAccount);
            this.hotGroupBox1.Controls.Add(this.picLogo);
            this.hotGroupBox1.Location = new System.Drawing.Point(6, 7);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(653, 60);
            this.hotGroupBox1.TabIndex = 3;
            this.hotGroupBox1.TabStop = false;
            this.hotGroupBox1.Text = "QQ信息";
            // 
            // btnLogoutQQ
            // 
            this.btnLogoutQQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogoutQQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogoutQQ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogoutQQ.FlatAppearance.BorderSize = 0;
            this.btnLogoutQQ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogoutQQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnLogoutQQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoutQQ.ForeColor = System.Drawing.Color.White;
            this.btnLogoutQQ.Location = new System.Drawing.Point(591, 23);
            this.btnLogoutQQ.Name = "btnLogoutQQ";
            this.btnLogoutQQ.Size = new System.Drawing.Size(42, 23);
            this.btnLogoutQQ.TabIndex = 9;
            this.btnLogoutQQ.Text = "注销";
            this.btnLogoutQQ.UseVisualStyleBackColor = false;
            this.btnLogoutQQ.Visible = false;
            this.btnLogoutQQ.Click += new System.EventHandler(this.btnLogoutQQ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "昵称：";
            // 
            // lbQQNickName
            // 
            this.lbQQNickName.Location = new System.Drawing.Point(268, 20);
            this.lbQQNickName.Name = "lbQQNickName";
            this.lbQQNickName.Size = new System.Drawing.Size(149, 26);
            this.lbQQNickName.TabIndex = 3;
            this.lbQQNickName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "QQ:";
            // 
            // lbQQAccount
            // 
            this.lbQQAccount.Location = new System.Drawing.Point(95, 21);
            this.lbQQAccount.Name = "lbQQAccount";
            this.lbQQAccount.Size = new System.Drawing.Size(102, 25);
            this.lbQQAccount.TabIndex = 3;
            this.lbQQAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::QQLogin.Properties.Resources.QQ40x40;
            this.picLogo.Location = new System.Drawing.Point(11, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(40, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "QQFace";
            this.dataGridViewImageColumn1.Image = global::QQLogin.Properties.Resources.qqgroup;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // QQMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotPanel1);
            this.Name = "QQMainControl";
            this.Size = new System.Drawing.Size(920, 607);
            this.Load += new System.EventHandler(this.QQMainControl_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageView)).EndInit();
            this.cmsToolsResult.ResumeLayout(false);
            this.hotGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
            this.cmsTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private HotTaoControls.HotPanel hotPanel1;
        private HotTaoControls.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label lbQQAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvContact;
        private HotTaoControls.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.ContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem toolAddListen;
        private System.Windows.Forms.Button btnLogoutQQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbQQNickName;
        private HotTaoControls.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.DataGridView dgvMessageView;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.CheckBox ckbAutoSend;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn QQFace;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupGid;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsToolsResult;
        private System.Windows.Forms.ToolStripMenuItem toolReSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageUrl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageUrl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewLinkColumn DeteleMessage;
        private System.Windows.Forms.CheckBox ckbEnableCustomTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolsUpdateAlias;
    }
}
