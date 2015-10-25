namespace TMKEASY.RISReport 
{
    partial class ShowPic_Form
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
            this.components = new System.ComponentModel.Container();
            this.panelImageList1 = new RIS.Vedio.PanelImageList();
            this.SuspendLayout();
            // 
            // panelImageList1
            // 
            this.panelImageList1.AllowMultiSelect = true;
            this.panelImageList1.AutoScroll = true;
            this.panelImageList1.Cols = 5;
            this.panelImageList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImageList1.ImagePath = "";
            this.panelImageList1.ImageSize = new System.Drawing.Size(246, 219);
            this.panelImageList1.Location = new System.Drawing.Point(0, 0);
            this.panelImageList1.Name = "panelImageList1";
            this.panelImageList1.PanelNumber = null;
            this.panelImageList1.SelectIndex = -1;
            this.panelImageList1.ShowImageNameOnLableNumber = true;
            this.panelImageList1.Size = new System.Drawing.Size(1016, 734);
            this.panelImageList1.SourceImage = null;
            this.panelImageList1.TabIndex = 6;
            // 
            // ShowPic_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.panelImageList1);
            this.Name = "ShowPic_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "显示图像";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.ShowPic_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RIS.Vedio.PanelImageList panelImageList1;
    }
}