using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class SendMessage_Form : Form
    {
        public SendMessage_Form()
        {
            InitializeComponent();
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
        patexam_Class d_patexam;
        public SendMessage_Form(patexam_Class p_patexam)
        {
            InitializeComponent();
            patregister_Class d_Patregister = new patregister_Class(p_patexam.patid);
            Name_TextEdit.Text = d_Patregister.Name;
            patient_id_TextEdit.Text = p_patexam.Patient_id;
            xno_TextEdit.Text = p_patexam.xno;
            accesno_TextEdit.Text = p_patexam.accessno;
            telephone_ComboBoxEdit.Text = d_Patregister.Telephone;
            d_patexam = p_patexam;
        }
        private void Print_SimpleButton_Click(object sender, EventArgs e)
        {
            string d_tel, d_content, d_result;
            d_tel = telephone_ComboBoxEdit.Text.Trim();
            if (d_tel == "")
            {

                ShowErr_Form d_form = new ShowErr_Form("请填写手机号码", "错误");
                d_form.ShowDialog();
                telephone_ComboBoxEdit.Focus();
                return;
            }
            try
            {


                d_content = Remark_MemoEdit.Text.Trim();

                //KY.Interface.Message.fey_message_Class.sendMessage(d_tel, d_content);
                string insertsql = "insert into sms_sendHistory(accession_no,type,SMSINFO,OPERATOR,remark) values('" + d_patexam.accessno + "','" + type_ComboBoxEdit.Text + "','" + d_content + "','" + Share_Class.User.user_id + "','" + Share_Class.GetIPAndAddress() + "')";
                if (RISOracle_Class.Exec_Cand(insertsql, insertsql) == true)
                {

                    ShowErr_Form d_form = new ShowErr_Form("发送成功", "提示");
                    d_form.ShowDialog();
                    Close();
                }
            }
            catch (Exception ex)
            {                 
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
            }
        }

        private void close_SimpleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendMessage_Form_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }
        private void FillComboBox()
        {
            string d_modality = d_patexam.modality;
            if (d_patexam.dep == "XRAY")
                d_modality = "DX";
            else if (d_patexam.dep == "MRI")
                d_modality = "MRI";
            else if (d_patexam.dep == "CT")
                d_modality = "CT";
            else if (d_patexam.dep == "DSA")
                d_modality = "DSA";

            Setup_Dict.setup_item_dic_dmb_Class.GetITEM(d_patexam.dep, d_modality, "短信类型", "", type_ComboBoxEdit);
        }

        private void type_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string d_modality = d_patexam.modality;
            if (d_patexam.dep == "XRAY")
                d_modality = "DX";
            else if (d_patexam.dep == "MRI")
                d_modality = "MRI";
            else if (d_patexam.dep == "CT")
                d_modality = "CT";
            else if (d_patexam.dep == "DSA")
                d_modality = "DSA";
            if (type_ComboBoxEdit.Text == "设置")
            {
                Setup_Dict.setup_item_dic_dmb_Form fm = new Setup_Dict.setup_item_dic_dmb_Form(d_patexam.dep, d_modality, "短信类型");
                fm.ShowDialog();
                type_ComboBoxEdit.Properties.Items.Clear();
                type_ComboBoxEdit.Text = "";
                FillComboBox();
            }
            else
            {

                DataSet ds = new DataSet();
                ds = Setup_Dict.setup_item_dic_dmb_Class.GetITEM(d_patexam.dep, d_modality, "短信类型", "", type_ComboBoxEdit.Text);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Remark_MemoEdit.Text = ds.Tables[0].Rows[0]["item_value"].ToString();
                            Remark_MemoEdit.Text = Remark_MemoEdit.Text.Replace("[modcheckdate]", d_patexam.modcheckdate.ToString()).Replace("[modality]", d_patexam.modality).Replace("[appoint_date]", d_patexam.appoint_date.ToString());
                            patregister_Class d_Patregister = new patregister_Class(d_patexam.patid);
                            Remark_MemoEdit.Text = Remark_MemoEdit.Text.Replace("[name]", d_Patregister.Name).Replace("[othercheck]", d_patexam.othercheck);

                        }
                    }
                }
            }
        }




    }
}
