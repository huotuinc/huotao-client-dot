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
            this.plMin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.hotPanel1 = new HotTaoSquare.module.HotPanel(this.components);
            this.picGoback = new System.Windows.Forms.PictureBox();
            this.plTop.SuspendLayout();
            this.plMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoback)).BeginInit();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.SystemColors.Control;
            this.plTop.Controls.Add(this.plMin);
            this.plTop.Controls.Add(this.picClose);
            this.plTop.Controls.Add(this.picGoback);
            this.plTop.Controls.Add(this.picMax);
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
            // plMin
            // 
            this.plMin.Controls.Add(this.panel1);
            this.plMin.Location = new System.Drawing.Point(1175, 5);
            this.plMin.Name = "plMin";
            this.plMin.Size = new System.Drawing.Size(20, 20);
            this.plMin.TabIndex = 120;
            this.plMin.Click += new System.EventHandler(this.plMin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.panel1.Location = new System.Drawing.Point(3, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 2);
            this.panel1.TabIndex = 119;
            this.panel1.Click += new System.EventHandler(this.plMin_Click);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(1225, 5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMax
            // 
            this.picMax.BackColor = System.Drawing.Color.Transparent;
            this.picMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMax.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.picMax.Location = new System.Drawing.Point(1200, 5);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(20, 20);
            this.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMax.TabIndex = 118;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1119, 30);
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
            this.hotPanel1.Size = new System.Drawing.Size(1248, 690);
            this.hotPanel1.TabIndex = 0;
            this.hotPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // picGoback
            // 
            this.picGoback.BackColor = System.Drawing.Color.Transparent;
            this.picGoback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGoback.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.picGoback.Location = new System.Drawing.Point(1149, 4);
            this.picGoback.Name = "picGoback";
            this.picGoback.Size = new System.Drawing.Size(20, 20);
            this.picGoback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGoback.TabIndex = 118;
            this.picGoback.TabStop = false;
            this.picGoback.Click += new System.EventHandler(this.picGoback_Click);
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
            this.plMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoback)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plMin;
        private System.Windows.Forms.PictureBox picGoback;
    }
}