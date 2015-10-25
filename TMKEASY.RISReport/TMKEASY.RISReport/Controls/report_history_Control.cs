using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer;

namespace TMKEASY.RISReport
{
    public partial class report_history_Control : UserControl
    {
        public report_history_Control()
        {
            InitializeComponent();
        }
        private string CurAccessno = "";
        //RISEditReport_Form d_reportform = new RISEditReport_Form();
        //public report_history_Control(string p_accessno, RISEditReport_Form p_reportform)
        //{
        //    InitializeComponent();
        //    CurAccessno = p_accessno;
        //    CurPatexam = new patexam_Class(CurAccessno);
        //    d_reportform = p_reportform;
        //    FormInit();
        //}
        Report_Form d_ReportEdit = new Report_Form();
        public report_history_Control(string p_accessno, Report_Form p_reportform)
        {
            InitializeComponent();
            CurAccessno = p_accessno;
            CurPatexam = new patexam_Class(CurAccessno);
            d_ReportEdit = p_reportform;
            FormInit();
        }
        //ReportEdit_UserControl d_ReportEdit_UserControl = new ReportEdit_UserControl();
        //public report_history_Control(string p_accessno, BaseReport_UserControl p_reportform)
        //{
        //    InitializeComponent();
        //    CurAccessno = p_accessno;
        //    CurPatexam = new patexam_Class(CurAccessno);
        //    d_ReportEdit_UserControl = p_reportform;
        //    FormInit();
        //}
        //   FTPSETUP_Class CurFTPSETUP = new FTPSETUP_Class();
        patexam_Class CurPatexam = new patexam_Class();
        //public void GetFTPSETUPByFTPCODE()
        //{
        //    patregister_Class CurPatregister = new patregister_Class(CurAccessno);
        //    CurFTPSETUP = new FTPSETUP_Class(CurPatregister.ftpcode);
        //    if (CurFTPSETUP.id == 0)
        //        CurFTPSETUP.GetDataByFTPStatus();
        //}
        //public void DownloadXML()
        //{
        //    string d_FTPOPEN = "";
        //    d_FTPOPEN = Public_Class.GetINI("setup", "FTPOPEN");
        //    if (d_FTPOPEN != "yes")
        //    {
        //        return;
        //    }
        //    GetFTPSETUPByFTPCODE();
        //    string d_FTPUserName, d_FTPPassword, d_FTPHost, d_FTPPort, d_FTPFileName;
        //    if (CurFTPSETUP.id == 0)
        //    {
        //        d_FTPUserName = Public_Class.GetINI("setup", "FTPUserName");
        //        d_FTPPassword = Public_Class.GetINI("setup", "FTPPassword");
        //        d_FTPHost = Public_Class.GetINI("setup", "FTPHost");
        //        d_FTPPort = Public_Class.GetINI("setup", "FTPPort");
        //        d_FTPFileName = Public_Class.GetINI("setup", "FTPFileName");
        //    }
        //    else
        //    {
        //        d_FTPUserName = CurFTPSETUP.FTPUserName;
        //        d_FTPPassword = CurFTPSETUP.FTPPassword;
        //        d_FTPHost = CurFTPSETUP.FTPHost;
        //        d_FTPPort = CurFTPSETUP.FTPPort;
        //        d_FTPFileName = CurFTPSETUP.FTPFileName;
        //    }
        //    RIS.Vedio.FtpClient ftp = new RIS.Vedio.FtpClient(d_FTPHost, Convert.ToInt32(d_FTPPort), d_FTPUserName, d_FTPPassword);
        //    string d_date = CurPatexam.checkdate.ToString("yyyyMMdd");
        //    // '设置本地和远程的路径 
        //    ftp.LocalDirectory = @"XML\" + d_date;
        //    if (Directory.Exists(ftp.LocalDirectory) == false)
        //    {
        //        Directory.CreateDirectory(ftp.LocalDirectory);
        //    }
        //    ftp.RemoteDirectory = d_FTPFileName + @"/XML/" + d_date;

        //    // '浏览目录,如果不存在,自动创建目录 
        //    try
        //    {
        //        List<string> files = ftp.ListDirectory(CurAccessno + ".xml");

        //        foreach (string file in files)
        //        {
        //            ftp.Download(file);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Public_Class.WriteFlog(ex.Message, "错误"); //'将详细错误信息写入日志
        //    }
        //}
        private void GetXMLFile()
        {

            FillInputXMLByClass();
            ReportXml_Class reportxml = new ReportXml_Class(CurPatexam.accessno);
            if (reportxml.xmlfile != "")
            {
                myEditControl.LoadDocumentFromString(reportxml.xmlfile.ToString(), "xml");
            }
            else
            {
                //FillInputXMLByClass();
                //DataTable dt = new DataTable();
                //dt = ReportStyle_Class.GetStyle(CurPatexam.dep, CurPatexam.modality, CurPatexam.checktype, CurPatexam.checkpos, "");
                //if (dt != null)
                //{
                //    ReportStyle_Class d_style = new ReportStyle_Class(dt.Rows[0]);
                //    myEditControl.LoadDocumentFromString(d_style.xmltext, "xml");
                //}
                //else
                //{
                string fileName = "";
                try
                {
                    if (CurPatexam.dep == "XRAY")
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\XRAYreport.xml";
                    }
                    else if (CurPatexam.dep == "CT")
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\CTreport.xml";
                    }
                    else if (CurPatexam.dep == "MRI")
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\MRIreport.xml";
                    }
                    else if (CurPatexam.dep == "DSA")
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\DSAreport.xml";
                    }
                    else if (CurPatexam.dep == "内窥镜")
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\ESreport.xml";
                    }
                    else
                    {
                        fileName = Share_Class.Dir + @"\xmlStyle\" + CurPatexam.dep + "report.xml";
                    }
                }
                catch
                {
                    fileName = Share_Class.Dir + @"\xmlStyle\CTreport.xml";
                }
                myEditControl.ExecuteCommand("FileOpen", false, fileName);
                //}
                XTextDocument xdocument = myEditControl.Document;
                DCSoft.Writer.Dom.XTextElementList d_list = xdocument.Fields;
                for (int i = 0; i < d_list.Count; i++)
                {
                    if (d_list[i].TypeName == "XTextBarcodeFieldElement")
                    {
                        XTextBarcodeFieldElement Element = (XTextBarcodeFieldElement)d_list[i];
                        Element.Text = CurPatexam.accessno;
                    }
                }
                FillTemplate(CurPatexam.reportinfo, CurPatexam.reportend);
                myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
            }
            //else
            //{
            //    //System.IO.Stream s = new System.IO.oryStream(System.Text.Encoding.Default.GetBytes(CurPatReport.xmltext));
            //    //System.IO.StreamReader reader = new System.IO.StreamReader(s, Encoding.Default, true);
            //    //myEditControl.ExecuteCommand("FileOpen", false, reader);
            //    //myEditControl.LoadDocumentFromString(CurPatReport.xmltext, "xml");
            //    myEditControl.ExecuteCommand("FileOpen", false, localfiles[0].ToString());
            //}

        }
        public void FillTemplate(string d_reportinfo, string d_reportend)
        {

            try
            {
                XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById("reportinfotable");
                try
                {
                    XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                    d_cell.Focus();
                    myEditControl.ExecuteCommand("MoveTo", false, MoveTarget.CellEnd);
                    if (d_cell.Text.Trim() != "")
                        d_reportinfo = "\r\n " + d_reportinfo;
                    if (d_reportinfo.IndexOf("XTextDocument") > -1)
                    {
                        myEditControl.ExecuteCommand("InsertXML", false, d_reportinfo);
                    }
                    else
                    {
                        myEditControl.ExecuteCommand("InsertString", false, d_reportinfo);
                    }
                }
                catch { }
                XTextTableElement reportendtable = (XTextTableElement)myEditControl.GetElementById("reportendtable");
                try
                {
                    XTextTableCellElement d_cell = reportendtable.GetCell(0, 0, true);
                    d_cell.Focus();
                    //d_cell.Elements.Insert(0, CurPatexam.reportend );
                    myEditControl.ExecuteCommand("MoveTo", false, MoveTarget.CellEnd);
                    if (d_cell.Text.Trim() != "")
                        d_reportend = "\r\n " + d_reportend;
                    if (d_reportend.IndexOf("XTextDocument") > -1)
                    {
                        myEditControl.ExecuteCommand("InsertXML", false, d_reportend);
                    }
                    else
                    {
                        myEditControl.ExecuteCommand("InsertString", false, d_reportend);
                    }
                }
                catch { }
            }
            catch { }

        }
        private void FillInputXMLByClass()
        {

            if (CurPatexam.reportdoc.Trim() == "")
            {// '如果报告医生为空,表示是第一次报告编辑,把当前用户设置成报告医生
                CurPatexam.reportdoc = Share_Class.User.user_id;
            }
            else
            {
                CurPatexam.reportdoc = CurPatexam.reportdoc.Trim();
            }
            if (CurPatexam.reportdate.Year == 1900)
            {// '如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                CurPatexam.reportdate = DateTime.Now;
            }

            if (CurPatexam.modcheckdate.Year == 1900)
            {// '如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                CurPatexam.modcheckdate = DateTime.Now;
            }
            if (CurPatexam.machinetype == "")
            {

                string d_GetValue = RisSetup_Class.GetINI("setup", CurPatexam.dep + "machinetype");
                CurPatexam.machinetype = d_GetValue;
            }
            string d_ReportType = "";
            try
            {

                if (CurPatexam.dep == "XRAY")
                {
                    d_ReportType = "X线检查报告单";
                }
                else if (CurPatexam.dep == "CT")
                {
                    d_ReportType = "CT检查报告单";
                }
                else if (CurPatexam.dep == "MRI")
                {
                    d_ReportType = "核磁共振(MRI)检查报告单";
                }
                else if (CurPatexam.dep == "DSA")
                {
                    d_ReportType = "DSA检查报告单";
                }
                else if (CurPatexam.dep == "DG")
                {
                    d_ReportType = "病理报告单";
                }
                else if (CurPatexam.dep == "内窥镜")
                {
                    d_ReportType = "电子内镜检查报告单";
                }
                else if (CurPatexam.dep == "US")
                {
                    d_ReportType = "多普勒超声检查报告单";
                }
                else
                {
                    d_ReportType = "报告单";
                }
            }
            catch { }
            patregister_Class CurPatregister = new patregister_Class(CurAccessno);
            myEditControl.SetDocumentParameterValue("hospitalname", Share_Class.hospital_name);
            myEditControl.SetDocumentParameterValue("ReportType", d_ReportType);
            myEditControl.SetDocumentParameterValue("patexam", CurPatexam);
            myEditControl.SetDocumentParameterValue("patregister", CurPatregister);
            myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
        }
        private void FormInit()
        {
            apply_writerControl.Visible = false;
            //   DownloadXML();
            GetXMLFile();
            apply_writerControl.Font = new Font(System.Windows.Forms.Control.DefaultFont.Name, 12);
            apply_writerControl.Font = new Font("宋体", 9);
            //myEditControl.AutoSetDocumentDefaultFont = true;

            apply_writerControl.DocumentOptions = new DocumentOptions();
            // 设置文档处于调试模式
            apply_writerControl.DocumentOptions.BehaviorOptions.DebugMode = false;
            // 设置为复杂留痕视图模式
            apply_writerControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);
            FillApplyByClass();
        }

        private void FillClassByInputXML(ref string d_reportinfo, ref string d_reportend)
        {

            myEditControl.ExecuteCommand("UpdateDataSourceForView", false, null);

            try
            {
                XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById("reportinfotable");
                try
                {
                    XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                    d_reportinfo = d_cell.Text;

                }
                catch { }
                XTextTableElement reportendtable = (XTextTableElement)myEditControl.GetElementById("reportendtable");
                try
                {
                    XTextTableCellElement d_cell = reportendtable.GetCell(0, 0, true);
                    d_reportend = d_cell.Text;
                    //d_cell.ContentBuilder.AppendText(CurPatexam.reportend);
                }
                catch { }

            }
            catch { }
        }
        //引用
        private void toolStripuItem1_Click(object sender, EventArgs e)
        {
            string d_reportinfo = "";
            string d_reportend = "";
            FillClassByInputXML(ref d_reportinfo, ref d_reportend);
            //d_reportform.FillTemplate(d_reportinfo, d_reportend);
            d_ReportEdit.CurReportForm.FillTemplate(d_reportinfo, d_reportend);
            ShowErr_Form d_form = new ShowErr_Form("调用成功", "提示");
            d_form.ShowDialog();
            d_ReportEdit.Report_XtraTabControl.SelectedTabPage = d_ReportEdit.Report_XtraTabPage;
            //d_reportform.Report_XtraTabControl.SelectedTabPage = d_reportform.Report_XtraTabPage ;
            //d_ReportEdit_UserControl.Report_XtraTabControl.SelectedTabPage = d_DG_ReportEdit_UserControl.Report_XtraTabPage;
            //d_ReportEdit.Report_XtraTabControlSelectedTabPage("Report_XtraTabPage");
        }
        //Pacs图像
        private void toolStripuItem2_Click(object sender, EventArgs e)
        {
            string p_OpenPacsType = RisSetup_Class.GetINI("setup", "OpenPacsType");
            string d_Modality = CurPatexam.modality;
            if (CurPatexam.modality.Length > 2)
                d_Modality = CurPatexam.modality.Substring(0, 2);
            if (p_OpenPacsType == "PIVIEW")
            {
                Share_Class.ShowPiviewPacsPicture(CurPatexam.xno, CurPatexam.Patient_id, CurPatexam.accessno, d_Modality);
            }
            else
            {
                Share_Class.ShowPacsPicture(CurPatexam.xno, CurPatexam.Patient_id, CurPatexam.accessno, d_Modality);
            }
        }

        private void Add_SimpleButton_Click(object sender, EventArgs e)
        {
            toolStripuItem1_Click(null, null);
        }
        //显示申请单
        private void Apply_SimpleButton_Click(object sender, EventArgs e)
        {
            //apply_writerControl.Visible = apply_writerControl.Visible ^ true;
            try
            {
                if (CurPatexam.picture_path.Trim() != "")
                { //'进入显示申请单图片

                    ShowApplyImage_Form CurShowApplyImage_Form = new ShowApplyImage_Form(CurPatexam.picture_path, "");
                    CurShowApplyImage_Form.ShowDialog();

                }
                else
                {

                    ShowApply_Form_old CurShowApply_Form = new ShowApply_Form_old(CurPatexam, null);

                    CurShowApply_Form.ShowDialog();
                }
            }
            catch
            {

            }
        }
        private void FillApplyByClass()
        {
            patexam_Class ApplyPatexam = new patexam_Class(CurPatexam.accessno);
            patregister_Class ApplyPatRegister = new patregister_Class(CurPatexam.accessno);
            if ((ApplyPatexam.dep == "US") || (ApplyPatexam.dep == "DG") || (ApplyPatexam.dep == "ES") || (ApplyPatexam.dep == "内窥镜"))
            {
                FTP_image_simpleButton.Visible = true;
            }
            else
                FTP_image_simpleButton.Visible = false;
            Image d_image = null;
            //if (ApplyPatexam.picture_path.Trim() != "")
            //{
            //    ApplyImage_Class d_applyimage = new ApplyImage_Class();
            //    d_image = d_applyimage.GetImage(ApplyPatexam.picture_path);
            //}
            if (d_image != null)
            {//图像
                apply_writerControl.ExecuteCommand(StandardCommandNames.FileNew, false, null);
                XTextImageElement imgElement = new XTextImageElement();
                imgElement.ImageValue = d_image;
                string d_GetValue = RisSetup_Class.GetINI("setup", "ApplyImageBig");
                float d_ApplyImageBig = 1;
                try
                {
                    if (d_GetValue != "")
                    {
                        d_ApplyImageBig = Convert.ToSingle(d_GetValue);
                    }
                }
                catch { d_ApplyImageBig = 1; }
                imgElement.Width = d_image.Width * d_ApplyImageBig;
                imgElement.Height = d_image.Height * d_ApplyImageBig;
                apply_writerControl.ExecuteCommand(StandardCommandNames.InsertImage, false, imgElement);

            }
            else
            {
                //DataTable dt = new DataTable();
                //dt = ReportStyle_Class.GetApplyStyle();
                //if (dt != null)
                //{
                //    ReportStyle_Class d_style = new ReportStyle_Class(dt.Rows[0]);
                //    if (d_style.xmltext != "")
                //        apply_writerControl.LoadDocumentFromString(d_style.xmltext, "xml");
                //    else
                //    {
                //        string fileName = "";
                //        fileName = Share_Class.Dir + @"\xml\Apply.xml";
                //        apply_writerControl.ExecuteCommand("FileOpen", false, fileName);
                //    }
                //}
                //else
                //{
                string fileName = "";
                fileName = Share_Class.Dir + @"\xmlStyle\Apply.xml";
                apply_writerControl.ExecuteCommand("FileOpen", false, fileName);
                //}

                string d_ReportType = "检查申请单";
                apply_writerControl.SetDocumentParameterValue("hospitalname", Share_Class.hospital_name);
                apply_writerControl.SetDocumentParameterValue("ReportType", d_ReportType);
                apply_writerControl.SetDocumentParameterValue("patexam", ApplyPatexam);
                apply_writerControl.SetDocumentParameterValue("patregister", ApplyPatRegister);
                apply_writerControl.ExecuteCommand("UpdateViewForDataSource", false, null);

            }
        }
        private void Image_SimpleButton_Click(object sender, EventArgs e)
        {
            toolStripuItem2_Click(null, null);
        }

        private void FTP_image_simpleButton_Click(object sender, EventArgs e)
        {
            ShowPic_Form d_form = new ShowPic_Form(CurPatexam.accessno);
            d_form.ShowDialog();
        }




    }
}
