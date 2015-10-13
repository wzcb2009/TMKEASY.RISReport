using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class report_rewrite_form : Form
    {
        public report_rewrite_form()
        {
            InitializeComponent();
            CurReport_rewrite = new report_rewrite_Class();
        }
        report_rewrite_Class CurReport_rewrite;
        public report_rewrite_form(patexam_Class d_patexam)
        {
            InitializeComponent();
            CurReport_rewrite = new report_rewrite_Class(d_patexam);
        }
        private void report_rewrite_form_Load(object sender, EventArgs e)
        {
            //'原因


            DataSet ds = setup_noSort_Dmb_Class.GetAll("giveup_cause");
            if (ds == null)
            {
                return;
            }
            // '填充数据库中调出的项
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                giveup_cause_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["giveup_cause"].ToString());
            }

            // '提示答案
            ds = setup_noSort_Dmb_Class.GetAll("tj_diseasetype");
            if (ds == null)
            {
                return;
            }
            //  '填充数据库中调出的项
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                result_ComboBoxEdit.Properties.Items.Add(ds.Tables[0].Rows[i]["name"].ToString());
            }


            giveup_cause_ComboBoxEdit.Text = CurReport_rewrite.giveup_cause.Trim();
            result_ComboBoxEdit.Text = CurReport_rewrite.result.Trim();
            describle_MemoEdit.Text = CurReport_rewrite.describle.Trim();
        }


        private void Close_SimpleButton_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void OK_SimpleButton_Click(Object sender, EventArgs e)
        {
            //'得到当前要处理的Dmb的信息()

            CurReport_rewrite.giveup_cause = giveup_cause_ComboBoxEdit.Text.Trim();
            CurReport_rewrite.result = result_ComboBoxEdit.Text.Trim();
            CurReport_rewrite.describle = describle_MemoEdit.Text.Trim();

            if (CurReport_rewrite.CheckErr_BeforeInsert() == false)
            { //'检查重写的数据是否有错
                if (CurReport_rewrite.report_rewrite() == false)
                {// '重写过程是否有错
                     
                    ShowErr_Form d_form = new ShowErr_Form("重写失败", "错误");
                    d_form.ShowDialog();

                }
                else
                {
                   
                    ShowErr_Form d_form = new ShowErr_Form("重写成功", "提示");
                    d_form.ShowDialog();
                    // 'Share_Forms_Class.PatexamListViewForm.SetListViewRowBypatexam(CurReport_rewrite.patexam, New patregister_Class(CurReport_rewrite.patexam.patid))
                    Close();
                }
            }
            else
            { //'数据有错，显示错误

                try
                {
                    ShowErr_Form d_form = new ShowErr_Form(CurReport_rewrite.Err, "错误");
                    d_form.ShowDialog();
                }
                catch { }
            }
        }

        #region 回车
        //'当回车时,进到下一个控件
        private void giveup_cause_ComboBoxEdit_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                result_ComboBoxEdit.Focus();
            }
        }

        private void result_ComboBoxEdit_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                describle_MemoEdit.Focus();
            }
        }

        private void describle_MemoEdit_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                OK_SimpleButton.Focus();
            }
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

    }
}
