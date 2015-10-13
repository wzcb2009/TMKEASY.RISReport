using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Security;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using System.IO;
using DCSoft.Writer.Extension.Data;

namespace TMKEASY.RISReport
{
    public partial class Report_Word_Form : BaseReport_Form
    {
        Report_Form d_reportform;
        private DCSoft.Writer.Controls.TrackListBoxControler _TrackListControler = null;
        string Curoldadvancedoc = "";
        public Report_Word_Form()
        {
            InitializeComponent();
        }

        public Report_Word_Form(string p_accessno)
            : base(p_accessno)
        {
            InitializeComponent();
            myEditControl.MoveFocusHotKey = MoveFocusHotKeys.Tab;


        }
        public Report_Word_Form(string p_accessno, Report_Form p_reportform)
            : base(p_accessno)
        {
            InitializeComponent();
            myEditControl.MoveFocusHotKey = MoveFocusHotKeys.Tab;
            d_reportform = p_reportform;

        }
        public override void ExecuteCommand(string exestr)
        {
            myEditControl.ExecuteCommand(exestr, false, null);
        }
        public override void ExecuteCommand(string exestr, bool showUI)
        {
            myEditControl.ExecuteCommand(exestr, showUI, null);
        }
        public override void ExecuteCommand(string exestr, bool showUI, object parameter)
        {
            myEditControl.ExecuteCommand(exestr, showUI, parameter);
        }
        public override object ReturnExecuteCommand(string exestr, bool showUI, object parameter)
        {
            return myEditControl.ExecuteCommand(exestr, showUI, parameter);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.myEditControl.StartPageIndex = 1;
            //this.myEditControl.EndPageIndex = 1;
            //this.myEditControl.EventCanInsertObject +=
            //    new DCSoft.Writer.CanInsertObjectEventHandler(this.myEditControl_EventCanInsertObject);
            //this.myEditControl.EventInsertObject +=
            //    new DCSoft.Writer.InsertObjectEventHandler(this.myEditControl_EventInsertObject);

            //this.myEditControl.DocumentControler = new DocumentControlerExt();
            //// 添加扩展编辑器命令模块对象
            //myEditControl.AppHost.CommandContainer.Modules.Add(
            //    new DCSoft.Writer.Extension.WriterCommandModuleExtension());
            //DCSoft.Writer.Controls.TextWindowsFormsEditorHost.PopupFormSizeFix = new System.Drawing.Size(40, 20);
            myEditControl.Font = new Font(System.Windows.Forms.Control.DefaultFont.Name, 12);
            myEditControl.Font = new Font("宋体", 9);
            //myEditControl.AutoSetDocumentDefaultFont = true;


            //this._TrackListControler = new TrackListBoxControler(lstUserTrack, this.myEditControl);
            //this._TrackListControler.Start();


            // 初始化设置命令执行器
            myEditControl.CommandControler = myCommandControler;
            //myEditControl.CommandControler.UpdateBindingControlStatus();
            myCommandControler.Start();
            myEditControl.DocumentOptions = new DocumentOptions();
            // 设置文档处于调试模式
            myEditControl.DocumentOptions.BehaviorOptions.DebugMode = false;
            // 执行一次新增文件操作
            //myEditControl.ExecuteCommand("FileNew", true, null);   
            myEditControl.DocumentOptions.ViewOptions.EnableFieldTextColor = true;
            myEditControl.DocumentOptions.ViewOptions.FieldTextColor = Color.Blue;
            myEditControl.GlobalEventTemplates[typeof(XTextTableElement)] = eetField;

            // 启用授权控制
            myEditControl.DocumentOptions.SecurityOptions.EnablePermission = false;
            // 允许逻辑删除
            myEditControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
            // 是否显示被逻辑删除的内容
            myEditControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
            // 是否显示用户痕迹标记。
            myEditControl.DocumentOptions.SecurityOptions.ShowPermissionMark = true;
            //压缩
            myEditControl.DocumentOptions.BehaviorOptions.OutputFormatedXMLSource = true;
            // 设置为复杂留痕视图模式
            //myEditControl.ExecuteCommand(StandardCommandNames.NormalViewMode, false, null);
            myEditControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);



            //if (Width < 1024)
            //{
            //   // this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide ;
            //}
            myEditControl.EventTemplates.Clear();
            ElementEventTemplate eet = new ElementEventTemplate();
            eet.MouseClick += new ElementMouseEventHandler(EET_MouseClick);
            //eet.MouseDblClick += new ElementMouseEventHandler(eet_MouseDblClick);
            //eet.KeyDown += new ElementKeyEventHandler(EET_KeyDown);
            //eet.LostFocus += new ElementEventHandler(EET_LostFocus);
            //  eet.GotFocus += new ElementEventHandler(EET_GotFocus);
            //eet.ContentChanging += new ContentChangingEventHandler(eet_ContentChanging);
            myEditControl.EventTemplates.Add(eet);

            Form_Init();
            //hideContainerRight.Controls.Remove(dockPanel5);
            //this.hideContainerRight.Controls.k

        }
        private void EET_MouseClick(object eventSender, ElementMouseEventArgs args)
        {
            try
            {
                XTextTableElement d_table = (XTextTableElement)args.Element;
                try
                {
                    string d_name = d_table.ID;

                    if (d_name == "reportinfotable")
                    {

                    }
                    else if (d_name == "reportendtable")
                    {

                    }
                    else
                    {

                    }
                }
                catch { }
            }
            catch { }

        }
        private void Form_Init()
        {
            try
            {
                // PicPath = Share_Class.Dir + "\\pic" + "\\" + CurPatexam.checkdate.ToString("yyyyMMdd") + "\\" + CurPatexam.accessno + "\\";
                DownList();
                GetXMLFile();
                //myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
                // FillInputByClass();
                //Thread d_thread4 = new Thread(FillInputByClass);
                //d_thread4.Start();
                //FillApplyByClass();
                //  FillApplyByClass();
                //  Fillhistroy();

                //UserLoginInfo d_user = new UserLoginInfo();
                //d_user.ID = Share_Class.User.user_id;
                //d_user.Name = Share_Class.User.user_id;
                //d_user.ClientName = System.Environment.MachineName;
                //if ((Share_Class.User.user_id == "admin") || (Share_Class.User.user_id == "ma"))
                //{
                //    d_user.PermissionLevel = 0;
                //}
                //else if (Share_Class.User.HaveFunction("g") == true)
                //{
                //    d_user.PermissionLevel = 3;
                //}
                //else if (Share_Class.User.HaveFunction("c") == true)
                //{
                //    d_user.PermissionLevel = 2;
                //}
                //else if (Share_Class.User.HaveFunction("b") == true)
                //{
                //    d_user.PermissionLevel = 1;
                //}
                //else
                //{
                //    d_user.PermissionLevel = 0;
                //}
                //myEditControl.UserLogin(d_user, false);
                btnRefreshTrackList_Click(null, null);
            }
            catch { }
        }

        private void DownList()
        {
            try
            {
                ListItemCollection items = new DCSoft.Writer.Data.ListItemCollection();
                items.AddByTextValue("男", "男");
                items.AddByTextValue("女", "女");
                items.AddByTextValue("其他", "其他");
                myEditControl.AddBufferedListItems("sexlist", items, true);

                //items = new ListItemCollection();
                //items.Clear();
                //if (CurPatexam.dep == "XRAY")
                //{
                //    items.AddByTextValue("XRAY检查报告单", "XRAY");
                //}
                //else if (CurPatexam.dep == "CT")
                //{
                //    items.AddByTextValue("CT检查报告单", "CT");
                //}
                //else if (CurPatexam.dep == "MRI")
                //{
                //    items.AddByTextValue("MRI检查报告单", "MRI");
                //}
                //else if (CurPatexam.dep == "DSA")
                //{
                //    items.AddByTextValue("DSA检查报告单", "DSA");
                //}
                //myEditControl.AddBufferedListItems("ReportTypeList", items, true);

                DataSet ds = new DataSet();
                ds = Userinfo_Class.GetUserByDept(Share_Class.User.userflag);
                items = new ListItemCollection();
                items.Clear();
                //radio_doctor_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //radio_doctor_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["user_id"].ToString().Trim());
                    items.AddByTextValue(ds.Tables[0].Rows[i]["user_id"].ToString().Trim(), ds.Tables[0].Rows[i]["user_id"].ToString().Trim());
                }
                myEditControl.AddBufferedListItems("radio_doctorlist", items, true);
                myEditControl.AddBufferedListItems("reportdoclist", items, true);
                myEditControl.AddBufferedListItems("advancedoclist", items, true);


                ds = setup_noSort_Dmb_Class.GetAll("sqdep");
                items = new ListItemCollection();
                items.Clear();
                //sqdep_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["sqdep"].ToString().Trim(), ds.Tables[0].Rows[i]["sqdep"].ToString().Trim());
                    // sqdep_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["sqdep"].ToString());
                }
                myEditControl.AddBufferedListItems("sqdeplist", items, true);

                //'ds = setup_noSort_Dmb_Class.GetAll("checkpos")
                //'items = new DCSoft.Writer.Data.ListItemCollection()
                //'items.Clear()
                //'For i = 0 To ds.Tables[0].Rows.Count - 1
                //'    items.AddByTextValue(ds.Tables[0].Rows[i]["checkpos"].ToString().Trim(), ds.Tables[0].Rows[i]["checkpos"].ToString().Trim())
                //'Next
                //'myEditControl.AddBufferedListItems("checkposlist", items, true);

                ds = setup_noSort_Dmb_Class.GetAll("ward");
                items = new ListItemCollection();
                items.Clear();
                //wardno_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["ward"].ToString().Trim(), ds.Tables[0].Rows[i]["ward"].ToString().Trim());
                    //wardno_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["ward"].ToString());
                }
                myEditControl.AddBufferedListItems("wardlist", items, true);

                ds = setup_noSort_Dmb_Class.GetAll("doctor");
                items = new ListItemCollection();
                items.Clear();
                //doctor_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["doctor"].ToString().Trim(), ds.Tables[0].Rows[i]["doctor"].ToString().Trim());
                    //doctor_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["doctor"].ToString());
                }
                myEditControl.AddBufferedListItems("doctorlist", items, true);
                ds = setup_noSort_Dmb_Class.GetAll("machinetype");
                items = new ListItemCollection();
                items.Clear();
                //machinetype_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["machinetype"].ToString().Trim(), ds.Tables[0].Rows[i]["machinetype"].ToString().Trim());
                    //machinetype_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["machinetype"].ToString());
                }
                myEditControl.AddBufferedListItems("machinetypelist", items, true);

                ds = setup_registerpart_Dmb_Class.Getmodality();
                items = new ListItemCollection();
                items.Clear();
                //modality_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["modality"].ToString().Trim(), ds.Tables[0].Rows[i]["modality"].ToString().Trim());
                    //modality_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["modality"].ToString());
                }
                myEditControl.AddBufferedListItems("modalitylist", items, true);

                ds = setup_noSort_Dmb_Class.GetAll("imagemethod");
                items = new ListItemCollection();
                items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["imagemethod"].ToString().Trim(), ds.Tables[0].Rows[i]["imagemethod"].ToString().Trim());
                    //imagemethod_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["imagemethod"].ToString());
                }
                myEditControl.AddBufferedListItems("imagemethodlist", items, true);
                myEditControl.ExcludeKeywords = "白痴";
                //   '报告类型列表框填充
                ds = setup_noSort_Dmb_Class.GetAll("reportdisease_Dmb");
                items = new ListItemCollection();
                items.Clear();
                //  reportdisease_CheckedListBoxControl.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["reportdisease"].ToString().Trim(), ds.Tables[0].Rows[i]["reportdisease"].ToString().Trim());
                    // reportdisease_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["reportdisease"].ToString(), CheckState.Unchecked);

                }
                myEditControl.AddBufferedListItems("reportdiseaselist", items, true);

                // '结果归类列表框填充
                ds = setup_noSort_Dmb_Class.GetAll("diseasetype");
                items = new ListItemCollection();
                items.Clear();
                //   '填充数据库中调出的项
                // diseasetype_CheckedListBoxControl.Items.Clear();
                //Picdiseasetype_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["diseasetype"].ToString().Trim(), ds.Tables[0].Rows[i]["diseasetype"].ToString().Trim());

                    //   diseasetype_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["diseasetype"].ToString(), CheckState.Unchecked);
                    //Picdiseasetype_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["diseasetype"].ToString());
                }
                myEditControl.AddBufferedListItems("diseasetypelist", items, true);

                // '结果归类列表框填充
                ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM(CurPatexam.dep, "", "扫描方式", "");
                //ds = setup_noSort_Dmb_Class.GetAll("diseasetype");
                items = new ListItemCollection();
                items.Clear();
                //   '填充数据库中调出的项
                // diseasetype_CheckedListBoxControl.Items.Clear();
                //Picdiseasetype_ComboBoxEdit.Properties.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items.AddByTextValue(ds.Tables[0].Rows[i]["item"].ToString().Trim(), ds.Tables[0].Rows[i]["item"].ToString().Trim());

                    //   diseasetype_CheckedListBoxControl.Items.Add(ds.Tables[0].Rows[i]["diseasetype"].ToString(), CheckState.Unchecked);
                    //Picdiseasetype_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["diseasetype"].ToString());
                }
                myEditControl.AddBufferedListItems("checktypelist", items, true);
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message);
            }
        }
        private void GetXMLFile()
        {


            FillInputXMLByClass();
            ReportXml_Class reportxml = new ReportXml_Class(CurPatexam.accessno);

            if (reportxml.xmlfile != "")
            {
                if (reportxml.stylename.Trim() != "")
                    d_reportform.ChangeReportStyle(reportxml.stylename.Trim());
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
                string p_type = "";

                if ((CurPatexam.dep == "PETCT") || (CurPatexam.dep == "ECT") || (CurPatexam.dep == "体检放射"))
                    p_type = "image";
                string fileName = GetReportStyleFile(p_type);
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
                //try
                //{
                //    XTextInputFieldElement reportendtable = (XTextInputFieldElement)myEditControl.GetElementById("ReportType");
                //    reportendtable.Focus();
                //    myEditControl.ExecuteCommand("MovePageUp", false, MoveTarget.PageHome);
                //}
                //catch { }

                //myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
                //myEditControl.ExecuteCommand("MovePageUp", false, null);
            }
            myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
            ShowDoctorImage();
            try
            {
                XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById("reportinfotable");
                XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                d_cell.Focus();
                myEditControl.ExecuteCommand("MoveTo", false, MoveTarget.CellHome);
            }
            catch { }
            //myEditControl.ExecuteCommand("MovePageUp", false, null);
            //else
            //{
            //    //System.IO.Stream s = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(CurPatReport.xmltext));
            //    //System.IO.StreamReader reader = new System.IO.StreamReader(s, Encoding.Default, true);
            //    //myEditControl.ExecuteCommand("FileOpen", false, reader);
            //    //myEditControl.LoadDocumentFromString(CurPatReport.xmltext, "xml");
            //    myEditControl.ExecuteCommand("FileOpen", false, localfiles[0].ToString());
            //}

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
                string d_GetValue = "";
                d_GetValue = setup_noSort_Dmb_Class.machinetypebycheckroom(CurPatexam.modality, CurPatexam.othercheck, CurPatexam.dep);
                if (d_GetValue == "")
                    d_GetValue = RisSetup_Class.GetINI("setup", CurPatexam.dep + "machinetype");
                CurPatexam.machinetype = d_GetValue;
            }
            Curoldadvancedoc = CurPatexam.advancedoc;
            string d_ReportType = "";
            if (CurPatexam.dep == "XRAY")
            {
                d_ReportType = "X线检查报告单";
            }
            else if (CurPatexam.dep == "CT")
            {
                d_ReportType = "CT检查报告单";
            }
            else if (CurPatexam.dep == "体检放射")
            {
                d_ReportType = "X线检查报告单";
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
            else if ((CurPatexam.dep == "PETCT") || (CurPatexam.dep == "ECT"))
            {
                d_ReportType = CurPatexam.checkpos + "检查报告单";
            }
            else
            {
                d_ReportType = "检查报告单";
            }
            CurPatregister.Age = CurPatregister.Age.ToUpper().Replace("Y", "岁").Replace("M", "月").Replace("D", "日").Replace("H", "时");
            myEditControl.SetDocumentParameterValue("hospitalname", Share_Class.hospital_name);
            myEditControl.SetDocumentParameterValue("secondhospitalname", Share_Class.Secondospital_name);
            myEditControl.SetDocumentParameterValue("accessno_code", CurPatexam.accessno);
            myEditControl.SetDocumentParameterValue("ReportType", d_ReportType);
            myEditControl.SetDocumentParameterValue("patexam", CurPatexam);
            myEditControl.SetDocumentParameterValue("patregister", CurPatregister);
        }
        private void btnRefreshTrackList_Click(object sender, EventArgs e)
        {
            this._TrackListControler.Refresh();
            myEditControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);
        }
        public override void OpenPacsImage()
        {
            base.OpenPacsImage();
            string p_OpenPacsType = RisSetup_Class.GetINI("setup", "OpenPacsType");
            patexam_Class d_patexam = new patexam_Class();
            //if (Report_XtraTabControl.SelectedTabPage == xtraTabPage2)
            //{
            //    d_patexam = new patexam_Class(clshistoryAccessno);
            //}
            //else
            d_patexam = CurPatexam;
            string d_Modality = d_patexam.modality;
            if (d_patexam.modality.Length > 2)
                d_Modality = d_patexam.modality.Substring(0, 2);
            if (p_OpenPacsType == "PIVIEW")
            {
                Share_Class.ShowPiviewPacsPicture(d_patexam.xno, d_patexam.Patient_id, d_patexam.accessno, d_Modality);
            }
            else
            {
                Share_Class.ShowPacsPicture(d_patexam.xno, d_patexam.Patient_id, CurPatregister.Match_Accessno, d_Modality);
            }
        }
        public override void FillTemplate(report_template_Class p_template)
        {
            try
            {
                string d_reportinfo = p_template.template_describle;
                string d_reportend = p_template.template_diag;
                if (p_template.xml_describle != "")
                {
                    d_reportinfo = p_template.xml_describle;
                }
                if (p_template.xml_diag != "")
                {
                    d_reportend = p_template.xml_diag;
                }
                InsertTemplate("reportinfotable", d_reportinfo);
                InsertTemplate("reportendtable", d_reportend);
                myEditControl.RefreshDocument();
            }
            catch { }


        }
        public override void FillTemplate(string d_reportinfo, string d_reportend)
        {

            try
            {
                InsertTemplate("reportinfotable", d_reportinfo);
                InsertTemplate("reportendtable", d_reportend);
                myEditControl.RefreshDocument();
            }
            catch { }

        }

        private void InsertTemplate(string p_name, string p_tempstr)
        {
            try
            {
                if (p_tempstr == "")
                    return;
                XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById(p_name);
                XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                d_cell.Focus();
                myEditControl.ExecuteCommand("MoveTo", false, MoveTarget.CellEnd);
                if (p_tempstr.IndexOf("XTextDocument") > -1)
                {
                    if (d_cell.Text.Trim() != "")
                        myEditControl.ExecuteCommand("InsertString", false, "\r\n ");

                    myEditControl.ExecuteCommand("InsertXML", true, p_tempstr);
                    XTextElementList elelist = d_cell.GetElementsByType(typeof(XTextParagraphFlagElement));

                    if (elelist[elelist.Count - 1] != null && elelist[elelist.Count - 1] is XTextParagraphFlagElement)
                    {
                        d_cell.Elements.Remove(elelist[elelist.Count - 1]);
                    }


                }
                else
                {
                    if (d_cell.Text.Trim() != "")
                        p_tempstr = "\r\n " + p_tempstr;
                    myEditControl.ExecuteCommand("InsertString", false, p_tempstr);
                }
            }
            catch { }

        }

        public override void Filldiag_word(string p_diag_word, string p_Table)
        {

            try
            {
                string tablename = "";

                if (p_Table == "DG_TEMPLATE_DESCRIBLE")
                {
                    //BL_HisText
                    tablename = "bltable";
                }
                else if (p_Table == "DG_TEMPLATE_DIAG")
                {
                    //reportend_RichTextBox 
                    tablename = "reportendtable";
                }
                else if (p_Table == "DG_TEMPLATE_MEGASCOPIC")
                {
                    //reportinfo_RichTextBox
                    tablename = "reportinfotable";
                }
                else if (p_Table == "DG_CLINICDIAGNOSE")
                {
                    tablename = "";
                    //clinicend_HisText  '临床诊断有时比较多需添加后面
                }
                else if (p_Table == "DG_REGISTERPART")
                {
                    //checkpos_ComboBoxEdit
                    tablename = "";
                }
                else
                {
                    tablename = "";
                }
                if (tablename != "")
                {
                    XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById(tablename);
                    try
                    {
                        XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                        d_cell.Focus();
                        myEditControl.ExecuteCommand("MoveTo", false, MoveTarget.CellEnd);
                        if (d_cell.Text.Trim() != "")
                            p_diag_word = "\r\n " + p_diag_word;
                        if (p_diag_word.IndexOf("XTextDocument") > -1)
                        {
                            myEditControl.ExecuteCommand("InsertXML", false, p_diag_word);
                        }
                        else
                        {
                            myEditControl.ExecuteCommand("InsertString", false, p_diag_word);
                        }
                    }

                    catch { }
                }
            }
            catch { }

        }
        private void FillClassByInputXML(ref patexam_Class p_Patexam, ref patregister_Class p_PatRegister)
        {

            myEditControl.ExecuteCommand("UpdateDataSourceForView", false, null);
            string d_xmltext = (string)myEditControl.ExecuteCommand("ViewXMLSource", false, null);
            p_Patexam = (patexam_Class)myEditControl.GetDocumnetParameterValue("patexam");
            p_PatRegister = (patregister_Class)myEditControl.GetDocumnetParameterValue("patregister");
            //CurPatReport.xmltext = d_xmltext;
            try
            {
                XTextTableElement reportinfotable = (XTextTableElement)myEditControl.GetElementById("reportinfotable");
                try
                {
                    XTextTableCellElement d_cell = reportinfotable.GetCell(0, 0, true);
                    CurPatexam.reportinfo = d_cell.Text;

                }
                catch { }
                XTextTableElement reportendtable = (XTextTableElement)myEditControl.GetElementById("reportendtable");
                try
                {
                    XTextTableCellElement d_cell = reportendtable.GetCell(0, 0, true);
                    CurPatexam.reportend = d_cell.Text;
                    //d_cell.ContentBuilder.AppendText(CurPatexam.reportend);
                }
                catch { }
                //string d_reportdisease = "";
                //for (int i = 0; i < reportdisease_CheckedListBoxControl.Items.Count; i++)
                //{
                //    if (reportdisease_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
                //        d_reportdisease += reportdisease_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
                //}
                //if (d_reportdisease != "")
                //    d_reportdisease = d_reportdisease.TrimEnd(new char[] { ',' });
                //p_Patexam.reportdisease = d_reportdisease;
                //string d_disease = "";
                //for (int i = 0; i < diseasetype_CheckedListBoxControl.Items.Count; i++)
                //{
                //    if (diseasetype_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
                //        d_disease += diseasetype_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
                //}
                //if (d_disease != "")
                //    d_disease = d_disease.TrimEnd(new char[] { ',' });
                //p_Patexam.diseasetype = d_disease;
            }
            catch { }
        }
        public override void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref patexam_Class p_patexam)
        {
            patregister_Class d_patregistr = new patregister_Class();
            FillClassByInputXML(ref p_patexam, ref d_patregistr);
            p_template_diag = p_patexam.reportend;
            p_template_describle = p_patexam.reportinfo;
        }
        public override void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref string p_template_part, ref string p_dep)
        {
            patregister_Class d_patregistr = new patregister_Class();
            patexam_Class p_patexam = new patexam_Class();
            FillClassByInputXML(ref p_patexam, ref d_patregistr);
            p_template_diag = p_patexam.reportend;
            p_template_describle = p_patexam.reportinfo;
            p_template_part = p_patexam.checkpos;
            //string d_reportdisease = this.ICD_10_ComboBoxEdit.Text.Trim();
            //if (d_reportdisease == "")
            //{
            //    for (int i = 0; i < reportdisease_CheckedListBoxControl.Items.Count; i++)
            //    {
            //        if (reportdisease_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
            //            d_reportdisease += reportdisease_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
            //    }
            //    if (d_reportdisease != "")
            //        d_reportdisease = d_reportdisease.TrimEnd(new char[] { ',' });
            //}

            //p_patexam.reportdisease = d_reportdisease;
            //string d_disease = diseasetype_ComboBoxEdit.Text.Trim();
            //if (d_disease == "")
            //{
            //    for (int i = 0; i < diseasetype_CheckedListBoxControl.Items.Count; i++)
            //    {
            //        if (diseasetype_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
            //            d_disease += diseasetype_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",";
            //    }
            //    if (d_disease != "")
            //        d_disease = d_disease.TrimEnd(new char[] { ',' });
            //}
            //p_patexam.diseasetype = d_disease;
        }

        #region 保存审核
        public override bool advance(string p_status)
        {
            //if (CurPatexam.dep != "DG")
            //{
            //    string d_check_status = "";
            //    if (CurPatexam.check_status == "已审核")
            //        d_check_status = "审核评价";
            //    else
            //        d_check_status = "书写评价";
            //    if (SaveReport_radiology(d_check_status) == false)
            //        return false;
            //    if (SaveQc_radiology("审核评价") == false)
            //        return false;
            //}
            //else
            //{
            //    SaveBitmap();
            //}
            patregister_Class d_patregistr = new patregister_Class();
            patexam_Class d_patexam = new patexam_Class();
            FillClassByInputXML(ref d_patexam, ref d_patregistr);

            if (d_patexam.reportdoc == "")
            {
                d_patexam.reportdoc = Share_Class.User.user_id;
                d_patexam.reportdoc_code = Share_Class.User.doctor_code;
            }
            //if (d_patexam.advancedoc == "")
            //{
            d_patexam.advancedoc_code = Share_Class.User.doctor_code;
            d_patexam.advancedoc = Share_Class.User.user_id;
            myEditControl.SetDocumentParameterValue("patexam", d_patexam);
            myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);

            //}
            d_patexam.Save_Advance(Curoldadvancedoc, p_status);
            base.ReBulid(d_patexam.accessno);
            ShowDoctorImage();
            SaveXmlFile();
            myEditControl.DocumentOptions.ViewOptions.FieldTextColor = Color.Black;
            myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");

            return true;
        }
        public override bool Save()
        {
            //if (CurPatexam.dep != "DG")
            //{
            //    if (SaveQc_radiology("书写评价") == false)
            //        return false;

            //}
            //else
            //{
            //    SaveBitmap();
            //}
            patregister_Class d_patregistr = new patregister_Class();
            patexam_Class d_patexam = new patexam_Class();
            FillClassByInputXML(ref d_patexam, ref d_patregistr);
            d_patexam.advancedoc = "";
            d_patexam.advancedoc_code = "";
            d_patexam.reportdoc = Share_Class.User.user_id;
            d_patexam.reportdoc_code = Share_Class.User.doctor_code;
            myEditControl.SetDocumentParameterValue("patexam", d_patexam);
            myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);

            d_patexam.Save_Report();
            base.ReBulid(d_patexam.accessno);
            ShowDoctorImage();
            SaveXmlFile();
            myEditControl.DocumentOptions.ViewOptions.FieldTextColor = Color.Black;
            myEditControl.ExecuteCommand("FileSaveAs", false, Share_Class.Dir + @"\xml\" + CurPatexam.checkdate.Date.ToString("yyyyMMdd") + @"\" + CurPatexam.accessno + ".xml");
            return true;
        }
        private void SaveXmlFile()
        {
            ReportXml_Class reportxml = new ReportXml_Class(CurPatexam.accessno);
            reportxml.accessno = CurPatexam.accessno;
            reportxml.stylename = d_reportform.image_ComboBoxEdit.Text.Trim();
            reportxml.xmlfile = myEditControl.Document.XMLText;
            reportxml.Save();
        }
        private void FillClassChange()
        {



        }
        #endregion

        public override void report_rewrite()
        {
            //machinetype_ComboBoxEdit.Text = "";
            //checktype_ComboBoxEdit.Text = "";

        }

        public void ShowUserPic()
        {

        }



        public override void PrintDocument(string d_PrintStatus)
        {
            if (myEditControl.Document.Modified == true)
            {
                ShowErr_Form d_form = new ShowErr_Form("该报告修改过，请先保存审核后再打印", "提示");
                d_form.ShowDialog();
                return;
            }
            myEditControl.DocumentOptions.ViewOptions.FieldTextColor = Color.Black;
            if (d_PrintStatus == "FilePrintPreview")
            {
                myEditControl.ExecuteCommand(d_PrintStatus, true, null);
            }
            else
            {
                myEditControl.ExecuteCommand(d_PrintStatus, false, null);
                patregister_Class.UpdatePrintStatus("已打印", CurPatexam.accessno);
            }
            myEditControl.DocumentOptions.ViewOptions.FieldTextColor = Color.Blue;

        }
        private SizeF[] imagesize(SizeF p_cellsize, int p_imageindex)
        {
            p_cellsize.Width = p_cellsize.Width - 100;
            p_cellsize.Height = p_cellsize.Height - 20;
            SizeF[] d_sizelist = new SizeF[p_imageindex];
            if ((CurPatexam.dep == "PETCT") || (CurPatexam.dep == "ECT"))
            {
                if (p_imageindex == 1)
                {
                    d_sizelist[0].Width = p_cellsize.Width;
                    d_sizelist[0].Height = p_cellsize.Height;
                }
                else if (p_imageindex == 2)
                {
                    d_sizelist[0].Width = p_cellsize.Width;
                    d_sizelist[0].Height = p_cellsize.Height / 2;
                    d_sizelist[1].Width = p_cellsize.Width;
                    d_sizelist[1].Height = p_cellsize.Height / 2;
                }
                else if (p_imageindex == 3)
                {
                    d_sizelist[0].Width = p_cellsize.Width;
                    d_sizelist[0].Height = p_cellsize.Height / 2;
                    d_sizelist[1].Width = p_cellsize.Width / 2;
                    d_sizelist[1].Height = p_cellsize.Height / 2;
                    d_sizelist[2].Width = p_cellsize.Width / 2;
                    d_sizelist[2].Height = p_cellsize.Height / 2;
                }
                else if (p_imageindex == 4)
                {
                    d_sizelist[0].Width = p_cellsize.Width / 2;
                    d_sizelist[0].Height = p_cellsize.Height / 2;
                    d_sizelist[1].Width = p_cellsize.Width / 2;
                    d_sizelist[1].Height = p_cellsize.Height / 2;
                    d_sizelist[2].Width = p_cellsize.Width / 2;
                    d_sizelist[2].Height = p_cellsize.Height / 2;
                    d_sizelist[3].Width = p_cellsize.Width / 2;
                    d_sizelist[3].Height = p_cellsize.Height / 2;
                }
            }
            else
            {
                if (p_imageindex == 1)
                {
                    d_sizelist[0].Width = p_cellsize.Width / 2;
                    d_sizelist[0].Height = p_cellsize.Height;
                }
                else if (p_imageindex == 2)
                {
                    d_sizelist[0].Width = p_cellsize.Width / 2;
                    d_sizelist[0].Height = p_cellsize.Height;
                    d_sizelist[1].Width = p_cellsize.Width / 2;
                    d_sizelist[1].Height = p_cellsize.Height;
                }
                else if (p_imageindex == 3)
                {
                    d_sizelist[0].Width = p_cellsize.Width / 2;
                    d_sizelist[0].Height = p_cellsize.Height / 2;
                    d_sizelist[1].Width = p_cellsize.Width / 2;
                    d_sizelist[1].Height = p_cellsize.Height / 2;
                    d_sizelist[2].Width = p_cellsize.Width / 2;
                    d_sizelist[2].Height = p_cellsize.Height / 2;
                }
                else if (p_imageindex == 4)
                {
                    d_sizelist[0].Width = p_cellsize.Width / 2;
                    d_sizelist[0].Height = p_cellsize.Height / 2;
                    d_sizelist[1].Width = p_cellsize.Width / 2;
                    d_sizelist[1].Height = p_cellsize.Height / 2;
                    d_sizelist[2].Width = p_cellsize.Width / 2;
                    d_sizelist[2].Height = p_cellsize.Height / 2;
                    d_sizelist[3].Width = p_cellsize.Width / 2;
                    d_sizelist[3].Height = p_cellsize.Height / 2;
                }
            }
            return d_sizelist;
        }

        public override void ImageAdd(string p_imagefile, string p_imagename, int p_imageindex)
        {

            string fileName = p_imagefile;
            if (System.IO.File.Exists(fileName))
            {
                Image img = Image.FromFile(fileName);
                XTextImageElement imgElement = new XTextImageElement();
                imgElement.ImageValue = img;
                //imgElement.Width = 600;
                //imgElement.Height = 600;
                imgElement.Text = p_imagename;
                imgElement.Title = p_imagename;
                imgElement.Tag = p_imagename;
                imgElement.Name = p_imagename;
                //XTextTableCellElement cell = table.GetCell(0, 0, true);
                //cell.Elements.Insert(0, imgElement);
                //table.EditorRefreshView();
                XTextTableElement imagetable = (XTextTableElement)myEditControl.GetElementById("imagetable");
                try
                {

                    XTextTableCellElement d_cell = imagetable.GetCell(0, 0, true);

                    SizeF[] d_sizelist = imagesize(d_cell.Size, p_imageindex);
                    XTextLabelElement d_strxtext = new XTextLabelElement();
                    d_strxtext.Text = " ";
                    XTextElementList eletextlist = d_cell.GetElementsByType(typeof(XTextImageElement));
                    if (CurPatexam.dep == "体检放射")
                    {

                        if (eletextlist.Count > 0)
                        {
                            try
                            {
                                if (eletextlist.Count % 2 == 0)
                                {
                                    //d_strxtext.Text = "\r\n";
                                    d_cell.Elements.Insert(d_cell.Elements.Count - 1, new XTextParagraphFlagElement());
                                }
                                else
                                {
                                    d_cell.Elements.Insert(d_cell.Elements.Count - 1, d_strxtext);
                                }
                                //d_cell.Elements.Insert(d_cell.Elements.Count - 1, d_strxtext);
                            }
                            catch { }
                        }
                    }
                    d_cell.Elements.Insert(d_cell.Elements.Count - 1, imgElement);
                    //try
                    //{
                    //    XTextElementList elelist = d_cell.GetElementsByType(typeof(XTextParagraphFlagElement));
                    //    for (int i = elelist.Count - 1; i >= 0; i--)
                    //    {
                    //        if (elelist[i] != null && elelist[i] is XTextParagraphFlagElement)
                    //        {
                    //            d_cell.Elements.Remove(elelist[i]);
                    //        }  
                    //        if (eletextlist.Count  > 0)
                    //        {
                    //            break;
                    //        }
                    //    }


                    //}
                    //catch { }
                    d_cell.Focus();
                    //d_cell.ContentVertialAlign = DCSoft.Drawing.VerticalAlignStyle.Middle;
                    //d_cell.Focused =true ;

                    myEditControl.ExecuteCommand("AlignCenter", false, null);
                    //imagetable.EditorRefreshView();
                    XTextElementList d_list = d_cell.GetElementsByType(typeof(XTextImageElement));
                    for (int i = 0; i < p_imageindex; i++)
                    {
                        XTextImageElement d_ele = (XTextImageElement)d_list[i];
                        d_ele.Width = d_sizelist[i].Width;
                        d_ele.Height = d_sizelist[i].Height;
                    }
                    d_cell.Focus();
                    myEditControl.ExecuteCommand("AlignCenter", false, null);
                    imagetable.EditorRefreshView();
                }
                catch { }
            }
        }
        public override void ImageDel(List<string> p_imagename, int p_count)
        {
            try
            {
                XTextTableElement imagetable = (XTextTableElement)myEditControl.GetElementById("imagetable");
                try
                {
                    XTextTableCellElement d_cell = imagetable.GetCell(0, 0, true);
                    SizeF[] d_sizelist = imagesize(d_cell.Size, p_count);
                    if (p_count == 0)
                    {
                        //d_cell.Elements.Clear();
                        for (int i = d_cell.Elements.Count - 1; i >= 0; i--)
                        {
                            if ((d_cell.Elements[i].TypeName.Trim() == "XTextImageElement") || (d_cell.Elements[i].TypeName.Trim() == "XTextLabelElement") || d_cell.Elements[i].TypeName.Trim() == "XTextParagraphFlagElement")
                            {
                                d_cell.Elements.RemoveAt(i);
                            }
                        }

                    }
                    else
                    {
                        for (int i = d_cell.Elements.Count - 1; i >= 0; i--)
                        {
                            if (d_cell.Elements[i].TypeName.Trim() == "XTextImageElement")
                            {
                                XTextImageElement imgElement = (XTextImageElement)d_cell.Elements[i];
                                if (p_imagename.Contains(imgElement.Tag.ToString()) == false)
                                {
                                    int j = i;
                                    if (i == 0)
                                    {
                                        j++;
                                    }
                                    else
                                    {
                                        j--;
                                    }
                                    if (d_cell.Elements[j].TypeName.Trim() == "XTextLabelElement" || d_cell.Elements[j].TypeName.Trim() == "XTextParagraphFlagElement")
                                    {
                                        d_cell.Elements.RemoveAt(j);
                                    }
                                    d_cell.Elements.Remove(imgElement);
                                }
                            }

                        }

                    }
                    //d_cell.
                    d_cell.Focus();
                    myEditControl.ExecuteCommand("AlignCenter", true, null);
                    XTextElementList d_list = d_cell.GetElementsByType(typeof(XTextImageElement));
                    for (int i = 0; i < p_count; i++)
                    {
                        XTextImageElement d_ele = (XTextImageElement)d_list[i];
                        d_ele.Width = d_sizelist[i].Width;
                        d_ele.Height = d_sizelist[i].Height;
                    }
                    imagetable.EditorRefreshView();


                }
                catch { }
            }
            catch { }


        }

        public override void ReCreateReportStyle(string p_type)
        {
            string d_reportinfo = CurPatexam.reportinfo;
            string d_reportend = CurPatexam.reportend;
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

                }
                catch { }

            }
            catch { }

            string fileName = GetReportStyleFile(p_type);
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
            FillTemplate(d_reportinfo, d_reportend);
            myEditControl.ExecuteCommand("UpdateViewForDataSource", false, null);
            ShowDoctorImage();
        }
        private string GetReportStyleFile(string p_type)
        {
            string fileName = "";
            string p_dep = CurPatexam.dep;
            if (CurPatexam.dep == "内窥镜")
            {
                p_dep = "ES";
            }
            fileName = CurPatexam.dep + "report";
            if (p_type != "")
            {
                fileName = fileName + "_" + p_type;
            }
            fileName = fileName + ".xml";
            fileName = Share_Class.Dir + @"\xmlStyle\" + fileName;
            if (File.Exists(fileName) == false)
            {
                flog_Class.WriteFlog("无法找到样式：" + fileName, Share_Class.Dir + @"\log");
                fileName = Share_Class.Dir + @"\xmlStyle\report.xml";
            }
            return fileName;
        }
        private FlagXTextRangeProvider provider = new FlagXTextRangeProvider();
        private DataSourceTreeViewControler dstvControler = null;
        private void myEditControl_SelectionChanged(object eventSender, WriterEventArgs args)
        {

            provider.Document = myEditControl.Document;
            provider.Prefix = '{';
            provider.Endfix = '}';
            XTextRange range = provider.GetRange(myEditControl.CurrentElement);
            if (range != null)
            {
                myEditControl.HighlightRange = new HighlightInfo(range);
            }
            else
            {
                myEditControl.HighlightRange = null;
            }


            SetContextMenu();

            if (this.dstvControler != null)
            {
                this.dstvControler.UpdateCurrentDataSourceNode(myEditControl);
            }
            //this.Text = myEditControl.CaretPosition.ToString();
        }
        /// <summary>
        /// 设置编辑器控件的快捷菜单
        /// </summary>
        private void SetContextMenu()
        {
            //this.myEditControl.ContextMenuStrip = null;
            //return;

            if (Math.Abs(myEditControl.Selection.Length) == 1)
            {
                XTextElement element = this.myEditControl.Selection.ContentElements[0];
                if (element is XTextImageElement)
                {
                    this.myEditControl.ContextMenuStrip = this.cmImage;
                    return;
                }
            }
            bool isInCell = false;
            if (myEditControl.Selection.Cells != null && myEditControl.Selection.Cells.Count > 0)
            {
                isInCell = true;
            }
            else
            {
                XTextContainerElement c = null;
                int index = 0;
                myEditControl.Document.Content.GetCurrentPositionInfo(out c, out index);
                if (c is XTextTableCellElement || c.OwnerCell != null)
                {
                    isInCell = true;
                }
            }
            if (isInCell)
            {
                myEditControl.ContextMenuStrip = cmTableCell;
                return;
            }
            myEditControl.ContextMenuStrip = cmEdit;
        }
        private void ShowDoctorImage()
        {
            try
            {
                string d_value = "yes";
                d_value = RisSetup_Class.GetINI_Oracle(CurPatexam.dep, "reportdocimage");
                if (d_value == "yes")
                {
                    Image d_repotrimage = Userinfo_Class.GetUserImage(CurPatexam.reportdoc, CurPatregister.reportdoc_code);
                    if (d_repotrimage != null)
                    {

                        XTextInputFieldElement input_reportdoc = (XTextInputFieldElement)myEditControl.GetElementById("reportdoc");
                        input_reportdoc.Elements.Clear();
                        XTextImageElement imageElement = new XTextImageElement();
                        imageElement.OwnerDocument = this.myEditControl.Document;
                        imageElement.ImageValue = d_repotrimage;
                        imageElement.Width = input_reportdoc.Width;
                        imageElement.Height = (input_reportdoc.Height * d_repotrimage.Height) / input_reportdoc.Width;
                        input_reportdoc.Elements.Add(imageElement);
                        input_reportdoc.EditorRefreshView();
                    }
                    else
                        flog_Class.WriteFlog("无签名图像", Share_Class.Dir + "\\log");
                }
                else if (d_value == "")
                    RisSetup_Class.WriteINI_Oracle(CurPatexam.dep, "reportdocimage", "no");

                d_value = RisSetup_Class.GetINI_Oracle(CurPatexam.dep, "advancedocimage");
                if (d_value == "yes")
                {
                    Image d_firadvancedoc = Userinfo_Class.GetUserImage(CurPatregister.firadvancedoc, "");
                    Image d_repotrimage = Userinfo_Class.GetUserImage(CurPatexam.advancedoc, CurPatregister.advancedoc_code);
                    if ((d_repotrimage != null) || (d_firadvancedoc != null))
                    {
                        XTextInputFieldElement input_reportdoc = (XTextInputFieldElement)myEditControl.GetElementById("advancedoc");
                        input_reportdoc.Elements.Clear();
                        float d_width = input_reportdoc.Width;
                        if ((d_repotrimage != null) && (d_firadvancedoc != null))
                            d_width = d_width / 2;
                        if (d_firadvancedoc != null)
                        {
                            XTextImageElement imageElement = new XTextImageElement();
                            imageElement.OwnerDocument = this.myEditControl.Document;
                            imageElement.ImageValue = d_firadvancedoc;
                            imageElement.Width = d_width;
                            imageElement.Height = (input_reportdoc.Height * d_firadvancedoc.Height) / d_width;
                            input_reportdoc.Elements.Add(imageElement);
                        }
                        if (d_repotrimage != null)
                        {
                            XTextImageElement imageElement = new XTextImageElement();
                            imageElement.OwnerDocument = this.myEditControl.Document;
                            imageElement.ImageValue = d_repotrimage;
                            imageElement.Width = d_width;
                            imageElement.Height = (input_reportdoc.Height * d_repotrimage.Height) / d_width;
                            input_reportdoc.Elements.Add(imageElement);
                        }
                        input_reportdoc.EditorRefreshView();
                    }
                    else
                        flog_Class.WriteFlog("无签名图像", Share_Class.Dir + "\\log");
                }
                else if (d_value == "")
                    RisSetup_Class.WriteINI_Oracle(CurPatexam.dep, "advancedocimage", "yes");
            }
            catch (Exception ex) { flog_Class.WriteFlog("电子签名：" + ex.Message, Share_Class.Dir + "\\log"); }

        }

    }

}
