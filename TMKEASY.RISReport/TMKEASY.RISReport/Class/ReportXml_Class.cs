using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
   public  class ReportXml_Class
    {
        #region 属性


        #region xml文件
        private string strxmlfile = "";
        public string xmlfile
        {
            get { return strxmlfile; }
            set { strxmlfile = value; }
        }
        #endregion



        #region 访问号
        private string straccessno = "";
        public string accessno
        {
            get { return straccessno; }
            set { straccessno = value; }
        }
        #endregion

        #region 报告样式名称
       private string strstylename = "";
       public string stylename
        {
            get { return strstylename; }
            set { strstylename = value; }
        }
        #endregion

        #endregion

        #region New
        public ReportXml_Class()
        {
        }

        public ReportXml_Class(string p_checkid)
        {
            LoadDataByID(p_checkid);
        }
        public ReportXml_Class(DataRow p_Dw)
        {
            SetPropertyByDs(p_Dw);
        }
        #endregion

        #region 方法
        private void LoadDataByID(string p_checkid)
        {
            string d_strSql = "";
            d_strSql = "Select * from ReportXml where accessno='" + p_checkid.ToString().Trim() + "'";
            DataSet Ds = new DataSet();
            Ds = RISOracle_Class.GetDS(d_strSql, "查询ReportXml表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
              ShowErr_Form d_form = new  ShowErr_Form("无法从数据库中取得数据", "错误");
              d_form.ShowDialog();
                return;
            }
            if (Ds.Tables.Count == 0)
            {
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            SetPropertyByDs(Ds.Tables[0].Rows[0]);
        }
        private void SetPropertyByDs(DataRow p_Dw)
        {


            straccessno = p_Dw["accessno"].ToString().Trim();
            strstylename = p_Dw["stylename"].ToString().Trim();
            try
            {
                strxmlfile = Convert.IsDBNull(p_Dw["xmlfile"]) ? "" : System.Text.Encoding.Default.GetString((byte[])p_Dw["xmlfile"]);
            }
            catch { strxmlfile = ""; }
        }
        public bool Save()
        {
            ReportXml_Class reportxml = new ReportXml_Class(straccessno);
            if (reportxml.accessno == "")
            {
                Insert();
            }
            return Update();


        }
        public bool Insert()
        {
            string d_strSql = "";
            d_strSql = "insert into  ReportXml(accessno,stylename) values ('" + straccessno + "','" + strstylename + "')";
            return RISOracle_Class.Exec_Cand(d_strSql, d_strSql);
        }
        public bool Update()
        {
            string d_strSql = "";
            d_strSql = "Update ReportXml set xmlfile=:Byte  ,stylename='"+strstylename +"'  where accessno='" + straccessno.ToString() + "' ";
            byte[] b_diag = System.Text.Encoding.Default.GetBytes(strxmlfile);
            return RISOracle_Class   .Exec_Cand_Blob(d_strSql, b_diag, d_strSql);
        }


        #endregion
    }
}
