using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class ApplyImage_Class
    {
        #region 属性

        #region image_server
        protected string strimage_server = "";
        public string image_server
        {
            get { return strimage_server; }
            set { strimage_server = value; }
        }
        #endregion

        #region server_password
        protected string strserver_password = "";
        public string server_password
        {
            get { return strserver_password; }
            set { strserver_password = value; }
        }
        #endregion

        #region image_disk
        protected string strimage_disk = "";
        public string image_disk
        {
            get { return strimage_disk; }
            set { strimage_disk = value; }
        }
        #endregion

        #region image_file
        protected string strimage_file = "";
        public string image_file
        {
            get { return strimage_file; }
            set { strimage_file = value; }
        }
        #endregion

        #endregion

        #region New
        public ApplyImage_Class()
        {

            string d_strSql = "Select * from imageroad_setup";
            DataSet ds =RISOracle_Class   .GetDS(d_strSql, "查询imageroad_setup表出错" + "\r\n" + d_strSql);

            if (ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法得到申请单保存服务器的信息", "错误");
                d_form.ShowDialog();

                return;
            }
            if (ds.Tables.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("申请单保存服务器的信息被破坏", "错误");
                d_form.ShowDialog();
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("申请单保存服务器的信息被破坏", "错误");
                d_form.ShowDialog();
                return;
            }
            strimage_server = ds.Tables[0].Rows[0]["image_server"].ToString().Trim();
            strserver_password = ds.Tables[0].Rows[0]["server_password"].ToString().Trim();
            strimage_disk = ds.Tables[0].Rows[0]["image_disk"].ToString().Trim();
            strimage_file = ds.Tables[0].Rows[0]["image_file"].ToString().Trim();
        }
        //    '取得图片,如果图片不存在返回Nothing

        public bool  OpenPath( )
        {
            try
            {                //'从数据库得到服务器名,用户名,密码,路径
                System.Diagnostics.Process.Start("net use \\" + strimage_server + "  " + strserver_password + " /user:administrator"); //'建立映射,用户名administrator,密码xing
                return true;
            }
            catch
            {
                return false ;
            }
        }
        public Image GetImage(string p_Path)
        {
            try
            {                //'从数据库得到服务器名,用户名,密码,路径
                System.Diagnostics.Process.Start("net use \\" + strimage_server + "  " + strserver_password + " /user:administrator"); //'建立映射,用户名administrator,密码xing
                // '文件夹
                string d_Path = strimage_file + DateTime.Now.ToString("yyyyMMdd");// '提到申请单要保存的文件夹路径
                if (System.IO.File.Exists(p_Path))
                    return Image.FromFile(p_Path);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

    }
}
