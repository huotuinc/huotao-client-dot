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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvLogView = new System.Windows.Forms.DataGridView();
            this.logTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keeperid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commissionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmsLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolClearAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).BeginInit();
            this.panel2.SuspendLayout();
            this.cmsTask.SuspendLayout();
            this.hotPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogView)).BeginInit();
            this.cmsLog.SuspendLayout();
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
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvTaskPlan.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTaskPlan.RowTemplate.Height = 23;
            this.dgvTaskPlan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTaskPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskPlan.Size = new System.Drawing.Size(895, 500);
            this.dgvTaskPlan.TabIndex = 4;
            this.dgvTaskPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaskPlan_CellClick);
            this.dgvTaskPlan.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTaskPlan_CellMouseDoubleClick);
            this.dgvTaskPlan.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTaskPlan_CellMouseMove);
            // 
            // taskid
            // 
            this.taskid.DataPropertyName = "id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.taskid.DefaultCellStyle = dataGridViewCellStyle1;
            this.taskid.HeaderText = "ID";
            this.taskid.MinimumWidth = 100;
            this.taskid.Name = "taskid";
            this.taskid.ReadOnly = true;
            // 
            // taskStatusText
            // 
            this.taskStatusText.DataPropertyName = "statusText";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.taskStatusText.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.taskTitle.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TpwdText.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(12, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 36);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label2.Location = new System.Drawing.Point(741, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.7F);
            this.label3.Location = new System.Drawing.Point(226, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "消息内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(124, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "消息类型";
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
            this.toolsTaskTpwd.Visible = false;
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
            this.hotPanel1.Controls.Add(this.dgvLogView);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 593);
            this.hotPanel1.TabIndex = 5;
            // 
            // dgvLogView
            // 
            this.dgvLogView.AllowUserToAddRows = false;
            this.dgvLogView.AllowUserToDeleteRows = false;
            this.dgvLogView.AllowUserToResizeColumns = false;
            this.dgvLogView.AllowUserToResizeRows = false;
            this.dgvLogView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvLogView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLogView.ColumnHeadersVisible = false;
            this.dgvLogView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logTime,
            this.goodsUrl,
            this.goodsName,
            this.goodsid,
            this.logId,
            this.logType,
            this.logContent,
            this.campId,
            this.keeperid,
            this.commissionRate,
            this.logStatus,
            this.operation});
            this.dgvLogView.ContextMenuStrip = this.cmsLog;
            this.dgvLogView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvLogView.Location = new System.Drawing.Point(12, 48);
            this.dgvLogView.MultiSelect = false;
            this.dgvLogView.Name = "dgvLogView";
            this.dgvLogView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLogView.RowHeadersVisible = false;
            this.dgvLogView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.dgvLogView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLogView.RowTemplate.Height = 23;
            this.dgvLogView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogView.Size = new System.Drawing.Size(895, 537);
            this.dgvLogView.TabIndex = 6;
            this.dgvLogView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogView_CellClick);
            // 
            // logTime
            // 
            this.logTime.HeaderText = "时间";
            this.logTime.Name = "logTime";
            this.logTime.ReadOnly = true;
            this.logTime.Width = 120;
            // 
            // goodsUrl
            // 
            this.goodsUrl.HeaderText = "goodsUrl";
            this.goodsUrl.Name = "goodsUrl";
            this.goodsUrl.ReadOnly = true;
            this.goodsUrl.Visible = false;
            // 
            // goodsName
            // 
            this.goodsName.HeaderText = "商品标题";
            this.goodsName.Name = "goodsName";
            this.goodsName.ReadOnly = true;
            this.goodsName.Visible = false;
            // 
            // goodsid
            // 
            this.goodsid.HeaderText = "商品ID";
            this.goodsid.Name = "goodsid";
            this.goodsid.ReadOnly = true;
            this.goodsid.Visible = false;
            // 
            // logId
            // 
            this.logId.DataPropertyName = "logId";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.logId.DefaultCellStyle = dataGridViewCellStyle6;
            this.logId.HeaderText = "编号";
            this.logId.MinimumWidth = 60;
            this.logId.Name = "logId";
            this.logId.ReadOnly = true;
            this.logId.Visible = false;
            this.logId.Width = 60;
            // 
            // logType
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.logType.DefaultCellStyle = dataGridViewCellStyle7;
            this.logType.HeaderText = "消息类型";
            this.logType.Name = "logType";
            this.logType.ReadOnly = true;
            // 
            // logContent
            // 
            this.logContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.logContent.DefaultCellStyle = dataGridViewCellStyle8;
            this.logContent.HeaderText = "信息内容";
            this.logContent.Name = "logContent";
            this.logContent.ReadOnly = true;
            this.logContent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // campId
            // 
            this.campId.HeaderText = "campId";
            this.campId.Name = "campId";
            this.campId.ReadOnly = true;
            this.campId.Visible = false;
            // 
            // keeperid
            // 
            this.keeperid.HeaderText = "keeperid";
            this.keeperid.Name = "keeperid";
            this.keeperid.ReadOnly = true;
            this.keeperid.Visible = false;
            // 
            // commissionRate
            // 
            this.commissionRate.HeaderText = "commissionRate";
            this.commissionRate.Name = "commissionRate";
            this.commissionRate.ReadOnly = true;
            this.commissionRate.Visible = false;
            // 
            // logStatus
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.logStatus.DefaultCellStyle = dataGridViewCellStyle9;
            this.logStatus.HeaderText = "状态";
            this.logStatus.Name = "logStatus";
            this.logStatus.ReadOnly = true;
            this.logStatus.Width = 60;
            // 
            // operation
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.operation.DefaultCellStyle = dataGridViewCellStyle10;
            this.operation.HeaderText = "操作";
            this.operation.Name = "operation";
            this.operation.ReadOnly = true;
            this.operation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cmsLog
            // 
            this.cmsLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClearAll});
            this.cmsLog.Name = "cmsLog";
            this.cmsLog.Size = new System.Drawing.Size(153, 48);
            // 
            // toolClearAll
            // 
            this.toolClearAll.Name = "toolClearAll";
            this.toolClearAll.Size = new System.Drawing.Size(152, 22);
            this.toolClearAll.Text = "清空日志";
            this.toolClearAll.Click += new System.EventHandler(this.toolClearAll_Click);
            // 
            // HistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.hotPanel1);
            this.Controls.Add(this.dgvTaskPlan);
            this.Name = "HistoryControl";
            this.Size = new System.Drawing.Size(920, 593);
            this.Load += new System.EventHandler(this.HistoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsTask.ResumeLayout(false);
            this.hotPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogView)).EndInit();
            this.cmsLog.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsTask;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskCopy;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskTpwd;
        private System.Windows.Forms.ToolStripMenuItem toolsTaskDelete;
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
        private System.Windows.Forms.DataGridView dgvLogView;
        private System.Windows.Forms.DataGridViewTextBoxColumn logTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsid;
        private System.Windows.Forms.DataGridViewTextBoxColumn logId;
        private System.Windows.Forms.DataGridViewTextBoxColumn logType;
        private System.Windows.Forms.DataGridViewTextBoxColumn logContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn campId;
        private System.Windows.Forms.DataGridViewTextBoxColumn keeperid;
        private System.Windows.Forms.DataGridViewTextBoxColumn commissionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn logStatus;
        private System.Windows.Forms.DataGridViewLinkColumn operation;
        private System.Windows.Forms.ContextMenuStrip cmsLog;
        private System.Windows.Forms.ToolStripMenuItem toolClearAll;
    }
}
