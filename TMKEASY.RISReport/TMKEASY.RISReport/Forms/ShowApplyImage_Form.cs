using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class ShowApplyImage_Form : Form
    {
        public ShowApplyImage_Form()
        {
            InitializeComponent();
        }
        private string CurPath = "";
        private Report_Form CurReportForm;
        private string CurRadio_doctor = "";
        public ShowApplyImage_Form(string p_path, string p_Radio_doctor)
        {

            //' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent();

            // ' 在 InitializeComponent() 调用之后添加任何初始化。

            CurPath = p_path;
            CurRadio_doctor = p_Radio_doctor;
        }

        public ShowApplyImage_Form(string p_path, Report_Form p_report_Form)
        {

            // ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent();

            // ' 在 InitializeComponent() 调用之后添加任何初始化。

            CurPath = p_path;
            CurReportForm = p_report_Form;
        }

        private void ShowApplyImage_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurReportForm != null)
            {
                CurReportForm.CurShowApplyImage_Form = null;
            }

            try
            {
                image_PictureBox.Image.Dispose();
                image_PictureBox.Image = null;
                // 'image_PictureBox.Dispose()
            }
            catch (Exception ex)
            {

            }
        }
        private void ShowApplyImage_Form_Load(object sender, EventArgs e)
        {
            try
            {
                //  'WindowState = FormWindowState.Maximized
                ApplyImage_Class d_applyimage = new ApplyImage_Class();
                if (d_applyimage.OpenPath())
                {
                    Bitmap d_dmp =(Bitmap) Image.FromFile(CurPath);
                    string d_GetValue = RisSetup_Class.GetINI("setup", "ApplyImageBig");
                    if (d_GetValue == "")
                    {
                        d_GetValue = "0.5";
                    }
                    image_PictureBox.Width =Convert .ToInt32 ( d_dmp.Width * Convert.ToSingle(d_GetValue));
                    image_PictureBox.Height = Convert .ToInt32 ( d_dmp.Height * Convert.ToSingle(d_GetValue));
                    image_PictureBox.Image = d_dmp;
                }
                else
                {
                    ShowErr_Form d_ErrForm = new ShowErr_Form("无法调出申请单图片", "错误");
                    d_ErrForm.ShowDialog();

                    Close();
                }
            }
            catch
            {
                ShowErr_Form d_ErrForm = new ShowErr_Form("无法调出申请单图片", "错误");
                d_ErrForm.ShowDialog();

                Close();
            }
            Radio_doctor_TextEdit.Text = CurRadio_doctor;
        }
        private void Old_SimpleButton_Click(object sender, EventArgs e)
        {
            ApplyImage_Class d_applyimage = new ApplyImage_Class();
            if (d_applyimage.OpenPath())
            {
                Bitmap d_dmp =(Bitmap) Image.FromFile(CurPath);
                image_PictureBox.Width = d_dmp.Width;
                image_PictureBox.Height = d_dmp.Height;
                image_PictureBox.Image = d_dmp;
            }
            curRotate = 0;
        }

        private void big_SimpleButton_Click(object sender, EventArgs e)
        {
            image_PictureBox.Width =Convert .ToInt32 (  image_PictureBox.Width * 1.2);
            image_PictureBox.Height = Convert .ToInt32 ( image_PictureBox.Height * 1.2);
        }

        private void small_SimpleButton_Click(object sender, EventArgs e)
        {
            image_PictureBox.Width = Convert .ToInt32 ( image_PictureBox.Width * 0.8);
            image_PictureBox.Height = Convert .ToInt32 ( image_PictureBox.Height * 0.8);
        }


        private void print_SimpleButton_Click(object sender, EventArgs e)
        {
            image_PrintDocument.Print();
        }

        private void image_PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (image_PictureBox.Image != null)
            {
                e.Graphics.DrawImage(image_PictureBox.Image, 50, 50);
            }
        }


        private int curRotate = 0;
        private void left_SimpleButton_Click(object sender, EventArgs e)
        {
            curRotate = curRotate - 90;
            RotateTrans(curRotate);
        }

        private void right_SimpleButton_Click(object sender, EventArgs e)
        {
            curRotate = curRotate + 90;
            RotateTrans(curRotate);
        }

        private void RotateTrans(int p_Rotate){
        Graphics G   = image_PictureBox.CreateGraphics();
        G.Clear(Color.White);
         
        Bitmap d_Image  =(Bitmap) image_PictureBox.Image;

       // '获取当前窗口的中心点
         Rectangle rect = new  Rectangle(0, 0, image_PictureBox.ClientSize.Width, image_PictureBox.ClientSize.Height);
        PointF center  = new PointF(rect.Width / 2, rect.Height / 2);

        float  offsetX   = 0;
        float offsetY   = 0;
        offsetX = center.X - d_Image.Width / 2;
        offsetY = center.Y - d_Image.Height / 2;
       // '构造图片显示区域:让图片的中心点与窗口的中心;点一致
        RectangleF picRect  = new RectangleF(offsetX, offsetY, d_Image.Width, d_Image.Height);
        PointF Pcenter = new PointF(picRect.X + picRect.Width / 2, picRect.Y + picRect.Height / 2);


       // ' 绘图平面以图片的中心点旋转
        G.TranslateTransform(Pcenter.X, Pcenter.Y);
        G.RotateTransform(p_Rotate);
       // '恢复绘图平面在水平和垂直方向的平移
        G.TranslateTransform(-Pcenter.X, -Pcenter.Y);
       // '绘制图片并延时
        G.DrawImage(d_Image, picRect);
      //  '重置绘图平面的所有变换
        G.ResetTransform();

    }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}