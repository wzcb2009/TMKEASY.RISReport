using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class Consult_request_form : Form
    {
        public Consult_request_form()
        {
            InitializeComponent();
        }
        public Consult_request_form(patexam_Class d_patexam)
        {
            InitializeComponent();
            CurPatexam = d_patexam;
            FillInputByClass();
        }
        //public Consult_request_form(patexam_Class d_patexam, DG_Report_Form p_report_form)
        //{
        //    InitializeComponent();
        //    CurPatexam = d_patexam;
        //    FillInputByClass();
        // //   d_report_form = p_report_form;
        //}
        public Consult_request_form(patexam_Class d_patexam, Report_Form p_report_form)
        {
            InitializeComponent();
            CurPatexam = d_patexam;
            FillInputByClass();
            d_report_form = p_report_form;
        }
        patexam_Class CurPatexam = new patexam_Class();
        CONSULT_DIAG_Class CurDG_CONSULT_DIAG = new CONSULT_DIAG_Class();
        patregister_Class CurPatRegister = new patregister_Class();

        Report_Form d_report_form;





        private void FillInputByClass()
        {

            CurPatRegister = new patregister_Class(CurPatexam.patid);//'得到病人信息
            patient_name_Label.Text = CurPatRegister.Name; ;
            patient_sex_Label.Text = CurPatRegister.Sex;
            patient_age_Label.Text = CurPatRegister.Age;
            patient_id_Label.Text = CurPatexam.Patient_id;
            Label_xno.Text = CurPatexam.xno;
            Label_accessno.Text = CurPatexam.accessno;
            Label_addTime.Text = CurPatexam.checkdate.ToString();
            Labelbedno.Text = CurPatexam.BedNo;
            sqdep_Label.Text = CurPatexam.sqdep;

        }

        private void FillClassByInput()
        {

            CurDG_CONSULT_DIAG.ACCESSION_NO = CurPatexam.accessno;
            CurDG_CONSULT_DIAG.PATIENT_ID = CurPatexam.Patient_id;
            CurDG_CONSULT_DIAG.REQUEST_DOCTOR = requestdoctor_ComboBoxEdit.Text.Trim();
            CurDG_CONSULT_DIAG.REQUEST_DTTM = Convert.ToDateTime(requestdttm_DateEdit.Text.Trim());
            CurDG_CONSULT_DIAG.REQUEST_CAUSE = ComboBoxEdit1.Text.Trim();
            CurDG_CONSULT_DIAG.PATIENT_NAME = CurPatRegister.Name;
            CurDG_CONSULT_DIAG.PATIENT_SEX = CurPatRegister.Sex; ;
            CurDG_CONSULT_DIAG.PATIENT_AGE = CurPatexam.agetrue;
            CurDG_CONSULT_DIAG.XNO = CurPatexam.xno;
            CurDG_CONSULT_DIAG.PATIENT_ADDRRESS = CurPatRegister.Address;
            CurDG_CONSULT_DIAG.PATIENT_TELEPHONE = CurPatRegister.Telephone;
            CurDG_CONSULT_DIAG.PATIENT_BIRTHDAY = Convert.ToDateTime(CurPatRegister.BirthDay).ToString();
            CurDG_CONSULT_DIAG.CHARGE_TYPE = "";
            CurDG_CONSULT_DIAG.PRINT_STATUS = "";
            CurDG_CONSULT_DIAG.XNO = CurPatexam.xno;
            CurDG_CONSULT_DIAG.MODALITY = CurPatexam.modality;
            CurDG_CONSULT_DIAG.CHECK_TYPE = CurPatexam.checktype;
            CurDG_CONSULT_DIAG.APPOINT_DATE = CurPatexam.appoint_date;
            CurDG_CONSULT_DIAG.EXPERT_DOCTOR = "";
            CurDG_CONSULT_DIAG.CONSULTATION_INFO = "";
            CurDG_CONSULT_DIAG.CONSULTATION_END = "";
            CurDG_CONSULT_DIAG.CONSULTATION_DATE = Convert.ToDateTime("1900-1-1");
            CurDG_CONSULT_DIAG.STATUS = "";
            CurDG_CONSULT_DIAG.REMARK = "";
            CurDG_CONSULT_DIAG.REMARK2 = "";
        }


        private void user_id_CheckedListBoxControl_Click(Object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("doctor");
            DataRow dr;
            for (int i = 0; i < user_id_CheckedListBoxControl.Items.Count; i++)
            {
                if (user_id_CheckedListBoxControl.Items[i].CheckState == CheckState.Checked)
                {
                    if (user_id_CheckedListBoxControl.Items[i].Value != user_id_CheckedListBoxControl.SelectedValue)
                    {
                        dr = dt.NewRow();
                        dr[0] = i + 1;
                        dr[1] = user_id_CheckedListBoxControl.Items[i].Value.ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    if (user_id_CheckedListBoxControl.Items[i].Value == user_id_CheckedListBoxControl.SelectedValue)
                    {
                        dr = dt.NewRow();
                        dr[0] = i + 1;
                        dr[1] = user_id_CheckedListBoxControl.Items[i].Value.ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                }
            }
            Immunol_GridControl.DataSource = dt;
            Immunol_GridView.RefreshData();
        }

        private void SimpleButton1_Click(Object sender, EventArgs e)
        {

            DataTable d_DTable = new DataTable();
            d_DTable = (DataTable)Immunol_GridControl.DataSource;
            if (d_DTable == null)
            {
                 ShowErr_Form d_form = new ShowErr_Form("请先选择要保存的会诊医生", "提示");
                d_form.ShowDialog();
                return;
            }
            if (d_DTable.Rows.Count == 0)
            {
                 ShowErr_Form d_form = new ShowErr_Form("请先选择要保存的会诊医生", "提示");
                d_form.ShowDialog();
                return;
            }
            if (ComboBoxEdit1.Text == "")
            {
                 ShowErr_Form d_form = new ShowErr_Form("会诊目的不能为空", "提示");
                d_form.ShowDialog();
                return;
            }
            if (requestdoctor_ComboBoxEdit.Text == "")
            {
                 ShowErr_Form d_form = new ShowErr_Form("发起医生不能为空", "提示");
                d_form.ShowDialog();
                return;
            }

            bool d_Status = true;
            FillClassByInput();
            for (int i = 0; i < d_DTable.Rows.Count; i++)
            {

                CurDG_CONSULT_DIAG.EXPERT_DOCTOR = d_DTable.Rows[i]["doctor"].ToString().Trim();
                d_Status = CurDG_CONSULT_DIAG.Insert();

            }
            if (d_Status == true)
            {
                FillGridControl();
                ShowErr_Form d_form = new ShowErr_Form("保存成功", "提示");
                d_form.ShowDialog();
                return;
            }
        }

        private void SimpleButton2_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void SimpleButton4_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void Consult_request_form_Load(Object sender, EventArgs e)
        {
            //  '根据部门填写用户
            DataSet Ds = Userinfo_Class.GetUserByDept(Share_Class.User.userflag);
            if (Ds == null)
            {
                return;
            }

            user_id_CheckedListBoxControl.Items.Clear();
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {

                user_id_CheckedListBoxControl.Items.Add(Ds.Tables[0].Rows[i]["user_id"], CheckState.Unchecked);
                requestdoctor_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["user_id"].ToString());
            }
            requestdttm_DateEdit.Text = DateTime.Now.ToShortDateString();
            FillGridControl();

        }
        private void FillGridControl()
        {

            CONSULT_DIAG_Class CurDG_CONSULT_DIAG = new CONSULT_DIAG_Class();
            DataSet DG_CONSULT_DIAG_Ds = new DataSet();
            DG_CONSULT_DIAG_Ds = CONSULT_DIAG_Class.GETEXPERT_DOCTOR(CurPatexam.accessno);
            if (DG_CONSULT_DIAG_Ds == null)
            {
                return;
            }
            string d_EXPERT_DOCTOR = "";
            string d_CONSULTATION_END = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataRow dr;
            DataRow dr2;
            dt.Columns.Add("id");
            dt.Columns.Add("doctor");
            dt2.Columns.Add("id");
            dt2.Columns.Add("doctor");
            dt2.Columns.Add("consult_status");
            if (DG_CONSULT_DIAG_Ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DG_CONSULT_DIAG_Ds.Tables[0].Rows.Count; i++)
                {
                    d_EXPERT_DOCTOR = d_EXPERT_DOCTOR + DG_CONSULT_DIAG_Ds.Tables[0].Rows[i]["EXPERT_DOCTOR"].ToString().Trim() + ",";
                    dr = dt.NewRow();
                    dr[0] = i + 1;
                    dr[1] = DG_CONSULT_DIAG_Ds.Tables[0].Rows[i]["EXPERT_DOCTOR"].ToString().Trim();
                    dt.Rows.Add(dr);
                    dr2 = dt2.NewRow();
                    dr2[0] = DG_CONSULT_DIAG_Ds.Tables[0].Rows[i]["ID"];
                    dr2[1] = DG_CONSULT_DIAG_Ds.Tables[0].Rows[i]["EXPERT_DOCTOR"].ToString().Trim();
                    d_CONSULTATION_END = DG_CONSULT_DIAG_Ds.Tables[0].Rows[i]["CONSULTATION_END"].ToString().Trim();
                    if (d_CONSULTATION_END == "")
                        dr2[2] = "否";
                    else
                        dr2[2] = "是";

                    dt2.Rows.Add(dr2);

                }
                ComboBoxEdit1.Text = DG_CONSULT_DIAG_Ds.Tables[0].Rows[0]["REQUEST_CAUSE"].ToString().Trim();
                requestdttm_DateEdit.Text = DG_CONSULT_DIAG_Ds.Tables[0].Rows[0]["REQUEST_DTTM"].ToString();
                requestdoctor_ComboBoxEdit.Text = DG_CONSULT_DIAG_Ds.Tables[0].Rows[0]["REQUEST_DOCTOR"].ToString().Trim();
                Immunol_GridControl.DataSource = dt;
                Immunol_GridView.RefreshData();
                GridControl1.DataSource = dt2;
                GridView1.RefreshData();
            }
            else
            {
                requestdoctor_ComboBoxEdit.Text = Share_Class.User.user_id;
            }
            for (int i = 0; i < user_id_CheckedListBoxControl.Items.Count; i++)
            {
                if (("," + d_EXPERT_DOCTOR + ",").IndexOf("," + user_id_CheckedListBoxControl.Items[i].Value.ToString().Trim() + ",") >= 0)
                {
                    user_id_CheckedListBoxControl.Items[i].CheckState = CheckState.Checked;
                }
            }
        }

        private void GridControl1_Click(Object sender, EventArgs e)
        {
            //  '得到列表中的记录表
            DataTable d_DTable = (DataTable)GridControl1.DataSource;
            // '得到当前访问号
            if (d_DTable == null)
            {
                 ShowErr_Form d_form = new ShowErr_Form("请先查出要操作的记录", "错误");
                d_form.ShowDialog();
                return;
            }

            if (d_DTable.Rows.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("请先查出要操作的记录", "错误");
                d_form.ShowDialog();
                return;
            }

            // 'Dim d_accessno = d_DTable.Rows(patexam_GridView.GetDataSourceRowIndex(patexam_GridView.FocusedRowHandle)).Item("accessno").ToString
            int d_id = Convert.ToInt32(d_DTable.Rows[GridView1.GetDataSourceRowIndex(GridView1.FocusedRowHandle)]["id"]);
            CONSULT_DIAG_Class d_DG_CONSULT_DIAG = new CONSULT_DIAG_Class(d_id);
            if (d_DG_CONSULT_DIAG.id == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("请先选择列表中的记录", "错误");
                d_form.ShowDialog();
                return;
            }
            BL_HisText.Text = d_DG_CONSULT_DIAG.CONSULTATION_INFO;
            reportend_RichTextBox.Text = d_DG_CONSULT_DIAG.CONSULTATION_END;
            //   'If d_DG_CONSULT_DIAG.EXPERT_DOCTOR <> "" ){
            advancedoc_ComboBoxEdit.Text = d_DG_CONSULT_DIAG.EXPERT_DOCTOR;

            reportdate_DateEdit.Text = d_DG_CONSULT_DIAG.CONSULTATION_DATE.ToShortDateString();
        }

        private void SimpleButton3_Click(Object sender, EventArgs e)
        {
            d_report_form.CurReportForm.FillTemplate(BL_HisText.Text, reportend_RichTextBox.Text);
            ShowErr_Form d_form = new ShowErr_Form("调用成功,是否立即关闭本界面", "是", "否");
                       if (d_form.ShowDialog() == DialogResult.OK)
            {
                Close();
            }

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
    }
}
