namespace HotTao.Controls
{
    partial class SetAccountControl
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
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbRegtime = new System.Windows.Forms.Label();
            this.lbLevelName = new System.Windows.Forms.Label();
            this.lbTaobaoName = new System.Windows.Forms.Label();
            this.lbLoginName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hotGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.label9);
            this.hotGroupBox2.Controls.Add(this.btnLogout);
            this.hotGroupBox2.Controls.Add(this.lbRegtime);
            this.hotGroupBox2.Controls.Add(this.lbLevelName);
            this.hotGroupBox2.Controls.Add(this.lbTaobaoName);
            this.hotGroupBox2.Controls.Add(this.lbLoginName);
            this.hotGroupBox2.Controls.Add(this.pictureBox1);
            this.hotGroupBox2.Controls.Add(this.label5);
            this.hotGroupBox2.Controls.Add(this.label3);
            this.hotGroupBox2.Controls.Add(this.label1);
            this.hotGroupBox2.Controls.Add(this.label8);
            this.hotGroupBox2.Location = new System.Drawing.Point(10, 12);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(730, 204);
            this.hotGroupBox2.TabIndex = 29;
            this.hotGroupBox2.TabStop = false;
            this.hotGroupBox2.Enter += new System.EventHandler(this.hotGroupBox2_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新宋体", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label9.Location = new System.Drawing.Point(193, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "淘宝账号：";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(196, 146);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 28);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "注销";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbRegtime
            // 
            this.lbRegtime.AutoSize = true;
            this.lbRegtime.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRegtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbRegtime.Location = new System.Drawing.Point(557, 44);
            this.lbRegtime.Name = "lbRegtime";
            this.lbRegtime.Size = new System.Drawing.Size(77, 14);
            this.lbRegtime.TabIndex = 17;
            this.lbRegtime.Text = "1970-01-01";
            this.lbRegtime.Visible = false;
            // 
            // lbLevelName
            // 
            this.lbLevelName.AutoSize = true;
            this.lbLevelName.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLevelName.ForeColor = System.Drawing.Color.Red;
            this.lbLevelName.Location = new System.Drawing.Point(243, 77);
            this.lbLevelName.Name = "lbLevelName";
            this.lbLevelName.Size = new System.Drawing.Size(35, 14);
            this.lbLevelName.TabIndex = 17;
            this.lbLevelName.Text = "普通";
            // 
            // lbTaobaoName
            // 
            this.lbTaobaoName.AutoSize = true;
            this.lbTaobaoName.Font = new System.Drawing.Font("新宋体", 10F);
            this.lbTaobaoName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbTaobaoName.Location = new System.Drawing.Point(273, 109);
            this.lbTaobaoName.Name = "lbTaobaoName";
            this.lbTaobaoName.Size = new System.Drawing.Size(140, 14);
            this.lbTaobaoName.TabIndex = 17;
            this.lbTaobaoName.Text = "your taobao account";
            // 
            // lbLoginName
            // 
            this.lbLoginName.AutoSize = true;
            this.lbLoginName.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbLoginName.Location = new System.Drawing.Point(243, 43);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(35, 14);
            this.lbLoginName.TabIndex = 17;
            this.lbLoginName.Text = "demo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotTao.Properties.Resources._140x140;
            this.pictureBox1.Location = new System.Drawing.Point(25, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label5.Location = new System.Drawing.Point(481, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "注册时间：";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label3.Location = new System.Drawing.Point(193, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "等级：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(193, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "账户：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label8.Location = new System.Drawing.Point(332, -4);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5);
            this.label8.Size = new System.Drawing.Size(67, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "账户信息";
            // 
            // SetAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox2);
            this.Name = "SetAccountControl";
            this.Size = new System.Drawing.Size(750, 241);
            this.Load += new System.EventHandler(this.SetAccountControl_Load);
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbLoginName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLevelName;
        private System.Windows.Forms.Label lbRegtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTaobaoName;
    }
}
