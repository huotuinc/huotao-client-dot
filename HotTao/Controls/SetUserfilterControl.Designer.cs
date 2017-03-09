namespace HotTao.Controls
{
    partial class SetUserfilterControl
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtUserfilter = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "删除";
            this.dataGridViewImageColumn1.Image = global::HotTao.Properties.Resources.icon_delete;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "编辑";
            this.dataGridViewImageColumn2.Image = global::HotTao.Properties.Resources.icon_delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.label3);
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox1.Controls.Add(this.btnSave);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 13);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 548);
            this.hotGroupBox1.TabIndex = 2;
            this.hotGroupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(611, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "请在文本中填入需要过滤的微信用户昵称，多个昵称之间用空格隔开，昵称用[]括起来，格式[昵称1] [昵称2] ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "开启自动回复或踢人动作后，将不对本功能中设置的用户生效。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "说明：";
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtUserfilter);
            this.hotGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox2.Location = new System.Drawing.Point(14, 38);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(700, 221);
            this.hotGroupBox2.TabIndex = 46;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtUserfilter
            // 
            this.txtUserfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtUserfilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserfilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserfilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUserfilter.Location = new System.Drawing.Point(3, 17);
            this.txtUserfilter.Name = "txtUserfilter";
            this.txtUserfilter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtUserfilter.Size = new System.Drawing.Size(694, 201);
            this.txtUserfilter.TabIndex = 0;
            this.txtUserfilter.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(622, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(330, -1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "用户过滤设置";
            // 
            // SetUserfilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SetUserfilterControl";
            this.Size = new System.Drawing.Size(750, 571);
            this.Load += new System.EventHandler(this.SetUserfilterControl_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtUserfilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
