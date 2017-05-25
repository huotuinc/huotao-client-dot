namespace HotTaoSquare
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.plTop = new System.Windows.Forms.Panel();
            this.plRightTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.hotPanel1 = new HotTaoSquare.module.HotPanel(this.components);
            this.picForward = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picRefresh = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.plTop.SuspendLayout();
            this.plRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.SystemColors.Control;
            this.plTop.Controls.Add(this.plRightTop);
            this.plTop.Controls.Add(this.lbTitle);
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1250, 30);
            this.plTop.TabIndex = 119;
            this.plTop.DoubleClick += new System.EventHandler(this.picMax_Click);
            this.plTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.plTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.plTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.picForward);
            this.plRightTop.Controls.Add(this.picMin);
            this.plRightTop.Controls.Add(this.pictureBox2);
            this.plRightTop.Controls.Add(this.pictureBox1);
            this.plRightTop.Controls.Add(this.picClose);
            this.plRightTop.Controls.Add(this.picRefresh);
            this.plRightTop.Controls.Add(this.picBack);
            this.plRightTop.Location = new System.Drawing.Point(1015, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(234, 28);
            this.plRightTop.TabIndex = 121;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(868, 30);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "淘广场";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.DoubleClick += new System.EventHandler(this.picMax_Click);
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.lbTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Location = new System.Drawing.Point(1, 30);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(1248, 689);
            this.hotPanel1.TabIndex = 0;
            this.hotPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // picForward
            // 
            this.picForward.BackColor = System.Drawing.Color.Transparent;
            this.picForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picForward.Image = global::HotTaoSquare.Properties.Resources.qj13x13;
            this.picForward.Location = new System.Drawing.Point(127, 4);
            this.picForward.Name = "picForward";
            this.picForward.Size = new System.Drawing.Size(20, 20);
            this.picForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picForward.TabIndex = 118;
            this.picForward.TabStop = false;
            this.picForward.Click += new System.EventHandler(this.picForward_Click);
            // 
            // picMin
            // 
            this.picMin.BackColor = System.Drawing.Color.Transparent;
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::HotTaoSquare.Properties.Resources.icon_min;
            this.picMin.Location = new System.Drawing.Point(178, 4);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(20, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 118;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.plMin_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HotTaoSquare.Properties.Resources.config;
            this.pictureBox2.Location = new System.Drawing.Point(76, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 118;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.lbSetting_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::HotTaoSquare.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(50, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.picHome_Click);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(203, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picRefresh
            // 
            this.picRefresh.BackColor = System.Drawing.Color.Transparent;
            this.picRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefresh.Image = global::HotTaoSquare.Properties.Resources.sx13x13;
            this.picRefresh.Location = new System.Drawing.Point(152, 4);
            this.picRefresh.Name = "picRefresh";
            this.picRefresh.Size = new System.Drawing.Size(20, 20);
            this.picRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRefresh.TabIndex = 118;
            this.picRefresh.TabStop = false;
            this.picRefresh.Click += new System.EventHandler(this.picRefresh_Click);
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBack.Image = global::HotTaoSquare.Properties.Resources.ht13x13;
            this.picBack.Location = new System.Drawing.Point(102, 4);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(20, 20);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBack.TabIndex = 118;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 720);
            this.Controls.Add(this.plTop);
            this.Controls.Add(this.hotPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "淘广场";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.plTop.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox picForward;
        private System.Windows.Forms.PictureBox picRefresh;
        private System.Windows.Forms.Panel plRightTop;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}