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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChatRoom = new System.Windows.Forms.DataGridView();
            this.btnAddChat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbAutoRemove = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wechattitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteWechat = new System.Windows.Forms.DataGridViewImageColumn();
            this.hotGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChatRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.panel1);
            this.hotGroupBox1.Controls.Add(this.dgvChatRoom);
            this.hotGroupBox1.Controls.Add(this.btnAddChat);
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.ckbAutoRemove);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(8, 8);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 495);
            this.hotGroupBox1.TabIndex = 2;
            this.hotGroupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 60);
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
            this.dgvChatRoom.Location = new System.Drawing.Point(14, 96);
            this.dgvChatRoom.Name = "dgvChatRoom";
            this.dgvChatRoom.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChatRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChatRoom.RowHeadersVisible = false;
            this.dgvChatRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvChatRoom.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChatRoom.RowTemplate.Height = 23;
            this.dgvChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvChatRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChatRoom.Size = new System.Drawing.Size(700, 375);
            this.dgvChatRoom.TabIndex = 42;
            this.dgvChatRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChatRoom_CellClick);
            // 
            // btnAddChat
            // 
            this.btnAddChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChat.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnAddChat.FlatAppearance.BorderSize = 0;
            this.btnAddChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChat.ForeColor = System.Drawing.Color.White;
            this.btnAddChat.Location = new System.Drawing.Point(636, 22);
            this.btnAddChat.Name = "btnAddChat";
            this.btnAddChat.Size = new System.Drawing.Size(78, 32);
            this.btnAddChat.TabIndex = 41;
            this.btnAddChat.Text = "添加";
            this.btnAddChat.UseVisualStyleBackColor = false;
            this.btnAddChat.Click += new System.EventHandler(this.btnAddChat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label3.Location = new System.Drawing.Point(116, 31);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.wechattitle.DefaultCellStyle = dataGridViewCellStyle1;
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
    }
}
