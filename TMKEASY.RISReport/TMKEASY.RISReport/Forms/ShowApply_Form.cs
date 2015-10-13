 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class ShowApply_Form : Form
    {
        public ShowApply_Form()
        {
            InitializeComponent();
        }
        string CurAccessno = "";
        public ShowApply_Form(string p_accessno)
        {
            InitializeComponent();
            CurAccessno = p_accessno;
        }
        #region 拖动窗体
        private Point mouse_offset;
        private void Report_GroupControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y > 13)
            {
                mouse_offset = Point.Empty;
                return;
            }
            mouse_offset = new Point(e.X, e.Y);
        }
        private void Report_GroupControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_offset == null)
                return;
            if (mouse_offset == Point.Empty)
                return;
            //'按住鼠标左右键均可拖动窗体
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = this.Location;
                //'获得鼠标偏移量
                mousePos.Offset(e.X - mouse_offset.X, e.Y - mouse_offset.Y);
                //'设置窗体随鼠标一起移动
                this.Location = mousePos;
            }
        }

        #endregion

        private void ShowApply_Form_Load(object sender, EventArgs e)
        {
            FillInputXMLByClass();
        }
      
        private void FillInputXMLByClass()
        {
            patexam_Class CurPatexam = new patexam_Class(CurAccessno);
            patregister_Class CurPatRegister = new patregister_Class(CurAccessno);
            //DataTable dt = new DataTable();
            //dt = ReportStyle_Class.GetApplyStyle();
            //if (dt != null)
            //{
            //    ReportStyle_Class d_style = new ReportStyle_Class(dt.Rows[0]);
            //    if (d_style.xmltext != "")
            //        myEditControl.LoadDocumentFromString(d_style.xmltext, "xml");
            //    else
            //    {
            //        string fileName = "";
            //        fileName = Share_Class.Dir + @"\xml\Apply.xml";
            //        myEditControl.ExecuteCommand("FileOpen", false, fileName);
            //    }
            //}
            //else
            //{
                string fileName = "";
                fileName = Share_Class.Dir + @"\xml\Apply.xml"; 
                myEditControl.ExecuteCommand("FileOpen", false, fileName);
            //}
                
            string d_ReportType = "检查申请单";
            myEditControl.SetDocumentParameterValue("hospitalname", Share_Class.hospital_name);
            myEditControl.SetDocumentParameterValue("ReportType", d_ReportType);
            myEditControl.SetDocumentParameterValue("patexam", CurPatexam);
            myEditControl.SetDocumentParameterValue("patregister", CurPatRegister);
        }
    }
}
