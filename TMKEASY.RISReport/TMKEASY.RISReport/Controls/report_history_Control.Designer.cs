namespace TMKEASY.RISReport
{
    partial class report_history_Control
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Apply_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Add_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Image_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.apply_writerControl = new DCSoft.Writer.Controls.WriterControl();
            this.myEditControl = new DCSoft.Writer.Controls.WriterControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Apply_SimpleButton);
            this.panelControl1.Controls.Add(this.Add_SimpleButton);
            this.panelControl1.Controls.Add(this.Image_SimpleButton);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 513);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(569, 46);
            this.panelControl1.TabIndex = 13;
            this.panelControl1.Text = "panelControl1";
            // 
            // Apply_SimpleButton
            // 
            this.Apply_SimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Apply_SimpleButton.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Apply_SimpleButton.Appearance.Options.UseFont = true;
            this.Apply_SimpleButton.Location = new System.Drawing.Point(388, 6);
            this.Apply_SimpleButton.Name = "Apply_SimpleButton";
            this.Apply_SimpleButton.Size = new System.Drawing.Size(88, 27);
            this.Apply_SimpleButton.TabIndex = 103;
            this.Apply_SimpleButton.Text = "申请单";
            this.Apply_SimpleButton.Click += new System.EventHandler(this.Apply_SimpleButton_Click);
            // 
            // Add_SimpleButton
            // 
            this.Add_SimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_SimpleButton.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_SimpleButton.Appearance.Options.UseFont = true;
            this.Add_SimpleButton.Location = new System.Drawing.Point(300, 6);
            this.Add_SimpleButton.Name = "Add_SimpleButton";
            this.Add_SimpleButton.Size = new System.Drawing.Size(88, 27);
            this.Add_SimpleButton.TabIndex = 102;
            this.Add_SimpleButton.Text = "调 用";
            this.Add_SimpleButton.Click += new System.EventHandler(this.Add_SimpleButton_Click);
            // 
            // Image_SimpleButton
            // 
            this.Image_SimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Image_SimpleButton.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Image_SimpleButton.Appearance.Options.UseFont = true;
            this.Image_SimpleButton.Location = new System.Drawing.Point(476, 6);
            this.Image_SimpleButton.Name = "Image_SimpleButton";
            this.Image_SimpleButton.Size = new System.Drawing.Size(88, 27);
            this.Image_SimpleButton.TabIndex = 101;
            this.Image_SimpleButton.Text = "图 像";
            this.Image_SimpleButton.Click += new System.EventHandler(this.Image_SimpleButton_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.apply_writerControl);
            this.panelControl2.Controls.Add(this.myEditControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(569, 513);
            this.panelControl2.TabIndex = 14;
            this.panelControl2.Text = "panelControl2";
            // 
            // apply_writerControl
            // 
            this.apply_writerControl.AllowDrop = true;
            this.apply_writerControl.BackColor = System.Drawing.SystemColors.Control;
            this.apply_writerControl.BackColorString = "buttonface";
            this.apply_writerControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.apply_writerControl.CurrentPageBorderColorString = "Black";
            this.apply_writerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apply_writerControl.Location = new System.Drawing.Point(2, 2);
            this.apply_writerControl.Name = "apply_writerControl";
            this.apply_writerControl.PageBackColorString = "window";
            this.apply_writerControl.PageBorderColorString = "Black";
            this.apply_writerControl.PageSpacing = 0;
            this.apply_writerControl.PageTitlePosition = DCSoft.Drawing.PageTitlePosition.BottomRight;
            this.apply_writerControl.RegisterCode = "023E4EA500000000000024000000E6B8A9E5B79EE58DA1E69893E7BD91E7BB9CE68A80E69CAFE69C8" +
                "9E99990E585ACE58FB8FD02080000004B617969536F66740400";
            this.apply_writerControl.Size = new System.Drawing.Size(565, 509);
            this.apply_writerControl.TabIndex = 12;
            // 
            // myEditControl
            // 
            this.myEditControl.AllowDrop = true;
            this.myEditControl.BackColor = System.Drawing.SystemColors.Control;
            this.myEditControl.BackColorString = "buttonface";
            this.myEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myEditControl.CommentVisibility = DCSoft.Writer.Controls.FunctionControlVisibility.Hide;
            this.myEditControl.CurrentPageBorderColorString = "Black";
            this.myEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEditControl.Location = new System.Drawing.Point(2, 2);
            this.myEditControl.Name = "myEditControl";
            this.myEditControl.PageBackColorString = "window";
            this.myEditControl.PageBorderColorString = "Black";
            this.myEditControl.PageSpacing = 0;
            this.myEditControl.RegisterCode = "023E4EA500000000000024000000E6B8A9E5B79EE58DA1E69893E7BD91E7BB9CE68A80E69CAFE69C8" +
                "9E99990E585ACE58FB8FD02080000004B617969536F66740400";
            this.myEditControl.Size = new System.Drawing.Size(565, 509);
            this.myEditControl.TabIndex = 11;
            // 
            // report_history_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "report_history_Control";
            this.Size = new System.Drawing.Size(569, 559);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal DevExpress.XtraEditors.SimpleButton Apply_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton Add_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton Image_SimpleButton;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        internal DCSoft.Writer.Controls.WriterControl apply_writerControl;
        internal DCSoft.Writer.Controls.WriterControl myEditControl;
    }
}
