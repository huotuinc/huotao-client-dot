﻿namespace HotTao.Controls
{
    partial class TestControl1
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
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotPanel1.Location = new System.Drawing.Point(116, 95);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(308, 219);
            this.hotPanel1.TabIndex = 0;
            // 
            // TestControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotPanel1);
            this.Name = "TestControl1";
            this.Size = new System.Drawing.Size(531, 423);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
    }
}
