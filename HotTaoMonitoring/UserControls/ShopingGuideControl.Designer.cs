namespace HotTaoMonitoring.UserControls
{
    partial class ShopingGuideControl
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
            this.hotPanel1 = new HotTaoMonitoring.module.HotPanel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.picWeChatHead = new System.Windows.Forms.PictureBox();
            this.lbTabWeChat = new System.Windows.Forms.Label();
            this.lbTabWeChatListen = new System.Windows.Forms.Label();
            this.PanelGuideContainer = new System.Windows.Forms.Panel();
            this.hotPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.PanelGuideContainer);
            this.hotPanel1.Controls.Add(this.panel1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(950, 637);
            this.hotPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.picWeChatHead);
            this.panel1.Controls.Add(this.lbTabWeChat);
            this.panel1.Controls.Add(this.lbTabWeChatListen);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 637);
            this.panel1.TabIndex = 16;
            // 
            // picWeChatHead
            // 
            this.picWeChatHead.Location = new System.Drawing.Point(15, 10);
            this.picWeChatHead.Name = "picWeChatHead";
            this.picWeChatHead.Size = new System.Drawing.Size(50, 50);
            this.picWeChatHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeChatHead.TabIndex = 15;
            this.picWeChatHead.TabStop = false;
            // 
            // lbTabWeChat
            // 
            this.lbTabWeChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(176)))));
            this.lbTabWeChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChat.ForeColor = System.Drawing.Color.White;
            this.lbTabWeChat.Location = new System.Drawing.Point(0, 70);
            this.lbTabWeChat.Name = "lbTabWeChat";
            this.lbTabWeChat.Size = new System.Drawing.Size(77, 60);
            this.lbTabWeChat.TabIndex = 14;
            this.lbTabWeChat.Text = "群设置";
            this.lbTabWeChat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTabWeChatListen
            // 
            this.lbTabWeChatListen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbTabWeChatListen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTabWeChatListen.ForeColor = System.Drawing.Color.White;
            this.lbTabWeChatListen.Location = new System.Drawing.Point(0, 130);
            this.lbTabWeChatListen.Name = "lbTabWeChatListen";
            this.lbTabWeChatListen.Size = new System.Drawing.Size(77, 60);
            this.lbTabWeChatListen.TabIndex = 14;
            this.lbTabWeChatListen.Text = "导购设置";
            this.lbTabWeChatListen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelGuideContainer
            // 
            this.PanelGuideContainer.Location = new System.Drawing.Point(77, 0);
            this.PanelGuideContainer.Name = "PanelGuideContainer";
            this.PanelGuideContainer.Size = new System.Drawing.Size(873, 637);
            this.PanelGuideContainer.TabIndex = 17;
            // 
            // ShopingGuideControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotPanel1);
            this.Name = "ShopingGuideControl";
            this.Size = new System.Drawing.Size(950, 637);
            this.Load += new System.EventHandler(this.ShopingGuideControl_Load);
            this.hotPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWeChatHead;
        private System.Windows.Forms.Label lbTabWeChat;
        private System.Windows.Forms.Label lbTabWeChatListen;
        private System.Windows.Forms.Panel PanelGuideContainer;
    }
}
