using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TMKEASY.RISReport
{
    public partial class Report_Layout_Form : BaseReport_Form
    {
        public Report_Layout_Form()
        {
            InitializeComponent();
        }
        public Report_Layout_Form(string p_accessno)
            : base(p_accessno)
        {
            InitializeComponent();
            InitForm();
        }

        HISItemText.HISItemText reportend_RichTextBox = new HISItemText.HISItemText();
        HISItemText.HISItemText reportinfo_RichTextBox = new HISItemText.HISItemText();


        private string[,][] InitFormNOTByXML()
        {
            string[,][] d_controllist = new string[4, 4][];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; i < 4; i++)
                {
                    d_controllist[i, j] = new string[] { "" };
                }
            }
            d_controllist[0, 0] = new string[] { "影 像 号：", "xno", "TextEdit", "false" };
            d_controllist[1, 0] = new string[] { "姓    名：", "name", "TextEdit", "false" };
            d_controllist[2, 0] = new string[] { "年    龄：", "age", "TextEdit", "false" };
            d_controllist[3, 0] = new string[] { "性    别：", "Sex", "TextEdit", "false" };
            d_controllist[0, 1] = new string[] { "检查日期：", "checkdate", "ComboBoxEdit", "false" };
            d_controllist[1, 1] = new string[] { "申请科室：", "sqdep", "ComboBoxEdit", "false" };
            d_controllist[2, 1] = new string[] { "床    号：", "bedno", "TextEdit", "false" };
            d_controllist[3, 1] = new string[] { "报告医生：", "reportdoc", "ComboBoxEdit", "false" };
            d_controllist[0, 2] = new string[] { "机器型号：", "machinetype", "ComboBoxEdit", "false" };
            d_controllist[1, 2] = new string[] { "检查部位：", "checkpos", "ComboBoxEdit", "false" };
            d_controllist[2, 2] = new string[] { "成像方位：", "imagepos", "ComboBoxEdit", "false" };
            d_controllist[3, 2] = new string[] { "成像方法：", "imagemethod", "ComboBoxEdit", "false" };
            d_controllist[0, 3] = new string[] { "扫描方式：", "checktype", "ComboBoxEdit", "false" };
            d_controllist[1, 3] = new string[] { "层    厚：", "layerthick", "ComboBoxEdit", "false" };
            d_controllist[2, 3] = new string[] { "层 间 隔：", "layerinterval", "ComboBoxEdit", "false" };
            d_controllist[3, 3] = new string[] { "报告医生：", "radio_doctor", "ComboBoxEdit", "false" };
            return d_controllist;
        }
        private string[,][] InitFormByXML(ref int p_row, ref int p_column)
        {
            try
            {
                XmlDocument d_xml = new System.Xml.XmlDocument();
                d_xml.Load(@"config\ReportList.xml");


                string d_ColumnNum = "";
                try
                {
                    d_ColumnNum = d_xml.SelectSingleNode("XmlDocument/ColumnNum").InnerText;
                    p_column = Convert.ToInt32(d_ColumnNum);
                }
                catch (Exception ex)
                {
                    p_column = 4;
                }

                int d_columncount = 0;

                try
                {
                    d_columncount = d_xml.SelectSingleNode("XmlDocument/ColumnData").ChildNodes.Count;
                    p_row = d_columncount / p_column;
                    if (d_columncount % p_column != 0)
                    {
                        p_row++;
                    }
                }
                catch (Exception ex)
                {

                }
                if (d_columncount == 0)
                {
                    return null;
                }
                string[,][] d_controllist = new string[p_row - 1, p_column - 1][];
                //string d_controllist[p_row - 1, p_column - 1][]=new string [,][]{}   ;
                for (int i = 0; i < p_row; i++)
                {
                    for (int j = 0; i < p_column; i++)
                    {
                        d_controllist[i, j] = new string[] { "" };
                    }
                }
                for (int i = 0; i < d_columncount; i++)
                {

                    XmlNode d_itemnode = d_xml.SelectSingleNode("XmlDocument/ColumnData").ChildNodes[i];
                    try
                    {
                        int temprow = Convert.ToInt32(d_itemnode.SelectSingleNode("RowIndex").InnerText);
                        int tempcolumn = Convert.ToInt32(d_itemnode.SelectSingleNode("ColumnIndex").InnerText);
                        d_controllist[temprow, tempcolumn] = new string[] { d_itemnode.SelectSingleNode("Caption").InnerText + ":", d_itemnode.SelectSingleNode("English").InnerText, d_itemnode.SelectSingleNode("ItemType").InnerText, d_itemnode.SelectSingleNode("ReadOnly").InnerText };
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return d_controllist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void InitForm()
        {

            //  'LayoutControl1.RestoreLayoutFromXml("")
            DevExpress.XtraLayout.LayoutControlItem d_LayoutItem_new = new DevExpress.XtraLayout.LayoutControlItem();
            DevExpress.XtraLayout.LayoutControlItem d_LayoutItem_old = new DevExpress.XtraLayout.LayoutControlItem();
            DevExpress.XtraEditors.BaseEdit d_textedit = new DevExpress.XtraEditors.BaseEdit();
            int d_row = 0;
            int d_column = 0;
            LayoutControlGroup1.AllowCustomizeChildren = false;
            string[,][] d_controllist = InitFormByXML(ref d_row, ref  d_column);
            if (d_controllist == null)
            {
                d_controllist = InitFormNOTByXML();
                d_row = 4;
                d_column = 4;
            }
            for (int i = 0; i < d_row; i++)
            {
                for (int j = 0; i < d_column; i++)
                {

                    string[] d_control = d_controllist[i, j];
                    if (d_control.Length > 1)
                    {
                        d_LayoutItem_new = new DevExpress.XtraLayout.LayoutControlItem();

                        if (d_control[2] == "TextEdit")
                        {
                            d_textedit = new DevExpress.XtraEditors.TextEdit();
                        }
                        else
                        {
                            d_textedit = new DevExpress.XtraEditors.ComboBoxEdit();
                            d_textedit.GotFocus += new EventHandler(TextChangeDmb_ComboBoxEdit_GotFocus);

                        }
                        if (d_control[3] == "true")
                        {
                            d_textedit.Properties.ReadOnly = true;
                        }
                        else
                        {
                            d_textedit.Properties.ReadOnly = false;
                        }
                        d_textedit.Name = d_control[1].ToString().ToLower() + "-" + d_control[2].ToString();
                        d_LayoutItem_new.Name = d_control[1].ToString().ToLower() + "-LayoutControlItem";
                        d_LayoutItem_new.Control = d_textedit;
                        d_LayoutItem_new.Text = d_control[0];
                        if (d_LayoutItem_old == null)
                        {
                            d_LayoutItem_new = LayoutControlGroup1.AddItem(d_LayoutItem_new);
                        }
                        else
                        {
                            d_LayoutItem_new = LayoutControlGroup1.AddItem(d_LayoutItem_new, d_LayoutItem_old, DevExpress.XtraLayout.Utils.InsertType.Right);
                        }
                        d_LayoutItem_old = d_LayoutItem_new;
                    }
                }

                d_LayoutItem_old = null;
            }
            int d_Height = 0;
            foreach (DevExpress.XtraLayout.LayoutControlItem d_LayoutItem in LayoutControlGroup1.Items)
            {
                d_LayoutItem.Size = new System.Drawing.Size(Width / d_column, d_LayoutItem.Size.Height);
                d_Height += d_LayoutItem.Size.Height;
            }


            DevExpress.XtraLayout.LayoutControlGroup d_report = new DevExpress.XtraLayout.LayoutControlGroup();
            d_report = LayoutControl1.Root.AddGroup();
            d_report.Text = "报告信息";
            d_LayoutItem_new = new DevExpress.XtraLayout.LayoutControlItem();
            //'d_LayoutItem_new = LayoutControlGroup1.AddItem();
            reportinfo_RichTextBox = new HISItemText.HISItemText();
            reportinfo_RichTextBox.Name = "reportinfo_RichTextBox";
            d_LayoutItem_new.Control = reportinfo_RichTextBox;
            d_LayoutItem_new.Text = "诊断描述：";
            // 'd_LayoutItem_new.Size = new Drawing.Size(Width, (Height - d_Height / 3) / 2);
            d_LayoutItem_new.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            d_LayoutItem_new = d_report.AddItem(d_LayoutItem_new);

            d_LayoutItem_old = new DevExpress.XtraLayout.LayoutControlItem();
            // 'd_LayoutItem_new = LayoutControlGroup1.AddItem
            reportend_RichTextBox = new HISItemText.HISItemText();
            reportend_RichTextBox.Name = "reportend_RichTextBox";
            d_LayoutItem_old.Control = reportend_RichTextBox;
            d_LayoutItem_old.Text = "诊断结论：";
            d_LayoutItem_old.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            // 'd_LayoutItem_old.Size = new Drawing.Size(Width, (Height - d_Height / 3) / 2);
            d_LayoutItem_old = d_report.AddItem(d_LayoutItem_old, d_LayoutItem_new, DevExpress.XtraLayout.Utils.InsertType.Bottom);

        }


        private void FillConfigByXML()
        {

        }

        private void Report_Layout_Form_Load(Object sender, EventArgs e)
        {
            Init_List();
            FillInputByClass();
        }



        #region Combobox的事件
        private void TextChangeDmb_ComboBoxEdit_GotFocus(Object sender, EventArgs e)
        {

            FillComboBoxEdit((DevExpress.XtraEditors.ComboBoxEdit)sender);
        }

        private void FillComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit p_combobox)
        {
            if (p_combobox.Properties.Items.Count > 0)
            {// '如果下拉框中已有内容,就会退出
                return;
            }

            DataSet ds = new DataSet();
            string d_Field = "";
            if (p_combobox.Name == "machinetype-ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("machinetype");
                d_Field = "machinetype";
            }
            else if (p_combobox.Name == "sqdep-ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("sqdep");
                d_Field = "sqdep";
            }
            else if (p_combobox.Name == "layerthick-ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("smthick");
                d_Field = "smthick";
            }
            else if (p_combobox.Name == "layerinterval_ComboBoxEdit")
            {
                ds = setup_noSort_Dmb_Class.GetAll("sminternal");
                d_Field = "sminterval";
            }
            else if (p_combobox.Name == "checkpos-ComboBoxEdit")
            {
                //'ds = setup_registerpart_Dmb_Class.Getchildpart;
                //'d_Field = "childpart";
            }
            if (ds == null)
            {
                return;
            }
            //   '填充数据库中调出的项()

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                p_combobox.Properties.Items.Add(ds.Tables[0].Rows[i][d_Field]);
            }

        }
        #endregion

        Dictionary<string, string> d_patientlist = new Dictionary<string, string>();
        private void Init_List()
        {

            patregister_Class d_PatRegister = new patregister_Class(CurPatexam.patid); //'得到病人信息
            if (CurPatexam.reportdoc.Trim() == "")
            {// '如果报告医生为空,表示是第一次报告编辑,把当前用户设置成报告医生
                d_patientlist.Add("reportdoc", Share_Class.User.user_id);
            }
            else
            {
                d_patientlist.Add("reportdoc", CurPatexam.reportdoc.Trim());
            }
            if (CurPatexam.reportdate.Year == 1900)
            {// '如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                CurPatexam.reportdate = Share_Class.GetSysdate();
            }
            if (CurPatexam.modcheckdate.Year == 1900)
            {// '如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                CurPatexam.modcheckdate = Share_Class.GetSysdate();
            }
            if (CurPatexam.machinetype == "")
            {
                string d_GetValue = "";
                //d_GetValue = setup_check_room_Dmb_Class.machinetypebycheckroom(CurPatexam.modality, CurPatexam.othercheck, CurPatexam.dep);
                if (d_GetValue == "")
                {
                    d_GetValue = RisSetup_Class.GetINI("setup", "CTmachinetype");
                    CurPatexam.machinetype = d_GetValue;
                }
            }
            d_patientlist.Add("modcheckdate", CurPatexam.modcheckdate.ToString().Trim());
            d_patientlist.Add("age", d_PatRegister.Age.ToString().Trim());
            // '  d_patientlist.Add("machinetype", .machinetype.ToString().Trim());
            d_patientlist.Add("name", d_PatRegister.Name.ToString().Trim());
            d_patientlist.Add("sex", d_PatRegister.Sex.ToString().Trim());
            d_patientlist.Add("sqdep", CurPatexam.sqdep.ToString().Trim());
            d_patientlist.Add("checktype", CurPatexam.checktype.ToString().Trim());
            // ' d_patientlist.Add("checktype", .checktype.ToString().Trim());
            d_patientlist.Add("clinicend", CurPatexam.clinicend.ToString().Trim());
            d_patientlist.Add("bedNo", CurPatexam.BedNo.ToString().Trim());
            d_patientlist.Add("layerthick", CurPatexam.layerthick.ToString().Trim());
            d_patientlist.Add("xno", CurPatexam.xno.ToString().Trim());
            d_patientlist.Add("checkpos", CurPatexam.checkpos.ToString().Trim());
            d_patientlist.Add("layerinterval", CurPatexam.layerinterval.ToString().Trim());
            d_patientlist.Add("reportinfo", CurPatexam.reportinfo.ToString().Trim());
            d_patientlist.Add("reportend", CurPatexam.reportend.ToString().Trim());
            d_patientlist.Add("machinetype", CurPatexam.machinetype.ToString().Trim());
            //' d_patientlist.Add("modcheckdate", .modcheckdate.ToString.Trim)
            //' d_patientlist.Add("modcheckdate", .modcheckdate.ToString.Trim)       




        }
        private void FillInputByClass()
        {

            for (int i = 0; i < LayoutControl1.Items.Count; i++)
            {
                if (LayoutControl1.Items[i].TypeName.ToString().IndexOf("LayoutControlItem") > -1)
                {
                    DevExpress.XtraLayout.LayoutControlItem d_LayoutItem = (DevExpress.XtraLayout.LayoutControlItem)LayoutControl1.Items[i];
                    string d_name = d_LayoutItem.Name.ToString().Trim();
                    string[] str = d_name.Split(new char[] { '-' });
                    try
                    {
                        d_LayoutItem.Control.Text = d_patientlist[str[0]];
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            reportend_RichTextBox.Rtf = d_patientlist["reportend"].ToString();
            reportinfo_RichTextBox.Rtf = d_patientlist["reportinfo"].ToString();


        }


        public override bool Save()
        {

            FillClassByInput();
            return CurPatexam.Save_Report();
        }

        public override bool advance(string p_status)
        {

            FillClassByInput();
            return CurPatexam.Save_Advance("", p_status);
        }
        private void FillClassByInput()
        {
            Dictionary<string, string> d_patientlist = new Dictionary<string, string>();
            for (int i = 0; i < LayoutControl1.Items.Count; i++)
            {
                if (LayoutControl1.Items[i].TypeName.ToString().IndexOf("LayoutControlItem") > -1)
                {
                    DevExpress.XtraLayout.LayoutControlItem d_LayoutItem = (DevExpress.XtraLayout.LayoutControlItem)LayoutControl1.Items[i];
                    string d_name = d_LayoutItem.Name.ToString().Trim();
                    string[] str = d_name.Split(new char[] { '-' });
                    try
                    {
                        //  'd_LayoutItem.Control.Text = d_patientlist[str(0))
                        d_patientlist[str[0]] = d_LayoutItem.Control.Text.ToString().Trim();
                        //  '  d_patientlist.Add(d_patientlist[str(0)), d_LayoutItem.Control.Text.ToString())
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            try
            {
                reportinfo_RichTextBox.SelectionStart = reportinfo_RichTextBox.SelectionStart - 1;

            }
            catch (Exception ex)
            {
                reportinfo_RichTextBox.SelectionStart = 2;
            }

            CurPatexam.reportinfo = reportinfo_RichTextBox.FactText.Replace("'", "''");
            try
            {
                reportend_RichTextBox.SelectionStart = reportend_RichTextBox.SelectionStart - 1;

            }
            catch (Exception ex)
            {
                reportend_RichTextBox.SelectionStart = 2;
            }

            if (reportend_RichTextBox.Text != "")
            {
                CurPatexam.reportend = reportend_RichTextBox.FactText.Replace("'", "''").Trim();
            }
            else
            {
                CurPatexam.reportend = reportend_RichTextBox.FactText.ToString().Trim();
            }
            CurPatexam.reportdoc = d_patientlist["reportdoc"].ToString().Trim();
            CurPatexam.modcheckdate = Convert.ToDateTime(d_patientlist["modcheckdate"].ToString().Trim());
            CurPatexam.machinetype = d_patientlist["machinetype"].ToString().Trim();
            CurPatexam.sqdep = d_patientlist["sqdep"].ToString().Trim();
            CurPatexam.checktype = d_patientlist["checktype"].ToString().Trim();
            CurPatexam.clinicend = d_patientlist["clinicend"].ToString().Trim();
            CurPatexam.BedNo = d_patientlist["BedNo"].ToString().Trim();
            CurPatexam.layerthick = d_patientlist["layerthick"].ToString().Trim();
            // '.xno = Convert.ToInt32(xno_TextEdit.Text.Trim)
            CurPatexam.xno = d_patientlist["xno"].ToString().Trim();
            CurPatexam.checkpos = d_patientlist["checkpos"].ToString().Trim();
            CurPatexam.layerinterval = d_patientlist["layerinterval"].ToString().Trim();

        }
        public override void report_rewrite()
        {
            //'machinetype_ComboBoxEdit.Text = ""
            //'checktype_ComboBoxEdit.Text = ""
            //'clinicend_TextEdit.Text = ""
            //'layerthick_ComboBoxEdit.Text = ""
            //'checkpos_ComboBoxEdit.Text = ""
            //'layerinterval_ComboBoxEdit.Text = ""
        }


        public override void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref string p_template_part, ref string p_dep)
        {
            p_template_diag = reportend_RichTextBox.FactText;
            p_template_describle = reportinfo_RichTextBox.FactText;
            p_template_part = "";// checkpos_ComboBoxEdit.Text.Trim();
            p_dep = CurPatexam.dep;
        }
        public override void FillTemplate(template_Class p_template)
        {

            if (reportinfo_RichTextBox.Rtf == "")
            {
                reportinfo_RichTextBox.Rtf = p_template.template_describle;
            }
            else
            {
                reportinfo_RichTextBox.AppendItemText("\r\n" + p_template.template_describle, true);
            }
            if (reportend_RichTextBox.Rtf == "")
            {
                reportend_RichTextBox.Rtf = p_template.template_diag;
            }
            else
            {
                reportend_RichTextBox.AppendItemText("\r\n" + p_template.template_diag, true);
            }
        }

        public override void FillTemplate(string p_template_describle, string p_template_diag)
        {

            if (reportinfo_RichTextBox.Rtf == "")
            {
                reportinfo_RichTextBox.Rtf = p_template_describle;
            }
            else
            {
                reportinfo_RichTextBox.AppendItemText("\r\n" + p_template_describle, true);
            }
            if (reportend_RichTextBox.Rtf == "")
            {
                reportend_RichTextBox.Rtf = p_template_diag;
            }
            else
            {
                reportend_RichTextBox.AppendItemText("\r\n" + p_template_diag, true);
            }
        }


    }
}