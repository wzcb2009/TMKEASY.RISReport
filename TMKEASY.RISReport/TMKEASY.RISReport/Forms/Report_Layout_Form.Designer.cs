namespace TMKEASY.RISReport 
{
    partial class Report_Layout_Form
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelControl1
            // 
            this.PanelControl1.Size = new System.Drawing.Size(571, 417);
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.OptionsView.EnableTransparentBackColor = true;
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(571, 417);
            this.LayoutControl1.TabIndex = 2;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroup1.Name = "LayoutControlGroup1";
            this.LayoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroup1.Size = new System.Drawing.Size(571, 417);
            this.LayoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroup1.Text = "LayoutControlGroup1";
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // Report_Layout_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 417);
            this.Controls.Add(this.LayoutControl1);
            this.Name = "Report_Layout_Form";
            this.Text = "Report_Layout_Form";
            this.Controls.SetChildIndex(this.PanelControl1, 0);
            this.Controls.SetChildIndex(this.LayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
    }
}