namespace HotTao.Controls
{
    partial class SendMessage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtSendMessage = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChatRoom = new System.Windows.Forms.DataGridView();
            this.groupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wechattitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteWechat = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddChat = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSendStatus = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbSendStatus);
            this.hotGroupBox1.Controls.Add(this.label4);
            this.hotGroupBox1.Controls.Add(this.btnSave);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.panel1);
            this.hotGroupBox1.Controls.Add(this.dgvChatRoom);
            this.hotGroupBox1.Controls.Add(this.btnAddChat);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 13);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 498);
            this.hotGroupBox1.TabIndex = 3;
            this.hotGroupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(633, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 27);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "发送";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtSendMessage);
            this.hotGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox2.Location = new System.Drawing.Point(14, 41);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(700, 128);
            this.hotGroupBox2.TabIndex = 45;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtSendMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtSendMessage.Location = new System.Drawing.Point(3, 17);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(694, 108);
            this.txtSendMessage.TabIndex = 0;
            this.txtSendMessage.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "群发内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "此群既是自动回复群";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 36);
            this.panel1.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label7.Location = new System.Drawing.Point(629, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "操作";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
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
            this.dgvChatRoom.Location = new System.Drawing.Point(14, 315);
            this.dgvChatRoom.Name = "dgvChatRoom";
            this.dgvChatRoom.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChatRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvChatRoom.RowHeadersVisible = false;
            this.dgvChatRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvChatRoom.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvChatRoom.RowTemplate.Height = 23;
            this.dgvChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvChatRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChatRoom.Size = new System.Drawing.Size(700, 165);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.wechattitle.DefaultCellStyle = dataGridViewCellStyle7;
            this.wechattitle.HeaderText = "群昵称";
            this.wechattitle.Name = "wechattitle";
            this.wechattitle.ReadOnly = true;
            this.wechattitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.wechattitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deleteWechat
            // 
            this.deleteWechat.HeaderText = "删除";
            this.deleteWechat.Image = global::HotTao.Properties.Resources.icon_delete;
            this.deleteWechat.Name = "deleteWechat";
            this.deleteWechat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteWechat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAddChat
            // 
            this.btnAddChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChat.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnAddChat.FlatAppearance.BorderSize = 0;
            this.btnAddChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChat.ForeColor = System.Drawing.Color.White;
            this.btnAddChat.Location = new System.Drawing.Point(636, 241);
            this.btnAddChat.Name = "btnAddChat";
            this.btnAddChat.Size = new System.Drawing.Size(78, 32);
            this.btnAddChat.TabIndex = 41;
            this.btnAddChat.Text = "添加";
            this.btnAddChat.UseVisualStyleBackColor = false;
            this.btnAddChat.Click += new System.EventHandler(this.btnAddChat_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(323, -1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "发送群消息";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "删除";
            this.dataGridViewImageColumn1.Image = global::HotTao.Properties.Resources.icon_delete;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "发送状态：";
            // 
            // lbSendStatus
            // 
            this.lbSendStatus.AutoSize = true;
            this.lbSendStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbSendStatus.Location = new System.Drawing.Point(77, 182);
            this.lbSendStatus.Name = "lbSendStatus";
            this.lbSendStatus.Size = new System.Drawing.Size(0, 12);
            this.lbSendStatus.TabIndex = 46;
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SendMessage";
            this.Size = new System.Drawing.Size(750, 514);
            this.Load += new System.EventHandler(this.SendMessage_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvChatRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn wechattitle;
        private System.Windows.Forms.DataGridViewImageColumn deleteWechat;
        private System.Windows.Forms.Button btnAddChat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.RichTextBox txtSendMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSendStatus;
        private System.Windows.Forms.Label label4;
    }
}
