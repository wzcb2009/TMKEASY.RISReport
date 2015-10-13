namespace TMKEASY.RISReport 
{
    partial class ShowApplyImage_Form
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
            this.button_PanelControl = new DevExpress.XtraEditors.PanelControl();
            this.Radio_doctor_TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.doctor_Label = new System.Windows.Forms.Label();
            this.SimpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.right_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.left_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.print_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.small_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.big_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Old_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.picture_XtraScrollableControl = new DevExpress.XtraEditors.XtraScrollableControl();
            this.image_PictureBox = new System.Windows.Forms.PictureBox();
            this.image_PrintDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.button_PanelControl)).BeginInit();
            this.button_PanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radio_doctor_TextEdit.Properties)).BeginInit();
            this.picture_XtraScrollableControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_PanelControl
            // 
            this.button_PanelControl.Controls.Add(this.Radio_doctor_TextEdit);
            this.button_PanelControl.Controls.Add(this.doctor_Label);
            this.button_PanelControl.Controls.Add(this.SimpleButton1);
            this.button_PanelControl.Controls.Add(this.right_SimpleButton);
            this.button_PanelControl.Controls.Add(this.left_SimpleButton);
            this.button_PanelControl.Controls.Add(this.print_SimpleButton);
            this.button_PanelControl.Controls.Add(this.small_SimpleButton);
            this.button_PanelControl.Controls.Add(this.big_SimpleButton);
            this.button_PanelControl.Controls.Add(this.Old_SimpleButton);
            this.button_PanelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_PanelControl.Location = new System.Drawing.Point(0, 434);
            this.button_PanelControl.Name = "button_PanelControl";
            this.button_PanelControl.Size = new System.Drawing.Size(738, 44);
            this.button_PanelControl.TabIndex = 1;
            this.button_PanelControl.Text = "PanelControl1";
            // 
            // Radio_doctor_TextEdit
            // 
            this.Radio_doctor_TextEdit.EditValue = "";
            this.Radio_doctor_TextEdit.Location = new System.Drawing.Point(80, 11);
            this.Radio_doctor_TextEdit.Name = "Radio_doctor_TextEdit";
            this.Radio_doctor_TextEdit.Properties.Appearance.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Radio_doctor_TextEdit.Properties.Appearance.Options.UseFont = true;
            this.Radio_doctor_TextEdit.Properties.ReadOnly = true;
            this.Radio_doctor_TextEdit.Size = new System.Drawing.Size(121, 25);
            this.Radio_doctor_TextEdit.TabIndex = 150;
            // 
            // doctor_Label
            // 
            this.doctor_Label.AutoSize = true;
            this.doctor_Label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doctor_Label.Location = new System.Drawing.Point(6, 15);
            this.doctor_Label.Name = "doctor_Label";
            this.doctor_Label.Size = new System.Drawing.Size(77, 14);
            this.doctor_Label.TabIndex = 149;
            this.doctor_Label.Text = "检查技师：";
            // 
            // SimpleButton1
            // 
            this.SimpleButton1.Location = new System.Drawing.Point(657, 10);
            this.SimpleButton1.Name = "SimpleButton1";
            this.SimpleButton1.Size = new System.Drawing.Size(70, 25);
            this.SimpleButton1.TabIndex = 7;
            this.SimpleButton1.Text = "关  闭";
            this.SimpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // right_SimpleButton
            // 
            this.right_SimpleButton.Location = new System.Drawing.Point(517, 10);
            this.right_SimpleButton.Name = "right_SimpleButton";
            this.right_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.right_SimpleButton.TabIndex = 5;
            this.right_SimpleButton.Text = "右旋";
            this.right_SimpleButton.Click += new System.EventHandler(this.right_SimpleButton_Click);
            // 
            // left_SimpleButton
            // 
            this.left_SimpleButton.Location = new System.Drawing.Point(447, 10);
            this.left_SimpleButton.Name = "left_SimpleButton";
            this.left_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.left_SimpleButton.TabIndex = 4;
            this.left_SimpleButton.Text = "左旋";
            this.left_SimpleButton.Click += new System.EventHandler(this.left_SimpleButton_Click);
            // 
            // print_SimpleButton
            // 
            this.print_SimpleButton.Location = new System.Drawing.Point(587, 10);
            this.print_SimpleButton.Name = "print_SimpleButton";
            this.print_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.print_SimpleButton.TabIndex = 3;
            this.print_SimpleButton.Text = "打  印";
            this.print_SimpleButton.Click += new System.EventHandler(this.right_SimpleButton_Click);
            // 
            // small_SimpleButton
            // 
            this.small_SimpleButton.Location = new System.Drawing.Point(377, 10);
            this.small_SimpleButton.Name = "small_SimpleButton";
            this.small_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.small_SimpleButton.TabIndex = 2;
            this.small_SimpleButton.Text = "缩  小";
            this.small_SimpleButton.Click += new System.EventHandler(this.small_SimpleButton_Click);
            // 
            // big_SimpleButton
            // 
            this.big_SimpleButton.Location = new System.Drawing.Point(307, 10);
            this.big_SimpleButton.Name = "big_SimpleButton";
            this.big_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.big_SimpleButton.TabIndex = 1;
            this.big_SimpleButton.Text = "放  大";
            this.big_SimpleButton.Click += new System.EventHandler(this.big_SimpleButton_Click);
            // 
            // Old_SimpleButton
            // 
            this.Old_SimpleButton.Location = new System.Drawing.Point(237, 10);
            this.Old_SimpleButton.Name = "Old_SimpleButton";
            this.Old_SimpleButton.Size = new System.Drawing.Size(70, 25);
            this.Old_SimpleButton.TabIndex = 0;
            this.Old_SimpleButton.Text = "还  原";
            this.Old_SimpleButton.Click += new System.EventHandler(this.Old_SimpleButton_Click);
            // 
            // picture_XtraScrollableControl
            // 
            this.picture_XtraScrollableControl.Appearance.BackColor = System.Drawing.Color.White;
            this.picture_XtraScrollableControl.Appearance.Options.UseBackColor = true;
            this.picture_XtraScrollableControl.Controls.Add(this.image_PictureBox);
            this.picture_XtraScrollableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_XtraScrollableControl.Location = new System.Drawing.Point(0, 0);
            this.picture_XtraScrollableControl.Name = "picture_XtraScrollableControl";
            this.picture_XtraScrollableControl.Size = new System.Drawing.Size(738, 434);
            this.picture_XtraScrollableControl.TabIndex = 3;
            // 
            // image_PictureBox
            // 
            this.image_PictureBox.BackColor = System.Drawing.Color.White;
            this.image_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_PictureBox.Location = new System.Drawing.Point(12, 12);
            this.image_PictureBox.Name = "image_PictureBox";
            this.image_PictureBox.Size = new System.Drawing.Size(486, 393);
            this.image_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_PictureBox.TabIndex = 2;
            this.image_PictureBox.TabStop = false;
            // 
            // image_PrintDocument
            // 
            this.image_PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.image_PrintDocument_PrintPage);
            // 
            // ShowApplyImage_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 478);
            this.Controls.Add(this.picture_XtraScrollableControl);
            this.Controls.Add(this.button_PanelControl);
            this.Name = "ShowApplyImage_Form";
            this.Text = "申请单预览";
            this.Load += new System.EventHandler(this.ShowApplyImage_Form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowApplyImage_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.button_PanelControl)).EndInit();
            this.button_PanelControl.ResumeLayout(false);
            this.button_PanelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radio_doctor_TextEdit.Properties)).EndInit();
            this.picture_XtraScrollableControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.PanelControl button_PanelControl;
        internal DevExpress.XtraEditors.TextEdit Radio_doctor_TextEdit;
        internal System.Windows.Forms.Label doctor_Label;
        internal DevExpress.XtraEditors.SimpleButton SimpleButton1;
        internal DevExpress.XtraEditors.SimpleButton right_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton left_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton print_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton small_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton big_SimpleButton;
        internal DevExpress.XtraEditors.SimpleButton Old_SimpleButton;
        internal DevExpress.XtraEditors.XtraScrollableControl picture_XtraScrollableControl;
        internal System.Windows.Forms.PictureBox image_PictureBox;
        internal System.Drawing.Printing.PrintDocument image_PrintDocument;

    }
}