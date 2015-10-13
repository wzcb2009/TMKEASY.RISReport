using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class Report_RIS_Form : BaseReport_Form
    {
        public Report_RIS_Form()
        {
            InitializeComponent();
        }
        public Report_RIS_Form(string p_accessno)
            : base(p_accessno)
        {
            InitializeComponent();
            FillInputByClass();
        }


        public Report_RIS_Form(patexam_Class p_Patexam)
            : base(p_Patexam)
        {
            InitializeComponent();
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

        public override bool Save()
        {
            if (checktype_ComboBoxEdit.Text.Trim() == "")
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("扫描方式未填", "错误");
                d_ErrForm.ShowDialog();

                checktype_ComboBoxEdit.Focus();
                return false;
            }

            FillClassByInput();
            return CurPatexam.Save_Report();
        }

        public override bool advance(string p_status)
        {
            if (checktype_ComboBoxEdit.Text.Trim() == "")
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("扫描方式未填", "错误");
                d_ErrForm.ShowDialog();

                checktype_ComboBoxEdit.Focus();
                return false;
            }
            FillClassByInput();
            return CurPatexam.Save_Advance("", p_status);
        }

        public override void report_rewrite()
        {
            machinetype_ComboBoxEdit.Text = "";
            checktype_ComboBoxEdit.Text = "";
            clinicend_TextEdit.Text = "";
            layerthick_ComboBoxEdit.Text = "";
            checkpos_ComboBoxEdit.Text = "";
            layerinterval_ComboBoxEdit.Text = "";
        }

        public override void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref string p_template_part, ref string p_dep)
        {
            p_template_diag = reportend_RichTextBox.FactText;
            p_template_describle = reportinfo_RichTextBox.FactText;
            p_template_part = checkpos_ComboBoxEdit.Text.Trim();
            p_dep = CurPatexam.dep;
        }

        private void FillInputByClass()
        {

            patregister_Class d_PatRegister = new patregister_Class(CurPatexam.patid);// '得到病人信息
            if (CurPatexam.reportdoc.Trim() == "")
            {// '如果报告医生为空,表示是第一次报告编辑,把当前用户设置成报告医生
                reportdoc_TextEdit.Text = Share_Class.User.user_id;
            }
            else
            {
                reportdoc_TextEdit.Text = CurPatexam.reportdoc.Trim();
            }

            if (CurPatexam.reportdate.Year == 1900)
            {// '如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                CurPatexam.reportdate = Share_Class.GetSysdate();
            }

            if (CurPatexam.modcheckdate.Year == 1900)
            { //'如果报告时间为1900,表示是第一次报告编辑,把当前时间设置成报告时间
                modcheckdate_ComboBoxEdit.Text = Share_Class.GetSysdate().ToString("yyyy-MM-dd");
            }
            else
            {
                modcheckdate_ComboBoxEdit.Text = CurPatexam.modcheckdate.ToString("yyyy-MM-dd");
                modcheckdate_ComboBoxEdit.Enabled = false;
            }
            machinetype_ComboBoxEdit.Text = CurPatexam.machinetype.Trim();
            Name_TextEdit.Text = d_PatRegister.Name.Trim();
            Sex_TextEdit.Text = d_PatRegister.Sex.Trim();
            Age_TextEdit.Text = d_PatRegister.Age.Trim();
            sqdep_ComboBoxEdit.Text = CurPatexam.sqdep.Trim();
            if (CurPatexam.checktype.Trim() == "")
            {
                checktype_ComboBoxEdit.Text = "平扫";
            }
            else
            {
                checktype_ComboBoxEdit.Text = CurPatexam.checktype.Trim();
            }
            checktype_ComboBoxEdit.Text = CurPatexam.checktype.Trim();
            clinicend_TextEdit.Text = CurPatexam.clinicend.Trim();
            bedno_TextEdit.Text = CurPatexam.BedNo.Trim();
            layerthick_ComboBoxEdit.Text = CurPatexam.layerthick.Trim();
            xno_TextEdit.Text = CurPatexam.xno.ToString().Trim();
            checkpos_ComboBoxEdit.Text = CurPatexam.checkpos.Trim();
            layerinterval_ComboBoxEdit.Text = CurPatexam.layerinterval.Trim();
            reportinfo_RichTextBox.Rtf = CurPatexam.reportinfo;

            reportend_RichTextBox.Rtf = CurPatexam.reportend;


            if (CurPatexam.machinetype != "")
            {
                machinetype_ComboBoxEdit.Text = CurPatexam.machinetype.Trim();
            }
            else
            {
                string d_GetValue = "";
                //d_GetValue = setup_check_room_Dmb_Class.machinetypebycheckroom(CurPatexam.modality,CurPatexam .othercheck, CurPatexam.dep);
                if (d_GetValue == "")
                {
                    d_GetValue = RisSetup_Class.GetINI("setup", "CTmachinetype");
                }
                machinetype_ComboBoxEdit.Text = d_GetValue;
            }

        }

        private void FillClassByInput()
        {


            CurPatexam.reportdoc = reportdoc_TextEdit.Text.Trim();
            CurPatexam.modcheckdate = Convert.ToDateTime(modcheckdate_ComboBoxEdit.Text.Trim());
            CurPatexam.machinetype = machinetype_ComboBoxEdit.Text.Trim();
            CurPatexam.sqdep = sqdep_ComboBoxEdit.Text.Trim();
            CurPatexam.checktype = checktype_ComboBoxEdit.Text.Trim();
            CurPatexam.clinicend = clinicend_TextEdit.Text.Trim();
            CurPatexam.BedNo = bedno_TextEdit.Text.Trim();
            CurPatexam.layerthick = layerthick_ComboBoxEdit.Text.Trim();

            CurPatexam.xno = xno_TextEdit.Text.Trim();
            CurPatexam.checkpos = checkpos_ComboBoxEdit.Text.Trim();
            CurPatexam.layerinterval = layerinterval_ComboBoxEdit.Text.Trim();
            CurPatexam.reportinfo = reportinfo_RichTextBox.FactText;
            CurPatexam.reportend = reportend_RichTextBox.FactText;

        }

        private void report_ct_form_Load(Object sender, EventArgs e)
        {
            //  '时间
            modcheckdate_ComboBoxEdit.Properties.Items.Add(Share_Class.GetSysdate().ToString("yyyy-MM-dd"));
            modcheckdate_ComboBoxEdit.Properties.Items.Add(Share_Class.GetSysdate().AddDays(-1).ToString("yyyy-MM-dd"));
            modcheckdate_ComboBoxEdit.Properties.Items.Add(Share_Class.GetSysdate().AddDays(-2).ToString("yyyy-MM-dd"));
            modcheckdate_ComboBoxEdit.Properties.Items.Add(Share_Class.GetSysdate().AddDays(-3).ToString("yyyy-MM-dd"));
            reportdoc_TextEdit.Focus();
        }



        //#region "回车和标题变红"
        //  //  '当回车时,进到下一个控件
        //    private void base_TextEdit_KeyPress(     Object sender,  KeyPressEventArgs e) 
        //    {
        //         if ( Asc(e.KeyChar) == 13 ){
        //            ContralGetFocusByEnter(sender, PanelControl1.Controls);
        //       }
        //   }

        //   // private void layerinterval_ComboBoxEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles layerinterval_ComboBoxEdit.KeyPress
        //   //      if ( Asc(e.KeyChar) = 13 ){
        //   //         reportinfo_RichTextBox.Focus()
        //   //    }
        //   //}

        //    private void ContralGetFocusByEnter( Control p_CurControl,  Control.ControlCollection p_Controls){
        //        int  d_NextTab   = p_CurControl.TabIndex + 1;// '得到下一个控件的TabIndex

        //        Control d_NextControl ; //'下一个得到焦点控件
        //        for(int  i = 0 ;i< p_Controls.Count ;i++)
        //            d_NextControl = p_Controls[i];
        //             if ( d_NextControl.TabIndex == d_NextTab ){ //'如果当前控件的TabIndex和Controls(i)相同,得到焦点,并退出
        //                d_NextControl.Focus();
        //                return ;
        //           }
        //       }
        //   }

        //   // '得到焦点,标题变红
        //    private void base_GotFocus(  Object sender, EventArgs e){Handles reportdoc_TextEdit.GotFocus, _
        //                                                                                           modcheckdate_ComboBoxEdit.GotFocus, _
        //                                                                                           machinetype_ComboBoxEdit.GotFocus, _
        //                                                                                           Name_TextEdit.GotFocus, _
        //                                                                                           sqdep_ComboBoxEdit.GotFocus, _
        //                                                                                           checktype_ComboBoxEdit.GotFocus, _
        //                                                                                           clinicend_TextEdit.GotFocus, _
        //                                                                                           bedno_TextEdit.GotFocus, _
        //                                                                                           layerthick_ComboBoxEdit.GotFocus, _
        //                                                                                           xno_TextEdit.GotFocus, _
        //                                                                                           checkpos_ComboBoxEdit.GotFocus, _
        //                                                                                           layerinterval_ComboBoxEdit.GotFocus

        //         if ( boolHistory ){ '如果当前是历史记录，退出操作
        //            return ;
        //       }

        //        Dim d_NextContralName As String '下一个得到焦点控件的名字
        //        Dim d_NextLabelName As String '下一个得到焦点控件对应的Label的名字
        //        Dim i As Integer
        //        d_NextContralName = sender.Name '得到焦点的控件的名字
        //        Dim d_poi As Integer
        //        d_poi = d_NextContralNaLastIndexOf("_")
        //        d_NextLabelName = d_NextContralNavoidstring(0, d_poi + 1) + "Label"
        //        For i = 0 To PanelControl1.Controls.Count - 1
        //             if ( PanelControl1.Controls(i).Name = d_NextLabelName ){
        //                PanelControl1.Controls(i).ForeColor = Color.Red
        //            Else
        //                PanelControl1.Controls(i).ForeColor = Color.Black
        //           }
        //       }

        //        For i = 0 To report_GroupControl.Controls.Count - 1
        //             if ( report_GroupControl.Controls(i).Name = d_NextLabelName ){
        //                report_GroupControl.Controls(i).ForeColor = Color.Red
        //            Else
        //                report_GroupControl.Controls(i).ForeColor = Color.Black
        //           }
        //       }
        //   }

        //    private void report_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        //         if ( boolHistory ){ '如果当前是历史记录，退出操作
        //            return ;
        //       }

        //        Dim d_NextContralName As String '下一个得到焦点控件的名字
        //        Dim d_NextLabelName As String '下一个得到焦点控件对应的Label的名字
        //        Dim i As Integer
        //        d_NextContralName = sender.Name '得到焦点的控件的名字
        //        Dim d_poi As Integer
        //        d_poi = d_NextContralNaLastIndexOf("_")
        //        d_NextLabelName = d_NextContralNavoidstring(0, d_poi + 1) + "Label"

        //        For i = 0 To PanelControl1.Controls.Count - 1
        //             if ( PanelControl1.Controls(i).Name = d_NextLabelName ){
        //                PanelControl1.Controls(i).ForeColor = Color.Red
        //            Else
        //                PanelControl1.Controls(i).ForeColor = Color.Black
        //           }
        //       }

        //        For i = 0 To report_GroupControl.Controls.Count - 1
        //             if ( report_GroupControl.Controls(i).Name = d_NextLabelName ){
        //                report_GroupControl.Controls(i).ForeColor = Color.Red
        //            Else
        //                report_GroupControl.Controls(i).ForeColor = Color.Black
        //           }
        //       }
        //   }
        //#endregion

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