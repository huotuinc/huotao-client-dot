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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTaskPlan = new System.Windows.Forms.DataGridView();
            this.taskid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTpwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpwdText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pidsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edittask = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmsTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsTaskUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsTaskCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsTaskTpwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsTaskDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnStartTpwd = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).BeginInit();
            this.panel2.SuspendLayout();
            this.cmsTask.SuspendLayout();
            this.hotPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaskPlan
            // 
            this.dgvTaskPlan.AllowUserToAddRows = false;
            this.dgvTaskPlan.AllowUserToDeleteRows = false;
            this.dgvTaskPlan.AllowUserToResizeColumns = false;
            this.dgvTaskPlan.AllowUserToResizeRows = false;
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
            this.isTpwd,
            this.TpwdText,
            this.goodsText,
            this.ExecStatus,
            this.pidsText,
            this.taskStartTime,
            this.taskEndTime,
            this.edittask});
            this.dgvTaskPlan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvTaskPlan.Location = new System.Drawing.Point(12, 85);
            this.dgvTaskPlan.MultiSelect = false;
            this.dgvTaskPlan.Name = "dgvTaskPlan";
            this.dgvTaskPlan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaskPlan.RowHeadersVisible = false;
            this.dgvTaskPlan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvTaskPlan.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTaskPlan.RowTemplate.Height = 23;
            this.dgvTaskPlan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTaskPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskPlan.Size = new System.Drawing.Size(895, 500);
            this.dgvTaskPlan.TabIndex = 4;
            this.dgvTaskPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaskPlan_CellClick);
            this.dgvTaskPlan.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTaskPlan_CellMouseMove);
            // 
            // taskid
            // 
            this.taskid.DataPropertyName = "id";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.taskid.DefaultCellStyle = dataGridViewCellStyle11;
            this.taskid.HeaderText = "ID";
            this.taskid.MinimumWidth = 100;
            this.taskid.Name = "taskid";
            this.taskid.ReadOnly = true;
            // 
            // taskStatusText
            // 
            this.taskStatusText.DataPropertyName = "statusText";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.taskStatusText.DefaultCellStyle = dataGridViewCellStyle12;
            this.taskStatusText.HeaderText = "执行状态";
            this.taskStatusText.MinimumWidth = 80;
            this.taskStatusText.Name = "taskStatusText";
            this.taskStatusText.ReadOnly = true;
            this.taskStatusText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.taskStatusText.Width = 80;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.taskTitle.DefaultCellStyle = dataGridViewCellStyle13;
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
            this.taskRemark.Visible = false;
            this.taskRemark.Width = 180;
            // 
            // isTpwd
            // 
            this.isTpwd.DataPropertyName = "isTpwd";
            this.isTpwd.HeaderText = "是否转链";
            this.isTpwd.Name = "isTpwd";
            this.isTpwd.ReadOnly = true;
            this.isTpwd.Visible = false;
            // 
            // TpwdText
            // 
            this.TpwdText.DataPropertyName = "TpwdText";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TpwdText.DefaultCellStyle = dataGridViewCellStyle14;
            this.TpwdText.HeaderText = "转链结果";
            this.TpwdText.Name = "TpwdText";
            this.TpwdText.ReadOnly = true;
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
            // ExecStatus
            // 
            this.ExecStatus.HeaderText = "ExecStatus";
            this.ExecStatus.Name = "ExecStatus";
            this.ExecStatus.ReadOnly = true;
            this.ExecStatus.Visible = false;
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
            // taskStartTime
            // 
            this.taskStartTime.HeaderText = "taskStartTime";
            this.taskStartTime.Name = "taskStartTime";
            this.taskStartTime.ReadOnly = true;
            this.taskStartTime.Visible = false;
            // 
            // taskEndTime
            // 
            this.taskEndTime.HeaderText = "taskEndTime";
            this.taskEndTime.Name = "taskEndTime";
            this.taskEndTime.ReadOnly = true;
            this.taskEndTime.Visible = false;
            // 
            // edittask
            // 
            this.edittask.HeaderText = "编辑";
            this.edittask.Image = global::HotTao.Properties.Resources.icon_edit;
            this.edittask.Name = "edittask";
            this.edittask.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.edittask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edittask.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(12, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 36);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label6.Location = new System.Drawing.Point(766, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "转链结果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label2.Location = new System.Drawing.Point(482, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "计划标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label3.Location = new System.Drawing.Point(189, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "计划时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "计划ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(124, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "状态";
            // 
            // cmsTask
            // 
            this.cmsTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsTaskUpdate,
            this.toolsTaskCopy,
            this.toolsTaskTpwd,
            this.toolsTaskDelete});
            this.cmsTask.Name = "cmsTask";
            this.cmsTask.Size = new System.Drawing.Size(125, 92);
            // 
            // toolsTaskUpdate
            // 
            this.toolsTaskUpdate.Name = "toolsTaskUpdate";
            this.toolsTaskUpdate.Size = new System.Drawing.Size(124, 22);
            this.toolsTaskUpdate.Text = "修改";
            this.toolsTaskUpdate.Click += new System.EventHandler(this.toolsTaskUpdate_Click);
            // 
            // toolsTaskCopy
            // 
            this.toolsTaskCopy.Name = "toolsTaskCopy";
            this.toolsTaskCopy.Size = new System.Drawing.Size(124, 22);
            this.toolsTaskCopy.Text = "复制计划";
            this.toolsTaskCopy.Click += new System.EventHandler(this.toolsTaskCopy_Click);
            // 
            // toolsTaskTpwd
            // 
            this.toolsTaskTpwd.Name = "toolsTaskTpwd";
            this.toolsTaskTpwd.Size = new System.Drawing.Size(124, 22);
            this.toolsTaskTpwd.Text = "一键转链";
            this.toolsTaskTpwd.Click += new System.EventHandler(this.toolsTaskTpwd_Click);
            // 
            // toolsTaskDelete
            // 
            this.toolsTaskDelete.Name = "toolsTaskDelete";
            this.toolsTaskDelete.Size = new System.Drawing.Size(124, 22);
            this.toolsTaskDelete.Text = "删除";
            this.toolsTaskDelete.Click += new System.EventHandler(this.toolsTaskDelete_Click);
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label5);
            this.hotPanel1.Controls.Add(this.label7);
            this.hotPanel1.Controls.Add(this.label14);
            this.hotPanel1.Controls.Add(this.btnStartTpwd);
            this.hotPanel1.Controls.Add(this.btnStartTask);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 593);
            this.hotPanel1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label7.Location = new System.Drawing.Point(492, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "只针对待执行未转链的任务进行转链";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label14.Location = new System.Drawing.Point(10, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 18;
            this.label14.Text = "任务计划列表";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartTpwd
            // 
            this.btnStartTpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartTpwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTpwd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartTpwd.FlatAppearance.BorderSize = 0;
            this.btnStartTpwd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnStartTpwd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnStartTpwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTpwd.ForeColor = System.Drawing.Color.White;
            this.btnStartTpwd.Location = new System.Drawing.Point(707, 10);
            this.btnStartTpwd.Name = "btnStartTpwd";
            this.btnStartTpwd.Size = new System.Drawing.Size(97, 29);
            this.btnStartTpwd.TabIndex = 17;
            this.btnStartTpwd.Text = "开始转链";
            this.btnStartTpwd.UseVisualStyleBackColor = false;
            this.btnStartTpwd.Click += new System.EventHandler(this.btnStartTpwd_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.FlatAppearance.BorderSize = 0;
            this.btnStartTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnStartTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnStartTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTask.ForeColor = System.Drawing.Color.White;
            this.btnStartTask.Location = new System.Drawing.Point(810, 10);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(97, 29);
            this.btnStartTask.TabIndex = 17;
            this.btnStartTask.Text = "启动计划";
            this.btnStartTask.UseVisualStyleBackColor = false;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label5.Location = new System.Drawing.Point(492, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "转链前，先确认是否设置PID";
            // 
            // HistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTaskPlan);
            this.Controls.Add(this.hotPanel1);
            this.Name = "HistoryControl";
            this.Size = new System.Drawing.Size(920, 593);
            this.Load += new System.EventHandler(this.HistoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsTask.ResumeLayout(false);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaskPlan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Button btnStartTpwd;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ContextMenuStrip cmsTask;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskCopy;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskTpwd;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskid;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn isTpwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TpwdText;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn pidsText;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskEndTime;
        private System.Windows.Forms.DataGridViewImageColumn edittask;
        private System.Windows.Forms.Label label5;
    }
}
