namespace HotTao.Controls
{
    partial class SetAutoRemoveChatroom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendTextLenght = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendImageCount = new System.Windows.Forms.TextBox();
            this.ckbSendLink = new System.Windows.Forms.CheckBox();
            this.ckbSendCard = new System.Windows.Forms.CheckBox();
            this.ckbSendMessage = new System.Windows.Forms.CheckBox();
            this.ckbSendImage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChatRoom = new System.Windows.Forms.DataGridView();
            this.groupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wechattitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteWechat = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddChat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbAutoRemove = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.panel1);
            this.hotGroupBox1.Controls.Add(this.dgvChatRoom);
            this.hotGroupBox1.Controls.Add(this.btnAddChat);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.ckbAutoRemove);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 13);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 498);
            this.hotGroupBox1.TabIndex = 2;
            this.hotGroupBox1.TabStop = false;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.label8);
            this.hotGroupBox2.Controls.Add(this.label5);
            this.hotGroupBox2.Controls.Add(this.label6);
            this.hotGroupBox2.Controls.Add(this.txtSendTextLenght);
            this.hotGroupBox2.Controls.Add(this.btnSave);
            this.hotGroupBox2.Controls.Add(this.label4);
            this.hotGroupBox2.Controls.Add(this.txtSendImageCount);
            this.hotGroupBox2.Controls.Add(this.ckbSendLink);
            this.hotGroupBox2.Controls.Add(this.ckbSendCard);
            this.hotGroupBox2.Controls.Add(this.ckbSendMessage);
            this.hotGroupBox2.Controls.Add(this.ckbSendImage);
            this.hotGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox2.Location = new System.Drawing.Point(14, 52);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(700, 173);
            this.hotGroupBox2.TabIndex = 45;
            this.hotGroupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "字，直接踢掉";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "次，直接踢掉";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "超过";
            // 
            // txtSendTextLenght
            // 
            this.txtSendTextLenght.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.txtSendTextLenght.Location = new System.Drawing.Point(112, 18);
            this.txtSendTextLenght.Name = "txtSendTextLenght";
            this.txtSendTextLenght.Size = new System.Drawing.Size(36, 21);
            this.txtSendTextLenght.TabIndex = 2;
            this.txtSendTextLenght.Text = "20";
            this.txtSendTextLenght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(19, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "应用";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "超过";
            // 
            // txtSendImageCount
            // 
            this.txtSendImageCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.txtSendImageCount.Location = new System.Drawing.Point(112, 43);
            this.txtSendImageCount.Name = "txtSendImageCount";
            this.txtSendImageCount.Size = new System.Drawing.Size(36, 21);
            this.txtSendImageCount.TabIndex = 2;
            this.txtSendImageCount.Text = "1";
            this.txtSendImageCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // ckbSendLink
            // 
            this.ckbSendLink.AutoSize = true;
            this.ckbSendLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbSendLink.Location = new System.Drawing.Point(19, 96);
            this.ckbSendLink.Name = "ckbSendLink";
            this.ckbSendLink.Size = new System.Drawing.Size(201, 16);
            this.ckbSendLink.TabIndex = 1;
            this.ckbSendLink.Text = "分享链接直接踢掉(只要包含连接)";
            this.ckbSendLink.UseVisualStyleBackColor = true;
            // 
            // ckbSendCard
            // 
            this.ckbSendCard.AutoSize = true;
            this.ckbSendCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbSendCard.Location = new System.Drawing.Point(19, 70);
            this.ckbSendCard.Name = "ckbSendCard";
            this.ckbSendCard.Size = new System.Drawing.Size(117, 16);
            this.ckbSendCard.TabIndex = 1;
            this.ckbSendCard.Text = "共享名片直接踢掉";
            this.ckbSendCard.UseVisualStyleBackColor = true;
            // 
            // ckbSendMessage
            // 
            this.ckbSendMessage.AutoSize = true;
            this.ckbSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbSendMessage.Location = new System.Drawing.Point(19, 20);
            this.ckbSendMessage.Name = "ckbSendMessage";
            this.ckbSendMessage.Size = new System.Drawing.Size(57, 16);
            this.ckbSendMessage.TabIndex = 0;
            this.ckbSendMessage.Text = "发消息";
            this.ckbSendMessage.UseVisualStyleBackColor = true;
            // 
            // ckbSendImage
            // 
            this.ckbSendImage.AutoSize = true;
            this.ckbSendImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbSendImage.Location = new System.Drawing.Point(19, 45);
            this.ckbSendImage.Name = "ckbSendImage";
            this.ckbSendImage.Size = new System.Drawing.Size(57, 16);
            this.ckbSendImage.TabIndex = 0;
            this.ckbSendImage.Text = "发图片";
            this.ckbSendImage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(311, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "添加自动踢人的群";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Location = new System.Drawing.Point(14, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 36);
            this.panel1.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.7F);
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChatRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvChatRoom.RowHeadersVisible = false;
            this.dgvChatRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvChatRoom.RowsDefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.wechattitle.DefaultCellStyle = dataGridViewCellStyle16;
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
            this.btnAddChat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddChat.FlatAppearance.BorderSize = 0;
            this.btnAddChat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnAddChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChat.ForeColor = System.Drawing.Color.White;
            this.btnAddChat.Location = new System.Drawing.Point(622, 245);
            this.btnAddChat.Name = "btnAddChat";
            this.btnAddChat.Size = new System.Drawing.Size(92, 28);
            this.btnAddChat.TabIndex = 41;
            this.btnAddChat.Text = "添加";
            this.btnAddChat.UseVisualStyleBackColor = false;
            this.btnAddChat.Click += new System.EventHandler(this.btnAddChat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label3.Location = new System.Drawing.Point(109, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "踢人操作必须群主身份";
            // 
            // ckbAutoRemove
            // 
            this.ckbAutoRemove.AutoSize = true;
            this.ckbAutoRemove.Location = new System.Drawing.Point(15, 30);
            this.ckbAutoRemove.Name = "ckbAutoRemove";
            this.ckbAutoRemove.Size = new System.Drawing.Size(96, 16);
            this.ckbAutoRemove.TabIndex = 35;
            this.ckbAutoRemove.Text = "开启自动踢人";
            this.ckbAutoRemove.UseVisualStyleBackColor = true;
            this.ckbAutoRemove.CheckedChanged += new System.EventHandler(this.ckbAutoRemove_CheckedChanged);
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
            this.label9.Text = "自动踢人设置";
            // 
            // SetAutoRemoveChatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SetAutoRemoveChatroom";
            this.Size = new System.Drawing.Size(750, 514);
            this.Load += new System.EventHandler(this.SetAutoRemoveChatroom_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvChatRoom;
        private System.Windows.Forms.Button btnAddChat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbAutoRemove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn wechattitle;
        private System.Windows.Forms.DataGridViewImageColumn deleteWechat;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbSendCard;
        private System.Windows.Forms.CheckBox ckbSendImage;
        private System.Windows.Forms.CheckBox ckbSendLink;
        private System.Windows.Forms.CheckBox ckbSendMessage;
        private System.Windows.Forms.TextBox txtSendImageCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSendTextLenght;
        private System.Windows.Forms.Button btnSave;
    }
}
