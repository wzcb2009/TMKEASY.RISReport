using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class ShowApply_Form_old : Form
    {
        public ShowApply_Form_old()
        {
            InitializeComponent();
        }
        #region �϶�����
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
            //'��ס������Ҽ������϶�����
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = this.Location;
                //'������ƫ����
                mousePos.Offset(e.X - mouse_offset.X, e.Y - mouse_offset.Y);
                //'���ô��������һ���ƶ�
                this.Location = mousePos;
            }
        }

        #endregion

        public ShowApply_Form_old(patexam_Class p_patexam)
        {

            //' �˵����� Windows ���������������ġ�
            InitializeComponent();

            // ' �� InitializeComponent() ����֮������κγ�ʼ����
            FillInputByClass(p_patexam);



        }
        private void FillInputByClass(patexam_Class p_patexam)
        {
            patregister_Class d_Patregister = new patregister_Class(p_patexam.patid);

            Name_TextEdit.Text = d_Patregister.Name;
            sex_TextEdit.Text = d_Patregister.Sex;
            agetrue_TextEdit.Text = p_patexam.agetrue;
            sqdep_TextEdit.Text = p_patexam.sqdep;
            clinicinfo_MemoEdit.Text = p_patexam.clinicinfo;
            clinicend_MemoEdit.Text = p_patexam.clinicend;
            checkpos_MemoEdit.Text = p_patexam.checkpos;
            doctor_TextEdit.Text = p_patexam.Doctor;
            checkdate_TextEdit.Text = p_patexam.checkdate.ToString();
            modality_TextEdit.Text = p_patexam.modality;
            xno_TextEdit.Text = p_patexam.xno;
            checkid_TextEdit.Text = p_patexam.checkid.ToString();
            Radio_doctor_TextEdit.Text = p_patexam.radio_doctor;
            remark_MemoEdit.Text = p_patexam.exammark;

            //int  _index_Site = 0;
            //Font newFont   = new Font("����", 14, FontStyle.Bold);
            //string  _str[] = new string [6];
            //_str[0] = "�����ܲ�ȫ";
            //_str[1] = "���ö���˫����ҩ��";
            //_str[2] = "";
            //_str(3) = "";
            //_str(4) = "";

            //_index_Site = clinicinfo_MemoEdit.Text.ToString().IndexOf("���Ŀ��")
            //If _index_Site > -1 Then
            //    clinicinfo_MemoEdit.Select(_index_Site, clinicinfo_MemoEdit.Text.ToString.Length - _index_Site)
            //    clinicinfo_MemoEdit.SelectionColor = Color.Red
            //    clinicinfo_MemoEdit.SelectionFont = newFont
            //    clinicinfo_MemoEdit.Select(clinicinfo_MemoEdit.Text.ToString().Length, 0)
            //    clinicinfo_MemoEdit.SelectionColor = Color.Black
            //End If

        }
        private Report_Form CurReportForm;
        public ShowApply_Form_old(patexam_Class p_patexam, Report_Form p_report_Form)
            
        {
            //' �˵����� Windows ���������������ġ�
            InitializeComponent();

            // ' �� InitializeComponent() ����֮������κγ�ʼ����
            FillInputByClass(p_patexam);
            // ' �� InitializeComponent() ����֮������κγ�ʼ����
            CurReportForm = p_report_Form;
        }

        private void ShowApply_Form_old_Load(object sender, EventArgs e)
        {

        }
        private void close_SimpleButton_Click(object sender, EventArgs e)
        {
            Close();
            if (CurReportForm != null)
                CurReportForm.CurShowApply_Form = null;


        }
    }
}