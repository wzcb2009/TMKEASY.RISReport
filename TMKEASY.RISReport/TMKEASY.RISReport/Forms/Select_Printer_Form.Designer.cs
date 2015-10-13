namespace TMKEASY.RISReport
{
    partial class Select_Printer_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Select_printer_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.Close_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Printer_ComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Printer_LabelControl = new DevExpress.XtraEditors.LabelControl();
            this.Save_SimpleButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Select_printer_GroupControl)).BeginInit();
            this.Select_printer_GroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Printer_ComboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_printer_GroupControl
            // 
            this.Select_printer_GroupControl.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.Select_printer_GroupControl.AppearanceCaption.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.Select_printer_GroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.Select_printer_GroupControl.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Select_printer_GroupControl.AppearanceCaption.Options.UseBackColor = true;
            this.Select_printer_GroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.Select_printer_GroupControl.AppearanceCaption.Options.UseTextOptions = true;
            this.Select_printer_GroupControl.Controls.Add(this.Close_SimpleButton);
            this.Select_printer_GroupControl.Controls.Add(this.Printer_ComboBoxEdit);
            this.Select_printer_GroupControl.Controls.Add(this.Printer_LabelControl);
            this.Select_printer_GroupControl.Controls.Add(this.Save_SimpleButton);
            this.Select_printer_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Select_printer_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.Select_printer_GroupControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.Select_printer_GroupControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Select_printer_GroupControl.Name = "Select_printer_GroupControl";
            this.Select_printer_GroupControl.Size = new System.Drawing.Size(284, 181);
            this.Select_printer_GroupControl.TabIndex = 5;
            this.Select_printer_GroupControl.Text = "默认打印机设置";
            this.Select_printer_GroupControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Report_GroupControl_MouseMove);
            this.Select_printer_GroupControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Report_GroupControl_MouseDown);
            // 
            // Close_SimpleButton
            // 
            this.Close_SimpleButton.Location = new System.Drawing.Point(156, 137);
            this.Close_SimpleButton.Name = "Close_SimpleButton";
            this.Close_SimpleButton.Size = new System.Drawing.Size(75, 23);
            this.Close_SimpleButton.TabIndex = 6;
            this.Close_SimpleButton.Text = "退  出";
            this.Close_SimpleButton.Click += new System.EventHandler(this.Close_SimpleButton_Click);
            // 
            // Printer_ComboBoxEdit
            // 
            this.Printer_ComboBoxEdit.Location = new System.Drawing.Point(46, 92);
            this.Printer_ComboBoxEdit.Name = "Printer_ComboBoxEdit";
            this.Printer_ComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Printer_ComboBoxEdit.Size = new System.Drawing.Size(194, 21);
            this.Printer_ComboBoxEdit.TabIndex = 5;
            // 
            // Printer_LabelControl
            // 
            this.Printer_LabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printer_LabelControl.Appearance.Options.UseFont = true;
            this.Printer_LabelControl.Location = new System.Drawing.Point(96, 51);
            this.Printer_LabelControl.Name = "Printer_LabelControl";
            this.Printer_LabelControl.Size = new System.Drawing.Size(84, 17);
            this.Printer_LabelControl.TabIndex = 4;
            this.Printer_LabelControl.Text = "请选择打印机";
            // 
            // Save_SimpleButton
            // 
            this.Save_SimpleButton.Location = new System.Drawing.Point(50, 137);
            this.Save_SimpleButton.Name = "Save_SimpleButton";
            this.Save_SimpleButton.Size = new System.Drawing.Size(75, 23);
            this.Save_SimpleButton.TabIndex = 3;
            this.Save_SimpleButton.Text = "确  定";
            this.Save_SimpleButton.Click += new System.EventHandler(this.Save_SimpleButton_Click);
            // 
            // Select_Printer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.Select_printer_GroupControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Select_Printer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择打印机";
            this.Load += new System.EventHandler(this.Select_Printer_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Select_printer_GroupControl)).EndInit();
            this.Select_printer_GroupControl.ResumeLayout(false);
            this.Select_printer_GroupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Printer_ComboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl Select_printer_GroupControl;
        internal DevExpress.XtraEditors.SimpleButton Close_SimpleButton;
        internal DevExpress.XtraEditors.ComboBoxEdit Printer_ComboBoxEdit;
        internal DevExpress.XtraEditors.LabelControl Printer_LabelControl;
        internal DevExpress.XtraEditors.SimpleButton Save_SimpleButton;
    }
}