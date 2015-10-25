using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TMKEASY.RISReport
{
    public partial class ShowPic_Form : Form
    {
        patexam_Class CurPatexam = new patexam_Class();
        public ShowPic_Form()
        {
            InitializeComponent();
        }
        public ShowPic_Form(string p_accessno)
        {
            InitializeComponent();
            CurPatexam = new patexam_Class(p_accessno);
        }
        private void ShowPic_Form_Load(object sender, EventArgs e)
        {
            DownloadPic();
            GetPic();
        }
        #region 图像上传下载
        public FTPSETUP_Class GetFTPSETUPByFTPCODE()
        {
            patregister_Class CurPatregister = new patregister_Class(CurPatexam.accessno);
            FTPSETUP_Class CurFTPSETUP = new FTPSETUP_Class(CurPatregister.ftpcode);
            if (CurFTPSETUP.id == 0)
                CurFTPSETUP.GetDataByFTPStatus();
            return CurFTPSETUP;
        }
        public void DownloadPic()
        {
            string d_FTPOPEN = "";
            d_FTPOPEN = RisSetup_Class.GetINI("setup", "FTPOPEN");
            if (d_FTPOPEN != "yes")
            {
                return;
            }
            FTPSETUP_Class CurFTPSETUP = GetFTPSETUPByFTPCODE();
            string d_FTPUserName, d_FTPPassword, d_FTPHost, d_FTPPort, d_FTPFileName;
            if (CurFTPSETUP.id == 0)
            {
                d_FTPUserName = RisSetup_Class.GetINI("setup", "FTPUserName");
                d_FTPPassword = RisSetup_Class.GetINI("setup", "FTPPassword");
                d_FTPHost = RisSetup_Class.GetINI("setup", "FTPHost");
                d_FTPPort = RisSetup_Class.GetINI("setup", "FTPPort");
                d_FTPFileName = RisSetup_Class.GetINI("setup", "FTPFileName");
            }
            else
            {
                d_FTPUserName = CurFTPSETUP.FTPUserName;
                d_FTPPassword = CurFTPSETUP.FTPPassword;
                d_FTPHost = CurFTPSETUP.FTPHost;
                d_FTPPort = CurFTPSETUP.FTPPort;
                d_FTPFileName = CurFTPSETUP.FTPFileName;
            }
            RIS.Vedio.FtpClient ftp = new RIS.Vedio.FtpClient(d_FTPHost, Convert.ToInt32(d_FTPPort), d_FTPUserName, d_FTPPassword);
            string d_date = CurPatexam.checkdate.ToString("yyyyMMdd");
            // '设置本地和远程的路径 

            ftp.LocalDirectory = Share_Class.Dir + @"\pic\" + d_date + @"\" + CurPatexam.accessno + @"\";
            if (Directory.Exists(ftp.LocalDirectory) == false)
            {
                Directory.CreateDirectory(ftp.LocalDirectory);
            }
            ftp.RemoteDirectory = d_FTPFileName + @"/pic/" + d_date + @"/" + CurPatexam.accessno + @"/";

            // '浏览目录,如果不存在,自动创建目录 
            try
            {
                bool d_status = false;
                string d_imgtype = "*.jpg|*.avi";
                string[] imgtype = d_imgtype.Split(new char[] { '|' });
                for (int i = 0; i < imgtype.Length; i++)
                {
                    List<string> files = ftp.ListDirectory(imgtype[i]);
                    string[] localfiles = System.IO.Directory.GetFiles(ftp.LocalDirectory, imgtype[i]);
                    foreach (string file in files)
                    {
                        d_status = false;
                        foreach (string localfile in localfiles)
                        {
                            if ((ftp.LocalDirectory + files) == localfile)
                            {
                                d_status = true;
                                break;
                            }
                        }
                        if (d_status == false)
                        {
                            ftp.Download(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }
        }
        private void GetPic()
        {
            string PicPath = Share_Class.Dir + "\\pic" + "\\" + CurPatexam.checkdate.ToString("yyyyMMdd") + "\\" + CurPatexam.accessno + "\\";

            Share_Class.CreatePath(PicPath);
            try
            {
                string d_imgtype = "*.jpg|*.avi";
                string[] imgtype = d_imgtype.Split(new char[] { '|' });
                panelImageList1.ImagePath = PicPath;
                panelImageList1.Clear();
                string ShowImageHeight = RisSetup_Class.GetINI("setup", "Report_ShowImageHeight");
                string ShowImageWidth = RisSetup_Class.GetINI("setup", "Report_ShowImageWidth");
                if ((ShowImageHeight != "") && (ShowImageWidth != ""))
                {
                    panelImageList1.ImageSize = new Size(Convert.ToInt32(ShowImageWidth), Convert.ToInt32(ShowImageHeight));
                }
                for (int i = 0; i < imgtype.Length; i++)
                {
                    string[] localfiles = System.IO.Directory.GetFiles(PicPath, imgtype[i]);
                    foreach (string localfile in localfiles)
                    {
                        GetPicfile(localfile);
                    }
                }
            }
            //lblimageNumber.Text = "共" + panelImageList1.Items.Count.ToString() + "张";
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }
        }
        private void GetPicfile(string file)
        {
            try
            {
                panelImageList1.AddImage(file, false);
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message); //'将详细错误信息写入日志
            }

        }
        #endregion
    }
}