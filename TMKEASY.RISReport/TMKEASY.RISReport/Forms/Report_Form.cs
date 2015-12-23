using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using System.Drawing;
using System.Drawing.Drawing2D;
using DCSoft.Writer.Dom;

namespace TMKEASY.RISReport
{
    public partial class Report_Form : Form
    {
        #region 初始化
        public Report_Form()
        {
            InitializeComponent();
        }

        public Report_Form(string p_accessno)
        {
            InitializeComponent();
            CurAccessno = p_accessno;

        }
        public Report_Form(string p_accessno, string hospital_name, string hospital_code)
        {
            InitializeComponent();
            CurAccessno = p_accessno;
            Share_Class.hospital_name = hospital_name;
            Share_Class.hospital_code = hospital_code;

        }
        public Report_Form(string p_accessno, string hospital_name, string Secondospital_name, string hospital_code)
        {
            InitializeComponent();
            CurAccessno = p_accessno;
            Share_Class.hospital_name = hospital_name;
            Share_Class.Secondospital_name = Secondospital_name;
            Share_Class.hospital_code = hospital_code;

        }

        private void Report_Form_Load(object sender, EventArgs e)
        {
            RIS.Common.Globals.Version = 200906;
            this.MaximizedBounds = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            Form_Init();
            InitEvent();
        }
        private void Form_Init()
        {

            CurReportForm = new Report_Word_Form(CurAccessno, this);
            //CurReportForm = new Report_RIS_Form(CurAccessno);
            CurReportForm.TopLevel = false;
            report_PanelControl.Controls.Add(CurReportForm);
            //CurReportForm.WindowState = FormWindowState.Maximized;
            CurReportForm.Top = 0;
            CurReportForm.Left = 0;
            CurReportForm.Dock = DockStyle.Fill;
            //  DownloadXML();
            //DownloadPic();

            CurReportForm.Show();
            patexam_Class.Setwrite_flag(CurAccessno, Share_Class.User.user_id);

            FillTemplate(CurReportForm.CurPatexam.dengjipart);
            //PadICD10_TreeList();
            Report_GroupControl.Text = Report_GroupControl.Text + "--" + Share_Class.hospital_name;
            Text = Report_GroupControl.Text + "--" + Share_Class.hospital_name;
            ShowButton();

            PicPath = Share_Class.Dir + "\\pic" + "\\" + CurReportForm.CurPatexam.checkdate.ToString("yyyyMMdd") + "\\" + CurReportForm.CurPatexam.accessno + "\\";
            Share_Class.CreatePath(PicPath);
            Share_Class.CreatePath(Share_Class.Dir + @"\xml\" + CurReportForm.CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\");

            initPermission();
            Filldiseasetype();
            FillInputByClass();
            Fillhistroy();


            if (CONSULT_DIAG_Class.ISEXPERT_DOCTOR(CurReportForm.CurPatexam.accessno) == true)
                this.huizhen_SimpleButton.ForeColor = Color.Red;

            //QcInit();


            if ((CurReportForm.CurPatexam.dep == "PETCT") || (CurReportForm.CurPatexam.dep == "ECT") || (CurReportForm.CurPatexam.dep == "体检放射"))
            {
                image_ComboBoxEdit.Text = "图文报告";
                Right_XtraTabControl.SelectedTabPageIndex = 2;
                DownloadPic();
                this.GetPic();
            }
            this.Template_TreeList.Focus();
        }
        #endregion

        #region 绑定事件
        private void InitEvent()
        {
            Report_GroupControl.MouseDown += new MouseEventHandler(Report_GroupControl_MouseDown);
            Report_GroupControl.MouseMove += new MouseEventHandler(Report_GroupControl_MouseMove);
            Template_TreeList.Click += new EventHandler(Template_TreeList_Click);
            Template_TreeList.DoubleClick += new EventHandler(Template_TreeList_DoubleClick);
            ShowAll_Template_SimpleButton.Click += new EventHandler(ShowAll_Template_SimpleButton_Click);
            template_grade_ComboBoxEdit.SelectedIndexChanged += new EventHandler(template_grade_ComboBoxEdit_SelectedIndexChanged);
            this.modality_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.machinetype_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.doctor_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.sqdep_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.wardno_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.radio_doctor_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.othercheck_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.checktype_ComboBoxEdit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);
            this.image_ComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.image_ComboBoxEdit_SelectedIndexChanged);
            ICD10_TreeList.Click += new EventHandler(ICD10_TreeList_Click);
            ICD10_TreeList.DoubleClick += new EventHandler(ICD10_TreeList_DoubleClick);
        }
        #endregion

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


        #region FTP
        #region FTP上传下载



        #endregion


        public FTPSETUP_Class GetFTPSETUPByFTPCODE()
        {
            FTPSETUP_Class CurFTPSETUP = new FTPSETUP_Class(CurReportForm.CurPatregister.ftpcode);
            if (CurFTPSETUP.id == 0)
                CurFTPSETUP.GetDataByFTPStatus();
            return CurFTPSETUP;
        }


        #region 图像上传下载
        public void DownloadPic()
        {
            string d_FTPOPEN = "";
            d_FTPOPEN = RisSetup_Class.GetINI("setup", "FTPOPEN");
            if (d_FTPOPEN != "yes")
            {
                return;
            }
            FTPSETUP_Class CurFTPSETUP = GetFTPSETUPByFTPCODE();
            string d_FTPUserName, d_FTPPassword, d_FTPHost, d_FTPPort, d_FTPFileName;
            if (CurFTPSETUP.id == 0)
            {
                d_FTPUserName = RisSetup_Class.GetINI("setup", "FTPUserName");
                d_FTPPassword = RisSetup_Class.GetINI("setup", "FTPPassword");
                d_FTPHost = RisSetup_Class.GetINI("setup", "FTPHost");
                d_FTPPort = RisSetup_Class.GetINI("setup", "FTPPort");
                d_FTPFileName = RisSetup_Class.GetINI("setup", "FTPFileName");
            }
            else
            {
                d_FTPUserName = CurFTPSETUP.FTPUserName;
                d_FTPPassword = CurFTPSETUP.FTPPassword;
                d_FTPHost = CurFTPSETUP.FTPHost;
                d_FTPPort = CurFTPSETUP.FTPPort;
                d_FTPFileName = CurFTPSETUP.FTPFileName;
            }
            RIS.Vedio.FtpClient ftp = new RIS.Vedio.FtpClient(d_FTPHost, Convert.ToInt32(d_FTPPort), d_FTPUserName, d_FTPPassword);
            string d_date = CurReportForm.CurPatexam.checkdate.ToString("yyyyMMdd");
            // '设置本地和远程的路径 

            ftp.LocalDirectory = Share_Class.Dir + @"\pic\" + d_date + @"\" + CurReportForm.CurPatexam.accessno + @"\";
            if (Directory.Exists(ftp.LocalDirectory) == false)
            {
                Directory.CreateDirectory(ftp.LocalDirectory);
            }
            ftp.RemoteDirectory = d_FTPFileName + @"/pic/" + d_date + @"/" + CurReportForm.CurPatexam.accessno + @"/";

            // '浏览目录,如果不存在,自动创建目录 
            try
            {
                bool d_status = false;
                string d_imgtype = "*.jpg|*.avi";
                string[] imgtype = d_imgtype.Split(new char[] { '|' });
                for (int i = 0; i < imgtype.Length; i++)
                {
                    List<string> files = ftp.ListDirectory(imgtype[i]);
                    string[] localfiles = System.IO.Directory.GetFiles(ftp.LocalDirectory, imgtype[i]);
                    foreach (string file in files)
                    {
                        d_status = false;
                        foreach (string localfile in localfiles)
                        {
                            if ((ftp.LocalDirectory + files) == localfile)
                            {
                                d_status = true;
                                break;
                            }
                        }
                        if (d_status == false)
                        {
                            ftp.Download(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }
        }

        public void DownloadSection()
        {
            string d_FTPOPEN = "";
            d_FTPOPEN = RisSetup_Class.GetINI("setup", "FTPOPEN");
            if (d_FTPOPEN != "yes")
            {
                return;
            }
            FTPSETUP_Class CurFTPSETUP = GetFTPSETUPByFTPCODE();
            string d_FTPUserName, d_FTPPassword, d_FTPHost, d_FTPPort, d_FTPFileName;
            if (CurFTPSETUP.id == 0)
            {
                d_FTPUserName = RisSetup_Class.GetINI("setup", "FTPUserName");
                d_FTPPassword = RisSetup_Class.GetINI("setup", "FTPPassword");
                d_FTPHost = RisSetup_Class.GetINI("setup", "FTPHost");
                d_FTPPort = RisSetup_Class.GetINI("setup", "FTPPort");
                d_FTPFileName = RisSetup_Class.GetINI("setup", "FTPFileName");
            }
            else
            {
                d_FTPUserName = CurFTPSETUP.FTPUserName;
                d_FTPPassword = CurFTPSETUP.FTPPassword;
                d_FTPHost = CurFTPSETUP.FTPHost;
                d_FTPPort = CurFTPSETUP.FTPPort;
                d_FTPFileName = CurFTPSETUP.FTPFileName;
            }
            RIS.Vedio.FtpClient ftp = new RIS.Vedio.FtpClient(d_FTPHost, Convert.ToInt32(d_FTPPort), d_FTPUserName, d_FTPPassword);
            string d_date = CurReportForm.CurPatexam.checkdate.ToString("yyyyMMdd");
            // '设置本地和远程的路径 

            ftp.LocalDirectory = Share_Class.Dir + @"\pic\" + d_date + @"\" + CurReportForm.CurPatexam.accessno + @"\";
            if (Directory.Exists(ftp.LocalDirectory) == false)
            {
                Directory.CreateDirectory(ftp.LocalDirectory);
            }
            ftp.RemoteDirectory = d_FTPFileName + @"/sectionpic/" + d_date + @"/" + CurReportForm.CurPatexam.accessno + @"/";

            // '浏览目录,如果不存在,自动创建目录 
            try
            {
                bool d_status = false;
                string d_imgtype = "*.jpg|*.avi";
                string[] imgtype = d_imgtype.Split(new char[] { '|' });
                for (int i = 0; i < imgtype.Length; i++)
                {
                    List<string> files = ftp.ListDirectory(imgtype[i]);
                    string[] localfiles = System.IO.Directory.GetFiles(ftp.LocalDirectory, imgtype[i]);
                    foreach (string file in files)
                    {
                        d_status = false;
                        foreach (string localfile in localfiles)
                        {
                            if ((ftp.LocalDirectory + files) == localfile)
                            {
                                d_status = true;
                                break;
                            }
                        }
                        if (d_status == false)
                        {
                            ftp.Download(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }
        }
        public void UpdatePic()
        {
            string d_FTPOPEN = "";
            d_FTPOPEN = RisSetup_Class.GetINI("setup", "FTPOPEN");
            if (d_FTPOPEN != "yes")
            {
                return;
            }
            FTPSETUP_Class CurFTPSETUP = GetFTPSETUPByFTPCODE();
            string d_FTPFileName = "";
            if (CurFTPSETUP.id == 0)
                d_FTPFileName = RisSetup_Class.GetINI("setup", "FTPFileName");
            else
                d_FTPFileName = CurFTPSETUP.FTPFileName;

            string d_RemoteDirectory = d_FTPFileName + @"/pic/" + CurReportForm.CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"/" + CurReportForm.CurPatexam.accessno + @"/";
            //  '在此设置远程路径，例如: d_FTPFileName + "/pic/" + d_date + "/" + d_accessno;
            List<RIS.Vedio.FtpUploadTaskItem> lst = new List<RIS.Vedio.FtpUploadTaskItem>();
            string d_path = Share_Class.Dir + @"\pic\" + CurReportForm.CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurReportForm.CurPatexam.accessno + @"\";
            string[] localfiles = System.IO.Directory.GetFiles(d_path, CurReportForm.CurPatexam.accessno + ".xml");
            foreach (string file in localfiles)
            {
                lst.Add(new RIS.Vedio.FtpUploadTaskItem(d_RemoteDirectory, file));
            }
            try
            {
                RIS.Vedio.FTP.FTPUploadAsyncHelper.AddUploadFileToTaskAsync(lst);
            }
            catch { }
            patregister_Class.UpdateFTPCode(CurFTPSETUP.FTPCode, CurReportForm.CurPatexam.patid);

        }
        #endregion

        #endregion

        #region 定义变量
        // 添加一个委托 
        public delegate void PassDataBetweenFormHandler(Object sender, EventArgs_Class e);
        // 添加一个PassDataBetweenFormHandler 类型的事件 
        public event PassDataBetweenFormHandler SaveReport;
        public event PassDataBetweenFormHandler AdvanceReport;

        public BaseReport_Form CurReportForm;
        string CurAccessno = "";
        ICD_10_Class CurICD_10;
        string PicPath = "";
        List<string> p_SelectedImage = new List<string>();
        public ShowApplyImage_Form CurShowApplyImage_Form;
        public ShowApply_Form_old CurShowApply_Form;
        #endregion

        #region 模板
        private void FillTemplate(string p_part)
        {
            //GetTemplateList
            DataTable dt = new DataTable();

            dt = report_template_Class.GetTemplateList(template_grade_ComboBoxEdit.Text, CurReportForm.CurPatexam.dep, p_part);
            Template_TreeList.Nodes.Clear();
            if (dt == null)
                return;
            TreeListNode d_BaseNode = null;
            TreeListNode d_Node;
            // '填充数据库中调出的项
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = Template_TreeList.AppendNode(new Object[] { dt.Rows[i]["t_part"].ToString(), CheckState.Unchecked }, d_BaseNode);
                Filldisease_typeNodeBytemplate_partNode(d_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
            if (dt.Rows.Count >= 1)
            {
                Template_TreeList.Nodes.FirstNode.Expanded = true;
                Template_TreeList.Nodes.FirstNode.FirstNode.Expanded = true;
            }
        }
        //'根据部位结点填充结果归类结点
        private void Filldisease_typeNodeBytemplate_partNode(TreeListNode p_Node)
        {
            //setup_REPORT_TEMPLATE_ORDER_Class.Update_REPORT_TEMPLATE_ORDER_DISEASE_TYPE(CurReportForm.CurPatexam.dep, p_Node.GetValue("template"));
            //setup_REPORT_TEMPLATE_ORDER_Class.Delete_REPORT_TEMPLATE_ORDER_DISEASE_TYPE(CurReportForm.CurPatexam.dep, p_Node.GetValue("template"));

            DataTable dt = new DataTable();
            dt = report_template_Class.Getdisease_typeBytemplate_part(template_grade_ComboBoxEdit.Text, CurReportForm.CurPatexam.dep, p_Node.GetValue("template").ToString());

            p_Node.Nodes.Clear();
            TreeListNode d_Node;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = Template_TreeList.AppendNode(new Object[] { dt.Rows[i][0].ToString(), CheckState.Unchecked }, p_Node);
                //Filltemplate_nameNodeBydisease_typeNode(d_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
        }
        //'根据结果归类结点填充模板结点
        private void Filltemplate_nameNodeBydisease_typeNode(TreeListNode p_Node)
        {
            //setup_REPORT_TEMPLATE_ORDER_Class.Update_REPORT_TEMPLATE_ORDER_TEMPLATE_NAME(CurPatexam.dep, p_Node.ParentNode.GetValue("template"), p_Node.GetValue("template"))
            //setup_REPORT_TEMPLATE_ORDER_Class.Delete_REPORT_TEMPLATE_ORDER_TEMPLATE_NAME(CurPatexam.dep, p_Node.ParentNode.GetValue("template"), p_Node.GetValue("template"))
            DataTable dt = new DataTable();
            dt = report_template_Class.Get_template_nameBydisease_type(template_grade_ComboBoxEdit.Text, CurReportForm.CurPatexam.dep, p_Node.ParentNode.GetValue("template").ToString(), p_Node.GetValue("template").ToString());
            p_Node.Nodes.Clear();
            TreeListNode d_Node;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = Template_TreeList.AppendNode(new Object[] { dt.Rows[i][1].ToString(), CheckState.Unchecked }, p_Node);
                //Filldisease_typeNodeBytemplate_partNode(d_Node);
                d_Node.Tag = dt.Rows[i][0].ToString();
                d_Node.ImageIndex = 1;
                d_Node.SelectImageIndex = 1;
            }

        }
        private void Template_TreeList_DoubleClick(object sender, EventArgs e)
        {
            if (Template_TreeList.Selection.Count == 0)
                return;

            // '取得选中的结点
            TreeListNode d_Node = Template_TreeList.Selection[0];
            string d_strpart, d_strdisease_type, d_strtemplate;

            if (d_Node.ParentNode == null)
            {// ){ '当前结点是部位
                Filldisease_typeNodeBytemplate_partNode(d_Node);
            }
            else if (d_Node.ParentNode.ParentNode == null)
            {//'当前结点是结果归类
                Filltemplate_nameNodeBydisease_typeNode(d_Node);
            }
            else if (d_Node.Nodes.Count == 0)
            {
                d_strtemplate = d_Node.GetValue(0).ToString();// '得到模板
                d_strdisease_type = d_Node.ParentNode.GetValue(0).ToString();// '得到结果
                d_strpart = d_Node.ParentNode.ParentNode.GetValue(0).ToString();// '得到部位
                report_template_Class d_template = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), CurReportForm.CurPatexam.dep, d_strpart, d_strdisease_type, d_strtemplate);
                //string idtemp = d_Node.Tag.ToString();
                //report_template_Class d_template = new report_template_Class("公有", Convert.ToInt32(idtemp));
                CurReportForm.FillTemplate(d_template);
                //FillTemplate(d_template);
                //CurReportForm.FillTemplate(d_template.template_describle, d_template.template_diag);
                //'填充结果归类
                diseasetype_ComboBoxEdit.Text = d_strdisease_type;
            }
        }

        private void Template_TreeList_Click(object sender, EventArgs e)
        {
            try
            {
                if (Template_TreeList.Selection.Count == 0)
                    return;

                // '取得选中的结点
                TreeListNode d_Node = Template_TreeList.Selection[0];
                string d_strpart, d_strdisease_type, d_strtemplate;
                if (d_Node.ParentNode == null)
                {// ){ '当前结点是部位

                }
                else if (d_Node.ParentNode.ParentNode == null)
                {//'当前结点是结果归类

                }
                else if (d_Node.Nodes.Count == 0)
                {
                    d_strtemplate = d_Node.GetValue(0).ToString();// '得到模板
                    d_strdisease_type = d_Node.ParentNode.GetValue(0).ToString();// '得到结果
                    d_strpart = d_Node.ParentNode.ParentNode.GetValue(0).ToString();// '得到部位

                    report_template_Class d_template = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), CurReportForm.CurPatexam.dep, d_strpart, d_strdisease_type, d_strtemplate);
                    template_describle_MemoEdit.Text = d_template.template_describle;
                    template_diag_MemoEdit.Text = d_template.template_diag;
                }
            }
            catch (Exception ex)
            {
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
            }
        }


        private void ShowAll_Template_SimpleButton_Click(object sender, EventArgs e)
        {
            if (ShowAll_Template_SimpleButton.Text == "显示全部模板")
            {
                FillTemplate("");
                ShowAll_Template_SimpleButton.Text = "显示当前模板";
            }
            else
            {
                FillTemplate(CurReportForm.CurPatexam.dengjipart);
                ShowAll_Template_SimpleButton.Text = "显示全部模板";
            }
        }

        private void template_grade_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (template_grade_ComboBoxEdit.Text.Trim() == "私有")
            {
                template_grade_ComboBoxEdit.Text = Share_Class.User.user_id.Trim();
                ShowAll_Template_SimpleButton.Text = "显示当前模板";
            }
            if (ShowAll_Template_SimpleButton.Text == "显示全部模板")
            {
                FillTemplate(CurReportForm.CurPatexam.dengjipart);
            }
            else
            {
                FillTemplate("");
            }

        }

        #endregion

        #region ICD10

        private void PadICD10_TreeList()
        {
            CurICD_10 = new ICD_10_Class();
            DataSet Ds = CurICD_10.GetFIRST_LEVEL_NAME();
            if (Ds == null)
                return;
            ICD10_TreeList.Nodes.Clear();

            string NodeStr = "";
            TreeListNode d_BaseNode = null;
            TreeListNode d_Node = null;
            // '填充数据库中调出的项       
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {

                NodeStr = Ds.Tables[0].Rows[i]["FIRST_LEVEL_NAME"].ToString();
                d_Node = ICD10_TreeList.AppendNode(new Object[] { NodeStr, CheckState.Unchecked }, d_BaseNode);
                d_Node.Tag = NodeStr;
                DataSet DirDs = CurICD_10.GetSECOND_LEVEL_NAME(NodeStr);
                d_Node = null;
            }
        }

        private void ICD10_TreeList_Click(object sender, EventArgs e)
        {
            try
            {
                if (ICD10_TreeList.Selection.Count == 0)
                    return;

                //'取得选中的结点
                TreeListNode d_Node = ICD10_TreeList.Selection[0];
                if (d_Node.ParentNode == null)
                {// '当前结点是部位
                    return;
                }
                else if (d_Node.ParentNode.ParentNode == null)
                {// '当前结点是结果归类
                    return;
                }
                else if (d_Node.ParentNode.ParentNode.ParentNode == null)
                {// '当前结点是结果归类
                    return;
                }
                else
                {
                    if (d_Node.Nodes.Count == 0)
                    {
                        //diseasetype_ComboBoxEdit.Text = d_Node.GetValue[0].ToString();// '得到模板
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
                return;

            }
        }

        private void ICD10_TreeList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ICD10_TreeList.Selection.Count == 0)
                    return;

                //'取得选中的结点
                TreeListNode d_Node = ICD10_TreeList.Selection[0];
                if (d_Node.ParentNode == null)
                {// '当前结点是部位
                    firstDir_typeNodeBytemplate_partNode(d_Node);
                }
                else if (d_Node.ParentNode.ParentNode == null)
                {// '当前结点是结果归类
                    secondDir_nameNodeBydisease_typeNode(d_Node);
                }
                else if (d_Node.ParentNode.ParentNode.ParentNode == null)
                {// '当前结点是结果归类
                    THIRD_LEVEL_NAMENodeBydisease_typeNode(d_Node);
                }
                else
                {
                    if (d_Node.Nodes.Count == 0)
                    {
                        //CurReportForm.Filldiseasetype(d_Node.GetValue(0).ToString());
                        diseasetype_ComboBoxEdit.Text = d_Node.GetValue(0).ToString();// '得到模板
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
                return;

            }
        }
        //'根据部位结点填充结果归类结点
        private void firstDir_typeNodeBytemplate_partNode(TreeListNode p_Node)
        {
            DataSet Ds = CurICD_10.GetSECOND_LEVEL_NAME(p_Node.GetValue(0).ToString());
            if (Ds == null)
                return;
            p_Node.Nodes.Clear();
            TreeListNode d_Node;
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {

                d_Node = ICD10_TreeList.AppendNode(new Object[] { Ds.Tables[0].Rows[i][0].ToString(), CheckState.Unchecked }, p_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
        }
        // '根据结果归类结点填充模板结点
        private void secondDir_nameNodeBydisease_typeNode(TreeListNode p_Node)
        {
            DataSet Ds = CurICD_10.GetTHIRD_LEVEL_NAME(p_Node.GetValue(0).ToString());
            if (Ds == null)
                return;
            p_Node.Nodes.Clear();
            TreeListNode d_Node;
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                d_Node = ICD10_TreeList.AppendNode(new Object[] { Ds.Tables[0].Rows[i][0].ToString(), CheckState.Unchecked }, p_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
        }
        //  '根据结果归类结点填充模板结点
        private void THIRD_LEVEL_NAMENodeBydisease_typeNode(TreeListNode p_Node)
        {
            DataSet Ds = CurICD_10.GetFOURTH_LEVEL_NAME(p_Node.GetValue(0).ToString());
            if (Ds == null)
                return;
            p_Node.Nodes.Clear();
            TreeListNode d_Node;
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                d_Node = ICD10_TreeList.AppendNode(new Object[] { Ds.Tables[0].Rows[i][0].ToString(), CheckState.Unchecked }, p_Node);
                d_Node.ImageIndex = 1;
                d_Node.SelectImageIndex = 1;
            }
        }
        #endregion

        #region 界面上方按钮
        private void initPermission()
        {
            //'设置权限
            Save_SimpleButton.Enabled = false;
            advance_SimpleButton.Enabled = false;
            doubleadvance_SimpleButton.Enabled = false;
            doubleadvance_SimpleButton.Text = "复 审";
            advance_SimpleButton.Text = "审 核";
            Save_SimpleButton.Text = "保 存";
            if (CurReportForm.CurPatexam.check_status == "已审核")
            {
                advance_SimpleButton.Text = "已审核";
                if (CurReportForm.CurPatregister.firadvancedoc != "")
                {
                    advance_SimpleButton.Enabled = false;
                    if (Share_Class.User.HaveFunction("g") == true)
                    {
                        doubleadvance_SimpleButton.Enabled = true;
                    }
                    else if ((Share_Class.User.HaveFunction("501") == true))
                    {
                        doubleadvance_SimpleButton.Enabled = true;
                    }
                    //else if ((Share_Class.User.HaveFunction("501") == true) && (CurReportForm.CurPatexam.advancedoc == Share_Class.User.user_id))
                    //{
                    //    doubleadvance_SimpleButton.Enabled = true;
                    //}
                    //else if ((Share_Class.User.HaveFunction("501") == true) && (CurReportForm.CurPatexam.advancedate.AddDays(+1) > DateTime.Now))
                    //{
                    //    doubleadvance_SimpleButton.Enabled = true;
                    //}
                }
                else
                {
                    if (CurReportForm.CurPatexam.advancedoc == Share_Class.User.user_id)
                    {
                        advance_SimpleButton.Enabled = true;
                    }
                    else if ((Share_Class.User.HaveFunction("c") == true) && (CurReportForm.CurPatexam.advancedate.AddDays(+1) > DateTime.Now))
                    {
                        advance_SimpleButton.Enabled = true;
                    }
                    if ((Share_Class.User.HaveFunction("g") == true) || (Share_Class.User.HaveFunction("501")))
                    {
                        doubleadvance_SimpleButton.Enabled = true;
                    }

                }

                //else if ((Share_Class.User.HaveFunction("c") == true) && (CurReportForm.CurPatexam.advancedoc == Share_Class.User.user_id) && (CurReportForm.CurPatexam.reportdate.AddDays(+7) > DateTime.Now))
                //{
                //    advance_SimpleButton.Enabled = true;
                //}
            }
            else if (CurReportForm.CurPatexam.check_status == "未审核")
            {
                Save_SimpleButton.Text = "已保存";
                //advance_SimpleButton.Enabled = true;
                if ((Share_Class.User.HaveFunction("b") == true) && (CurReportForm.CurPatexam.reportdoc == Share_Class.User.user_id))
                {
                    Save_SimpleButton.Enabled = true;
                }
                if ((Share_Class.User.HaveFunction("g") == true) || (Share_Class.User.HaveFunction("c") == true))
                {
                    advance_SimpleButton.Enabled = true;
                }

            }
            else
            {
                if ((Share_Class.User.HaveFunction("b") == true))
                {
                    Save_SimpleButton.Enabled = true;
                }
                if ((Share_Class.User.HaveFunction("g") == true) || (Share_Class.User.HaveFunction("c") == true))
                {
                    advance_SimpleButton.Enabled = true;
                }
            }

        }
        private void ShowButton()
        {
            List<DevExpress.XtraEditors.SimpleButton> d_buttonlist = new List<DevExpress.XtraEditors.SimpleButton>();

            d_buttonlist.Add(this.temp_Save_SimpleButton);
            //If Share_Class.SoftVersion = "0593010" ){
            //    Save_SimpleButton.Text = "提交"
            //Endif (
            d_buttonlist.Add(Save_SimpleButton);
            d_buttonlist.Add(advance_SimpleButton);
            if (CurReportForm.CurPatexam.check_status == "已审核")
                d_buttonlist.Add(doubleadvance_SimpleButton);
            d_buttonlist.Add(preview_SimpleButton);
            d_buttonlist.Add(Print_SimpleButton);
            //If Share_Class.SoftVersion = "0577002" ){
            //    d_buttonlist.Add(SimpleButton10)
            //Endif (

            d_buttonlist.Add(dzbs_simpleButton);
            d_buttonlist.Add(Image_SimpleButton);
            d_buttonlist.Add(again_SimpleButton);
            d_buttonlist.Add(apply_SimpleButton);

            d_buttonlist.Add(template_SimpleButton);
            d_buttonlist.Add(huizhen_SimpleButton);
            //'d_buttonlist.Add(OutPdf_SimpleButton);
            d_buttonlist.Add(Close_SimpleButton);
            int d_x = (Width - d_buttonlist.Count * 60) / 2;
            foreach (DevExpress.XtraEditors.SimpleButton item in d_buttonlist)
            {
                item.Location = new Point(d_x, 9);
                d_x = d_x + item.Width;
                item.Visible = true;
            }

        }

        private void dzbs_simpleButton_Click(object sender, EventArgs e)
        {
            string EpisodeID = "";
            string d_str = "select P_ADMNO from  HISEXAM where P_ACCESSNO ='" + CurReportForm.CurPatexam.accessno  + "'";
            DataSet ds = RISOracle_Class.GetDS(d_str, d_str);
            if (ds == null)
                return;
            if (ds.Tables.Count == 0)
                return;
            if (ds.Tables [0].Rows.Count ==0)
                return ;
            EpisodeID = ds.Tables[0].Rows[0][0].ToString();
            string iePath = RisSetup_Class.GetINI("setup", "iepath");
            string pacsstr = "";
            string d_values = RisSetup_Class.GetINI("setup", "dzbsie");
            if (d_values == "")
                pacsstr = @"http://129.60.0.154/dthealth/web/csp/websys.csp?a=a&TMENU=53651";
            pacsstr += "&EpisodeID=" + EpisodeID + "";

            if (iePath != "")
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = iePath;
                p.StartInfo.Arguments = pacsstr;
                p.Start();
            }
            else
            {
                System.Diagnostics.Process.Start(pacsstr);
            }



        }

        private void caption_picturebox_Paint(object sender, PaintEventArgs e)
        {
            Color d_color1 = Color.LightSkyBlue;// 'PeachPuff '颜色1
            Color d_color2 = Color.LightSeaGreen;// 'CornflowerBlue
            LinearGradientBrush lgbrush;
            Rectangle rect = new Rectangle(0, 0, caption_picturebox.Width, caption_picturebox.Height);
            lgbrush = new LinearGradientBrush(rect, d_color1, d_color2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(lgbrush, rect);


            try
            {

                Bitmap d_image = new Bitmap("report_edit2.png");
                e.Graphics.DrawImage(d_image, 10, 15);

            }
            catch
            {

            }


        }

        private void Next_SimpleButton_Click(object sender, EventArgs e)
        {

        }

        private void Close_SimpleButton_Click(object sender, EventArgs e)
        {
            patexam_Class.Setwrite_flag(CurReportForm.CurPatexam.accessno, "");
            try
            {
                string p_direct_image = RisSetup_Class.GetINI("setup", "direct_image");
                if (p_direct_image == "yes")
                {
                    string p_OpenPacsType = RisSetup_Class.GetINI("setup", "OpenPacsType");
                    //patexam_Class d_patexam = new patexam_Class();
                    ////if (Report_XtraTabControl.SelectedTabPage == xtraTabPage2)
                    ////{
                    ////    d_patexam = new patexam_Class(clshistoryAccessno);
                    ////}
                    ////else
                    //d_patexam = CurPatexam;
                    //string d_Modality = d_patexam.modality;
                    //if (d_patexam.modality.Length > 2)
                    //    d_Modality = d_patexam.modality.Substring(0, 2);
                    if (p_OpenPacsType == "PIVIEW")
                    {
                        // Share_Class.ShowPiviewPacsPicture(d_patexam.xno, d_patexam.Patient_id, d_patexam.accessno, d_Modality);
                    }
                    else
                    {

                        Share_Class.ClosePacsPicture();
                    }
                }
            }
            catch { }
            Close();
        }

        private void huizhen_SimpleButton_Click(object sender, EventArgs e)
        {
            //Report_Outside_doctor_form p_report_outside_form = new Report_Outside_doctor_form(CurReportForm.CurPatexam.accessno);
            //p_report_outside_form.Show();
            Consult_request_form d_form = new Consult_request_form(CurReportForm.CurPatexam, this);
            d_form.Show();
            if (huizhen_SimpleButton.ForeColor == Color.Red)
            {
                d_form.XtraTabControl2.SelectedTabPageIndex = 1;
            }
        }

        private void template_SimpleButton_Click(object sender, EventArgs e)
        {
            string d_template_diag, d_template_describle, d_checkPos, d_dep;
            d_template_diag = "";
            d_template_describle = "";
            d_checkPos = "";
            d_dep = "";
            CurReportForm.getTemplateContent(ref d_template_diag, ref d_template_describle, ref  d_checkPos, ref d_dep);
            template_Word_form d_form = new template_Word_form(d_template_diag, d_template_describle, d_checkPos, d_dep);
            d_form.ShowDialog();
        }

        private void apply_SimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurReportForm.CurPatexam.picture_path.Trim() != "")
                { //'进入显示申请单图片
                    if (CurShowApplyImage_Form == null)
                    {
                        CurShowApplyImage_Form = new ShowApplyImage_Form(CurReportForm.CurPatexam.picture_path, this);
                    }
                    CurShowApplyImage_Form.Show();
                    CurShowApplyImage_Form.Focus();
                }
                else
                {
                    if (CurShowApply_Form == null)
                    {
                        CurShowApply_Form = new ShowApply_Form_old(CurReportForm.CurPatexam, this);
                    }
                    CurShowApply_Form.Show();
                    CurShowApply_Form.Focus();
                }
            }
            catch
            {

            }
        }

        private void again_SimpleButton_Click(object sender, EventArgs e)
        {
            if (Share_Class.User.HaveFunction("n") == false)
            {

                ShowErr_Form d_form1 = new ShowErr_Form("用户无此操作权限", "提示");
                d_form1.ShowDialog();
                return;
            }

            // '弹出重写框
            report_rewrite_form d_form = new report_rewrite_form(CurReportForm.CurPatexam);
            d_form.ShowDialog();

            // '清除报告界面中的重写内容
            CurReportForm.report_rewrite();
        }

        private void Image_SimpleButton_Click(object sender, EventArgs e)
        {

            CurReportForm.OpenPacsImage();

        }

        private void SendMessage_SimpleButton_Click(object sender, EventArgs e)
        {
            SendMessage_Form d_form = new SendMessage_Form(CurReportForm.CurPatexam);
            d_form.ShowDialog();
        }

        private void Print_SimpleButton_Click(object sender, EventArgs e)
        {
            //myEditControl.ExecuteCommand("FilePrint", true, null);
            //CurReportForm.ExecuteCommand("FilePrint", true);
            if (image_ComboBoxEdit.Text.Trim() == "急诊报告" && CurReportForm.CurPatexam.check_status != "已审核" && CurReportForm.CurPatexam.check_status != "未审核")
            {
                SaveTemp();
            }
            CurReportForm.PrintDocument("FilePrint");

        }
        private void SaveTemp()
        {
            //'质控            
            if (BeforeSave("保存", false) == true)
            {

                if (CurReportForm.Save() == true)
                {
                    try
                    {
                        EventArgs_Class args = new EventArgs_Class(CurReportForm.CurPatexam.accessno);
                        if (SaveReport != null)
                            SaveReport(this, args);
                        UpdatePic();
                    }
                    catch { }
                    ////CurPatexam.UpdateRegister();
                    //myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");
                    ////CurPatReport.Update();
                    //UpdateXML();

                }
            }
        }

        private void preview_SimpleButton_Click(object sender, EventArgs e)
        {
            //myEditControl.ExecuteCommand("FilePrintPreview", true, null);
            //CurReportForm.ExecuteCommand("FilePrintPreview", true);
            if (image_ComboBoxEdit.Text.Trim() == "急诊报告" && CurReportForm.CurPatexam.check_status != "已审核" && CurReportForm.CurPatexam.check_status != "未审核")
            {
                SaveTemp();
            }
            CurReportForm.PrintDocument("FilePrintPreview");
        }

        private void advance_SimpleButton_Click(object sender, EventArgs e)
        {
            if (BeforeSave("审核", true) == true)
            {
                if (CurReportForm.advance("审核") == true)
                {
                    try
                    {
                        EventArgs_Class args = new EventArgs_Class(CurReportForm.CurPatexam.accessno);
                        if (AdvanceReport != null)
                            AdvanceReport(this, args);
                    }
                    catch { }
                    //CurPatexam.UpdateRegister();
                    //myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");
                    //CurPatReport.Update();
                    //UpdateXML();
                    AfterSave("审核");

                }
            }
        }
        private void doubleadvance_SimpleButton_Click(object sender, EventArgs e)
        {
            if (BeforeSave("复审", true) == true)
            {
                if (CurReportForm.advance("复审") == true)
                {
                    try
                    {
                        EventArgs_Class args = new EventArgs_Class(CurReportForm.CurPatexam.accessno);
                        if (AdvanceReport != null)
                            AdvanceReport(this, args);
                    }
                    catch { }
                    //CurPatexam.UpdateRegister();
                    //myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");
                    //CurPatReport.Update();
                    //UpdateXML();
                    AfterSave("复审");

                }
            }
        }

        private void Save_SimpleButton_Click(object sender, EventArgs e)
        {
            //'质控            
            if (BeforeSave("保存", true) == true)
            {

                if (CurReportForm.Save() == true)
                {
                    try
                    {
                        EventArgs_Class args = new EventArgs_Class(CurReportForm.CurPatexam.accessno);
                        if (SaveReport != null)
                            SaveReport(this, args);
                    }
                    catch { }
                    ////CurPatexam.UpdateRegister();
                    //myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");
                    ////CurPatReport.Update();
                    //UpdateXML();
                    AfterSave("保存");
                }
            }
        }

        private void temp_Save_SimpleButton_Click(object sender, EventArgs e)
        {
            if ((CurReportForm.CurPatexam.check_status != "未审核") && (CurReportForm.CurPatexam.check_status != "已审核"))
            {
                string p_diseasetype, p_name, p_describe, p_diagnose, p_part;
                p_diseasetype = "";
                p_name = "";
                p_describe = "";
                p_diagnose = "";
                p_part = "";
                CurReportForm.getTemplateContent(ref p_diagnose, ref  p_describe, ref p_diagnose, ref p_part);
                if (CurReportForm.CurPatexam.TempReportSave(p_describe, p_diagnose, CurReportForm.CurPatexam.accessno) == true)
                {
                    ShowErr_Form d_ErrForm = new ShowErr_Form("报告暂存成功", "提示");
                    d_ErrForm.ShowDialog();

                }
                else
                {
                    ShowErr_Form d_ErrForm = new ShowErr_Form("报告暂存失败", "提示");
                    d_ErrForm.ShowDialog();

                }
            }
        }

        private bool BeforeSave(string p_status, bool p_tempflag)
        {
            try
            {
                patexam_Class p_patexam = new patexam_Class(CurReportForm.CurPatexam.accessno);
                string showstr = "";

                if (p_patexam.check_status == "已审核")
                {
                    if (CurReportForm.CurPatexam.check_status != "已审核")
                    {
                        if (p_status == "保存")
                        {
                            showstr = "该报告已审核无法再保存，请退出报告界面或者重新审核";
                            showstr += "\r\n" + "审核医生：" + p_patexam.advancedoc + "审核时间：" + p_patexam.advancedate.ToString();

                        }
                        else
                        {
                            showstr = "该报告已审核,是否继续审核";
                            showstr += "\r\n" + "审核医生：" + p_patexam.advancedoc + "审核时间：" + p_patexam.advancedate.ToString();
                            ShowErr_Form d_form = new ShowErr_Form(showstr, "是", "否");
                            if (d_form.ShowDialog() == DialogResult.OK)
                            {
                                showstr = "";
                            }
                            else
                                return false;
                        }
                    }
                }
                else if (p_patexam.check_status == "未审核")
                {

                    if ((p_patexam.reportdoc != "") && (p_patexam.reportdoc != Share_Class.User.user_id) && (p_status == "保存"))
                    {
                        showstr = "该报告已保存无法再保存，请退出报告界面或者重新审核";
                        showstr += "\r\n" + "报告医生：" + p_patexam.reportdoc + "报告时间：" + p_patexam.reportdate.ToString();
                    }
                }


                if (showstr != "")
                {
                    ShowErr_Form d_form = new ShowErr_Form(showstr, "错误");
                    d_form.ShowDialog();
                    return false;
                }
                if (p_tempflag == true)
                {
                    if (p_status == "保存")
                    {

                        if (Share_Class.User.HaveFunction("b") == false)
                        {
                            ShowErr_Form d_form = new ShowErr_Form("用户无此操作权限", "错误");
                            d_form.ShowDialog();
                            return false;
                        }
                    }
                    else
                    {
                        if (Share_Class.User.HaveFunction("c") == false)
                        {
                            ShowErr_Form d_form = new ShowErr_Form("用户无此操作权限", "错误");
                            d_form.ShowDialog();
                            return false;
                        }
                    }
                }

                if (CurShowApplyImage_Form != null)
                {
                    CurShowApplyImage_Form.Close();
                }

                string d_template_diag = "";
                string d_template_describle = "";
                patexam_Class d_patexam = new patexam_Class();
                CurReportForm.getTemplateContent(ref d_template_diag, ref d_template_describle, ref d_patexam);

                string d_reportdisease = "";// this.ICD_10_ComboBoxEdit.Text.Trim();
                if (d_reportdisease == "")
                {
                    for (int i = 0; i < reportdisease_CheckedListBoxControl.Items.Count; i++)
                    {
                        if (reportdisease_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
                            d_reportdisease += reportdisease_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
                    }
                    if (d_reportdisease != "")
                        d_reportdisease = d_reportdisease.TrimEnd(new char[] { ',' });
                }

                d_patexam.reportdisease = d_reportdisease;
                string d_disease = diseasetype_ComboBoxEdit.Text.Trim();
                if (d_disease == "")
                {
                    for (int i = 0; i < diseasetype_CheckedListBoxControl.Items.Count; i++)
                    {
                        if (diseasetype_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
                            d_disease += diseasetype_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
                    }
                    if (d_disease != "")
                        d_disease = d_disease.TrimEnd(new char[] { ',' });
                }
                d_patexam.diseasetype = d_disease;
                if (p_tempflag == true)
                {
                    if ((d_patexam.reportdisease != "临时报告") && (d_patexam.diseasetype == ""))
                    {
                        ShowErr_Form d_form = new ShowErr_Form("结果归类未选", "错误");
                        d_form.ShowDialog();
                        return false;
                    }
                    else
                    {
                        string d_values = RisSetup_Class.GetINI_Oracle(CurReportForm.CurPatexam.dep, "diseasetype_show");
                        if (d_values == "yes")
                        {
                            ShowErr_Form d_form = new ShowErr_Form("报告的结果归类为" + d_patexam.diseasetype + ",是否继续?", "是", "否");
                            if ((d_form.ShowDialog() != System.Windows.Forms.DialogResult.OK))
                            {
                                this.Right_XtraTabControl.SelectedTabPageIndex = 0;
                                return false;

                            }
                        }
                        else if (d_values == "")
                        {
                            RisSetup_Class.WriteINI_Oracle(CurReportForm.CurPatexam.dep, "diseasetype_show", "no");
                        }
                    }
                }
                //  FillClassByInputXML();
                if (d_template_diag == "")
                {
                    ShowErr_Form d_form = new ShowErr_Form("诊断描述未填", "错误");
                    d_form.ShowDialog();
                    return false;
                }
                //else if (d_template_diag.Length > 2000)
                //{              
                //    ShowErr_Form d_form = new ShowErr_Form("诊断描述字符长度过长", "错误");
                //    d_form.ShowDialog();
                //    return false;
                //}
                if (d_template_describle == "")
                {
                    ShowErr_Form d_form = new ShowErr_Form("诊断结果未填", "错误");
                    d_form.ShowDialog();
                    return false;
                }
                //else if (d_template_describle.Length > 2000)
                //{
                //    Public_Class.ShowErr_Form("诊断结果字符长度过长", "错误");
                //    return false;
                //}
                else if ((p_tempflag == true) && (d_template_describle.IndexOf("左") > -1) && (d_template_describle.IndexOf("右") > -1))
                {
                    ShowErr_Form d_form = new ShowErr_Form("报告中含有左右描述，请确认是否正确?", "是", "否");
                    if (d_form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return false;
                    }
                }
                if (p_tempflag == true)
                {
                    ValueValidateResultList list = (ValueValidateResultList)CurReportForm.ReturnExecuteCommand("DocumentValueValidate", false, null);
                    if (list != null && list.Count > 0)
                    {                    // 校验不成功
                        StringBuilder str = new StringBuilder();
                        foreach (ValueValidateResult item in list)
                        {
                            if (str.Length > 0)
                            {
                                str.Append(Environment.NewLine);
                            }
                            str.Append(item.Element.ID + ":" + item.Message);
                        }
                        ShowErr_Form d_form = new ShowErr_Form(str.ToString() + "是否继续?", "是", "否");
                        if (d_form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            return false;
                        }
                    }
                }


                CurReportForm.CurPatexam.diseasetype = d_disease;
                CurReportForm.CurPatexam.reportdisease = d_reportdisease;

                ////DataSet ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM("XRAY", "", CurReportForm.CurPatregister.Sex + "性错误纠正", "");
                ////if (ds != null)
                ////{
                ////    if (ds.Tables.Count > 0)
                ////    {
                ////        if (ds.Tables[0].Rows.Count > 0)
                ////        {
                ////            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                ////            {
                ////                string d_item = ds.Tables[0].Rows[i]["item"].ToString().Trim();
                ////                if (d_template_describle.IndexOf(d_item) > -1)
                ////                {
                ////                    if (Public_Class.ShowErr_Form("该患者性别为" + CurReportForm.CurPatregister.Sex + "性，报告描述中存在" + d_item + "描述，请确认是否正确?", "是", "否") != System.Windows.Forms.DialogResult.OK)
                ////                    {
                ////                        return false;
                ////                    }
                ////                }
                ////                else if (d_template_diag.IndexOf(d_item) > -1)
                ////                {

                ////                    if (Public_Class.ShowErr_Form("该患者性别为" + CurReportForm.CurPatregister.Sex + "性，诊断提示中存在" + d_item + "诊断，请确认是否正确?", "是", "否") != System.Windows.Forms.DialogResult.OK)
                ////                    {
                ////                        return false;
                ////                    }
                ////                }
                ////            }
                ////        }
                ////    }
                ////}
            }

            catch
            {
                return false;
            }

            return true;

        }
        private bool AfterSave(string p_status)
        {
            try
            {
                // ''危急值判定
                //flog_Class.WriteFlog("危急值判定：" + Convert.ToString(Share_Class.GetTickCount() - CurTickCount))
                UpdatePic();

                Setup_Dict.danger_patient_info_class.judgeDanger(CurReportForm.CurPatexam.accessno, Share_Class.User.user_des);

                if (CurReportForm.CurPatexam.reportdisease.IndexOf("会诊") > -1)
                {
                    string _hospital_code = "";
                    string _hospital_name = "";

                    _hospital_code = Share_Class.hospital_code;
                    _hospital_name = Share_Class.hospital_name;

                    if (_hospital_code == "")
                        _hospital_code = RisSetup_Class.GetINI("setup", "hospital_code");

                    if (_hospital_name == "")
                        _hospital_name = RisSetup_Class.GetINI("setup", "hospital_name");

                    if (_hospital_code == "")
                    {
                        ShowErr_Form d_form = new ShowErr_Form("医疗机构代码未设置", "警告");
                        d_form.ShowDialog();
                        return false;
                    }
                    if (_hospital_name == "")
                    {
                        ShowErr_Form d_form = new ShowErr_Form("医疗机构名称未设置", "警告");
                        d_form.ShowDialog();
                        return false;
                    }
                    Setup_Dict.transfer_operate d_form1 = new Setup_Dict.transfer_operate(Share_Class.User.user_id, Share_Class.User.userflag, _hospital_name, _hospital_code, CurReportForm.CurPatexam.accessno);
                    d_form1.ShowDialog();
                }

                // patregister_Class.UpdateROUTE_STATUS(CurReportForm.CurPatexam.accessno);


                //'Share_Forms_Class.PatexamListViewForm.SetListViewRowBypatexam(CurReportForm.CurPatexam, New patregister_Class(CurReportForm.CurPatexam.patid))


                string d_GetValue = "";// '从配置文件取得的内容
                string d_value = "";
                //'审核成功后是否关闭报告窗口
                if (p_status == "保存")
                {
                    d_value = RisSetup_Class.GetINI_Oracle(CurReportForm.CurPatexam.dep, "save_show");
                    if (d_value == "yes")
                    {
                        ShowErr_Form d_from = new ShowErr_Form("报告信息" + p_status + "成功。", "提示");
                        d_from.ShowDialog();
                    }
                    else if (d_value == "")
                        RisSetup_Class.WriteINI_Oracle(CurReportForm.CurPatexam.dep, "save_show", "yes");
                    d_GetValue = RisSetup_Class.GetINI("setup", "save_Whether");
                }
                else
                {
                    d_value = RisSetup_Class.GetINI_Oracle(CurReportForm.CurPatexam.dep, "advance_show");
                    if (d_value == "")
                    {
                        RisSetup_Class.WriteINI_Oracle(CurReportForm.CurPatexam.dep, "advance_show", "yes");
                        d_value = "yes";
                    }

                    ShowErr_Form d_from = new ShowErr_Form("报告信息" + p_status + "成功,是否立即打印?", "是", "否");
                    if ((d_value == "print") || ((d_value == "yes") && (d_from.ShowDialog() == DialogResult.OK)))
                    {//'弹出提示是否更新数据库中病人基本信息

                        Print_SimpleButton_Click(null, null);

                    }



                    d_GetValue = RisSetup_Class.GetINI("setup", "advance_Whether");
                }
                if (d_GetValue == "yes")
                {
                    Close_SimpleButton_Click(null, null);
                }
                initPermission();

            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Minimized_SimpleButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 年龄修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Age_TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Age_TextEdit.Text.Trim().Length < 1)
                return;
            try
            {
                if (Age_TextEdit.Text.Trim().Substring(0, 1) == "-")
                {
                    Age_TextEdit.Text = Age_TextEdit.Text.Substring(1);
                }
                string d_char = Age_TextEdit.Text.Substring(Age_TextEdit.Text.Trim().Length - 1).ToLower();
                DateTime d_date = patregister_Class.GetBirthDayByAge(Age_TextEdit.Text.Trim());
                string d_age = patregister_Class.GetByAgeBirthDay(BirthDay_DateEdit.DateTime);
                if (d_date.Year != 1900)
                {
                    if (d_age != Age_TextEdit.Text.Trim())
                        BirthDay_DateEdit.DateTime = d_date;
                }
            }
            catch { }
        }
        /// <summary>
        /// 出生日期修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthDay_DateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (BirthDay_DateEdit.DateTime.Year != 1900)
            {
                string d_age = patregister_Class.GetByAgeBirthDay(BirthDay_DateEdit.DateTime);
                if (d_age != Age_TextEdit.Text.Trim())
                {
                    Age_TextEdit.Text = d_age;
                }
            }
        }

        private void FillInputByClass()
        {
            Filldengjipart(CurReportForm.CurPatexam.modality.Trim());
            accessno_textEdit.Text = CurReportForm.CurPatexam.accessno.Trim();
            Name_TextEdit.Text = CurReportForm.CurPatregister.Name.Trim();
            this.Patient_id_ButtonEdit.Text = CurReportForm.CurPatexam.Patient_id.Trim();
            sex_ComboBoxEdit.Text = CurReportForm.CurPatregister.Sex.Trim();
            Age_TextEdit.Text = CurReportForm.CurPatregister.Age.Trim();
            BirthDay_DateEdit.DateTime = CurReportForm.CurPatregister.BirthDay;
            telephone_TextEdit.Text = CurReportForm.CurPatregister.Telephone.Trim();
            pat_type_ComboBoxEdit.Text = CurReportForm.CurPatexam.Pat_type.Trim();
            Inpatient_id_textEdit.Text = CurReportForm.CurPatregister.INPatient_id.Trim();
            //CurApplyNo = CurPatregister.Ticket_ID;
            //CurID_Card = CurPatregister.ID_Card;
            //CurMagcard_ID = CurPatregister.Magcard_ID;

            Report_XtraTabControl.Text = CurReportForm.CurPatexam.Patient_id.Trim();
            radio_doctor_ComboBoxEdit.Text = CurReportForm.CurPatexam.radio_doctor;
            checktype_ComboBoxEdit.Text = CurReportForm.CurPatexam.checktype;
            othercheck_ComboBoxEdit.Text = CurReportForm.CurPatexam.othercheck;
            wardno_ComboBoxEdit.Text = CurReportForm.CurPatexam.wardno.Trim();
            doctor_ComboBoxEdit.Text = CurReportForm.CurPatexam.Doctor.Trim();
            modality_ComboBoxEdit.Text = CurReportForm.CurPatexam.modality.Trim();
            sqdep_ComboBoxEdit.Text = CurReportForm.CurPatexam.sqdep.Trim();
            clinicend_MemoEdit.Text = CurReportForm.CurPatexam.clinicend.Trim();
            //xno_TextEdit.Text = CurReportForm.CurPatexam.xno.ToString().Trim();
            Xno_TextEdit.Text = CurReportForm.CurPatexam.xno.ToString().Trim();
            bedno_TextEdit.Text = CurReportForm.CurPatexam.BedNo.Trim();
            clinicend_MemoEdit.Text = CurReportForm.CurPatexam.clinicend;
            clinicinfo_MemoEdit.Text = CurReportForm.CurPatexam.clinicinfo;
            Price_TextEdit.Text = CurReportForm.CurPatexam.Price.ToString().Trim();
            modality_ComboBoxEdit.Text = CurReportForm.CurPatexam.modality.Trim();
            machinetype_ComboBoxEdit.Text = CurReportForm.CurPatexam.machinetype;
            diseasetype_ComboBoxEdit.Text = CurReportForm.CurPatexam.diseasetype;
            HISPos_MemoEdit.Text = CurReportForm.CurPatexam.hischeckpos;
            if (CurReportForm.CurPatexam.reportdisease.Trim() != "")
            {
                string[] d_str;
                d_str = CurReportForm.CurPatexam.reportdisease.Split(new char[] { '、' });

                for (int j = 0; j < d_str.Length; j++)
                {
                    for (int i = 0; i < reportdisease_CheckedListBoxControl.Items.Count; i++)
                    {
                        if (("," + d_str[j] + ",").IndexOf("," + reportdisease_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
                        {
                            reportdisease_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;
                        }
                    }
                }
            }
            if (CurReportForm.CurPatexam.diseasetype.Trim() != "")
            {
                for (int i = 0; i < diseasetype_CheckedListBoxControl.Items.Count; i++)
                {
                    if (("," + CurReportForm.CurPatexam.diseasetype + ",").IndexOf("," + diseasetype_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
                    {
                        diseasetype_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;
                    }
                }
                //'如果数据字典中没有该结果归类自动加上   ---YDY
                if ((diseasetype_CheckedListBoxControl.CheckedItems.Count == 0) && (CurReportForm.CurPatexam.diseasetype != ""))
                    diseasetype_CheckedListBoxControl.Items.Add(CurReportForm.CurPatexam.diseasetype, CheckState.Checked);
            }
            //'部位设置
            TreeListNode d_node, d_smallNode;
            try
            {
                string d_nodetext, d_smallnodeText;// '部位内容
                for (int i = 0; i < dengjipart_TreeList.Nodes.Count; i++)
                {
                    // '设置部位是不是选中
                    d_node = dengjipart_TreeList.Nodes[i];
                    d_nodetext = d_node.GetValue("pos").ToString().Trim();
                    if (("," + CurReportForm.CurPatexam.dengjipart + ",").IndexOf("," + d_nodetext + ",") >= 0)
                    {// '如果当前的部位是已经存在于部位属性中,那么选中,因为可以某个部位字符是另一个部位的一部分,所以二边加上","
                        d_node.SetValue("Check", CheckState.Checked);
                    }
                    //  '设置小部位是不是选中
                    for (int j = 0; i < d_node.Nodes.Count; j++)
                    {
                        d_smallNode = d_node.Nodes[j];
                        d_smallnodeText = d_smallNode.GetValue("pos").ToString().Trim();
                        if (("," + CurReportForm.CurPatexam.checkpos + ",").IndexOf("," + d_smallnodeText + ",") >= 0)
                        {// '如果当前的小部位是已经存在于小部位属性中,那么选中,因为可以某个小部位字符是另一个部位的一部分,所以二边加上","
                            d_smallNode.SetValue("Check", CheckState.Checked);
                        }
                    }
                }
            }
            catch { }





            if (CurReportForm.CurPatexam.reportdisease.Trim() == "")
            {// '如果报告医生为空,表示是第一次报告编辑,把当前用户设置成报告医生

            }
            else
            {
                string[] d_str;
                d_str = CurReportForm.CurPatexam.reportdisease.Split(new char[] { '、' });

                for (int j = 0; j < d_str.Length; j++)
                {
                    for (int i = 0; i < reportdisease_CheckedListBoxControl.Items.Count; i++)
                    {
                        if (("," + d_str[j] + ",").IndexOf("," + reportdisease_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
                        {
                            reportdisease_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;
                        }
                    }
                }
            }


        }
        private void Modify_SimpleButton_Click(object sender, EventArgs e)
        {
            if (Newpatexam_SimpleButton.Text == "取消")
            {
                //撤销
                Newpatexam_SimpleButton.Text = "新建";
                Modify_SimpleButton.Text = "修改";
                Patient_id_ButtonEdit.Enabled = false;
                FillInputByClass();
            }
            else
            {
                //Newpatexam_SimpleButton.Enabled = false;
                PatientInfo_Init();
                Patient_id_ButtonEdit.Enabled = true;
                Patient_id_ButtonEdit.Text = "";
                Newpatexam_SimpleButton.Text = "取消";
                Modify_SimpleButton.Text = "保存";
            }
        }
        private void PatientInfo_Init()
        {
            Report_XtraTabControl.Text = "";
            Name_TextEdit.Text = "";
            sex_ComboBoxEdit.Text = "";
            Age_TextEdit.Text = "";
            BirthDay_DateEdit.DateTime = Convert.ToDateTime("1900-1-1");
            telephone_TextEdit.Text = "";
            Price_TextEdit.Text = "0";

            Xno_TextEdit.Text = "";
            clinicend_MemoEdit.Text = "待查";
            Patient_id_ButtonEdit.Text = "";
            sqdep_ComboBoxEdit.Text = "";
            doctor_ComboBoxEdit.Text = "";
            wardno_ComboBoxEdit.Text = "";
            bedno_TextEdit.Text = "";

            telephone_TextEdit.Text = "";
            radio_doctor_ComboBoxEdit.Text = "";
            clinicinfo_MemoEdit.Text = "";
            HISPos_MemoEdit.Text = "";
            accessno_textEdit.Text = "";
            //CurApplyNo = "";
            //CurMagcard_ID = "";
            Inpatient_id_textEdit.Text = "";
            othercheck_ComboBoxEdit.Text = "";
            diseasetype_ComboBoxEdit.Text = "";
            Filldengjipart(modality_ComboBoxEdit.Text.Trim());
            //Report_XtraTabControl.Text = Format(Now, "yyyyMMddHHmmss") + RisSetup_Class.GetINI("setup", "machineno").Trim
        }
        private void Filldengjipart(string modality)
        {
            string TableName, Field_Search_Flag, Field_Search_Top, Field_Search_0, Field_Search_1, Field_Search_Botten, Field_Search_ENTop, Field_Search_ENCTop;
            Field_Search_0 = "";
            Field_Search_1 = "";
            string CommString = "";
            int Mulits = 0;
            string CurrentDataSetString, CurrentENDataSetString, CurrentENCDataSetString;
            TreeListNode Current_Node;
            DataSet TreeListSet;
            Field_Search_Top = "dengjipart";
            Field_Search_Botten = "childpart";
            Field_Search_ENTop = "part_english";
            Field_Search_ENCTop = "childpart_english";
            Field_Search_Flag = "search_id";
            TableName = "registerpart";
            Current_Node = null; //'根节点

            CommString = " Select distinct ";
            if (Field_Search_Top != "")
            {
                CommString += Field_Search_Top + ",";
                Mulits += 1;
            }
            if (Field_Search_ENTop != "")
            {
                CommString += Field_Search_ENTop + ",";
                Mulits += 1;
            }
            if (Field_Search_ENCTop != "")
            {
                CommString += Field_Search_ENCTop + ",";
                Mulits += 1;
            }
            if (Field_Search_Botten != "")
            {
                CommString += Field_Search_Botten + ",";
                Mulits += 1;
            }
            if (Field_Search_Flag != "")
            {
                CommString += Field_Search_Flag + ",";
            }
            CommString += " id From " + TableName;
            CommString += " where modality= '" + modality.Trim() + "'";

            if (Field_Search_Flag != "")
            {
                CommString += " ORDER BY " + Field_Search_Flag;
            }
            if (Field_Search_Top == "")
            {
                if (Field_Search_0 == "")
                {
                    if (Field_Search_1 == "")
                    {
                        if (Field_Search_Botten == "")
                        {
                            return;
                        }
                    }
                }
            }
            if (TableName == "")
            {
                return;
            }
            TreeListSet = null;
            TreeListSet = RISOracle_Class.GetDS(CommString, "查询" + TableName + "表出错" + "\r\n" + CommString);
            dengjipart_TreeList.Nodes.Clear();
            if (TreeListSet != null)
            {
                if (TreeListSet.Tables[0].Rows.Count > 0)
                {
                    int Row = 0;
                    int RowCount = TreeListSet.Tables[0].Rows.Count;
                    for (Row = 0; Row < RowCount; Row++)
                    {
                        if (Field_Search_Top != "")
                        {
                            CurrentDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_Top].ToString().Trim();
                            CurrentENDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_ENTop].ToString().Trim();

                            if (dengjipart_TreeList.Nodes.Count == 0)
                            {
                                Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                Current_Node.Tag = CurrentENDataSetString;
                            }
                            else
                            {
                                int i = 0;
                                for (i = 0; i < dengjipart_TreeList.Nodes.Count; i++)
                                {

                                    if (dengjipart_TreeList.Nodes[i].Tag.ToString() == CurrentENDataSetString)
                                    {
                                        Current_Node = dengjipart_TreeList.Nodes[i];
                                        break;
                                    }
                                }
                                if (i == dengjipart_TreeList.Nodes.Count)
                                {
                                    Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                    Current_Node.Tag = CurrentENDataSetString;
                                }
                            }

                        }
                        if (Field_Search_0 != "")
                        {
                            CurrentDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_0].ToString();
                            if (Current_Node.Nodes.Count == 0)
                            {
                                Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                Current_Node.Tag = CurrentDataSetString;
                            }
                            else
                            {
                                int i = 0;
                                for (i = 0; i < Current_Node.Nodes.Count; i++)
                                {

                                    if (Current_Node.Nodes[i].Tag.ToString() == CurrentDataSetString)
                                    {
                                        Current_Node = Current_Node.Nodes[i];
                                        break;
                                    }
                                }
                                if (i == Current_Node.Nodes.Count)
                                {
                                    Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                    Current_Node.Tag = CurrentDataSetString;
                                }
                            }
                        }
                        if (Field_Search_1 != "")
                        {
                            CurrentDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_1].ToString().Trim();
                            if (Current_Node.Nodes.Count == 0)
                            {
                                Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                Current_Node.Tag = CurrentDataSetString;
                            }
                            else
                            {
                                int i = 0;
                                for (i = 0; i < Current_Node.Nodes.Count; i++)
                                {

                                    if (Current_Node.Nodes[i].Tag.ToString() == CurrentDataSetString)
                                    {
                                        Current_Node = Current_Node.Nodes[i];
                                        break;
                                    }
                                }
                                if (i == Current_Node.Nodes.Count)
                                {
                                    Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                    Current_Node.Tag = CurrentDataSetString;
                                }
                            }
                        }
                        if (Field_Search_Botten != "")
                        {
                            CurrentDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_Botten].ToString().Trim();
                            CurrentENCDataSetString = TreeListSet.Tables[0].Rows[Row][Field_Search_ENCTop].ToString().Trim();
                            if (CurrentDataSetString == "")
                            {
                            }
                            else
                            {
                                if (Current_Node.Nodes.Count == 0)
                                {
                                    Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                    Current_Node.Tag = CurrentENCDataSetString;
                                }
                                else
                                {
                                    int i = 0;
                                    for (i = 0; i < Current_Node.Nodes.Count; i++)
                                    {

                                        if (Current_Node.Nodes[i].Tag.ToString() == CurrentDataSetString)
                                        {
                                            Current_Node = Current_Node.Nodes[i];
                                            break;
                                        }
                                    }
                                    if (i == Current_Node.Nodes.Count)
                                    {
                                        Current_Node = dengjipart_TreeList.AppendNode(new Object[] { CurrentDataSetString, CheckState.Unchecked }, Current_Node);
                                        Current_Node.Tag = CurrentENCDataSetString;
                                    }

                                }
                            }

                        }
                        Current_Node = null;
                    }
                }
            }
        }
        //   '得到状态图
        private void dengjipart_TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {

            try
            {
                CheckState check = (CheckState)e.Node.GetValue("Check");
                if (check == CheckState.Unchecked)
                    e.NodeImageIndex = 0;
                else if (check == CheckState.Checked)
                    e.NodeImageIndex = 1;
                else
                    e.NodeImageIndex = 2;
            }
            catch { }

        }


        private void Newpatexam_SimpleButton_Click(object sender, EventArgs e)
        {
            if (clinicend_MemoEdit.Text.Length > 50)
            {
                ShowErr_Form d_form = new ShowErr_Form("临床诊断输入框字数太多，请重新确认", "错误");
                d_form.ShowDialog();
                return;
            }
            else
                clinicend_MemoEdit.Text = Set_Special_Charcter(clinicend_MemoEdit.Text);


            if (sqdep_ComboBoxEdit.Text.Length > 14)
            {
                ShowErr_Form d_form = new ShowErr_Form("申请科室输入框字数太多，请重新确认", "错误");
                d_form.ShowDialog();
                return;
            }
            else

                sqdep_ComboBoxEdit.Text = Set_Special_Charcter(sqdep_ComboBoxEdit.Text);


            if (wardno_ComboBoxEdit.Text.Length > 14)
            {
                ShowErr_Form d_form = new ShowErr_Form("病区输入框字数太多，请重新确认", "错误");
                d_form.ShowDialog();
                return;
            }
            else
                wardno_ComboBoxEdit.Text = Set_Special_Charcter(wardno_ComboBoxEdit.Text);


            if (bedno_TextEdit.Text.Length > 9)
            {
                ShowErr_Form d_form = new ShowErr_Form("床号输入框字数太多，请重新确认", "错误");
                d_form.ShowDialog();
                return;
            }
            else
                bedno_TextEdit.Text = Set_Special_Charcter(bedno_TextEdit.Text);


            if (telephone_TextEdit.Text.Length > 46)
            {
                ShowErr_Form d_form = new ShowErr_Form("联系电话输入框字数太多，请重新确认", "错误");
                d_form.ShowDialog();
                return;
            }
            else
                telephone_TextEdit.Text = Set_Special_Charcter(telephone_TextEdit.Text);


            //if (Modify_SimpleButton.Text == "修改")
            //{
            //    patexam_Class d_patexam = new patexam_Class(CurPatexam.accessno);
            //    patregister_Class d_patregister = new patregister_Class(CurPatregister.clinicno);
            //    FillClassByInput(ref d_patexam, ref d_patregister);
            //    if (d_patregister.Update() == false)
            //    {
            //        ShowErr_Form d_form = new ShowErr_Form("patregister修改失败", "错误");
            //        d_form.ShowDialog();
            //        return;
            //    }
            //    else
            //    {
            //        if (d_patexam.UpdateRegister() == false)
            //        {
            //            ShowErr_Form d_form = new ShowErr_Form("patexam修改失败", "错误");
            //            d_form.ShowDialog();
            //            return;
            //        }
            //        else
            //        {
            //            ShowErr_Form d_form = new ShowErr_Form("修改成功", "提示");
            //            d_form.ShowDialog();
            //        }
            //    }
            //}
            //else
            //{
            //    patexam_Class d_patexam = new patexam_Class();
            //    patregister_Class d_patregister = new patregister_Class();
            //    FillClassByInput(ref d_patexam, ref d_patregister);
            //    if (d_patregister.Insert() == false)
            //    {
            //        Public_Class.ShowErr_Form("patregister保存失败", "错误");
            //        ShowErr_Form d_form = new ShowErr_Form("patregister保存失败", "错误");
            //        d_form.ShowDialog();
            //        return;
            //    }
            //    else
            //    {
            //        d_patexam.accessno = d_patregister.clinicno;
            //        d_patexam.patid = d_patregister.clinicno;
            //        if (d_patexam.AddRegister("0", "") == false)
            //        {
            //            ShowErr_Form d_form = new ShowErr_Form("patexam保存失败", "错误");
            //            d_form.ShowDialog();
            //            return;
            //        }
            //        else
            //        {
            //            ShowErr_Form d_form = new ShowErr_Form("保存成功", "提示");
            //            d_form.ShowDialog();
            //            turnperson(d_patexam.patid);
            //        }
            //    }
            //}
        }
        private string Set_Special_Charcter(string p_Text)
        {//  '对单引号的处理
            if (p_Text != "")
            {
                return p_Text.Replace("'", "");
            }
            return "";
        }
        #endregion

        private void Patient_id_ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        //纠错
        private void SimpleButton9_Click(object sender, EventArgs e)
        {

            Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", CurReportForm.CurPatregister.Sex + "性错误纠正");
            d_form.ShowDialog();
            CurReportForm.SetExcludeKeywords();
        }
        //危急值
        private void SimpleButton5_Click(object sender, EventArgs e)
        {
            Setup_Dict.setup_dic_dmb_Form fm = new Setup_Dict.setup_dic_dmb_Form(Share_Class.User.userflag, "", "危机值", "影像楼");
            fm.ShowDialog();
        }

        private void GetPic_Timer_Tick(object sender, EventArgs e)
        {
            if ((image_ComboBoxEdit.Text == "图文报告") || (image_ComboBoxEdit.Text == "图像报告"))
            {
                string d_Path = PicPath;// Share_Class.Dir + "PIC" + "\\" + CurReportForm.CurPatexam.accessno.Trim();// '图片要保存的文件夹路径
                Share_Class.CreatePath(d_Path);


                if (Clipboard.GetDataObject().GetFormats(false).Length <= 0)
                    return;

                Image a = (Image)Clipboard.GetData(DataFormats.Bitmap);
                if (a == null)
                    return;


                Bitmap Bmp;
                Graphics g;
                Rectangle FromRectangle;
                Rectangle ToRectangle;

                int d_Width, d_Hight;
                d_Width = a.Width;
                d_Hight = a.Height;

                FromRectangle = new Rectangle(0, 0, d_Width, d_Hight);
                Bmp = new Bitmap(d_Width, d_Hight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                g = Graphics.FromImage(Bmp);
                ToRectangle = new Rectangle(0, 0, d_Width, d_Hight);
                g.DrawImage(a, ToRectangle, FromRectangle, GraphicsUnit.Pixel);
                if (Bmp == null)
                    return;

                this.BackgroundImage = Bmp;
                string m = Share_Class.GetSysdate().ToString("yyyyMMHHddmmss");
                BackgroundImage.Save(d_Path + "\\" + m.ToString().Trim() + ".jpg");
                Clipboard.Clear();// '清除剪贴板内容   

                GetPic();
            }

        }


        #region 归类
        private void Filldiseasetype()
        {
            DataSet ds = setup_noSort_Dmb_Class.GetAll("reportdisease_Dmb");
            reportdisease_CheckedListBoxControl.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                reportdisease_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["reportdisease"].ToString(), CheckState.Unchecked);
            }

            // '结果归类列表框填充
            ds = setup_noSort_Dmb_Class.GetAll("diseasetype");

            //   '填充数据库中调出的项
            diseasetype_CheckedListBoxControl.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                diseasetype_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["diseasetype"].ToString(), CheckState.Unchecked);
            }
        }
        #endregion

        #region 质控

        //private void QcInit()
        //{
        //    try
        //    {
        //        string is_qc = "";
        //        is_qc = Public_Class.GetINI("setup", "IMAGE_QC");
        //        if (is_qc == "yes")
        //            CheckEdit1.Checked = true;
        //        else
        //            CheckEdit1.Checked = false;


        //        is_qc = Public_Class.GetINI("setup", "REPORT_QC");
        //        if (is_qc == "yes")
        //            CheckEdit2.Checked = true;
        //        else
        //            CheckEdit2.Checked = false;


        //        DataSet ds = new DataSet();

        //        Qc_CheckedListBox.Properties.Items.Clear();
        //        ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM("XRAY", "", "照片质量", "");
        //        d_listQC.Clear();
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            Dictionary<int, string> values = new Dictionary<int, string>();
        //            values.Add(1, ds.Tables[0].Rows[i]["item"].ToString());
        //            values.Add(2, ds.Tables[0].Rows[i]["item_value"].ToString());
        //            d_listQC.Add(values);
        //            DevExpress.XtraEditors.Controls.RadioGroupItem d_radio = new DevExpress.XtraEditors.Controls.RadioGroupItem(ds.Tables[0].Rows[i]["item"].ToString(), ds.Tables[0].Rows[i]["item"].ToString());
        //            Qc_CheckedListBox.Properties.Items.Add(d_radio);
        //        }

        //        report_RadioGroup.Properties.Items.Clear();
        //        ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM("XRAY", "", "报告质量", "");
        //        d_listreport.Clear();
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            Dictionary<int, string> values = new Dictionary<int, string>();
        //            values.Add(1, ds.Tables[0].Rows[i]["item"].ToString());
        //            values.Add(2, ds.Tables[0].Rows[i]["item_value"].ToString());
        //            d_listreport.Add(values);
        //            DevExpress.XtraEditors.Controls.RadioGroupItem d_radio = new DevExpress.XtraEditors.Controls.RadioGroupItem(ds.Tables[0].Rows[i]["item"].ToString(), ds.Tables[0].Rows[i]["item"].ToString());
        //            report_RadioGroup.Properties.Items.Add(d_radio);
        //        }
        //    }
        //    catch { }
        //    InitCheckedListBoxControl();
        //    ShowQc_radiology();
        //    ShowQc_Report();
        //}
        //#region 保存评片结果

        //private bool SaveQc_radiology(string p_check_status)
        //{

        //    if (Qc_CheckedListBox.SelectedIndex >= 0)
        //    {
        //        p_Qcradiology.radiology_general = Qc_CheckedListBox.Properties.Items[Qc_CheckedListBox.SelectedIndex].Description.ToString();
        //        p_Qcradiology.radiology_quality_result = p_Qcradiology.radiology_general;
        //        p_Qcradiology.radiology_quality_remark = Qc_ComboBoxEdit.Text.Trim();

        //        FillradiologyClassByInput();
        //        if (p_Qcradiology.ID == 0)
        //            p_Qcradiology.Insert();
        //        else
        //            p_Qcradiology.Update();

        //        string d_check_status = p_check_status;

        //        p_Qcradiology.InsertLOG(CurPatexam.reportdoc, CurPatexam.advancedoc, d_check_status, CurPatexam.reportinfo, CurPatexam.reportend, CurPatexam.diseasetype);

        //    }
        //    else
        //    {
        //        string is_qc = Public_Class.GetINI("setup", "IMAGE_QC");
        //        if (is_qc == "yes")
        //        {
        //            Public_Class.ShowErr_Form("请先评定照片质量", "提示");
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //#endregion

        //#region 保存报告质控

        //private bool SaveReport_radiology(string p_check_status)
        //{


        //    if (report_RadioGroup.SelectedIndex >= 0)
        //    {
        //        FilldiagnosisClassByInput();
        //        if (p_QCDIAGNOSIS.ID == 0)
        //        {
        //            p_QCDIAGNOSIS.Insert();
        //        }
        //        else
        //        {
        //            p_QCDIAGNOSIS.Update();
        //        }

        //        string d_check_status = p_check_status;

        //        p_QCDIAGNOSIS.InsertLog(CurPatexam.reportdoc, CurPatexam.advancedoc, d_check_status, CurPatexam.reportinfo, CurPatexam.reportend, CurPatexam.diseasetype);

        //    }
        //    else
        //    {
        //        string is_qc = "";
        //        is_qc = Public_Class.GetINI("setup", "REPORT_QC");
        //        if (is_qc == "yes")
        //        {
        //            Public_Class.ShowErr_Form("请先评定报告质量", "提示");

        //            return false;
        //        }
        //    }


        //    return true;
        //}

        //#endregion

        //#region 显示评片结果
        //private void InitCheckedListBoxControl()
        //{
        //    DataSet ds = new DataSet();

        //    ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM("XRAY", "", "报告质控结果", "");
        //    report_CheckedListBoxControl.Items.Clear();
        //    report_ComboBoxEdit.Properties.Items.Clear();
        //    d_reportremark.Clear();
        //    if (ds != null)
        //    {
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                report_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["item"].ToString());
        //                report_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["item"].ToString(), CheckState.Unchecked);
        //                d_reportremark.Add(ds.Tables[0].Rows[i]["item"].ToString(), ds.Tables[0].Rows[i]["item_value"].ToString());
        //            }
        //        }
        //    }

        //    ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM("XRAY", "", "照片质控结果", "");
        //    Qc_CheckedListBoxControl.Items.Clear();
        //    Qc_ComboBoxEdit.Properties.Items.Clear();
        //    d_qcremark.Clear();
        //    if (ds != null)
        //    {
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                Qc_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["item"].ToString(), CheckState.Unchecked);
        //                Qc_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["item"].ToString());

        //                d_qcremark.Add(ds.Tables[0].Rows[i]["item"].ToString(), ds.Tables[0].Rows[i]["item_value"].ToString());
        //            }
        //        }
        //    }

        //}
        //QC_diagnosis_Class p_QCDIAGNOSIS = new QC_diagnosis_Class();
        //private void FillInputBydiagnosisClass()
        //{
        //    try
        //    {

        //        for (int i = 0; i < report_RadioGroup.Properties.Items.Count; i++)
        //        {
        //            if (report_RadioGroup.Properties.Items[i].Description.ToString() == p_QCDIAGNOSIS.report_quality)
        //            {
        //                report_RadioGroup.SelectedIndex = i;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Public_Class.WriteFlog(ex.Message, Share_Class.Dir + @"\log");
        //    }

        //    // 'diagnosis_MemoEdit.Text = p_QCDIAGNOSIS.report_quality_result
        //    for (int i = 0; i < report_CheckedListBoxControl.Items.Count; i++)
        //    {
        //        if (("," + p_QCDIAGNOSIS.report_quality_remark + ",").IndexOf("," + report_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
        //        {
        //            report_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;

        //        }
        //    }
        //    //'如果数据字典中没有该结果归类自动加上   ---YDY
        //    if ((report_CheckedListBoxControl.CheckedItems.Count == 0) && (p_QCDIAGNOSIS.report_quality_remark != ""))
        //    {
        //        report_CheckedListBoxControl.Items.Add(p_QCDIAGNOSIS.report_quality_remark, CheckState.Checked);
        //    }
        //    report_ComboBoxEdit.Text = p_QCDIAGNOSIS.report_quality_remark;
        //}
        //private void FilldiagnosisClassByInput()
        //{
        //    p_QCDIAGNOSIS.report_quality = report_RadioGroup.Properties.Items[report_RadioGroup.SelectedIndex].Description.ToString();
        //    p_QCDIAGNOSIS.report_quality_result = p_QCDIAGNOSIS.report_quality;
        //    p_QCDIAGNOSIS.report_quality_remark = report_ComboBoxEdit.Text;
        //}
        //private void report_CheckedListBoxControl_Click(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double d_result = 100;
        //        string QC_str = "";

        //        for (int i = 0; i < report_CheckedListBoxControl.Items.Count; i++)
        //        {
        //            if (report_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
        //            {
        //                if (report_CheckedListBoxControl.Items[i].Value.ToString().Trim() != report_CheckedListBoxControl.SelectedValue.ToString().Trim())
        //                {
        //                    if (QC_str == "")
        //                    {
        //                        QC_str = report_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    else
        //                    {
        //                        QC_str = QC_str + "," + report_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    try
        //                    {
        //                        string str = d_reportremark[report_CheckedListBoxControl.Items[i].Value.ToString().Trim()];
        //                        double values = Convert.ToDouble(str);
        //                        d_result = d_result + values;
        //                    }
        //                    catch { }
        //                }
        //            }
        //            else
        //            {
        //                if (report_CheckedListBoxControl.Items[i].Value.ToString().Trim() == report_CheckedListBoxControl.SelectedValue.ToString().Trim())
        //                {
        //                    if (QC_str == "")
        //                    {
        //                        QC_str = report_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    else
        //                    {
        //                        if (("," + QC_str + ",").IndexOf("," + report_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") < 0)
        //                        {
        //                            QC_str = QC_str + "," + report_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                        }
        //                    }
        //                    try
        //                    {
        //                        string str = d_reportremark[report_CheckedListBoxControl.Items[i].Value.ToString().Trim()];
        //                        double values = Convert.ToDouble(str);
        //                        d_result = d_result + values;
        //                    }
        //                    catch { }
        //                }
        //            }
        //        }
        //        report_ComboBoxEdit.Text = QC_str;
        //        try
        //        {
        //            string str = qc_Statues(d_result, d_listreport);
        //            for (int i = 0; i < report_RadioGroup.Properties.Items.Count; i++)
        //            {
        //                if (report_RadioGroup.Properties.Items[i].Description == str)
        //                {
        //                    report_RadioGroup.SelectedIndex = i;
        //                    break;
        //                }
        //            }
        //        }
        //        catch { }
        //    }
        //    catch { }

        //}
        //QC_radiology_Class p_Qcradiology = new QC_radiology_Class();
        //private void FillInputByradiologyClass()
        //{
        //    try
        //    {

        //        for (int i = 0; i < Qc_CheckedListBox.Properties.Items.Count; i++)
        //        {
        //            if (Qc_CheckedListBox.Properties.Items[i].Description.ToString() == p_Qcradiology.radiology_general)
        //            {
        //                Qc_CheckedListBox.SelectedIndex = i;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Public_Class.WriteFlog(ex.Message, Share_Class.Dir + @"\log");
        //    }
        //    for (int i = 0; i < Qc_CheckedListBoxControl.Items.Count; i++)
        //    {
        //        if (("," + p_Qcradiology.radiology_quality_remark + ",").IndexOf("," + Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
        //        {
        //            Qc_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;

        //        }
        //    }

        //    //'如果数据字典中没有该结果归类自动加上   ---YDY
        //    if ((Qc_CheckedListBoxControl.CheckedItems.Count == 0) && (p_Qcradiology.radiology_quality_remark != ""))
        //    {
        //        Qc_CheckedListBoxControl.Items.Add(p_Qcradiology.radiology_quality_remark, CheckState.Checked);
        //    }
        //    Qc_ComboBoxEdit.Text = p_Qcradiology.radiology_quality_remark;
        //}
        //private void FillradiologyClassByInput()
        //{
        //    p_Qcradiology.radiology_general = Qc_CheckedListBox.Properties.Items[Qc_CheckedListBox.SelectedIndex].Description.ToString();
        //    p_Qcradiology.radiology_quality_result = p_Qcradiology.radiology_general;
        //    p_Qcradiology.radiology_quality_remark = Qc_ComboBoxEdit.Text.Trim();
        //}
        //private void Qc_CheckedListBoxControl_Click(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double d_result = 100;
        //        string QC_str = "";

        //        for (int i = 0; i < Qc_CheckedListBoxControl.Items.Count; i++)
        //        {
        //            if (Qc_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
        //            {
        //                if (Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim() != Qc_CheckedListBoxControl.SelectedValue.ToString().Trim())
        //                {
        //                    if (QC_str == "")
        //                    {
        //                        QC_str = Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    else
        //                    {
        //                        QC_str = QC_str + "," + Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    try
        //                    {
        //                        string str = d_qcremark[Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim()];
        //                        double values = Convert.ToDouble(str);
        //                        d_result = d_result + values;
        //                    }
        //                    catch { }
        //                }
        //            }
        //            else
        //            {
        //                if (Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim() == Qc_CheckedListBoxControl.SelectedValue.ToString().Trim())
        //                {
        //                    if (QC_str == "")
        //                    {
        //                        QC_str = Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                    }
        //                    else
        //                    {
        //                        if (("," + QC_str + ",").IndexOf("," + Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") < 0)
        //                        {
        //                            QC_str = QC_str + "," + Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim();
        //                        }
        //                    }
        //                    try
        //                    {
        //                        string str = d_qcremark[Qc_CheckedListBoxControl.Items[i].Value.ToString().Trim()];
        //                        double values = Convert.ToDouble(str);
        //                        d_result = d_result + values;
        //                    }
        //                    catch { }
        //                }
        //            }
        //        }
        //        Qc_ComboBoxEdit.Text = QC_str;
        //        try
        //        {
        //            string str = qc_Statues(d_result, d_listQC);
        //            for (int i = 0; i < Qc_CheckedListBox.Properties.Items.Count; i++)
        //            {
        //                if (Qc_CheckedListBox.Properties.Items[i].Description == str)
        //                {
        //                    Qc_CheckedListBox.SelectedIndex = i;
        //                    break;
        //                }
        //            }
        //        }
        //        catch { }
        //    }
        //    catch { }
        //}
        //// '照片质量
        //private void ShowQc_radiology()
        //{

        //    // '  string  TechPr 

        //    //'string  Qc_radiology As DataSet

        //    string patid = "";
        //    string xno = "";
        //    string accessno = "";

        //    patid = CurPatexam.Patient_id;
        //    xno = CurPatexam.xno;
        //    accessno = CurPatexam.accessno;
        //    p_Qcradiology = new QC_radiology_Class(accessno);
        //    FillInputByradiologyClass();
        //    p_Qcradiology.radiology_appraise_doctor = Share_Class.User.user_id;
        //    p_Qcradiology.patient_id = patid;
        //    p_Qcradiology.xno = xno;
        //    p_Qcradiology.accessno = accessno;

        //}

        //// '报告质量
        //private void ShowQc_Report()
        //{


        //    //string  commstring 
        //    //string  p_Qc_radiology  = ""
        //    //'string  Qc_radiology As DataSet
        //    //' report_RadioGroup.SelectedIndex = 0
        //    string patid = "";
        //    string xno = "";
        //    string accessno = "";


        //    patid = CurPatexam.Patient_id;
        //    xno = CurPatexam.xno;
        //    accessno = CurPatexam.accessno;
        //    p_QCDIAGNOSIS = new QC_diagnosis_Class(accessno);
        //    FillInputBydiagnosisClass();

        //    p_QCDIAGNOSIS.report_appraise_doctor = Share_Class.User.user_id;
        //    p_QCDIAGNOSIS.patient_id = patid;
        //    p_QCDIAGNOSIS.xno = xno;
        //    p_QCDIAGNOSIS.accessno = accessno;
        //}

        //private void setupReport_SimpleButton_Click_1(object sender, EventArgs e)
        //{
        //    if ((Share_Class.User.user_id != "ma") && (Share_Class.User.user_id != "admin") && (Share_Class.User.HaveFunction("306") == false))
        //    {
        //        Public_Class.ShowErr_Form("用户无此操作权限", "提示");

        //        return;
        //    }

        //    Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", "报告质控结果");
        //    d_form.ShowDialog();
        //    InitCheckedListBoxControl();
        //}

        //private void SimpleButton8_Click(object sender, EventArgs e)
        //{
        //    if ((Share_Class.User.user_id != "ma") && (Share_Class.User.user_id != "admin") && (Share_Class.User.HaveFunction("306") == false))
        //    {
        //        Public_Class.ShowErr_Form("用户无此操作权限", "提示");

        //        return;
        //    }

        //    Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", "照片质控结果");
        //    d_form.ShowDialog();
        //    InitCheckedListBoxControl();

        //}

        //private void setup_SQDSimpleButton_Click(Object sender, EventArgs e)
        //{
        //    if ((Share_Class.User.user_id != "ma") && (Share_Class.User.user_id != "admin") && (Share_Class.User.HaveFunction("306") == false))
        //    {
        //        Public_Class.ShowErr_Form("用户无此操作权限", "提示");

        //        return;
        //    }

        //    Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", "申请单质量");
        //    d_form.ShowDialog();
        //}

        //private void setupQC_SimpleButton_Click(Object sender, EventArgs e)
        //{
        //    if ((Share_Class.User.user_id != "ma") && (Share_Class.User.user_id != "admin") && (Share_Class.User.HaveFunction("306") == false))
        //    {
        //        Public_Class.ShowErr_Form("用户无此操作权限", "提示");

        //        return;
        //    }
        //    Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", "照片质量");
        //    d_form.ShowDialog();
        //}

        //private void setupReport_SimpleButton_Click(Object sender, EventArgs e)
        //{
        //    if ((Share_Class.User.user_id != "ma") && (Share_Class.User.user_id != "admin") && (Share_Class.User.HaveFunction("306") == false))
        //    {
        //        Public_Class.ShowErr_Form("用户无此操作权限", "提示");

        //        return;
        //    }
        //    Setup_Dict.setup_dic_dmb_Form d_form = new Setup_Dict.setup_dic_dmb_Form("XRAY", "", "报告质量");
        //    d_form.ShowDialog();
        //}
        //#endregion

        //private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckEdit1.Checked == false)
        //        Public_Class.WriteINI("setup", "IMAGE_QC", "no");
        //    else
        //        Public_Class.WriteINI("setup", "IMAGE_QC", "yes");

        //}

        //private void CheckEdit2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckEdit2.Checked == false)
        //        Public_Class.WriteINI("setup", "REPORT_QC", "no");
        //    else
        //        Public_Class.WriteINI("setup", "REPORT_QC", "yes");

        //}


        ////private void radiology_SimpleButton_Click(Object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        FillradiologyClassByInput();
        ////        FilldiagnosisClassByInput();
        ////        QC_Edit_Form qc_editfm = new QC_Edit_Form(p_QCDIAGNOSIS, p_Qcradiology, 0);
        ////        qc_editfm.ShowDialog();
        ////        p_QCDIAGNOSIS = qc_editfm.QCDIAGNOSIS;
        ////        p_Qcradiology = qc_editfm.Qcradiology;
        ////        FillInputBydiagnosisClass();
        ////        FillInputByradiologyClass();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Public_Class.WriteFlog(ex.Message, Share_Class.Dir + @"\log");
        ////    }
        ////}

        ////private void diagnosis_SimpleButton_Click(Object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        FilldiagnosisClassByInput();
        ////        FillradiologyClassByInput();
        ////        QC_Edit_Form qc_editfm = new QC_Edit_Form(p_QCDIAGNOSIS, p_Qcradiology, 1);
        ////        qc_editfm.ShowDialog();
        ////        p_QCDIAGNOSIS = qc_editfm.QCDIAGNOSIS;
        ////        p_Qcradiology = qc_editfm.Qcradiology;
        ////        FillInputBydiagnosisClass();
        ////        FillInputByradiologyClass();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Public_Class.WriteFlog(ex.Message, Share_Class.Dir + @"\log");
        ////    }

        ////}
        #endregion

        #region 图像
        private void panelImageList1_MouseClickImage(object sender, EventArgs e)
        {
            if ((panelImageList1.SelectedItems.Count == 0) && (p_SelectedImage.Count > 0))
            {
                p_SelectedImage.Clear();
                CurReportForm.ImageDel(p_SelectedImage, 0);
            }
            else if (panelImageList1.SelectedItems.Count > p_SelectedImage.Count)
            {
                if (panelImageList1.SelectedImage != null)
                {
                    string fileName = panelImageList1.SelectedImage.ImageFile;
                    CurReportForm.ImageAdd(fileName, panelImageList1.SelectedImage.ImageName, panelImageList1.SelectedItems.Count);
                    p_SelectedImage.Add(panelImageList1.SelectedImage.ImageName);
                }
            }
            else if (panelImageList1.SelectedItems.Count < p_SelectedImage.Count)
            {
                p_SelectedImage.Clear();
                //CurReportForm.ImageDel(panelImageList1 );
                foreach (RIS.Vedio.PanelImage pi in panelImageList1.SelectedItems)
                {
                    p_SelectedImage.Add(pi.ImageName);
                }
                CurReportForm.ImageDel(p_SelectedImage, panelImageList1.SelectedItems.Count);
            }
            //p_SelectedImage = panelImageList1.SelectedItems.Count;
        }

        private void GetPic()
        {

            Share_Class.CreatePath(PicPath);
            try
            {
                string d_imgtype = "*.jpg|*.avi";
                string[] imgtype = d_imgtype.Split(new char[] { '|' });
                panelImageList1.ImagePath = PicPath;
                panelImageList1.Clear();
                string ShowImageHeight = RisSetup_Class.GetINI("setup", "Report_ShowImageHeight");
                string ShowImageWidth = RisSetup_Class.GetINI("setup", "Report_ShowImageWidth");
                if ((ShowImageHeight != "") && (ShowImageWidth != ""))
                {
                    panelImageList1.ImageSize = new Size(Convert.ToInt32(ShowImageWidth), Convert.ToInt32(ShowImageHeight));
                }
                for (int i = 0; i < imgtype.Length; i++)
                {
                    string[] localfiles = System.IO.Directory.GetFiles(PicPath, imgtype[i]);
                    foreach (string localfile in localfiles)
                    {
                        GetPicfile(localfile);
                    }
                }
            }
            //lblimageNumber.Text = "共" + panelImageList1.Items.Count.ToString() + "张";
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }
        }
        private void GetPicfile(string file)
        {
            try
            {
                panelImageList1.AddImage(file, false);
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }

        }

        //int[] BITMAP_x = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] BITMAP_y = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //private void GetBITMAP_xy()
        //{
        //    string d_date = CurReportForm.CurPatexam.checkdate.ToString("yyyyMMdd");
        //    string path = Share_Class.Dir + @"\pic\" + d_date + @"\" + CurReportForm.CurPatexam.accessno + @"\";
        //  Share_Class    .CreatePath(path);

        //    ES_Bitmap_Class d_ES_Bitmap = new ES_Bitmap_Class();
        //    DataSet ds = new DataSet();
        //    BITMAP_x = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //    BITMAP_y = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //    string BITMAP_Name = "";
        //    string d_bitmap = "";
        //    char d_Char = ',';
        //    string[] d_str = new string[] { };
        //    string[] BITMAP_ID = new string[8] { "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT" };
        //    string[] BITMAP_File_Name = new string[8] { "", "", "", "", "", "", "", "" };
        //    string[] BITMAP_PicName = new string[8] { "", "", "", "", "", "", "", "" };
        //    ds = d_ES_Bitmap.SelectBitmapByAccessno(CurReportForm.CurPatexam.accessno);
        //    panelImageList1.AllowMultiSelect = true;
        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        // 'Public_Class.WriteFlog("加载图像SelectBitmapByAccessno" + "\r\n", Share_Class.newdir + "\\Log") '将详细错误信息写入日志
        //        try
        //        {
        //            for (int i = 0; i < 8; i++)
        //            {
        //                BITMAP_Name = "BITMAP_" + BITMAP_ID[i];
        //                d_bitmap = ds.Tables[0].Rows[0][BITMAP_Name].ToString().Trim();
        //                if (d_bitmap != "")
        //                {
        //                    try
        //                    {
        //                        d_str = d_bitmap.Split(d_Char);
        //                        // 'Public_Class.WriteFlog("加载图像d_str(1)：" + d_str(1) + "\r\n", Share_Class.newdir + "\\Log") '将详细错误信息写入日志
        //                        BITMAP_x[i] = Convert.ToInt32(Convert.ToDouble(d_str[1]) * 190 / 225);
        //                        // 'Public_Class.WriteFlog("加载图像d_str(2)：" + d_str(2) + "\r\n", Share_Class.newdir + "\\Log") '将详细错误信息写入日志
        //                        BITMAP_y[i] = Convert.ToInt32(Convert.ToDouble(d_str[2]) * 235 / 278);
        //                        // 'Public_Class.WriteFlog("加载图像d_str(3)：" + d_str(3) + "\r\n", Share_Class.newdir + "\\Log") '将详细错误信息写入日志
        //                        BITMAP_File_Name[i] = d_str[3];
        //                        if (d_str.Length > 4)
        //                        {
        //                            BITMAP_PicName[i] = d_str[4];
        //                            panelImageList1.Items[i].ImageCaption = BITMAP_PicName[i];
        //                        }
        //                        try
        //                        {
        //                            GetPicfile(path + BITMAP_File_Name[i] + ".jpg");
        //                            panelImageList1.Items[i].Selected = true;
        //                            //DengjiPart_ComboBoxEdit.Text = "";
        //                            //DengjiPart_ComboBoxEdit.Text = BITMAP_ONE_PicName;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            flog_Class.WriteFlog("加载图像路径" + ex.Message, Share_Class.Dir + @"\Log");//'将详细错误信息写入日志
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        flog_Class.WriteFlog("加载图像路径" + ex.Message, Share_Class.Dir + @"\Log");//'将详细错误信息写入日志
        //                    }
        //                }
        //            }
        //            //SaveBitmap()
        //        }
        //        catch (Exception ex)
        //        {
        //            flog_Class.WriteFlog("加载图像路径" + ex.Message, Share_Class.Dir + @"\Log");//'将详细错误信息写入日志
        //        }
        //    }
        //}

        //private void SavePic()
        //{
        //    string d_FTPOPEN = "";
        //    d_FTPOPEN = RisSetup_Class.GetINI("setup", "FTPOPEN");
        //    if (d_FTPOPEN != "yes")
        //    {
        //        return;
        //    }
        //    XIS_STUDY_Class d_XIS_STUDY = new XIS_STUDY_Class(CurPatexam.accessno);
        //    int d_SERIES_COUNT = 0;
        //    List<string> d_FileName = new List<string>();
        //    List<string> d_FileNameAdd = new List<string>();
        //    if (d_XIS_STUDY.STUDY_KEY != 0)
        //    {
        //        d_SERIES_COUNT = Convert.ToInt32(d_XIS_STUDY.SERIES_COUNT);
        //        DataSet d_FileDs = new DataSet();
        //        d_FileDs = XIS_IMAGE_Class.GetByStudyKey(d_XIS_STUDY.STUDY_KEY.ToString());
        //        if (d_FileDs != null)
        //        {
        //            if (d_FileDs.Tables.Count > 0)
        //            {
        //                if (d_FileDs.Tables[0].Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < d_FileDs.Tables[0].Rows.Count; i++)
        //                    {
        //                        d_FileName.Add(d_FileDs.Tables[0].Rows[i]["filename"].ToString().Trim());
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    try
        //    {
        //        string d_imgtype = "*.jpg|*.avi";
        //        string[] imgtype = d_imgtype.Split(new char[] { '|' });
        //        for (int i = 0; i < imgtype.Length; i++)
        //        {
        //            string[] localfiles = System.IO.Directory.GetFiles(PicPath, imgtype[i]);
        //            foreach (string localfile in localfiles)
        //            {
        //                if (d_FileName.Contains(localfile) == false)
        //                {
        //                    d_FileNameAdd.Add(localfile);
        //                }
        //            }
        //        }
        //    }
        //    //lblimageNumber.Text = "共" + panelImageList1.Items.Count.ToString() + "张";
        //    catch (Exception ex)
        //    {
        //        Public_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
        //    }
        //    if (d_FileNameAdd.Count > 0)
        //    {
        //        d_XIS_STUDY = new XIS_STUDY_Class();
        //        d_XIS_STUDY.TRIGGER_DTTM = DateTime.Now.ToString("yyyyMMddHHmmss");
        //        d_XIS_STUDY.REPLICA_DTTM = "A";
        //        d_XIS_STUDY.PATIENT_NAME = CurPatregister.Name;
        //        d_XIS_STUDY.PATIENT_ID = CurPatexam.Patient_id;
        //        d_XIS_STUDY.PATIENT_SEX = CurPatregister.Sex;
        //        d_XIS_STUDY.PATIENT_AGE = CurPatregister.Age;
        //        d_XIS_STUDY.PATIENT_BIRTH_DATE = CurPatregister.BirthDay.ToString("yyyyMMdd");
        //        d_XIS_STUDY.STUDY_DTTM = DateTime.Now.ToString("yyyyMMddHHmmss");
        //        if (CurPatexam.dep == "内窥镜")
        //        {
        //            d_XIS_STUDY.MODALITY = "ES";
        //        }
        //        else
        //        {
        //            d_XIS_STUDY.MODALITY = CurPatexam.modality;
        //        }
        //        if (CurPatexam.dengjipart == "")
        //        {
        //            d_XIS_STUDY.BODYPART = "other";
        //        }
        //        else
        //        {
        //            d_XIS_STUDY.BODYPART = CurPatexam.dengjipart;
        //        }
        //        if (CurPatexam.checkpos == "")
        //        {
        //            d_XIS_STUDY.STUDY_DESC = "other";
        //        }
        //        else
        //        {
        //            d_XIS_STUDY.STUDY_DESC = CurPatexam.checkpos;
        //        }

        //        d_XIS_STUDY.ACCESSION_NO = CurPatexam.accessno;

        //        d_XIS_STUDY.SERIES_COUNT = Convert.ToString(d_SERIES_COUNT + 1);
        //        d_XIS_STUDY.IMAGE_COUNT = d_FileNameAdd.Count.ToString();
        //        int d_study_key = d_XIS_STUDY.insert();
        //        if (d_study_key != 0)
        //        {
        //            XIS_SERIES_Class d_XIS_SERIES = new XIS_SERIES_Class();
        //            d_XIS_SERIES.series_key = d_study_key;
        //            d_XIS_SERIES.series_no = d_XIS_STUDY.SERIES_COUNT;
        //            d_XIS_SERIES.series_desc = d_XIS_STUDY.STUDY_DESC;
        //            d_XIS_SERIES.series_dttm = d_XIS_STUDY.TRIGGER_DTTM;
        //            d_XIS_SERIES.modality = d_XIS_STUDY.MODALITY;
        //            d_XIS_SERIES.bodypart = d_XIS_STUDY.BODYPART;
        //            d_XIS_SERIES.image_count = d_XIS_STUDY.IMAGE_COUNT;

        //            int d_series_key = d_XIS_SERIES.Add();
        //            if (d_study_key != 0)
        //            {

        //                for (int i = 0; i < d_FileNameAdd.Count; i++)
        //                {
        //                    XIS_IMAGE_Class d_XIS_IMAGE = new XIS_IMAGE_Class();
        //                    d_XIS_IMAGE.study_key = d_study_key.ToString();
        //                    d_XIS_IMAGE.series_key = d_series_key.ToString();
        //                    d_XIS_IMAGE.filename = d_FileNameAdd[i];
        //                    d_XIS_IMAGE.Add();
        //                }
        //            }
        //        }
        //    }

        //}

        //private void SaveBitmap()
        //{
        //    try
        //    {
        //        BITMAP_x = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //        BITMAP_y = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

        //        foreach (RIS.Vedio.LabelNumber pn in PanelNumber1.Items)
        //        {
        //            BITMAP_x[pn.Number] = pn.Location.X * 190 / 225;
        //            BITMAP_y[pn.Number] = pn.Location.Y * 235 / 278;
        //        }


        //        PanelNumber1.ClearItems();
        //        foreach (RIS.Vedio.PanelImage pi in panelImageList1.SelectedItems)
        //        {
        //            if (BITMAP_x[pi.SelectNumber] == 0)
        //            {
        //                BITMAP_x[pi.SelectNumber] = 10 * (pi.SelectNumber - 1) + 1;
        //                BITMAP_y[pi.SelectNumber] = 10 * (pi.SelectNumber - 1) + 1;
        //            }
        //            PanelNumber1.AddItem(pi.SelectNumber, pi.ImageName, BITMAP_x[pi.SelectNumber] * 225 / 190, BITMAP_y[pi.SelectNumber] * 278 / 235, pi.ImageCaption);
        //        }



        //        DG_Bitmap_Class CurBitmap = new DG_Bitmap_Class();
        //        string d_path = Share_Class.Dir + @"\Bitmap\weijing.jpg";
        //        string path = Share_Class.Dir + @"\Bitmap\" + CurPatexam.checkdate.ToString("yyyyMMdd") + "\\" + CurPatexam.accessno + "\\";
        //        Bitmap d_bitmap = new Bitmap(d_path);
        //        Public_Class.CreatePath(path);
        //        Graphics g = Graphics.FromImage(d_bitmap);
        //        SolidBrush mBrush = new SolidBrush(Color.Yellow);
        //        foreach (RIS.Vedio.LabelNumber pn in PanelNumber1.Items)
        //        {
        //            Rectangle rfBound1 = new Rectangle(BITMAP_x[pn.Number] * 225 / 190, BITMAP_y[pn.Number] * 278 / 235, 15, 15);// '定义矩形大小
        //            g.FillRectangle(mBrush, rfBound1);
        //            Font PrintFont = new Font("宋体", 14, FontStyle.Bold);
        //            g.DrawString(pn.Number.ToString(), PrintFont, Brushes.Red, BITMAP_x[pn.Number] * 225 / 190, BITMAP_y[pn.Number] * 278 / 235);
        //            string str = pn.Number.ToString() + "," + pn.Location.X.ToString() + "," + pn.Location.Y.ToString() + "," + pn.ImageName.ToString() + "," + pn.ImageCaption.ToString();
        //            if (pn.Number == 1)
        //                CurBitmap.BITMAP_ONE = str;
        //            else if (pn.Number == 2)
        //                CurBitmap.BITMAP_TWO = str;
        //            else if (pn.Number == 3)
        //                CurBitmap.BITMAP_THREE = str;
        //            else if (pn.Number == 4)
        //                CurBitmap.BITMAP_FOUR = str;
        //            else if (pn.Number == 5)
        //                CurBitmap.BITMAP_FIVE = str;
        //            else if (pn.Number == 6)
        //                CurBitmap.BITMAP_SIX = str;
        //            else if (pn.Number == 7)
        //                CurBitmap.BITMAP_SEVEN = str;
        //            else if (pn.Number == 8)
        //                CurBitmap.BITMAP_EIGHT = str;

        //        }
        //        d_bitmap.Save(path + "wentu.jpg");
        //        CurBitmap.ACCESSION_NO = CurPatexam.accessno;
        //        CurBitmap.SaveBitmap();
        //    }
        //    catch { }
        //    SavePic();
        //}

        #endregion

        #region Combobox的事件
        private void TextChangeDmb_ComboBoxEdit_GotFocus(Object sender, EventArgs e)
        {

            FillComboBoxEdit((DevExpress.XtraEditors.ComboBoxEdit)sender);
        }

        private void FillComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit p_combobox)
        {
            if (p_combobox.Properties.Items.Count > 0)
            { //'如果下拉框中已有内容,就会退出
                return;
            }

            DataSet ds = new DataSet();
            string d_Field = "";
            if (p_combobox.Name == "machinetype_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("machinetype");
                d_Field = "machinetype";
            }
            else if (p_combobox.Name == "sqdep_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("sqdep");
                d_Field = "sqdep";
            }
            else if (p_combobox.Name == "doctor_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("doctor");
                d_Field = "doctor";
            }
            else if (p_combobox.Name == "radio_doctor_ComboBoxEdit")
            {
                ds = Userinfo_Class.GetUserByDept(this.CurReportForm.CurPatexam.dep);
                d_Field = "userid";
            }
            else if (p_combobox.Name == "checktype_ComboBoxEdit")
            {
                //ds = setup_noSort_Dmb_Class.GetAll("checktype");
                //d_Field = "item";

                ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM(this.CurReportForm.CurPatexam.dep, "", "扫描方式", "", "");
                d_Field = "item";
            }
            //else if (p_combobox.Name == "othercheck_ComboBoxEdit")
            //{
            //    ds = setup_noSort_Dmb_Class.GetAll("sqdep");
            //    d_Field = "sqdep";
            //}
            else if (p_combobox.Name == "modality_ComboBoxEdit")
            {
                ds = setup_registerpart_Dmb_Class.Getmodality();
                d_Field = "modality";
            }
            else if (p_combobox.Name == "layerthick_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("smthick");
                d_Field = "smthick";
            }
            else if (p_combobox.Name == "layerinterval_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("sminternal");
                d_Field = "sminterval";
            }
            //else if (p_combobox.Name == "checkpos_ComboBoxEdit")
            //{
            //    ds = setup_registerpart_Dmb_Class.Getchildpart;
            //    d_Field = "childpart";
            //}
            if (ds == null)
            {
                return;
            }
            // '填充数据库中调出的项()

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                p_combobox.Properties.Items.Add(ds.Tables[0].Rows[i][d_Field].ToString().Trim());
            }

        }
        #endregion

        #region 历史报告
        public void Fillhistroy()
        {
            string d_name = "";
            string d_accessno = "";
            string d_patient_id = "";
            string d_patid = "";
            string d_xno = "";
            d_accessno = CurReportForm.CurPatexam.accessno;
            d_patient_id = CurReportForm.CurPatexam.Patient_id;
            d_patid = CurReportForm.CurPatexam.patid;
            d_xno = CurReportForm.CurPatexam.xno;

            d_name = CurReportForm.CurPatregister.Name.Trim();

            //if ( d_PatRegister.Is_Write.ToLower == "yes" )
            //    yz_PictureBox.Visible = true;

            // '得到历史记录
            DataSet Ds = patexam_Class.Findpatexamhistroy(d_name, d_patient_id, d_accessno, d_xno);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("不能取得数据", "错误");
                d_form.ShowDialog();
                return;
            }
            //'把得到的数据加到列表中
            patexam_GridControl.DataSource = Ds.Tables[0];
            patexam_GridView.RefreshData();

            Ds = patexam_Class.Findpatexamhistroy(d_name, d_accessno);   //  'ma速度变慢
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("不能取得数据", "错误");
                d_form.ShowDialog();
                return;
            }
            //'把得到的数据加到列表中
            name_GridControl.DataSource = Ds.Tables[0];
            name_GridView.RefreshData();
        }


        private void patexam_GridControl_DoubleClick(object sender, EventArgs e)
        {
            //''得到当前要处理的Dmb的信息
            DataTable d_DTable = (DataTable)patexam_GridControl.DataSource;
            if (d_DTable == null)
                return;
            DataRow dw = d_DTable.Rows[patexam_GridView.GetDataSourceRowIndex(patexam_GridView.FocusedRowHandle)];
            string d_accessno = dw["accession_no"].ToString().Trim();
            //clshistoryAccessno = d_accessno;
            histroyreport_xtraTabPage.PageVisible = true;
            histroyreport_xtraTabPage.Controls.Clear();
            report_history_Control d_history = new report_history_Control(d_accessno, this);
            histroyreport_xtraTabPage.Controls.Add(d_history);
            d_history.Dock = DockStyle.Fill;
            d_history.Show();
            this.Report_XtraTabControl.SelectedTabPage = histroyreport_xtraTabPage;
            //'    string  d_form =new  report_history_form(["transcriber_name").ToString(),
            //'                                          ["scheduled_dttm").ToString(),
            //'                                          ["accession_no").ToString(),
            //'                                          ["patient_name").ToString(),
            //'                                          ["request_department").ToString(),
            //'                                          ["scheduled_modality").ToString(),
            //'                                          ["patient_id").ToString(),
            //'                                          ["checkpos").ToString(),
            //'                                          ["bedno").ToString(),
            //'                                          ["conclusion").ToString(),
            //'                                          ["REPORT_TEXT").ToString)
            //'    d_form.ShowDialog()

        }

        private void name_GridControl_DoubleClick(object sender, EventArgs e)
        {
            //''得到当前要处理的Dmb的信息
            DataTable d_DTable = (DataTable)name_GridControl.DataSource;
            if (d_DTable == null)
                return;
            DataRow dw = d_DTable.Rows[name_GridView.GetDataSourceRowIndex(name_GridView.FocusedRowHandle)];
            string d_accessno = dw["accession_no"].ToString().Trim();
            histroyreport_xtraTabPage.PageVisible = true;
            histroyreport_xtraTabPage.Controls.Clear();
            report_history_Control d_history = new report_history_Control(d_accessno, this);
            histroyreport_xtraTabPage.Controls.Add(d_history);
            d_history.Dock = DockStyle.Fill;
            d_history.Show();
            this.Report_XtraTabControl.SelectedTabPage = histroyreport_xtraTabPage;
        }

        private void name_GridControl_Click(object sender, EventArgs e)
        {
            DataTable d_DTable = (DataTable)name_GridControl.DataSource;
            if (d_DTable == null)
                return;
            DataRow dw = d_DTable.Rows[name_GridView.GetDataSourceRowIndex(name_GridView.FocusedRowHandle)];
            string d_accessno = dw["accession_no"].ToString().Trim();
            patexam_Class d_patexam = new patexam_Class(d_accessno);
            this.memoEdit3.Text = d_patexam.reportend;
            memoEdit4.Text = d_patexam.reportinfo;
        }

        private void patexam_GridControl_Click(object sender, EventArgs e)
        {
            DataTable d_DTable = (DataTable)patexam_GridControl.DataSource;
            if (d_DTable == null)
                return;
            DataRow dw = d_DTable.Rows[patexam_GridView.GetDataSourceRowIndex(patexam_GridView.FocusedRowHandle)];
            string d_accessno = dw["accession_no"].ToString().Trim();
            patexam_Class d_patexam = new patexam_Class(d_accessno);
            memoEdit1.Text = d_patexam.reportend;
            memoEdit2.Text = d_patexam.reportinfo;
        }


        #endregion

        private void Report_XtraTabControl_Resize(object sender, EventArgs e)
        {
            //CurReportForm.WindowState = FormWindowState.Normal;
            //CurReportForm.WindowState = FormWindowState.Maximized ;

        }

        private void Left_XtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (Left_XtraTabControl.SelectedTabPage == this.ICD_XtraTabPage)
            {
                PadICD10_TreeList();
            }
            else if (Left_XtraTabControl.SelectedTabPage == this.ICD_XtraTabPage)
            {

            }
        }

        private void Report_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            // '设置报告编辑状态

            patexam_Class.Setwrite_flag(CurReportForm.CurPatexam.accessno, "");

            if (CurShowApplyImage_Form != null)
            {
                CurShowApplyImage_Form.Close();
            }

            //'关闭申请单和电子申请单窗体
            //If CurShowApplyImage_Form IsNot Nothing ){
            //    CurShowApplyImage_Form.Close()
            //Endif (
            if (CurShowApply_Form != null)
                CurShowApply_Form.Close();

        }

        private void image_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (image_ComboBoxEdit.Text.Trim() == "普通报告")
            {
                CurReportForm.ReCreateReportStyle("");
            }
            else if (image_ComboBoxEdit.Text.Trim() == "急诊报告")
            {
                CurReportForm.ReCreateReportStyle("jz");
            }
            else if (image_ComboBoxEdit.Text.Trim() == "图文报告")
            {
                CurReportForm.ReCreateReportStyle("image");
            }
            else if (image_ComboBoxEdit.Text.Trim() == "图像报告")
            {
                CurReportForm.ReCreateReportStyle("onlyimage");
            }
        }
        public void ChangeReportStyle(string p_stylename)
        {
            image_ComboBoxEdit.Text = p_stylename;
        }

        private void diseasetype_CheckedListBoxControl_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < diseasetype_CheckedListBoxControl.CheckedItems.Count; i++)
                {
                    if (diseasetype_CheckedListBoxControl.CheckedItems[i].ToString().Trim() != diseasetype_CheckedListBoxControl.SelectedValue.ToString())
                        diseasetype_CheckedListBoxControl.Items[diseasetype_CheckedListBoxControl.CheckedIndices[i]].CheckState = CheckState.Unchecked;
                }
                diseasetype_ComboBoxEdit.Text = diseasetype_CheckedListBoxControl.SelectedValue.ToString();


            }
            catch { }

        }













    }
}