using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class report_rewrite_Class
    {
        #region ����
        #region ID��,������
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

        //'����checkid�õ����˻�������
        private void LoadDataByID(int p_checkid)
        {

            string d_strSql = "Select * from giveup where checkid=" + p_checkid.ToString().Trim() + "";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "��ѯgiveup�����" + "\r\n" + d_strSql);
            if (Ds == null)
            {
               
                ShowErr_Form d_form = new ShowErr_Form("��дʱ����", "����");
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
        //'��д
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

        // '���ݼӵ�giveup����
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

            return RISOracle_Class.Exec_Cand(d_strsql, "����giveup�����" + "\r\n" + d_strsql);
        }

        // '�Ǽ���Ϣ����֮ǰ�������
        public bool CheckErr_BeforeInsert()
        {

            if (strgiveup_cause == "")
            {
                colErr = "��дԭ��δ��";
            }
            //if (strresult == "")
            //{
            //    colErr = "��ʾ��δ��";
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
