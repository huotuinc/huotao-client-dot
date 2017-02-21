namespace HotTao.Controls
{
    partial class HistoryControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTaskPlan = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.taskid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pidsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaskPlan
            // 
            this.dgvTaskPlan.AllowUserToAddRows = false;
            this.dgvTaskPlan.AllowUserToDeleteRows = false;
            this.dgvTaskPlan.AllowUserToResizeColumns = false;
            this.dgvTaskPlan.AllowUserToResizeRows = false;
            this.dgvTaskPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTaskPlan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTaskPlan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvTaskPlan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaskPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTaskPlan.ColumnHeadersVisible = false;
            this.dgvTaskPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskid,
            this.taskStatusText,
            this.startTimeText,
            this.taskContent,
            this.taskTitle,
            this.taskRemark,
            this.goodsText,
            this.pidsText,
            this.Column7});
            this.dgvTaskPlan.GridColor = System.Drawing.Color.AntiqueWhite;
            this.dgvTaskPlan.Location = new System.Drawing.Point(12, 82);
            this.dgvTaskPlan.Name = "dgvTaskPlan";
            this.dgvTaskPlan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaskPlan.RowHeadersVisible = false;
            this.dgvTaskPlan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvTaskPlan.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaskPlan.RowTemplate.Height = 23;
            this.dgvTaskPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskPlan.Size = new System.Drawing.Size(904, 375);
            this.dgvTaskPlan.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 36);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.label5.Location = new System.Drawing.Point(497, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "计划内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.label3.Location = new System.Drawing.Point(271, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "计划时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.label4.Location = new System.Drawing.Point(137, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "计划ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.label2.Location = new System.Drawing.Point(729, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "备注";
            // 
            // taskid
            // 
            this.taskid.DataPropertyName = "id";
            this.taskid.HeaderText = "ID";
            this.taskid.MinimumWidth = 130;
            this.taskid.Name = "taskid";
            this.taskid.ReadOnly = true;
            this.taskid.Width = 130;
            // 
            // taskStatusText
            // 
            this.taskStatusText.DataPropertyName = "statusText";
            this.taskStatusText.HeaderText = "执行状态";
            this.taskStatusText.MinimumWidth = 130;
            this.taskStatusText.Name = "taskStatusText";
            this.taskStatusText.ReadOnly = true;
            this.taskStatusText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.taskStatusText.Width = 130;
            // 
            // startTimeText
            // 
            this.startTimeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.startTimeText.DataPropertyName = "startTimeText";
            this.startTimeText.HeaderText = "执行时间";
            this.startTimeText.Name = "startTimeText";
            this.startTimeText.ReadOnly = true;
            this.startTimeText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // taskContent
            // 
            this.taskContent.DataPropertyName = "taskContent";
            this.taskContent.HeaderText = "计划内容";
            this.taskContent.Name = "taskContent";
            this.taskContent.ReadOnly = true;
            this.taskContent.Visible = false;
            this.taskContent.Width = 21;
            // 
            // taskTitle
            // 
            this.taskTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskTitle.DataPropertyName = "title";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.taskTitle.DefaultCellStyle = dataGridViewCellStyle1;
            this.taskTitle.HeaderText = "任务标题";
            this.taskTitle.Name = "taskTitle";
            this.taskTitle.ReadOnly = true;
            this.taskTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // taskRemark
            // 
            this.taskRemark.DataPropertyName = "remark";
            this.taskRemark.HeaderText = "备注";
            this.taskRemark.MinimumWidth = 180;
            this.taskRemark.Name = "taskRemark";
            this.taskRemark.ReadOnly = true;
            this.taskRemark.Width = 180;
            // 
            // goodsText
            // 
            this.goodsText.DataPropertyName = "goodsText";
            this.goodsText.HeaderText = "推广商品ids";
            this.goodsText.Name = "goodsText";
            this.goodsText.ReadOnly = true;
            this.goodsText.Visible = false;
            this.goodsText.Width = 21;
            // 
            // pidsText
            // 
            this.pidsText.DataPropertyName = "pidsText";
            this.pidsText.HeaderText = "推广位ids";
            this.pidsText.Name = "pidsText";
            this.pidsText.ReadOnly = true;
            this.pidsText.Visible = false;
            this.pidsText.Width = 21;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "编辑";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Visible = false;
            this.Column7.Width = 21;
            // 
            // HistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTaskPlan);
            this.Controls.Add(this.panel2);
            this.Name = "HistoryControl";
            this.Size = new System.Drawing.Size(930, 472);
            this.Load += new System.EventHandler(this.HistoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaskPlan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskid;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsText;
        private System.Windows.Forms.DataGridViewTextBoxColumn pidsText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
