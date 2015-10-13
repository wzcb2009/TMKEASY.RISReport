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
            // '填充数据库中调出的项
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
        //'根据部位结点填充结果归类结点
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
        //'根据结果归类结点填充模板结点
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

            // '取得选中的结点
            TreeListNode d_Node = template_TreeList.Selection[0];
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
                Curtemplate = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), this.dep_ComboBoxEdit.Text.Trim(), d_strpart, d_strdisease_type, d_strtemplate);
                //string idtemp = d_Node.Tag.ToString();
                //report_template_Class d_template = new report_template_Class("公有", Convert.ToInt32(idtemp));
                SetInputByClass();
                //FillTemplate(d_template);
                //CurReportForm.FillTemplate(d_template.template_describle, d_template.template_diag);
                //'填充结果归类
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

                // '取得选中的结点
                TreeListNode d_Node = template_TreeList.Selection[0];
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

                    Curtemplate = new report_template_Class(template_grade_ComboBoxEdit.Text.Trim(), this.dep_ComboBoxEdit.Text.Trim(), d_strpart, d_strdisease_type, d_strtemplate);
                    SetInputByClass();
                }
            }
            catch (Exception ex)
            {
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
            }
        }

        private void dep_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTemplate();
        }


        private void add_SimpleButton_Click(object sender, EventArgs e)
        {
            if ((template_grade_ComboBoxEdit.Text.Trim() == "公有") && (Share_Class.User.HaveFunction("o") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("用户无此操作权限", "提示");
                d_ErrForm.ShowDialog();

                return;
            }
            if (!ValidateData())
                return;

            Curtemplate = new report_template_Class();
            //  '得到当前要处理的Dmb的信息()
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
                    ShowErr_Form d_ErrForm = new ShowErr_Form("增加模板成功", "提示");
                    d_ErrForm.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "新增模版", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Update_SimpleButton_Click(object sender, EventArgs e)
        {
            if ((template_grade_ComboBoxEdit.Text.Trim() == "公有") && (Share_Class.User.HaveFunction("s") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("用户无此操作权限", "提示");
                d_ErrForm.ShowDialog();

                return;
            }
            //      '得到当前要处理的Dmb的信息()
            SetClassByInput();

            if (Curtemplate.template_id == 0)
                return;


            if (!ValidateData())
                return;

            try
            {
                int id = Curtemplate.template_id;



                if (MessageBox.Show("确定要修改模版吗?", "修改模版", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                MessageBox.Show(ex.Message, "新增模版", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Delete_SimpleButton_Click(object sender, EventArgs e)
        {

            if ((template_grade_ComboBoxEdit.Text.Trim() == "公有") && (Share_Class.User.HaveFunction("p") == false))
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("用户无此操作权限", "提示");
                d_ErrForm.ShowDialog();

                return;
            }

            // '得到当前要处理的Dmb的信息()
            if (Curtemplate.Delete() == false)
            {// '增加过程是否有错
                ShowErr_Form d_ErrForm = new ShowErr_Form("操作失败", "错误");
                d_ErrForm.ShowDialog();

                return;
            }
            else
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("删除部位成功", "提示");
                d_ErrForm.ShowDialog();

                FillTemplate();
            }
        }

        private void close_SimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        //  '把窗体上的内容填写到类中
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
                MessageBox.Show("检查部位不能为空,请正确填入!", "模版", MessageBoxButtons.OK, MessageBoxIcon.Error);
                template_part_ComboBoxEdit.Focus();
                return false;
            }

            if (disease_type_ComboBoxEdit.Text.TrimEnd().Length == 0)
            {
                MessageBox.Show("模版组名不能为空,请正确填入!", "模版", MessageBoxButtons.OK, MessageBoxIcon.Error);
                disease_type_ComboBoxEdit.Focus();
                return false;
            }

            if (template_name_TextEdit.Text.TrimEnd().Length == 0)
            {
                MessageBox.Show("模版名不能为空,请正确填入!", "模版", MessageBoxButtons.OK, MessageBoxIcon.Error);
                template_name_TextEdit.Focus();
                return false;
            }

            if (t_describe.TrimEnd().Length == 0)
            {
                MessageBox.Show("模版描述不能为空,请正确填入!", "模版", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void template_Word_form_Load(object sender, EventArgs e)
        {
            //template_grade_ComboBoxEdit.Text = "公有";
            //this.dep_ComboBoxEdit.Properties .Items.Clear();
            //this.dep_ComboBoxEdit.Properties.Items.Add("CT");
            //this.dep_ComboBoxEdit.Properties.Items.Add("XRAY");
            //this.dep_ComboBoxEdit.Properties.Items.Add("MRI");
            //this.dep_ComboBoxEdit.Properties.Items.Add("DSA");
            //this.dep_ComboBoxEdit .SelectedIndex = 0;
            //   '检查部门
            DataSet Ds = Userinfo_Class.GetAllDept();
            if (Ds != null)
            {
                //'填充数据库中调出的项

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    dep_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["userflag"].ToString());
                }
            }

            //'所在部位
            Ds = report_template_Class.GetAlltemplate_part();
            if (Ds != null)
            {
                //'填充数据库中调出的项

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    template_part_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["template_part"].ToString());
                }
            }



            // '结果归类
            Ds = setup_noSort_Dmb_Class.GetAll("diseasetype");
            if (Ds != null)
            {
                //'填充数据库中调出的项

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    disease_type_ComboBoxEdit.Properties.Items.Add(Ds.Tables[0].Rows[i]["diseasetype"].ToString());
                }
            }


            // '初始化
            template_grade_ComboBoxEdit.Text = "公有";
            if (dep_ComboBoxEdit.Properties.Items.Count > 0)
                dep_ComboBoxEdit.SelectedIndex = 0;
            FillNewTemplate();
        }

        private void template_grade_ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (template_grade_ComboBoxEdit.Text  == "私有")
            {
                template_grade_ComboBoxEdit.Text = Share_Class.User.user_id;
                return;
            }
            FillTemplate();
        }

    }
}