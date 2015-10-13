using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class ApplyImage_Class
    {
        #region ����

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
            DataSet ds =RISOracle_Class   .GetDS(d_strSql, "��ѯimageroad_setup�����" + "\r\n" + d_strSql);

            if (ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("�޷��õ����뵥�������������Ϣ", "����");
                d_form.ShowDialog();

                return;
            }
            if (ds.Tables.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("���뵥�������������Ϣ���ƻ�", "����");
                d_form.ShowDialog();
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("���뵥�������������Ϣ���ƻ�", "����");
                d_form.ShowDialog();
                return;
            }
            strimage_server = ds.Tables[0].Rows[0]["image_server"].ToString().Trim();
            strserver_password = ds.Tables[0].Rows[0]["server_password"].ToString().Trim();
            strimage_disk = ds.Tables[0].Rows[0]["image_disk"].ToString().Trim();
            strimage_file = ds.Tables[0].Rows[0]["image_file"].ToString().Trim();
        }
        //    'ȡ��ͼƬ,���ͼƬ�����ڷ���Nothing

        public bool  OpenPath( )
        {
            try
            {                //'�����ݿ�õ���������,�û���,����,·��
                System.Diagnostics.Process.Start("net use \\" + strimage_server + "  " + strserver_password + " /user:administrator"); //'����ӳ��,�û���administrator,����xing
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
            {                //'�����ݿ�õ���������,�û���,����,·��
                System.Diagnostics.Process.Start("net use \\" + strimage_server + "  " + strserver_password + " /user:administrator"); //'����ӳ��,�û���administrator,����xing
                // '�ļ���
                string d_Path = strimage_file + DateTime.Now.ToString("yyyyMMdd");// '�ᵽ���뵥Ҫ������ļ���·��
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
