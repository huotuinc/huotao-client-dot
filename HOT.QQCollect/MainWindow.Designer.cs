namespace HOT.QQCollect
{
    partial class MainWindow
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plRightTop = new System.Windows.Forms.Panel();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.QQMainView = new System.Windows.Forms.Panel();
            this.pHead.SuspendLayout();
            this.plRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pHead
            // 
            this.pHead.BackColor = System.Drawing.Color.Gainsboro;
            this.pHead.Controls.Add(this.label1);
            this.pHead.Controls.Add(this.plRightTop);
            this.pHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pHead.Location = new System.Drawing.Point(0, 0);
            this.pHead.Name = "pHead";
            this.pHead.Size = new System.Drawing.Size(920, 25);
            this.pHead.TabIndex = 0;
            this.pHead.Visible = false;
            this.pHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.pHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.pHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 123;
            this.label1.Text = "抓取QQ采集群商品（内部版，请勿外传）";
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.picMin);
            this.plRightTop.Controls.Add(this.picClose);
            this.plRightTop.Location = new System.Drawing.Point(811, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(108, 25);
            this.plRightTop.TabIndex = 122;
            // 
            // picMin
            // 
            this.picMin.BackColor = System.Drawing.Color.Transparent;
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::HOT.QQCollect.Properties.Resources.icon_min_1;
            this.picMin.Location = new System.Drawing.Point(59, 2);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(20, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 118;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HOT.QQCollect.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(85, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // QQMainView
            // 
            this.QQMainView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QQMainView.Location = new System.Drawing.Point(0, 25);
            this.QQMainView.Name = "QQMainView";
            this.QQMainView.Size = new System.Drawing.Size(920, 607);
            this.QQMainView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 632);
            this.Controls.Add(this.pHead);
            this.Controls.Add(this.QQMainView);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "面板";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.pHead.ResumeLayout(false);
            this.pHead.PerformLayout();
            this.plRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHead;
        private System.Windows.Forms.Panel QQMainView;
        private System.Windows.Forms.Panel plRightTop;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label label1;
    }
}

