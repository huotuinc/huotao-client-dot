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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsToolsResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolReSend = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAddListen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsUpdateAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.hotPanel1 = new HotTaoControls.HotPanel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.txtStartTime = new System.Windows.Forms.DateTimePicker();
            this.ckbEnableSendTime = new System.Windows.Forms.CheckBox();
            this.ckbEnableJoinImage = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.hotGroupBox3 = new HotTaoControls.HotGroupBox(this.components);
            this.dgvMessageView = new System.Windows.Forms.DataGridView();
            this.MessageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullMessageContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageUrl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageUrl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeteleMessage = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ckbEnableCustomTemplate = new System.Windows.Forms.CheckBox();
            this.ckbAutoSend = new System.Windows.Forms.CheckBox();
            this.hotGroupBox2 = new HotTaoControls.HotGroupBox(this.components);
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvContact = new System.Windows.Forms.DataGridView();
            this.QQFace = new System.Windows.Forms.DataGridViewImageColumn();
            this.GroupGid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotGroupBox1 = new HotTaoControls.HotGroupBox(this.components);
            this.lbRegsvr = new System.Windows.Forms.LinkLabel();
            this.loginTypeKQ = new System.Windows.Forms.RadioButton();
            this.loginTypeSan = new System.Windows.Forms.RadioButton();
            this.btnLogoutQQ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbQQNickName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbQQAccount = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ckBigCow = new System.Windows.Forms.CheckBox();
            this.cmsToolsResult.SuspendLayout();
            this.cmsTools.SuspendLayout();
            this.hotPanel1.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageView)).BeginInit();
            this.hotGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
            this.hotGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsToolsResult
            // 
            this.cmsToolsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolReSend,
            this.toolClearAll});
            this.cmsToolsResult.Name = "cmsToolsResult";
            this.cmsToolsResult.Size = new System.Drawing.Size(125, 48);
            this.cmsToolsResult.Opening += new System.ComponentModel.CancelEventHandler(this.cmsToolsResult_Opening);
            // 
            // toolReSend
            // 
            this.toolReSend.Name = "toolReSend";
            this.toolReSend.Size = new System.Drawing.Size(124, 22);
            this.toolReSend.Text = "手动处理";
            this.toolReSend.Click += new System.EventHandler(this.toolReSend_Click);
            // 
            // toolClearAll
            // 
            this.toolClearAll.Name = "toolClearAll";
            this.toolClearAll.Size = new System.Drawing.Size(124, 22);
            this.toolClearAll.Text = "清空";
            this.toolClearAll.Click += new System.EventHandler(this.toolClearAll_Click);
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
            this.toolsUpdateAlias.Visible = false;
            this.toolsUpdateAlias.Click += new System.EventHandler(this.toolsUpdateAlias_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "QQFace";
            this.dataGridViewImageColumn1.Image = global::QQLogin.Properties.Resources.qqgroup;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.txtEndTime);
            this.hotPanel1.Controls.Add(this.txtStartTime);
            this.hotPanel1.Controls.Add(this.ckbEnableSendTime);
            this.hotPanel1.Controls.Add(this.ckbEnableJoinImage);
            this.hotPanel1.Controls.Add(this.linkLabel1);
            this.hotPanel1.Controls.Add(this.label4);
            this.hotPanel1.Controls.Add(this.hotGroupBox3);
            this.hotPanel1.Controls.Add(this.ckbEnableCustomTemplate);
            this.hotPanel1.Controls.Add(this.ckbAutoSend);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Controls.Add(this.ckBigCow);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 607);
            this.hotPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "-";
            // 
            // txtEndTime
            // 
            this.txtEndTime.CustomFormat = "";
            this.txtEndTime.Enabled = false;
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtEndTime.Location = new System.Drawing.Point(380, 110);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ShowUpDown = true;
            this.txtEndTime.Size = new System.Drawing.Size(81, 21);
            this.txtEndTime.TabIndex = 22;
            // 
            // txtStartTime
            // 
            this.txtStartTime.CustomFormat = "";
            this.txtStartTime.Enabled = false;
            this.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtStartTime.Location = new System.Drawing.Point(285, 110);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ShowUpDown = true;
            this.txtStartTime.Size = new System.Drawing.Size(77, 21);
            this.txtStartTime.TabIndex = 22;
            // 
            // ckbEnableSendTime
            // 
            this.ckbEnableSendTime.AutoSize = true;
            this.ckbEnableSendTime.Location = new System.Drawing.Point(151, 113);
            this.ckbEnableSendTime.Name = "ckbEnableSendTime";
            this.ckbEnableSendTime.Size = new System.Drawing.Size(132, 16);
            this.ckbEnableSendTime.TabIndex = 21;
            this.ckbEnableSendTime.Text = "启用发送时间段配置";
            this.ckbEnableSendTime.UseVisualStyleBackColor = true;
            this.ckbEnableSendTime.CheckedChanged += new System.EventHandler(this.ckbEnableSendTime_CheckedChanged);
            // 
            // ckbEnableJoinImage
            // 
            this.ckbEnableJoinImage.AutoSize = true;
            this.ckbEnableJoinImage.Location = new System.Drawing.Point(13, 113);
            this.ckbEnableJoinImage.Name = "ckbEnableJoinImage";
            this.ckbEnableJoinImage.Size = new System.Drawing.Size(132, 16);
            this.ckbEnableJoinImage.TabIndex = 20;
            this.ckbEnableJoinImage.Text = "自动跟发商品合成图";
            this.ckbEnableJoinImage.UseVisualStyleBackColor = true;
            this.ckbEnableJoinImage.Visible = false;
            this.ckbEnableJoinImage.CheckedChanged += new System.EventHandler(this.ckbEnableJoinImage_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(582, 86);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "清空日志";
            this.linkLabel1.Click += new System.EventHandler(this.toolClearAll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(270, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "(启用则使用采集到的文案)";
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.dgvMessageView);
            this.hotGroupBox3.Location = new System.Drawing.Point(5, 146);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(634, 456);
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
            this.FullMessageContent,
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
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessageView.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvMessageView.RowHeadersVisible = false;
            this.dgvMessageView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvMessageView.RowsDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvMessageView.RowTemplate.Height = 40;
            this.dgvMessageView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessageView.Size = new System.Drawing.Size(628, 436);
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
            // FullMessageContent
            // 
            this.FullMessageContent.HeaderText = "FullMessageContent";
            this.FullMessageContent.Name = "FullMessageContent";
            this.FullMessageContent.ReadOnly = true;
            this.FullMessageContent.Visible = false;
            // 
            // MessageUrl1
            // 
            dataGridViewCellStyle25.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MessageUrl1.DefaultCellStyle = dataGridViewCellStyle25;
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
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MessageStatus.DefaultCellStyle = dataGridViewCellStyle30;
            this.MessageStatus.HeaderText = "MessageStatus";
            this.MessageStatus.Name = "MessageStatus";
            this.MessageStatus.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            this.Status.Width = 60;
            // 
            // DeteleMessage
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.NullValue = "删除";
            this.DeteleMessage.DefaultCellStyle = dataGridViewCellStyle35;
            this.DeteleMessage.HeaderText = "删除";
            this.DeteleMessage.Name = "DeteleMessage";
            this.DeteleMessage.ReadOnly = true;
            this.DeteleMessage.Width = 50;
            // 
            // ckbEnableCustomTemplate
            // 
            this.ckbEnableCustomTemplate.AutoSize = true;
            this.ckbEnableCustomTemplate.Location = new System.Drawing.Point(151, 80);
            this.ckbEnableCustomTemplate.Name = "ckbEnableCustomTemplate";
            this.ckbEnableCustomTemplate.Size = new System.Drawing.Size(120, 16);
            this.ckbEnableCustomTemplate.TabIndex = 16;
            this.ckbEnableCustomTemplate.Text = "启用QQ自定义文案";
            this.ckbEnableCustomTemplate.UseVisualStyleBackColor = true;
            this.ckbEnableCustomTemplate.CheckedChanged += new System.EventHandler(this.ckbEnableCustomTemplate_CheckedChanged);
            // 
            // ckbAutoSend
            // 
            this.ckbAutoSend.AutoSize = true;
            this.ckbAutoSend.Location = new System.Drawing.Point(13, 81);
            this.ckbAutoSend.Name = "ckbAutoSend";
            this.ckbAutoSend.Size = new System.Drawing.Size(120, 16);
            this.ckbAutoSend.TabIndex = 16;
            this.ckbAutoSend.Text = "自动跟发商品文案";
            this.ckbAutoSend.UseVisualStyleBackColor = true;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.picLoading);
            this.hotGroupBox2.Controls.Add(this.label6);
            this.hotGroupBox2.Controls.Add(this.label7);
            this.hotGroupBox2.Controls.Add(this.label5);
            this.hotGroupBox2.Controls.Add(this.dgvContact);
            this.hotGroupBox2.Location = new System.Drawing.Point(641, 7);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(276, 596);
            this.hotGroupBox2.TabIndex = 14;
            this.hotGroupBox2.TabStop = false;
            this.hotGroupBox2.Text = "QQ群";
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoading.Image = global::QQLogin.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(3, 17);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(270, 576);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 14;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "群名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "别名";
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
            this.GroupTitle,
            this.GroupAlias,
            this.GroupStatus});
            this.dgvContact.ContextMenuStrip = this.cmsTools;
            this.dgvContact.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvContact.Location = new System.Drawing.Point(4, 45);
            this.dgvContact.MultiSelect = false;
            this.dgvContact.Name = "dgvContact";
            this.dgvContact.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContact.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvContact.RowHeadersVisible = false;
            this.dgvContact.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvContact.RowsDefaultCellStyle = dataGridViewCellStyle38;
            this.dgvContact.RowTemplate.Height = 40;
            this.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContact.Size = new System.Drawing.Size(267, 548);
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
            this.QQFace.Visible = false;
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
            dataGridViewCellStyle32.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GroupTitle.DefaultCellStyle = dataGridViewCellStyle32;
            this.GroupTitle.HeaderText = "GroupTitle";
            this.GroupTitle.Name = "GroupTitle";
            this.GroupTitle.ReadOnly = true;
            // 
            // GroupAlias
            // 
            this.GroupAlias.HeaderText = "GroupAlias";
            this.GroupAlias.Name = "GroupAlias";
            this.GroupAlias.Width = 80;
            // 
            // GroupStatus
            // 
            this.GroupStatus.HeaderText = "GroupStatus";
            this.GroupStatus.Name = "GroupStatus";
            this.GroupStatus.ReadOnly = true;
            this.GroupStatus.Width = 50;
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbRegsvr);
            this.hotGroupBox1.Controls.Add(this.loginTypeKQ);
            this.hotGroupBox1.Controls.Add(this.loginTypeSan);
            this.hotGroupBox1.Controls.Add(this.btnLogoutQQ);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.lbQQNickName);
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.lbQQAccount);
            this.hotGroupBox1.Controls.Add(this.picLogo);
            this.hotGroupBox1.Location = new System.Drawing.Point(6, 7);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(631, 60);
            this.hotGroupBox1.TabIndex = 3;
            this.hotGroupBox1.TabStop = false;
            this.hotGroupBox1.Text = "QQ信息";
            // 
            // lbRegsvr
            // 
            this.lbRegsvr.AutoSize = true;
            this.lbRegsvr.Location = new System.Drawing.Point(436, 40);
            this.lbRegsvr.Name = "lbRegsvr";
            this.lbRegsvr.Size = new System.Drawing.Size(191, 12);
            this.lbRegsvr.TabIndex = 18;
            this.lbRegsvr.TabStop = true;
            this.lbRegsvr.Text = "点击此处修复酷Q应用加载失败问题";
            this.lbRegsvr.Visible = false;
            this.lbRegsvr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRegsvr_LinkClicked);
            // 
            // loginTypeKQ
            // 
            this.loginTypeKQ.AutoSize = true;
            this.loginTypeKQ.Location = new System.Drawing.Point(440, 17);
            this.loginTypeKQ.Name = "loginTypeKQ";
            this.loginTypeKQ.Size = new System.Drawing.Size(41, 16);
            this.loginTypeKQ.TabIndex = 11;
            this.loginTypeKQ.Text = "酷Q";
            this.loginTypeKQ.UseVisualStyleBackColor = true;
            this.loginTypeKQ.CheckedChanged += new System.EventHandler(this.loginTypeKQ_CheckedChanged);
            // 
            // loginTypeSan
            // 
            this.loginTypeSan.AutoSize = true;
            this.loginTypeSan.Checked = true;
            this.loginTypeSan.Location = new System.Drawing.Point(487, 17);
            this.loginTypeSan.Name = "loginTypeSan";
            this.loginTypeSan.Size = new System.Drawing.Size(71, 16);
            this.loginTypeSan.TabIndex = 11;
            this.loginTypeSan.TabStop = true;
            this.loginTypeSan.Text = "扫描登录";
            this.loginTypeSan.UseVisualStyleBackColor = true;
            this.loginTypeSan.CheckedChanged += new System.EventHandler(this.loginTypeKQ_CheckedChanged);
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
            this.btnLogoutQQ.Location = new System.Drawing.Point(560, 13);
            this.btnLogoutQQ.Name = "btnLogoutQQ";
            this.btnLogoutQQ.Size = new System.Drawing.Size(65, 23);
            this.btnLogoutQQ.TabIndex = 9;
            this.btnLogoutQQ.Text = "登录";
            this.btnLogoutQQ.UseVisualStyleBackColor = false;
            this.btnLogoutQQ.Click += new System.EventHandler(this.btnLogoutQQ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "昵称：";
            // 
            // lbQQNickName
            // 
            this.lbQQNickName.Location = new System.Drawing.Point(210, 20);
            this.lbQQNickName.Name = "lbQQNickName";
            this.lbQQNickName.Size = new System.Drawing.Size(121, 26);
            this.lbQQNickName.TabIndex = 3;
            this.lbQQNickName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "QQ:";
            // 
            // lbQQAccount
            // 
            this.lbQQAccount.Location = new System.Drawing.Point(83, 21);
            this.lbQQAccount.Name = "lbQQAccount";
            this.lbQQAccount.Size = new System.Drawing.Size(74, 25);
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
            // ckBigCow
            // 
            this.ckBigCow.AutoSize = true;
            this.ckBigCow.Location = new System.Drawing.Point(13, 81);
            this.ckBigCow.Name = "ckBigCow";
            this.ckBigCow.Size = new System.Drawing.Size(168, 16);
            this.ckBigCow.TabIndex = 19;
            this.ckBigCow.Text = "勾选启用大牛选单商品采集";
            this.ckBigCow.UseVisualStyleBackColor = true;
            this.ckBigCow.Visible = false;
            // 
            // QQMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotPanel1);
            this.Name = "QQMainControl";
            this.Size = new System.Drawing.Size(920, 607);
            this.Load += new System.EventHandler(this.QQMainControl_Load);
            this.cmsToolsResult.ResumeLayout(false);
            this.cmsTools.ResumeLayout(false);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageView)).EndInit();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip cmsToolsResult;
        private System.Windows.Forms.ToolStripMenuItem toolReSend;
        private System.Windows.Forms.CheckBox ckbEnableCustomTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolsUpdateAlias;
        private System.Windows.Forms.ToolStripMenuItem toolClearAll;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewImageColumn QQFace;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupGid;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullMessageContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageUrl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageUrl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewLinkColumn DeteleMessage;
        private System.Windows.Forms.RadioButton loginTypeKQ;
        private System.Windows.Forms.RadioButton loginTypeSan;
        private System.Windows.Forms.LinkLabel lbRegsvr;
        private System.Windows.Forms.CheckBox ckBigCow;
        private System.Windows.Forms.CheckBox ckbEnableJoinImage;
        private System.Windows.Forms.CheckBox ckbEnableSendTime;
        private System.Windows.Forms.DateTimePicker txtStartTime;
        private System.Windows.Forms.DateTimePicker txtEndTime;
        private System.Windows.Forms.Label label1;
    }
}
