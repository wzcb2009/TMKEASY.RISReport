namespace TMKEASY.RISReport
{
    partial class ShowApply_Form
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
            this.form_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.myEditControl = new DCSoft.Writer.Controls.WriterControl();
            ((System.ComponentModel.ISupportInitialize)(this.form_GroupControl)).BeginInit();
            this.form_GroupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // form_GroupControl
            // 
            this.form_GroupControl.AppearanceCaption.BackColor = System.Drawing.Color.Azure;
            this.form_GroupControl.AppearanceCaption.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.form_GroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.form_GroupControl.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.form_GroupControl.AppearanceCaption.Options.UseBackColor = true;
            this.form_GroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.form_GroupControl.AppearanceCaption.Options.UseTextOptions = true;
            this.form_GroupControl.Controls.Add(this.myEditControl);
            this.form_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.form_GroupControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.form_GroupControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.form_GroupControl.Name = "form_GroupControl";
            this.form_GroupControl.Size = new System.Drawing.Size(709, 490);
            this.form_GroupControl.TabIndex = 2;
            this.form_GroupControl.Text = "电子申请单";
            this.form_GroupControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Report_GroupControl_MouseDown);
            this.form_GroupControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Report_GroupControl_MouseMove);
            // 
            // myEditControl
            // 
            this.myEditControl.AllowDrop = true;
            this.myEditControl.AutoScroll = true;
            this.myEditControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.myEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myEditControl.BoundsSelection = null;
            this.myEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEditControl.LastPrintPosition = 0;
            this.myEditControl.LastPrintResult = null;
            this.myEditControl.Location = new System.Drawing.Point(2, 21);
            this.myEditControl.Name = "myEditControl";
            this.myEditControl.PageSettings = null;
            this.myEditControl.PageSpacing = 0;
            this.myEditControl.Size = new System.Drawing.Size(705, 467);
            this.myEditControl.TabIndex = 6;
            // 
            // ShowApply_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 490);
            this.Controls.Add(this.form_GroupControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowApply_Form";
            this.Text = "ApplyShow_Form";
            this.Load += new System.EventHandler(this.ShowApply_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.form_GroupControl)).EndInit();
            this.form_GroupControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl form_GroupControl;
        internal DCSoft.Writer.Controls.WriterControl myEditControl;
    }
}