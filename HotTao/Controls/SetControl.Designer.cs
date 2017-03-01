namespace HotTao.Controls
{
    partial class SetControl
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
            this.SetContainer = new System.Windows.Forms.SplitContainer();
            this.hotLeftPanel = new HotTao.Controls.module.HotPanel(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.plSet5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.plSet4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plSet3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.plSet1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plSet2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.hotPanel2 = new HotTao.Controls.module.HotPanel(this.components);
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SetContainer)).BeginInit();
            this.SetContainer.Panel1.SuspendLayout();
            this.SetContainer.Panel2.SuspendLayout();
            this.SetContainer.SuspendLayout();
            this.hotLeftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plSet5.SuspendLayout();
            this.plSet4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.plSet3.SuspendLayout();
            this.plSet1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.plSet2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetContainer
            // 
            this.SetContainer.BackColor = System.Drawing.Color.Transparent;
            this.SetContainer.IsSplitterFixed = true;
            this.SetContainer.Location = new System.Drawing.Point(0, 0);
            this.SetContainer.Name = "SetContainer";
            // 
            // SetContainer.Panel1
            // 
            this.SetContainer.Panel1.Controls.Add(this.hotLeftPanel);
            this.SetContainer.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            // 
            // SetContainer.Panel2
            // 
            this.SetContainer.Panel2.AutoScroll = true;
            this.SetContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.SetContainer.Panel2.Controls.Add(this.splitContainer1);
            this.SetContainer.Panel2.Controls.Add(this.hotPanel2);
            this.SetContainer.Size = new System.Drawing.Size(919, 606);
            this.SetContainer.SplitterDistance = 168;
            this.SetContainer.SplitterWidth = 1;
            this.SetContainer.TabIndex = 0;
            // 
            // hotLeftPanel
            // 
            this.hotLeftPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotLeftPanel.Controls.Add(this.panel3);
            this.hotLeftPanel.Controls.Add(this.plSet5);
            this.hotLeftPanel.Controls.Add(this.plSet4);
            this.hotLeftPanel.Controls.Add(this.panel1);
            this.hotLeftPanel.Controls.Add(this.plSet3);
            this.hotLeftPanel.Controls.Add(this.plSet1);
            this.hotLeftPanel.Controls.Add(this.panel2);
            this.hotLeftPanel.Controls.Add(this.panel5);
            this.hotLeftPanel.Controls.Add(this.plSet2);
            this.hotLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.hotLeftPanel.Name = "hotLeftPanel";
            this.hotLeftPanel.Size = new System.Drawing.Size(168, 606);
            this.hotLeftPanel.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(1, 240);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 30);
            this.panel3.TabIndex = 3;
            this.panel3.Tag = "6";
            this.panel3.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 0;
            this.label9.Tag = "6";
            this.label9.Text = "自动踢人设置";
            this.label9.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // plSet5
            // 
            this.plSet5.BackColor = System.Drawing.Color.White;
            this.plSet5.Controls.Add(this.label8);
            this.plSet5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSet5.Location = new System.Drawing.Point(1, 210);
            this.plSet5.Name = "plSet5";
            this.plSet5.Size = new System.Drawing.Size(166, 30);
            this.plSet5.TabIndex = 3;
            this.plSet5.Tag = "5";
            this.plSet5.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 0;
            this.label8.Tag = "5";
            this.label8.Text = "自动回复设置";
            this.label8.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // plSet4
            // 
            this.plSet4.BackColor = System.Drawing.Color.White;
            this.plSet4.Controls.Add(this.label7);
            this.plSet4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSet4.Location = new System.Drawing.Point(1, 150);
            this.plSet4.Name = "plSet4";
            this.plSet4.Size = new System.Drawing.Size(166, 30);
            this.plSet4.TabIndex = 2;
            this.plSet4.Tag = "4";
            this.plSet4.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(51, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Tag = "4";
            this.label7.Text = "群发设置";
            this.label7.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 30);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotTao.Properties.Resources.icon_set;
            this.pictureBox1.Location = new System.Drawing.Point(20, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账户设置";
            // 
            // plSet3
            // 
            this.plSet3.BackColor = System.Drawing.Color.White;
            this.plSet3.Controls.Add(this.label6);
            this.plSet3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSet3.Location = new System.Drawing.Point(1, 120);
            this.plSet3.Name = "plSet3";
            this.plSet3.Size = new System.Drawing.Size(166, 30);
            this.plSet3.TabIndex = 1;
            this.plSet3.Tag = "3";
            this.plSet3.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(51, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Tag = "3";
            this.label6.Text = "文案";
            this.label6.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // plSet1
            // 
            this.plSet1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.plSet1.Controls.Add(this.label2);
            this.plSet1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSet1.Location = new System.Drawing.Point(1, 30);
            this.plSet1.Name = "plSet1";
            this.plSet1.Size = new System.Drawing.Size(166, 30);
            this.plSet1.TabIndex = 0;
            this.plSet1.Tag = "1";
            this.plSet1.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Tag = "1";
            this.label2.Text = "软件账户设置";
            this.label2.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.panel2.Location = new System.Drawing.Point(1, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 30);
            this.panel2.TabIndex = 0;
            this.panel2.Tag = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotTao.Properties.Resources.icon_set4;
            this.pictureBox3.Location = new System.Drawing.Point(20, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "辅助设置";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.panel5.Location = new System.Drawing.Point(1, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 30);
            this.panel5.TabIndex = 0;
            this.panel5.Tag = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotTao.Properties.Resources.icon_set2;
            this.pictureBox2.Location = new System.Drawing.Point(20, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "软件设置";
            // 
            // plSet2
            // 
            this.plSet2.BackColor = System.Drawing.Color.White;
            this.plSet2.Controls.Add(this.label3);
            this.plSet2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSet2.Location = new System.Drawing.Point(1, 60);
            this.plSet2.Name = "plSet2";
            this.plSet2.Size = new System.Drawing.Size(166, 30);
            this.plSet2.TabIndex = 0;
            this.plSet2.Tag = "2";
            this.plSet2.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Tag = "2";
            this.label3.Text = "淘宝账号";
            this.label3.Click += new System.EventHandler(this.SwitchControl_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(750, 606);
            this.splitContainer1.SplitterDistance = 564;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(635, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "确认";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hotPanel2
            // 
            this.hotPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel2.Location = new System.Drawing.Point(0, 0);
            this.hotPanel2.Name = "hotPanel2";
            this.hotPanel2.Size = new System.Drawing.Size(750, 606);
            this.hotPanel2.TabIndex = 1;
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 607);
            this.hotPanel1.TabIndex = 1;
            // 
            // SetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SetContainer);
            this.Controls.Add(this.hotPanel1);
            this.Name = "SetControl";
            this.Size = new System.Drawing.Size(920, 607);
            this.Load += new System.EventHandler(this.SetControl_Load);
            this.SetContainer.Panel1.ResumeLayout(false);
            this.SetContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SetContainer)).EndInit();
            this.SetContainer.ResumeLayout(false);
            this.hotLeftPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.plSet5.ResumeLayout(false);
            this.plSet5.PerformLayout();
            this.plSet4.ResumeLayout(false);
            this.plSet4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.plSet3.ResumeLayout(false);
            this.plSet3.PerformLayout();
            this.plSet1.ResumeLayout(false);
            this.plSet1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.plSet2.ResumeLayout(false);
            this.plSet2.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SetContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel plSet2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plSet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel plSet3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel plSet4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel plSet5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private module.HotPanel hotLeftPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private module.HotPanel hotPanel1;
        private module.HotPanel hotPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
    }
}
