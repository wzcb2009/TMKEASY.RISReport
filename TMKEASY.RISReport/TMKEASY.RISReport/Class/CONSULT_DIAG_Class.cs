using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    class CONSULT_DIAG_Class
    {
        #region 属性

        #region ID号,自增量
        protected int intid = 0;
        public int id
        {
            get { return intid; }
            set { intid = value; }
        }
        #endregion

        #region ACCESSION_NO
        private string strACCESSION_NO = "";
        public string ACCESSION_NO
        {
            get
            {
                return strACCESSION_NO
            ;
            }
            set
            {
                strACCESSION_NO = value
            ;
            }
        }
        #endregion

        #region PATIENT_ID
        private string strPATIENT_ID = "";
        public string PATIENT_ID
        {
            get
            {
                return strPATIENT_ID
            ;
            }
            set
            {
                strPATIENT_ID = value
            ;
            }
        }
        #endregion

        #region REQUEST_DOCTOR
        private string strREQUEST_DOCTOR = "";
        public string REQUEST_DOCTOR
        {
            get
            {
                return strREQUEST_DOCTOR
            ;
            }
            set
            {
                strREQUEST_DOCTOR = value
            ;
            }
        }
        #endregion

        #region REQUEST_DTTM
        private DateTime dateREQUEST_DTTM = Convert.ToDateTime("1900-1-1");
        public DateTime REQUEST_DTTM
        {
            get
            {
                return dateREQUEST_DTTM
            ;
            }
            set
            {
                dateREQUEST_DTTM = value
            ;
            }
        }
        #endregion

        #region REQUEST_CAUSE
        private string strREQUEST_CAUSE = "";
        public string REQUEST_CAUSE
        {
            get
            {
                return strREQUEST_CAUSE
            ;
            }
            set
            {
                strREQUEST_CAUSE = value
            ;
            }
        }
        #endregion

        #region PATIENT_NAME
        private string strPATIENT_NAME = "";
        public string PATIENT_NAME
        {
            get
            {
                return strPATIENT_NAME
            ;
            }
            set
            {
                strPATIENT_NAME = value
            ;
            }
        }
        #endregion

        #region PATIENT_SEX
        private string strPATIENT_SEX = "";
        public string PATIENT_SEX
        {
            get
            {
                return strPATIENT_SEX
            ;
            }
            set
            {
                strPATIENT_SEX = value
            ;
            }
        }
        #endregion

        #region PATIENT_AGE
        private string strPATIENT_AGE = "";
        public string PATIENT_AGE
        {
            get
            {
                return strPATIENT_AGE
            ;
            }
            set
            {
                strPATIENT_AGE = value
            ;
            }
        }
        #endregion

        #region PATIENT_ADDRRESS
        private string strPATIENT_ADDRRESS = "";
        public string PATIENT_ADDRRESS
        {
            get
            {
                return strPATIENT_ADDRRESS
            ;
            }
            set
            {
                strPATIENT_ADDRRESS = value
            ;
            }
        }
        #endregion

        #region PATIENT_TELEPHONE
        private string strPATIENT_TELEPHONE = "";
        public string PATIENT_TELEPHONE
        {
            get
            {
                return strPATIENT_TELEPHONE
            ;
            }
            set
            {
                strPATIENT_TELEPHONE = value
            ;
            }
        }
        #endregion

        #region PATIENT_BIRTHDAY
        private string strPATIENT_BIRTHDAY = "";
        public string PATIENT_BIRTHDAY
        {
            get
            {
                return strPATIENT_BIRTHDAY
            ;
            }
            set
            {
                strPATIENT_BIRTHDAY = value
            ;
            }
        }
        #endregion

        #region CHARGE_TYPE
        private string strCHARGE_TYPE = "";
        public string CHARGE_TYPE
        {
            get
            {
                return strCHARGE_TYPE
            ;
            }
            set
            {
                strCHARGE_TYPE = value
            ;
            }
        }
        #endregion

        #region PRINT_STATUS
        private string strPRINT_STATUS = "";
        public string PRINT_STATUS
        {
            get
            {
                return strPRINT_STATUS
            ;
            }
            set
            {
                strPRINT_STATUS = value
            ;
            }
        }
        #endregion

        #region XNO
        private string strXNO = "";
        public string XNO
        {
            get
            {
                return strXNO
            ;
            }
            set
            {
                strXNO = value
            ;
            }
        }
        #endregion

        #region MODALITY
        private string strMODALITY = "";
        public string MODALITY
        {
            get
            {
                return strMODALITY
            ;
            }
            set
            {
                strMODALITY = value
            ;
            }
        }
        #endregion

        #region CHECK_TYPE
        private string strCHECK_TYPE = "";
        public string CHECK_TYPE
        {
            get
            {
                return strCHECK_TYPE
            ;
            }
            set
            {
                strCHECK_TYPE = value
            ;
            }
        }
        #endregion

        #region  APPOINT_DATE
        private DateTime dateAPPOINT_DATE = DateTime.Now;
        public DateTime APPOINT_DATE
        {
            get
            {
                return dateAPPOINT_DATE
            ;
            }
            set
            {
                dateAPPOINT_DATE = value
            ;
            }
        }
        #endregion

        #region EXPERT_DOCTOR
        private string strEXPERT_DOCTOR = "";
        public string EXPERT_DOCTOR
        {
            get
            {
                return strEXPERT_DOCTOR
            ;
            }
            set
            {
                strEXPERT_DOCTOR = value
            ;
            }
        }
        #endregion

        #region CONSULTATION_INFO
        private string strCONSULTATION_INFO = "";
        public string CONSULTATION_INFO
        {
            get
            {
                return strCONSULTATION_INFO
            ;
            }
            set
            {
                strCONSULTATION_INFO = value
            ;
            }
        }
        #endregion

        #region CONSULTATION_END
        private string strCONSULTATION_END = "";
        public string CONSULTATION_END
        {
            get
            {
                return strCONSULTATION_END
            ;
            }
            set
            {
                strCONSULTATION_END = value
            ;
            }
        }
        #endregion

        #region CONSULTATION_DATE
        private DateTime dateCONSULTATION_DATE = Convert.ToDateTime("1900-1-1");
        public DateTime CONSULTATION_DATE
        {
            get
            {
                return dateCONSULTATION_DATE
            ;
            }
            set
            {
                dateCONSULTATION_DATE = value
            ;
            }
        }
        #endregion

        #region STATUS
        private string strSTATUS = "";
        public string STATUS
        {
            get
            {
                return strSTATUS
            ;
            }
            set
            {
                strSTATUS = value
            ;
            }
        }
        #endregion

        #region REMARK
        private string strREMARK = "";
        public string REMARK
        {
            get
            {
                return strREMARK
            ;
            }
            set
            {
                strREMARK = value
            ;
            }
        }
        #endregion

        #region REMARK2
        private string strREMARK2 = "";
        public string REMARK2
        {
            get
            {
                return strREMARK2
            ;
            }
            set
            {
                strREMARK2 = value
            ;
            }
        }
        #endregion

        #region Err
        //private colErr As Collection
        //public ReadOnly string  Err() As Collection
        //    get{
        //        return colErr
        //    ;}
        //}
        #endregion
        #endregion

        #region New
        public CONSULT_DIAG_Class()
        {
        }


        public CONSULT_DIAG_Class(int p_ID)
        {
            LoadDataByID(p_ID);
        }

        // 
        public CONSULT_DIAG_Class(string p_ACCESSION_NO, string p_EXPERT_DOCTOR)
        {
            LoadDataByID(p_ACCESSION_NO, p_EXPERT_DOCTOR);
        }


        #endregion

        #region 方法
        //  '根据病人ID号得到病人基本资料
        private void LoadDataByID(int p_ID)
        {
            string d_strSql = "";
            d_strSql = "Select * from CONSULT_DIAG where id='" + p_ID.ToString() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询DG_CONSULT_DIAG表出错" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }
        private void SetPropertyByDs(DataSet Ds)
        {
            try
            {
                if (Ds == null)
                {
                    ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
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
                intid = Convert.ToInt32(Ds.Tables[0].Rows[0]["ID"]);
                strACCESSION_NO = Ds.Tables[0].Rows[0]["ACCESSION_NO"].ToString().Trim();
                strPATIENT_ID = Ds.Tables[0].Rows[0]["PATIENT_ID"].ToString().Trim();
                strREQUEST_DOCTOR = Ds.Tables[0].Rows[0]["REQUEST_DOCTOR"].ToString().Trim();
                dateREQUEST_DTTM = Convert.IsDBNull(Ds.Tables[0].Rows[0]["REQUEST_DTTM"]) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(Ds.Tables[0].Rows[0]["REQUEST_DTTM"]);
                strREQUEST_CAUSE = Ds.Tables[0].Rows[0]["REQUEST_CAUSE"].ToString().Trim();
                strPATIENT_NAME = Ds.Tables[0].Rows[0]["PATIENT_NAME"].ToString().Trim();
                strPATIENT_SEX = Ds.Tables[0].Rows[0]["PATIENT_SEX"].ToString().Trim();
                strPATIENT_AGE = Ds.Tables[0].Rows[0]["PATIENT_AGE"].ToString().Trim();
                strPATIENT_ADDRRESS = Ds.Tables[0].Rows[0]["PATIENT_ADDRRESS"].ToString().Trim();
                strPATIENT_TELEPHONE = Ds.Tables[0].Rows[0]["PATIENT_TELEPHONE"].ToString().Trim();
                strPATIENT_BIRTHDAY = Ds.Tables[0].Rows[0]["PATIENT_BIRTHDAY"].ToString().Trim();
                strCHARGE_TYPE = Ds.Tables[0].Rows[0]["CHARGE_TYPE"].ToString().Trim();
                strPRINT_STATUS = Ds.Tables[0].Rows[0]["PRINT_STATUS"].ToString().Trim();
                strXNO = Ds.Tables[0].Rows[0]["XNO"].ToString().Trim();
                strMODALITY = Ds.Tables[0].Rows[0]["MODALITY"].ToString().Trim();
                strCHECK_TYPE = Ds.Tables[0].Rows[0]["CHECK_TYPE"].ToString().Trim();
                dateAPPOINT_DATE = Convert.IsDBNull(Ds.Tables[0].Rows[0]["APPOINT_DATE"]) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(Ds.Tables[0].Rows[0]["APPOINT_DATE"]);
                strEXPERT_DOCTOR = Ds.Tables[0].Rows[0]["EXPERT_DOCTOR"].ToString().Trim();
                strCONSULTATION_INFO = Ds.Tables[0].Rows[0]["CONSULTATION_INFO"].ToString().Trim();
                strCONSULTATION_END = Ds.Tables[0].Rows[0]["CONSULTATION_END"].ToString().Trim();
                dateCONSULTATION_DATE = Convert.IsDBNull(Ds.Tables[0].Rows[0]["CONSULTATION_DATE"]) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(Ds.Tables[0].Rows[0]["CONSULTATION_DATE"]);
                strSTATUS = Ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
                strREMARK = Ds.Tables[0].Rows[0]["REMARK"].ToString().Trim();
                strREMARK2 = Ds.Tables[0].Rows[0]["REMARK2"].ToString().Trim();
            }
            catch (Exception ex)
            {
                flog_Class.WriteFlog(ex.Message);
                ShowErr_Form d_form = new ShowErr_Form(ex.Message, "错误");
                d_form.ShowDialog();
            }
        }
        // '根据病人ID号得到病人基本资料
        private void LoadDataByID(string p_ACCESSION_NO, string p_EXPERT_DOCTOR)
        {
            string d_strSql = "";
            d_strSql = "Select * from CONSULT_DIAG where ACCESSION_NO='" + p_ACCESSION_NO + "' and EXPERT_DOCTOR='" + p_EXPERT_DOCTOR + "' ";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询DG_CONSULT_DIAG表出错" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }

        public bool Insert()
        {
            string d_strSql = "";
            DataSet Ds;
            d_strSql = "select * from CONSULT_DIAG where ACCESSION_NO='" + strACCESSION_NO + "' and EXPERT_DOCTOR='" + strEXPERT_DOCTOR + "' ";
            Ds = RISOracle_Class.GetDS(d_strSql, d_strSql);
            if (Ds.Tables[0].Rows.Count == 0)
            {
                d_strSql = "Insert into DG_CONSULT_DIAG(ACCESSION_NO,PATIENT_ID,REQUEST_DOCTOR,REQUEST_DTTM"
                                                                + ",REQUEST_CAUSE,PATIENT_NAME,PATIENT_SEX,PATIENT_AGE"
                                                                + ",PATIENT_ADDRRESS,PATIENT_TELEPHONE,PATIENT_BIRTHDAY"
                                                                + ",CHARGE_TYPE,PRINT_STATUS,XNO,MODALITY,CHECK_TYPE"
                                                                + ",APPOINT_DATE,EXPERT_DOCTOR,CONSULTATION_INFO,CONSULTATION_END"
                                                                + ",CONSULTATION_DATE,STATUS,REMARK,REMARK2) values ('"
                                                                    + strACCESSION_NO + "','"
                                                                    + strPATIENT_ID + "','"
                                                                    + strREQUEST_DOCTOR + "',"
                                                                    + "to_date('" + dateREQUEST_DTTM.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss'),'"
                                                                    + strREQUEST_CAUSE + "','"
                                                                    + strPATIENT_NAME + "','"
                                                                    + strPATIENT_SEX + "','"
                                                                    + strPATIENT_AGE + "','"
                                                                    + strPATIENT_ADDRRESS + "','"
                                                                    + strPATIENT_TELEPHONE + "','"
                                                                    + strPATIENT_BIRTHDAY + "','"
                                                                    + strCHARGE_TYPE + "','"
                                                                    + strPRINT_STATUS + "','"
                                                                    + strXNO + "','"
                                                                    + strMODALITY + "','"
                                                                    + strCHECK_TYPE + "',"
                                                                    + "to_date('" + dateAPPOINT_DATE.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss'),'"
                                                                    + strEXPERT_DOCTOR + "','"
                                                                    + strCONSULTATION_INFO + "','"
                                                                    + strCONSULTATION_END + "',"
                                                                    + "to_date('" + dateCONSULTATION_DATE.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss'),'"
                                                                    + strSTATUS + "','"
                                                                    + strREMARK + "','"
                                                                    + strREMARK2 + "')";
                return RISOracle_Class.Exec_Cand(d_strSql, "插入DG_CONSULT_DIAG表出错" + "\r\n" + d_strSql);
            }
            return true;
        }

        public bool Update(string p_ID)
        {
            string d_strSql = "";
            d_strSql = "Update CONSULT_DIAG Set EXPERT_DOCTOR='" + strEXPERT_DOCTOR.Trim()
                                          + "',CONSULTATION_INFO='" + strCONSULTATION_INFO.Trim()
                                          + "',CONSULTATION_END='" + strCONSULTATION_END.Trim()
                                          + "',CONSULTATION_DATE=to_date('" + dateCONSULTATION_DATE.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')"
                                          + ",STATUS='" + strSTATUS
                                          + "' where id=" + p_ID.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "更新DG_CONSULT_DIAG表出错" + "\r\n" + d_strSql);
        }

        public bool Delete(string p_Table)
        {
            string d_strSql = "";
            d_strSql = "delete from " + p_Table + " where id=" + intid.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "删除" + p_Table + "表出错" + "\r\n" + d_strSql);
        }


        public static  DataSet GETEXPERT_DOCTOR(string p_ACCESSION_NO)
        {
            string d_strSql = "";
            d_strSql = "select * from CONSULT_DIAG where ACCESSION_NO='" + p_ACCESSION_NO + "' ";
            return RISOracle_Class.GetDS(d_strSql, d_strSql);
        }
        public static bool ISEXPERT_DOCTOR(string p_ACCESSION_NO)
        {
            DataSet Ds =  GETEXPERT_DOCTOR(p_ACCESSION_NO);
            if (Ds != null)
                return false;
            if (Ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public DataSet GETEXPERT_DOCTOR(string p_ACCESSION_NO, string p_expert_doctor)
        {
            string d_strSql = "";
            d_strSql = "select * from CONSULT_DIAG where ACCESSION_NO='" + p_ACCESSION_NO + "' and expert_doctor='" + p_expert_doctor + "'";
            return RISOracle_Class.GetDS(d_strSql, d_strSql);
        }

        #endregion
    }
}
