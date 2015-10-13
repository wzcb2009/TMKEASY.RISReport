using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class report_rewrite_Class
    {
        #region 属性
        #region ID号,自增量
        private int intid = 0;
        public int id
        {
            get
            {
                return intid
            ;
            }
            set
            {
                intid = value
           ;
            }
        }
        #endregion

        #region patexam
        private patexam_Class clspatexam;
        public patexam_Class patexam
        {
            get
            {
                return clspatexam
            ;
            }
            set
            {
                clspatexam = value
           ;
            }
        }
        #endregion

        #region giveup_cause
        private string strgiveup_cause = "";
        public string giveup_cause
        {
            get
            {
                return strgiveup_cause
            ;
            }
            set
            {
                strgiveup_cause = value
           ;
            }
        }
        #endregion

        #region result
        private string strresult = "";
        public string result
        {
            get
            {
                return strresult
            ;
            }
            set
            {
                strresult = value
           ;
            }
        }
        #endregion

        #region describle
        private string strdescrible = "";
        public string describle
        {
            get
            {
                return strdescrible
            ;
            }
            set
            {
                strdescrible = value
           ;
            }
        }
        #endregion

        #region Err
        private string colErr = "";
        public string Err
        {
            get
            {
                return colErr
            ;
            }
        }
        #endregion

        #endregion

        public report_rewrite_Class()
        {

        }
        public report_rewrite_Class(patexam_Class p_patexam)
        {
            clspatexam = p_patexam;
            LoadDataByID(p_patexam.checkid);
        }

        //'根据checkid得到病人基本资料
        private void LoadDataByID(int p_checkid)
        {

            string d_strSql = "Select * from giveup where checkid=" + p_checkid.ToString().Trim() + "";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询giveup表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
               
                ShowErr_Form d_form = new ShowErr_Form("重写时出错", "错误");
                d_form.ShowDialog();
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            intid = Convert.ToInt32(Ds.Tables[0].Rows[0]["id"]);
            strgiveup_cause = Ds.Tables[0].Rows[0]["giveup_cause"].ToString().Trim();
            strresult = Ds.Tables[0].Rows[0]["result"].ToString().Trim();
            strdescrible = Ds.Tables[0].Rows[0]["describle"].ToString();

        }
        //'重写
        public bool report_rewrite()
        {
            if (clspatexam.Save_giveup())
            {
                return Save();
            }
            else
            {
                return false;
            }
        }

        // '数据加到giveup表中
        private bool Save()
        {
            string d_strsql = "";
            if (intid == 0)
            {
                d_strsql = "insert into giveup (CHECKID,GIVEUP_CAUSE,RESULT,DESCRIBLE) values (" + clspatexam.checkid.ToString().Trim()
                                            + ",'" + strgiveup_cause.Trim()
                                            + "','" + strresult.Trim()
                                            + "','" + describle + "')";
            }
            else
            {
                d_strsql = "Update giveup set giveup_cause='" + strgiveup_cause.Trim()
                                                        + "',result='" + strresult.Trim()
                                                        + "',describle='" + strdescrible + "' where id=" + intid.ToString().Trim();
            }

            return RISOracle_Class.Exec_Cand(d_strsql, "保存giveup表出错" + "\r\n" + d_strsql);
        }

        // '登记信息增加之前错误检验
        public bool CheckErr_BeforeInsert()
        {

            if (strgiveup_cause == "")
            {
                colErr = "重写原因未填";
            }
            //if (strresult == "")
            //{
            //    colErr = "提示答案未填";
            //}

            if (colErr == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
