namespace HotTao.Controls
{
    partial class VerifyCoupon
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
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.hotPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.panel7);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(320, 273);
            this.hotPanel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel7.Controls.Add(this.lbTitle);
            this.panel7.Controls.Add(this.pbClose);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(320, 28);
            this.panel7.TabIndex = 9;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(7, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(65, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "验证优惠券";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(300, 7);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(13, 13);
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            // 
            // VerifyCoupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 273);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifyCoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "验券";
            this.hotPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
    }
}