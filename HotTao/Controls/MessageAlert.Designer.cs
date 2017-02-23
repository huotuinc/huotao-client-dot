namespace HotTao.Controls
{
    partial class MessageAlert
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lbContent = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel7.Controls.Add(this.lbTitle);
            this.panel7.Controls.Add(this.pbClose);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(284, 22);
            this.panel7.TabIndex = 7;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(7, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(29, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "提示";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(263, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(13, 13);
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.toolTip1.SetToolTip(this.pbClose, "关闭");
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lbContent
            // 
            this.lbContent.BackColor = System.Drawing.Color.Transparent;
            this.lbContent.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbContent.Location = new System.Drawing.Point(0, 20);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(284, 60);
            this.lbContent.TabIndex = 8;
            this.lbContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackgroundImage = global::HotTao.Properties.Resources.icon_login_bg;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(80, 82);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(111, 29);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // MessageAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            this.BackgroundImage = global::HotTao.Properties.Resources.icon_login_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageAlert";
            this.Load += new System.EventHandler(this.MessageAlert_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}