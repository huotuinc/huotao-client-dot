namespace HotTao.Controls
{
    partial class GoodsControl
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
            this.hotPanel2 = new HotTao.Controls.module.HotPanel(this.components);
            this.SuspendLayout();
            // 
            // hotPanel2
            // 
            this.hotPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel2.Location = new System.Drawing.Point(0, 0);
            this.hotPanel2.Name = "hotPanel2";
            this.hotPanel2.Size = new System.Drawing.Size(920, 607);
            this.hotPanel2.TabIndex = 0;
            this.hotPanel2.Tag = "";
            // 
            // GoodsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotPanel2);
            this.Name = "GoodsControl";
            this.Size = new System.Drawing.Size(920, 607);
            this.Tag = "goods";
            this.Load += new System.EventHandler(this.GoodsControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private module.HotPanel hotPanel2;
    }
}
