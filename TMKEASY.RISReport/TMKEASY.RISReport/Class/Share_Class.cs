using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport
{
    public class Share_Class
    {
        #region 路径
        private static string clsDir = GetAssemblyPath();
        public static string Dir
        {
            get { return clsDir; }
            set { clsDir = value; }
        }
        /// <summary>
        /// 获取Assembly的运行路径
        /// </summary>
        ///<returns></returns>
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是file:// 的长度

            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }

            return _FolderPath;
        }
        #endregion

        #region 操作员
        private static Table.Userinfo clsUser;
        public static Table.Userinfo User
        {
            get { return clsUser; }

            set { clsUser = value; }

        }
        #endregion

        #region 医疗机构名称
        private static string strhospital_name = "市第一医院";
        public static string hospital_name
        {
            get { return strhospital_name; }
            set { strhospital_name = value; }
        }
        private static string strSecondhospital_name = "";
        public static string Secondospital_name
        {
            get { return strSecondhospital_name; }
            set { strSecondhospital_name = value; }
        }
        #endregion

        #region 医疗机构代码
        private static string strhospital_code = "";
        public static string hospital_code
        {
            get { return strhospital_code; }
            set { strhospital_code = value; }
        }
        #endregion

        #region PACS
        public static void ShowPiviewPacsPicture(string p_xno, string p_patid, string p_accessno, string p_modality)
        {
            KY.PacsPictureModule.PacsPictureModule.ShowPiviewPacsPicture(p_xno, p_patid, p_accessno, p_modality);
        }
        //public static void ShowPacsPicture(string p_xno, string p_patid, string p_accessno, string p_modality)
        //{
        //    try
        //    {
        //         KY.PacsPictureModule.PacsPictureModule.ShowPacsPicture(p_xno, "", p_accessno, p_modality, "1");

        //    }
        //    catch { }
        //}
        public static void ShowPacsPicture(string p_xno, string p_patid, string p_accessno, string p_modality)
        {
            string p_direct_image = RisSetup_Class.GetINI("setup", "direct_image");

            string d_PacsUser, d_PacsPwd, d_PacsIP;
            d_PacsUser = RisSetup_Class.GetINI("setup", "PACSID");
            d_PacsPwd = RisSetup_Class.GetINI("setup", "PACSPassword");
            d_PacsIP = RisSetup_Class.GetINI("setup", "PACSIP");
            //If Share_Class.User.reportdoc <> "" And Share_Class.User.grade <> "" Then
            //    d_PacsUser = Share_Class.User.reportdoc
            //    d_PacsPwd = Share_Class.User.grade
            //End If

            string iePath = RisSetup_Class.GetINI("setup", "iepath");
            string pacsstr = "";
            pacsstr = @"http://" + d_PacsIP + @"/pkg_pacs/external_interface.aspx?LID=" + d_PacsUser + "&LPW=" + d_PacsPwd + "";
            if (p_accessno == "")
            {
                // 'If p_modality = "" Then
                pacsstr += "&pid=" + p_xno + "&mx=1";
                //'Else
                //'    pacsstr += "&pid=" & p_xno & "&mx=1"
                //'End If
            }
            else
            {
                pacsstr += "&an=" + p_accessno + "";
            }
            if (iePath != "")
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = iePath;
                p.StartInfo.Arguments = pacsstr;
                p.Start();
            }
            else
            {
                System.Diagnostics.Process.Start(pacsstr);
            }



        }
        public static void ClosePacsPicture()
        {
            string p_direct_image = RisSetup_Class.GetINI("setup", "direct_image");

            string d_PacsUser, d_PacsPwd, d_PacsIP;
            d_PacsUser = RisSetup_Class.GetINI("setup", "PACSID");
            d_PacsPwd = RisSetup_Class.GetINI("setup", "PACSPassword");
            d_PacsIP = RisSetup_Class.GetINI("setup", "PACSIP");
            //If Share_Class.User.reportdoc <> "" And Share_Class.User.grade <> "" Then
            //    d_PacsUser = Share_Class.User.reportdoc
            //    d_PacsPwd = Share_Class.User.grade
            //End If

            string iePath = RisSetup_Class.GetINI("setup", "iepath");
            string pacsstr = "";

            pacsstr = @"http://" + d_PacsIP + @"/pkg_pacs/external_interface.aspx?LID=" + d_PacsUser + "&LPW=" + d_PacsPwd + "&TYPE=CCE";


            if (iePath != "")
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = iePath;
                p.StartInfo.Arguments = pacsstr;
                p.Start();
            }
            else
            {
                System.Diagnostics.Process.Start(pacsstr);
            }



        }
        #endregion

        public static DateTime GetSysdate()
        {
            string d_strSql = "";
            d_strSql = "select sysdate from dual";
            System.Data.DataSet Ds = RISOracle_Class.GetDS(d_strSql, "取服务器时间出错" + "\r\n" + d_strSql);
            try
            {
                return Convert.ToDateTime(Ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static string GetIPAndAddress()
        {
            System.Net.IPAddress[] Address;

            string p_IPAddress = "";
            Address = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList;
            p_IPAddress = "主机名称：" + System.Net.Dns.GetHostName().ToString() + "；IP地址：";
            for (int i = 0; i < Address.Length; i++)
            {
                p_IPAddress = p_IPAddress + Address[i].ToString();
            }
            return p_IPAddress;
        }

        public static void CreatePath(string path)
        {
            if (System.IO.Directory.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
    }
}
