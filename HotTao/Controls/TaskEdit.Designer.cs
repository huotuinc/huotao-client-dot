namespace HotTao.Controls
{
    partial class TaskEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "开始时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "截止时间";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(132, 31);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(190, 21);
            this.txtTaskTitle.TabIndex = 1;
            // 
            // txtStartTime
            // 
            this.txtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartTime.Location = new System.Drawing.Point(132, 68);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(190, 21);
            this.txtStartTime.TabIndex = 2;
            // 
            // txtEndTime
            // 
            this.txtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEndTime.Location = new System.Drawing.Point(132, 108);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(190, 21);
            this.txtEndTime.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(114, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Image = global::HotTao.Properties.Resources.icon_close1;
            this.btnClose.Location = new System.Drawing.Point(378, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TaskEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 198);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndTime);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaskEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskEdit";
            this.Load += new System.EventHandler(this.TaskEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.DateTimePicker txtStartTime;
        private System.Windows.Forms.DateTimePicker txtEndTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox btnClose;
    }
}