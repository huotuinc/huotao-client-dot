namespace HotTao.Controls
{
    partial class MenuControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAbout = new System.Windows.Forms.Label();
            this.lbLogout = new System.Windows.Forms.Label();
            this.lbSwitchTaobao = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 1);
            this.panel1.TabIndex = 0;
            // 
            // lbAbout
            // 
            this.lbAbout.AutoSize = true;
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAbout.Location = new System.Drawing.Point(14, 12);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(53, 12);
            this.lbAbout.TabIndex = 1;
            this.lbAbout.Text = "关于我们";
            this.lbAbout.Click += new System.EventHandler(this.lbAbout_Click);
            // 
            // lbLogout
            // 
            this.lbLogout.AutoSize = true;
            this.lbLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogout.Location = new System.Drawing.Point(13, 99);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(29, 12);
            this.lbLogout.TabIndex = 1;
            this.lbLogout.Text = "退出";
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // lbSwitchTaobao
            // 
            this.lbSwitchTaobao.AutoSize = true;
            this.lbSwitchTaobao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbSwitchTaobao.Location = new System.Drawing.Point(12, 43);
            this.lbSwitchTaobao.Name = "lbSwitchTaobao";
            this.lbSwitchTaobao.Size = new System.Drawing.Size(53, 12);
            this.lbSwitchTaobao.TabIndex = 1;
            this.lbSwitchTaobao.Text = "切换淘宝";
            this.lbSwitchTaobao.Click += new System.EventHandler(this.lbSwitchTaobao_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(12, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(55, 1);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Location = new System.Drawing.Point(14, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(55, 1);
            this.panel3.TabIndex = 0;
            // 
            // lbHelp
            // 
            this.lbHelp.AutoSize = true;
            this.lbHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbHelp.Location = new System.Drawing.Point(13, 72);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(53, 12);
            this.lbHelp.TabIndex = 1;
            this.lbHelp.Text = "使用说明";
            this.lbHelp.Click += new System.EventHandler(this.lbHelp_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(72, 118);
            this.Controls.Add(this.lbSwitchTaobao);
            this.Controls.Add(this.lbHelp);
            this.Controls.Add(this.lbLogout);
            this.Controls.Add(this.lbAbout);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MenuControl";
            this.Load += new System.EventHandler(this.MenuControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Label lbLogout;
        private System.Windows.Forms.Label lbSwitchTaobao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbHelp;
    }
}