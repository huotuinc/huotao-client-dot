namespace HotTaoMonitoring.UserControls
{
    partial class UserEditControl
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.plTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmsMouseTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCtrlV = new System.Windows.Forms.ToolStripMenuItem();
            this.hotPanel1 = new HotTaoMonitoring.module.HotPanel(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.hotWebKitBrowser = new HotTaoMonitoring.module.HotPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.cmsMouseTools.SuspendLayout();
            this.hotPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(0, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(402, 44);
            this.lbTitle.TabIndex = 53;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTaoMonitoring.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(374, 16);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 53;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(404, 1);
            this.plTop.TabIndex = 56;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 1);
            this.panel2.TabIndex = 56;
            // 
            // cmsMouseTools
            // 
            this.cmsMouseTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCtrlV});
            this.cmsMouseTools.Name = "cmsMouseTools";
            this.cmsMouseTools.Size = new System.Drawing.Size(153, 48);
            // 
            // tsmCtrlV
            // 
            this.tsmCtrlV.Name = "tsmCtrlV";
            this.tsmCtrlV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmCtrlV.ShowShortcutKeys = false;
            this.tsmCtrlV.Size = new System.Drawing.Size(127, 22);
            this.tsmCtrlV.Text = "粘贴";
            this.tsmCtrlV.Click += new System.EventHandler(this.tsmCtrlV_Click);
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.btnSend);
            this.hotPanel1.Controls.Add(this.txtContent);
            this.hotPanel1.Location = new System.Drawing.Point(0, 556);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(402, 184);
            this.hotPanel1.TabIndex = 55;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnSend.Location = new System.Drawing.Point(302, 149);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(92, 28);
            this.btnSend.TabIndex = 50;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.White;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.ContextMenuStrip = this.cmsMouseTools;
            this.txtContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtContent.Location = new System.Drawing.Point(7, 9);
            this.txtContent.Margin = new System.Windows.Forms.Padding(5);
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtContent.Size = new System.Drawing.Size(387, 132);
            this.txtContent.TabIndex = 51;
            this.txtContent.Text = "";
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyDown);
            this.txtContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyUp);
            // 
            // hotWebKitBrowser
            // 
            this.hotWebKitBrowser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotWebKitBrowser.Location = new System.Drawing.Point(0, 56);
            this.hotWebKitBrowser.Name = "hotWebKitBrowser";
            this.hotWebKitBrowser.Size = new System.Drawing.Size(402, 494);
            this.hotWebKitBrowser.TabIndex = 54;
            // 
            // UserEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.plTop);
            this.Controls.Add(this.hotPanel1);
            this.Controls.Add(this.hotWebKitBrowser);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lbTitle);
            this.Name = "UserEditControl";
            this.Size = new System.Drawing.Size(402, 740);
            this.Load += new System.EventHandler(this.UserEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.cmsMouseTools.ResumeLayout(false);
            this.hotPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picClose;
        private module.HotPanel hotWebKitBrowser;
        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmsMouseTools;
        private System.Windows.Forms.ToolStripMenuItem tsmCtrlV;
    }
}
