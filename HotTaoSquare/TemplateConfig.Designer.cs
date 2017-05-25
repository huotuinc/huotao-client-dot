namespace HotTaoSquare
{
    partial class TemplateConfig
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
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTempText = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTipMsg = new System.Windows.Forms.Label();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.bgPanel.Controls.Add(this.lbTitle);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(520, 28);
            this.bgPanel.TabIndex = 14;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(7, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(77, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "设置文案模板";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.pbClose.Location = new System.Drawing.Point(494, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.groupBox1.Controls.Add(this.txtTempText);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(6, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 305);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // txtTempText
            // 
            this.txtTempText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtTempText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTempText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTempText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtTempText.Location = new System.Drawing.Point(3, 17);
            this.txtTempText.Name = "txtTempText";
            this.txtTempText.Size = new System.Drawing.Size(502, 285);
            this.txtTempText.TabIndex = 27;
            this.txtTempText.Text = "";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(302, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 25);
            this.label15.TabIndex = 67;
            this.label15.Text = "[简介描述]";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(179, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 25);
            this.label10.TabIndex = 58;
            this.label10.Text = "[分隔符]";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(243, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 25);
            this.label8.TabIndex = 59;
            this.label8.Text = "[短链接]";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(414, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 60;
            this.label7.Text = "[优惠券价格]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(361, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 25);
            this.label6.TabIndex = 61;
            this.label6.Text = "[销量]";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(308, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 25);
            this.label5.TabIndex = 62;
            this.label5.Text = "[来源]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(77, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 63;
            this.label4.Text = "[二合一淘口令]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label12.Location = new System.Drawing.Point(9, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 57;
            this.label12.Text = "可用变量：";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(232, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "[券后价格]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(77, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 66;
            this.label3.Text = "[商品标题]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(156, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 65;
            this.label9.Text = "[商品价格]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.SetTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(7, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "文案模板：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(408, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 32);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "保存文案配置";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbTipMsg
            // 
            this.lbTipMsg.ForeColor = System.Drawing.Color.Red;
            this.lbTipMsg.Location = new System.Drawing.Point(348, 452);
            this.lbTipMsg.Name = "lbTipMsg";
            this.lbTipMsg.Size = new System.Drawing.Size(55, 31);
            this.lbTipMsg.TabIndex = 70;
            this.lbTipMsg.Text = "保存成功";
            this.lbTipMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTipMsg.Visible = false;
            // 
            // TemplateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 492);
            this.Controls.Add(this.lbTipMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bgPanel);
            this.Name = "TemplateConfig";
            this.Text = "TemplateConfig";
            this.Load += new System.EventHandler(this.TemplateConfig_Load);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtTempText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTipMsg;
    }
}