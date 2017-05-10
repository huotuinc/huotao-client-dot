namespace QQLogin
{
    partial class QQGroupList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQGroupList));
            this.dgvContact = new System.Windows.Forms.DataGridView();
            this.QQFace = new System.Windows.Forms.DataGridViewImageColumn();
            this.GroupGid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAddListen = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
            this.cmsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContact
            // 
            this.dgvContact.AllowUserToAddRows = false;
            this.dgvContact.AllowUserToDeleteRows = false;
            this.dgvContact.AllowUserToResizeColumns = false;
            this.dgvContact.AllowUserToResizeRows = false;
            this.dgvContact.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
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
            this.dgvContact.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvContact.Location = new System.Drawing.Point(1, 28);
            this.dgvContact.MultiSelect = false;
            this.dgvContact.Name = "dgvContact";
            this.dgvContact.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContact.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContact.RowHeadersVisible = false;
            this.dgvContact.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvContact.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContact.RowTemplate.Height = 60;
            this.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContact.Size = new System.Drawing.Size(283, 554);
            this.dgvContact.TabIndex = 12;
            this.dgvContact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContact_CellClick);
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
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GroupTitle.DefaultCellStyle = dataGridViewCellStyle1;
            this.GroupTitle.HeaderText = "GroupTitle";
            this.GroupTitle.Name = "GroupTitle";
            // 
            // cmsTools
            // 
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddListen});
            this.cmsTools.Name = "cmsTools";
            this.cmsTools.Size = new System.Drawing.Size(125, 26);
            this.cmsTools.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTools_Opening);
            // 
            // toolAddListen
            // 
            this.toolAddListen.Name = "toolAddListen";
            this.toolAddListen.Size = new System.Drawing.Size(124, 22);
            this.toolAddListen.Text = "添加监控";
            this.toolAddListen.Click += new System.EventHandler(this.toolAddListen_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Location = new System.Drawing.Point(6, 2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(228, 23);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.lbTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "QQFace";
            this.dataGridViewImageColumn1.Image = global::QQLogin.Properties.Resources.QQ40x40;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // picMin
            // 
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::QQLogin.Properties.Resources.icon_min;
            this.picMin.Location = new System.Drawing.Point(239, 2);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(20, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 2;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::QQLogin.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(262, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picLoading
            // 
            this.picLoading.Image = global::QQLogin.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(0, 27);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(284, 555);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 13;
            this.picLoading.TabStop = false;
            // 
            // QQGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 582);
            this.Controls.Add(this.picMin);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.dgvContact);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QQGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QQ群列表";
            this.Load += new System.EventHandler(this.QQGroupList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
            this.cmsTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContact;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.ContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem toolAddListen;
        private System.Windows.Forms.DataGridViewImageColumn QQFace;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupGid;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
    }
}