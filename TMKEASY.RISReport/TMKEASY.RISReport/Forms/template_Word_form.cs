using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace TMKEASY.RISReport
{
    public partial class template_Word_form : Form
    {

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


        public template_Word_form()
        {
            InitializeComponent();
            
        }

        public template_Word_form(int userID, string Curdir, string hospital_name)
        {
            InitializeComponent();
            Share_Class.User = new Userinfo_Class(userID);
            Share_Class.Dir = Curdir;
            Share_Class.hospital_name = hospital_name;

        }

        public template_Word_form(string p_template_diag, string p_template_describle, string p_template_part, string p_dep)
        {


            InitializeComponent();
 
            
            template_name_TextEdit.Text = p_template_diag;
            template_part_ComboBoxEdit.Text = p_template_part;
            dep_ComboBoxEdit.Text = p_dep;
            t_describe = p_template_describle;
            t_diagnose = p_template_diag;
        }
        string t_describe = "";
        string t_diagnose = "";
        int d_id = 0;
        report_template_Class Curtemplate = new report_template_Class();
        private void FillNewTemplate()
        {
            template_Control_describe.FillTemplate(t_describe, t_describe);
            template_Control_diagnose.FillTemplate(t_diagnose, t_diagnose);
        }
        private void FillTemplate()
        {
            //GetTemplateList
            DataTable dt = new DataTable();

            dt = report_template_Class.GetTemplateList(template_grade_ComboBoxEdit.Text, this.dep_ComboBoxEdit.Text.Trim(), "");
            template_TreeList.Nodes.Clear();
            if (dt == null)
                return;
            TreeListNode d_BaseNode = null;
            TreeListNode d_Node;
            // '������ݿ��е�������
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = template_TreeList.AppendNode(new Object[] { dt.Rows[i]["t_part"].ToString(), CheckState.Unchecked }, d_BaseNode);
                Filldisease_typeNodeBytemplate_partNode(d_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
            if (dt.Rows.Count >= 1)
            {
                template_TreeList.Nodes.FirstNode.Expanded = true;
                template_TreeList.Nodes.FirstNode.FirstNode.Expanded = true;
            }
        }
        //'���ݲ�λ��������������
        private void Filldisease_typeNodeBytemplate_partNode(TreeListNode p_Node)
        {
            //setup_REPORT_TEMPLATE_ORDER_Class.Update_REPORT_TEMPLATE_ORDER_DISEASE_TYPE(CurReportForm.CurPatexam.dep, p_Node.GetValue("template"));
            //setup_REPORT_TEMPLATE_ORDER_Class.Delete_REPORT_TEMPLATE_ORDER_DISEASE_TYPE(CurReportForm.CurPatexam.dep, p_Node.GetValue("template"));

            DataTable dt = new DataTable();
            dt = report_template_Class.Getdisease_typeBytemplate_part(template_grade_ComboBoxEdit.Text, this.dep_ComboBoxEdit.Text.Trim(), p_Node.GetValue("template").ToString());

            p_Node.Nodes.Clear();
            TreeListNode d_Node;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = template_TreeList.AppendNode(new Object[] { dt.Rows[i][0].ToString(), CheckState.Unchecked }, p_Node);
                //Filltemplate_nameNodeBydisease_typeNode(d_Node);
                d_Node.ImageIndex = 0;
                d_Node.SelectImageIndex = 0;
            }
        }
        //'���ݽ�����������ģ����
        private void Filltemplate_nameNodeBydisease_typeNode(TreeListNode p_Node)
        {
            //setup_REPORT_TEMPLATE_ORDER_Class.Update_REPORT_TEMPLATE_ORDER_TEMPLATE_NAME(CurPatexam.dep, p_Node.ParentNode.GetValue("template"), p_Node.GetValue("template"))
            //setup_REPORT_TEMPLATE_ORDER_Class.Delete_REPORT_TEMPLATE_ORDER_TEMPLATE_NAME(CurPatexam.dep, p_Node.ParentNode.GetValue("template"), p_Node.GetValue("template"))
            DataTable dt = new DataTable();
            dt = report_template_Class.Get_template_nameBydisease_type(template_grade_ComboBoxEdit.Text, this.dep_ComboBoxEdit.Text.Trim(), p_Node.ParentNode.GetValue("template").ToString(), p_Node.GetValue("template").ToString());
            p_Node.Nodes.Clear();
            TreeListNode d_Node;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                d_Node = template_TreeList.AppendNode(new Object[] { dt.Rows[i][1].ToString(), CheckState.Unchecked }, p_Node);
                //Filldisease_typeNodeBytemplate_partNode(d_Node);
                d_Node.Tag = dt.Rows[i][0].ToString();
                d_Node.ImageIndex = 1;
                d_Node.SelectImageIndex = 1;
            }

        }
        private void Template_TreeList_DoubleClick(object sender, EventArgs e)
        {
            if (template_TreeList.Selection.Count == 0)
                return;

            // 'ȡ��ѡ�еĽ��
            TreeListNode d_Node = template_TreeList.Selection[0];
            string d_strpart, d_strdisease_type, d_strtemplate;

            if (d_Node.ParentNode == null)
            {// ){ '��ǰ����ǲ�λ
                Filldisease_typeNodeBytemplate_partNode(d_Node);
            }
            else if (d_Node.ParentNode.ParentNode == null)
            {//'��ǰ����ǽ������
                Filltemplate_nameNodeBydisease_typeNode(d_Node);
            }
            else if (d_Node.Nodes.Count == 0)
            {
                d_strtemplate = d_Node.GetValue(0).ToString();// '�õ�ģ��
                d_strdisease_type = d_Node.ParentNode.GetValue(0).ToString();// '�õ����
                d_strpart = d_Node.ParentNode.ParentNode.GetValue(0).ToString();// '�õ���λ
                Curtemplate = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), this.dep_ComboBoxEdit.Text.Trim(), d_strpart, d_strdisease_type, d_strtemplate);
                //string idtemp = d_Node.Tag.ToString();
                //report_template_Class d_template = new report_template_Class("����", Convert.ToInt32(idtemp));
                SetInputByClass();
                //FillTemplate(d_template);
                //CurReportForm.FillTemplate(d_template.template_describle, d_template.template_diag);
                //'���������
                //diseasetype_ComboBoxEdit.Text = d_strdisease_type;
            }
        }
        private void SetInputByClass()
        {

            if (Curtemplate.template_id != 0)
            {

                //t_part.Text = p_template.template_part;
                //t_diseasetype.Text = p_template.disease_type;
                //t_name.Text = p_template.template_name;
                //t_describe = p_template.template_describle;
                //t_diagnose = p_template.template_diag;
                //t_grade_ComboBox.Text = p_template.template_grade;
                //d_id = p_template.template_id;

                template_Control_describe.FillTemplate(Curtemplate.xml_describle, Curtemplate.template_describle);
                template_Control_diagnose.FillTemplate(Curtemplate.xml_diag, Curtemplate.template_diag);
                template_part_ComboBoxEdit.Text = Curtemplate.template_part;
                template_name_TextEdit.Text = Curtemplate.template_name;
                disease_type_ComboBoxEdit.Text = Curtemplate.disease_type;

                t_describe = Curtemplate.template_describle;
                t_diagnose = Curtemplate.template_diag;

            }

        }
        private void Template_TreeList_Click(object sender, EventArgs e)
        {
            try
            {
                if (template_TreeList.Selection.Count == 0)
                    return;

                // 'ȡ��ѡ�еĽ��
                TreeListNode d_Node = template_TreeList.Selection[0];
                string d_strpart, d_strdisease_type, d_strtemplate;
                if (d_Node.ParentNode == null)
                {// ){ '��ǰ����ǲ�λ

                }
                else if (d_Node.ParentNode.ParentNode == null)
                {//'��ǰ����ǽ������

                }
                else if (d_Node.Nodes.Count == 0)
                {
                    d_strtemplate = d_Node.GetValue(0).ToString();// '�õ�ģ��
                    d_strdisease_type = d_Node.ParentNode.GetValue(0).ToString();// '�õ����
                    d_strpart = d_Node.ParentNode.ParentNode.GetValue(0).ToString();// '�õ���λ

                    Curtemplate = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), this.dep_ComboBoxEdit.Text.Trim(), d_strpart, d_strdisease_type, d_strtemplate);
                    SetInputByClass();
                }
            }
            catch (Exception ex)
            {
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "����");
                d_form.ShowDialog();
            }
        }

        private void dep_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTemplate();
        }


        private void add_SimpleButton_Click(object sender, EventArgs e)
        {
            if ((template_grade_ComboBoxEdit.Text.Trim() == "����") && (Share_Class.User.HaveFunction("o") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("�û��޴˲���Ȩ��", "��ʾ");
                d_ErrForm.ShowDialog();

                return;
            }
            if (!ValidateData())
                return;

            Curtemplate = new report_template_Class();
            //  '�õ���ǰҪ�����Dmb����Ϣ()
            SetClassByInput();

            try
            {


                string p_xml_describe = template_Control_describe.GetTemplateXML();
                string p_xml_diagnose = template_Control_diagnose.GetTemplateXML();
                //Curtemplate.dep = toolStripComboBox_DEP.Text.Trim();
                int newid = Curtemplate.Insert();
                if (newid > 0)
                {
                    d_id = newid;
                    Curtemplate.Update(p_xml_describe, p_xml_diagnose, d_id.ToString());

                    FillTemplate();
                    ShowErr_Form d_ErrForm = new ShowErr_Form("����ģ��ɹ�", "��ʾ");
                    d_ErrForm.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Update_SimpleButton_Click(object sender, EventArgs e)
        {
            if ((template_grade_ComboBoxEdit.Text.Trim() == "����") && (Share_Class.User.HaveFunction("s") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("�û��޴˲���Ȩ��", "��ʾ");
                d_ErrForm.ShowDialog();

                return;
            }
            //      '�õ���ǰҪ�����Dmb����Ϣ()
            SetClassByInput();

            if (Curtemplate.template_id == 0)
                return;


            if (!ValidateData())
                return;

            try
            {
                int id = Curtemplate.template_id;



                if (MessageBox.Show("ȷ��Ҫ�޸�ģ����?", "�޸�ģ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                string p_xml_describe = template_Control_describe.GetTemplateXML();
                string p_xml_diagnose = template_Control_diagnose.GetTemplateXML();

                if (Curtemplate.Modify())
                {
                    Curtemplate.Update(p_xml_describe, p_xml_diagnose, id.ToString());
                    SetInputByClass();
                    FillTemplate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Delete_SimpleButton_Click(object sender, EventArgs e)
        {

            if ((template_grade_ComboBoxEdit.Text.Trim() == "����") && (Share_Class.User.HaveFunction("p") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("�û��޴˲���Ȩ��", "��ʾ");
                d_ErrForm.ShowDialog();

                return;
            }

            // '�õ���ǰҪ�����Dmb����Ϣ()
            if (Curtemplate.Delete() == false)
            {// '���ӹ����Ƿ��д�
                ShowErr_Form d_ErrForm = new ShowErr_Form("����ʧ��", "����");
                d_ErrForm.ShowDialog();

                return;
            }
            else
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("ɾ����λ�ɹ�", "��ʾ");
                d_ErrForm.ShowDialog();

                FillTemplate();
            }
        }

        private void close_SimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        //  '�Ѵ����ϵ�������д������
        private void SetClassByInput()
        {

            Curtemplate.template_grade = template_grade_ComboBoxEdit.Text;
            
            Curtemplate.dep = dep_ComboBoxEdit.Text;
            Curtemplate.template_part = template_part_ComboBoxEdit.Text;
            Curtemplate.template_name = template_name_TextEdit.Text;
            Curtemplate.disease_type = disease_type_ComboBoxEdit.Text;
            //Curtemplate   .template_time =template_time_DateEdit.DateTime;
            //Curtemplate   .template_describle =template_describle_MemoEdit.Text;
            //Curtemplate.template_diag = template_diag_MemoEdit.Text;
            Curtemplate.template_describle = template_Control_describe.GetTemplateText();
            Curtemplate.template_diag = template_Control_diagnose.GetTemplateText();

        }

        private bool ValidateData()
        {
            t_describe = template_Control_describe.GetTemplateText();
            t_diagnose = template_Control_diagnose.GetTemplateText();

            if (template_part_ComboBoxEdit.Text.TrimEnd().Length == 0)
            {
                MessageBox.Show("��鲿λ����Ϊ��,����ȷ����!", "ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                template_part_ComboBoxEdit.Focus();
                return false;
            }

            if (disease_type_ComboBoxEdit.Text.TrimEnd().Length == 0)
            {
                MessageBox.Show("ģ����������Ϊ��,����ȷ����!", "ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                disease_type_ComboBoxEdit.Focus();
                return false;
            }

            if (template_name_TextEdit.Text.TrimEnd().Length == 0)
            {
                MessageBox.Show("ģ��������Ϊ��,����ȷ����!", "ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                template_name_TextEdit.Focus();
                return false;
            }

            if (t_describe.TrimEnd().Length == 0)
            {
                MessageBox.Show("ģ����������Ϊ��,����ȷ����!", "ģ��", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void template_Word_form_Load(object sender, EventArgs e)
        {
            //template_grade_ComboBoxEdit.Text = "����";
            //this.dep_ComboBoxEdit.Properties .Items.Clear();
            //this.dep_ComboBoxEdit.Properties.Items.Add("CT");
            //this.dep_ComboBoxEdit.Properties.Items.Add("XRAY");
            //this.dep_ComboBoxEdit.Properties.Items.Add("MRI");
            //this.dep_ComboBoxEdit.Properties.Items.Add("DSA");
            //this.dep_ComboBoxEdit .SelectedIndex = 0;
            //   '��鲿��
            DataSet Ds = Userinfo_Class.GetAllDept();
            if (Ds != null)
            {
                //'������ݿ��е�������

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    dep_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["userflag"].ToString());
                }
            }

            //'���ڲ�λ
            Ds = report_template_Class.GetAlltemplate_part();
            if (Ds != null)
            {
                //'������ݿ��е�������

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    template_part_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["template_part"].ToString());
                }
            }



            // '�������
            Ds = setup_noSort_Dmb_Class.GetAll("diseasetype");
            if (Ds != null)
            {
                //'������ݿ��е�������

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    disease_type_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["diseasetype"].ToString());
                }
            }


            // '��ʼ��
            template_grade_ComboBoxEdit.Text = "����";
            if (dep_ComboBoxEdit.Properties.Items.Count > 0)
                dep_ComboBoxEdit.SelectedIndex = 0;
            FillNewTemplate();
        }

        private void template_grade_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (template_grade_ComboBoxEdit.Text  == "˽��")
            {
                template_grade_ComboBoxEdit.Text = Share_Class.User.user_id;
                return;
            }
            FillTemplate();
        }

    }
}