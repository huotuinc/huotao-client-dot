namespace HotTao.Controls
{
    partial class SetAutoReplyControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKeyword = new System.Windows.Forms.DataGridView();
            this.keywordid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteKeyword = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChatRoom = new System.Windows.Forms.DataGridView();
            this.groupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wechattitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteWechat = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnWeChat = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbAutoReplay = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyword)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.button2);
            this.hotGroupBox1.Controls.Add(this.panel2);
            this.hotGroupBox1.Controls.Add(this.dgvKeyword);
            this.hotGroupBox1.Controls.Add(this.panel1);
            this.hotGroupBox1.Controls.Add(this.dgvChatRoom);
            this.hotGroupBox1.Controls.Add(this.btnWeChat);
            this.hotGroupBox1.Controls.Add(this.label8);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.ckbAutoReplay);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 13);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 548);
            this.hotGroupBox1.TabIndex = 1;
            this.hotGroupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(622, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 41;
            this.button2.Text = "添加";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(14, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 36);
            this.panel2.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label6.Location = new System.Drawing.Point(634, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "操作";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label5.Location = new System.Drawing.Point(271, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "自动回复内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label4.Location = new System.Drawing.Point(120, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "自动回复类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "回复关键字";
            // 
            // dgvKeyword
            // 
            this.dgvKeyword.AllowUserToAddRows = false;
            this.dgvKeyword.AllowUserToDeleteRows = false;
            this.dgvKeyword.AllowUserToResizeColumns = false;
            this.dgvKeyword.AllowUserToResizeRows = false;
            this.dgvKeyword.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKeyword.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKeyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKeyword.ColumnHeadersVisible = false;
            this.dgvKeyword.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keywordid,
            this.replyKeyword,
            this.replyType,
            this.replyContent,
            this.deleteKeyword});
            this.dgvKeyword.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvKeyword.Location = new System.Drawing.Point(14, 307);
            this.dgvKeyword.Name = "dgvKeyword";
            this.dgvKeyword.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKeyword.RowHeadersDefaultCellStyle = dataGridViewCellStyle52;
            this.dgvKeyword.RowHeadersVisible = false;
            this.dgvKeyword.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvKeyword.RowsDefaultCellStyle = dataGridViewCellStyle53;
            this.dgvKeyword.RowTemplate.Height = 23;
            this.dgvKeyword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvKeyword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeyword.Size = new System.Drawing.Size(700, 232);
            this.dgvKeyword.TabIndex = 42;
            this.dgvKeyword.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKeyword_CellClick);
            // 
            // keywordid
            // 
            this.keywordid.DataPropertyName = "id";
            this.keywordid.HeaderText = "id";
            this.keywordid.MinimumWidth = 50;
            this.keywordid.Name = "keywordid";
            this.keywordid.ReadOnly = true;
            this.keywordid.Visible = false;
            this.keywordid.Width = 50;
            // 
            // replyKeyword
            // 
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.replyKeyword.DefaultCellStyle = dataGridViewCellStyle49;
            this.replyKeyword.HeaderText = "关键字";
            this.replyKeyword.Name = "replyKeyword";
            this.replyKeyword.ReadOnly = true;
            this.replyKeyword.Width = 120;
            // 
            // replyType
            // 
            this.replyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.replyType.DefaultCellStyle = dataGridViewCellStyle50;
            this.replyType.FillWeight = 15.46391F;
            this.replyType.HeaderText = "回复类型";
            this.replyType.Name = "replyType";
            this.replyType.ReadOnly = true;
            this.replyType.Width = 150;
            // 
            // replyContent
            // 
            this.replyContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.replyContent.DataPropertyName = "replyContent";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.replyContent.DefaultCellStyle = dataGridViewCellStyle51;
            this.replyContent.FillWeight = 15.46391F;
            this.replyContent.HeaderText = "回复内容";
            this.replyContent.Name = "replyContent";
            this.replyContent.ReadOnly = true;
            // 
            // deleteKeyword
            // 
            this.deleteKeyword.HeaderText = "删除";
            this.deleteKeyword.Image = global::HotTao.Properties.Resources.icon_delete;
            this.deleteKeyword.Name = "deleteKeyword";
            this.deleteKeyword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteKeyword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Location = new System.Drawing.Point(14, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 36);
            this.panel1.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label7.Location = new System.Drawing.Point(634, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "操作";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "已添加的群";
            // 
            // dgvChatRoom
            // 
            this.dgvChatRoom.AllowUserToAddRows = false;
            this.dgvChatRoom.AllowUserToDeleteRows = false;
            this.dgvChatRoom.AllowUserToResizeColumns = false;
            this.dgvChatRoom.AllowUserToResizeRows = false;
            this.dgvChatRoom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvChatRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChatRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChatRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChatRoom.ColumnHeadersVisible = false;
            this.dgvChatRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupid,
            this.wechattitle,
            this.deleteWechat});
            this.dgvChatRoom.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvChatRoom.Location = new System.Drawing.Point(14, 93);
            this.dgvChatRoom.Name = "dgvChatRoom";
            this.dgvChatRoom.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChatRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.dgvChatRoom.RowHeadersVisible = false;
            this.dgvChatRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvChatRoom.RowsDefaultCellStyle = dataGridViewCellStyle56;
            this.dgvChatRoom.RowTemplate.Height = 23;
            this.dgvChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvChatRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChatRoom.Size = new System.Drawing.Size(700, 127);
            this.dgvChatRoom.TabIndex = 42;
            this.dgvChatRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChatRoom_CellClick);
            // 
            // groupid
            // 
            this.groupid.DataPropertyName = "id";
            this.groupid.HeaderText = "id";
            this.groupid.MinimumWidth = 50;
            this.groupid.Name = "groupid";
            this.groupid.ReadOnly = true;
            this.groupid.Visible = false;
            this.groupid.Width = 50;
            // 
            // wechattitle
            // 
            this.wechattitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.wechattitle.DataPropertyName = "wechattitle";
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.wechattitle.DefaultCellStyle = dataGridViewCellStyle54;
            this.wechattitle.HeaderText = "群昵称";
            this.wechattitle.Name = "wechattitle";
            this.wechattitle.ReadOnly = true;
            this.wechattitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.wechattitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deleteWechat
            // 
            this.deleteWechat.HeaderText = "编辑";
            this.deleteWechat.Image = global::HotTao.Properties.Resources.icon_delete;
            this.deleteWechat.Name = "deleteWechat";
            // 
            // btnWeChat
            // 
            this.btnWeChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnWeChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeChat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnWeChat.FlatAppearance.BorderSize = 0;
            this.btnWeChat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnWeChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnWeChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeChat.ForeColor = System.Drawing.Color.White;
            this.btnWeChat.Location = new System.Drawing.Point(622, 20);
            this.btnWeChat.Name = "btnWeChat";
            this.btnWeChat.Size = new System.Drawing.Size(92, 28);
            this.btnWeChat.TabIndex = 41;
            this.btnWeChat.Text = "添加";
            this.btnWeChat.UseVisualStyleBackColor = false;
            this.btnWeChat.Click += new System.EventHandler(this.btnAddChat_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "自动回复关键字";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(301, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "添加开启自动回复的群";
            // 
            // ckbAutoReplay
            // 
            this.ckbAutoReplay.AutoSize = true;
            this.ckbAutoReplay.Location = new System.Drawing.Point(14, 29);
            this.ckbAutoReplay.Name = "ckbAutoReplay";
            this.ckbAutoReplay.Size = new System.Drawing.Size(96, 16);
            this.ckbAutoReplay.TabIndex = 35;
            this.ckbAutoReplay.Text = "开启自动回复";
            this.ckbAutoReplay.UseVisualStyleBackColor = true;
            this.ckbAutoReplay.CheckedChanged += new System.EventHandler(this.ckbAutoReplay_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(323, -1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "自动回复设置";
            // 
            // SetAutoReplyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SetAutoReplyControl";
            this.Size = new System.Drawing.Size(750, 571);
            this.Load += new System.EventHandler(this.SetAutoReplyControl_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyword)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckbAutoReplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnWeChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvChatRoom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKeyword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn keywordid;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyContent;
        private System.Windows.Forms.DataGridViewImageColumn deleteKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn wechattitle;
        private System.Windows.Forms.DataGridViewImageColumn deleteWechat;
    }
}
