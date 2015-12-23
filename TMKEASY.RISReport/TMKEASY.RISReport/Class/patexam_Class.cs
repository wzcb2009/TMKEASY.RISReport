using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport
{
    public class patexam_Class : Table.Patexam
    {

        #region reportdoc_code
        private string strreportdoc_code = "";
        public string reportdoc_code
        {
            get { return strreportdoc_code; }
            set { strreportdoc_code = value; }
        }
        #endregion

        #region advancedoc_code
        private string stradvancedoc_code = "";
        public string advancedoc_code
        {
            get { return stradvancedoc_code; }
            set { stradvancedoc_code = value; }
        }
        #endregion

        #region New

        public patexam_Class()
        {
        }

        public patexam_Class(int p_checkid)
        {
            LoadDataByID(p_checkid);
        }

        public patexam_Class(string p_accessno)
        {
            LoadDataByID(p_accessno);
        }

        public patexam_Class(string p_patid, string name)
        {
            LoadDataByID(p_patid, name);
        }

        #endregion

        #region 方法
        //'根据checkid得到病人基本资料
        private void LoadDataByID(int p_checkid)
        {
            string d_strSql = "";
            d_strSql = "Select * from patexam where checkid='" + p_checkid.ToString().Trim() + "'";
            DataSet Ds = new DataSet();
            Ds = RISOracle_Class.GetDS(d_strSql, "查询patexam表出错" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }

        //'根据访问号得到病人基本资料
        private void LoadDataByID(string p_accessno)
        {
            string d_strSql = "";
            d_strSql = "Select * from patexam where accessno='" + p_accessno.Trim() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询patexam表出错" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }

        //'根据访问号得到病人基本资料
        private void LoadDataByID(string p_patid, string name)
        {
            string d_strSql = "";
            d_strSql = "Select * from patexam where patid='" + p_patid.Trim() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询patexam表出错" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }

        //'审核
        public bool Save_Advance(string p_oldadvancedoc, string p_status)
        {
            string d_strsql = "";
            DateTime nowdate = Share_Class.GetSysdate();
            //stradvancedoc = Share_Class.User.user_id;
            d_strsql = "Update patexam Set advancedoc='" + stradvancedoc + "'";
            if (p_status != "复审")
                d_strsql += ",advancedate=to_date('" + nowdate.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')";

            if ((strcheck_status != "已审核") && (strcheck_status != "未审核"))
            {
                d_strsql += ",reportdoc='" + strreportdoc.Trim();
                d_strsql += "',reportdate=to_date('" + nowdate.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')";
            }
            d_strsql += ",machinetype='" + strmachinetype.Trim()
                  + "',sqdep='" + strsqdep.Trim()
                  + "',checktype='" + strchecktype.Trim()
                  + "',clinicend='" + strclinicend.Trim()
                  + "',bedno='" + strBedNo.Trim()
                  + "',layerthick='" + strlayerthick.Trim()
                  + "',xno='" + strxno.ToString().Trim()
                  + "',checkpos='" + strcheckpos.Trim()
                  + "',layerinterval='" + strlayerinterval.Trim()
                  + "',imagepos='" + strimagepos.Trim()
                  + "',imagemethod='" + strimagemethod.Trim()
                  + "',reportdisease='" + strreportdisease.Trim()
                  + "',diseasetype='" + strdiseasetype.Trim()
                  + "',check_status='已审核"
                  + "',reportinfo='" + strreportinfo
                  + "',reportend='" + strreportend + "' where accessno='" + straccessno + "'";
            if (RISOracle_Class.Exec_Cand(d_strsql, "更新patexam表出错" + "\r\n" + d_strsql))
            {
                if ((strcheck_status != "已审核") && (strcheck_status != "未审核"))
                {
                    Update_Two_wl_Report();
                    patregister_Class.Updatedoctorcode(straccessno, "reportdoc_code", strreportdoc_code);

                }
                patregister_Class.Updatedoctorcode(straccessno, "advancedoc_code", stradvancedoc_code);
                Update_Two_wl_Advance();
                flog_Class.Insertflog("报告审核", "", "Save_Advance", straccessno);
                strcheck_status = "已审核";
                if (p_status == "复审")
                {
                    if (p_oldadvancedoc == "")
                        p_oldadvancedoc = Share_Class.User.user_id;
                    patregister_Class.Updatedoctorcode(straccessno, "firadvancedoc", p_oldadvancedoc);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //'报告
        public bool Save_Report()
        {
            string d_strsql = "";
            DateTime nowdate = Share_Class.GetSysdate();

            d_strsql = "Update patexam Set reportdoc='" + strreportdoc.Trim()
                                       + "',modcheckdate=to_date('" + datemodcheckdate.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')"
                                       + ",reportdate=to_date('" + nowdate.ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss')"
                                       + ",machinetype='" + strmachinetype.Trim()
                                       + "',sqdep='" + strsqdep.Trim()
                                       + "',checktype='" + strchecktype.Trim()
                                       + "',clinicend='" + strclinicend.Trim()
                                       + "',bedno='" + strBedNo.Trim()
                                       + "',layerthick='" + strlayerthick.Trim()
                                       + "',xno='" + strxno.ToString().Trim()
                                       + "',checkpos='" + strcheckpos.Trim()
                                       + "',layerinterval='" + strlayerinterval.Trim()
                                       + "',reportdisease='" + strreportdisease.Trim()
                                       + "',imagepos='" + strimagepos.Trim()
                                       + "',imagemethod='" + strimagemethod.Trim()
                                       + "',diseasetype='" + strdiseasetype.Trim()
                                       + "',check_status='未审核"
                                       + "',reportinfo='" + strreportinfo
                                       + "',reportend='" + strreportend + "' where accessno='" + straccessno + "'";
            if (RISOracle_Class.Exec_Cand(d_strsql, "更新patexam表出错" + "\r\n" + d_strsql))
            {
                Update_Two_wl_Report();
                flog_Class.Insertflog("报告保存", "", "Save_Report", straccessno);
                patregister_Class.Updatedoctorcode(straccessno, "reportdoc_code", strreportdoc_code);
                strcheck_status = "未审核";
                return true;
            }
            else
            {
                return false;
            }
        }
        //  '在审核后更新mwlwl表和REPORTWL表
        public bool Update_Two_wl_Advance()
        {
            //'MWLWL
            string d_strSql = "";
            string d_user_des = "";
            DataSet Ds = new DataSet();
            d_strSql = "Select user_des from userinfo where user_id='" + strreportdoc.Trim() + "'";
            Ds = RISOracle_Class.GetDS(d_strSql, "更新userinfo表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                return false;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                d_user_des = strreportdoc;
            }
            else
            {
                d_user_des = Ds.Tables[0].Rows[0][0].ToString().Trim();
                if (d_user_des.Trim() == "")
                {
                    d_user_des = strreportdoc;
                }
            }

            d_strSql = "Update MWLWL set SCHEDULED_PROC_STATUS='240' where ACCESSION_NO='" + straccessno + "'";
            RISOracle_Class.Exec_Cand(d_strSql, "更新MWLWL表出错" + "\r\n" + d_strSql);

            // 'MWLWL
            d_strSql = "Update MWLWL set REPLICA_DTTM=TRIGGER_DTTM where ACCESSION_NO='" + straccessno + "' and REPLICA_DTTM='ANY'";
            RISOracle_Class.Exec_Cand(d_strSql, "更新MWLWL表出错" + "\r\n" + d_strSql);


            d_strSql = "Update call_register set LAST_CALL_DTTM='" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' where ACCESSION_NO='" + straccessno + "'";
            RISOracle_Class.Exec_Cand(d_strSql, "更新call_register表出错" + "\r\n" + d_strSql);
            // 'REPORTWL


            d_strSql = "Update REPORTWL set TRIGGER_DTTM='" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                      + "',REPORT_STAT='240"
                                      + "',REPLICA_DTTM='ANY"
                                      + "',APPROVER_id='" + d_user_des.Trim()
                                      + "',APPROVER_NAME='" + stradvancedoc.Trim()
                                      + "',APPROVE_DTTM='" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                      + "',REPORT_TEXT='" + reportinfo
                                      + "',CONCLUSION='" + reportend + "'  where EXAM_ID='" + straccessno + "'";
            return RISOracle_Class.Exec_Cand(d_strSql, "更新REPORTWL表出错" + "\r\n" + d_strSql);
        }
        //   '在报告后更新mwlwl表和REPORTWL表
        public bool Update_Two_wl_Report()
        {

            string d_strSql = "";
            string d_user_des = "";
            DataSet Ds = new DataSet();
            d_strSql = "Select user_des from userinfo where user_id='" + strreportdoc.Trim() + "'";
            Ds = RISOracle_Class.GetDS(d_strSql, "查询user_des表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                return false;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                d_user_des = strreportdoc;
            }
            else
            {
                d_user_des = Ds.Tables[0].Rows[0][0].ToString().Trim();
                if (d_user_des.Trim() == "")
                {
                    d_user_des = strreportdoc;
                }
            }
            // 'MWLWL
            d_strSql = "Update MWLWL set SCHEDULED_PROC_STATUS='230' where ACCESSION_NO='" + straccessno + "'";
            RISOracle_Class.Exec_Cand(d_strSql, "更新MWLWL表出错" + "\r\n" + d_strSql);

            // 'MWLWL
            d_strSql = "Update MWLWL set REPLICA_DTTM=TRIGGER_DTTM where ACCESSION_NO='" + straccessno + "' and REPLICA_DTTM='ANY'";
            RISOracle_Class.Exec_Cand(d_strSql, "更新MWLWL表出错" + "\r\n" + d_strSql);

            //  'call_register
            d_strSql = "Update call_register set FIRST_CALL_DTTM='" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' where ACCESSION_NO='" + straccessno + "'";// '更新报告时间
            RISOracle_Class.Exec_Cand(d_strSql, "更新call_register表出错" + "\r\n" + d_strSql);


            d_strSql = "select * from REPORTWL  where EXAM_ID='" + straccessno + "'";
            Ds = RISOracle_Class.GetDS(d_strSql, "查询REPORTWL表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                return false;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                d_strSql = "Insert into REPORTWL (TRIGGER_DTTM,REPLICA_DTTM,EXAM_ID,PATIENT_ID,REPORT_STAT,CREATOR_ID,CREATOR_NAME,CREATE_DTTM,DICTATOR_ID,DICTATOR_NAME,DICTATE_DTTM,TRANSCRIBER_ID,TRANSCRIBER_NAME,TRANSCRIBE_DTTM,APPROVER_ID,APPROVER_NAME,APPROVE_DTTM,REVISER_ID,REVISER_NAME,REVISE_DTTM,REPORT_TYPE,REPORT_TEXT,CONCLUSION)  values ('" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                          + "','ANY"
                                          + "','" + straccessno.Trim()
                                          + "','" + strxno.ToString().Trim()
                                          + "','230"
                                          + "','med"
                                          + "','med"
                                          + "','" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','" + d_user_des.Trim()
                                          + "','" + strreportdoc.Trim()
                                          + "','" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','"
                                          + "','" + strreportinfo.Trim()
                                          + "','" + strreportend + "')";
            }
            else
            {
                //  'REPORTWL
                d_strSql = "Update REPORTWL set TRIGGER_DTTM='" + DateTime.Now.ToString("yyyyMMddHHmmss").Trim()
                                          + "',REPORT_STAT='230"
                                          + "',TRANSCRIBER_ID='" + d_user_des.Trim()
                                          + "',TRANSCRIBER_NAME='" + strreportdoc.Trim()
                                          + "',TRANSCRIBE_DTTM='" + datereportdate.ToString("yyyyMMddHHmmss").Trim()
                                          + "',REPORT_TEXT='" + reportinfo
                                          + "',CONCLUSION='" + reportend + "'  where EXAM_ID='" + straccessno + "'";
            }
            return RISOracle_Class.Exec_Cand(d_strSql, "更新REPORTWL表出错" + "\r\n" + d_strSql);
        }
        public bool TempReportSave(string d_reportinfo, string d_reportend, string d_accessno)
        {
            string d_strsql = "";
            d_strsql = "Update patexam Set reportinfo='" + d_reportinfo + "',reportend='" + d_reportend + "' where accessno='" + d_accessno + "'";
            return RISOracle_Class.Exec_Cand(d_strsql, "更新patexam表出错" + "\r\n" + d_strsql);

        }

        // '根据姓名或PatId来查询记录
        public static DataSet Findpatexamhistroy(string p_Name, string p_patient_id, string p_acceson, string d_xno)
        {
            string d_strSql = "";
            d_strSql = "select patient_name,patient_sex, patient_birth_date,to_date(scheduled_dttm,'yyyyMMddhh24miss') scheduled_dttm,conclusion,REPORT_TEXT,mwlwl.patient_id,scheduled_modality,accession_no,transcriber_name,approver_name,request_department,age from mwlwl,reportwl,patregister "
                    + " where mwlwl.accession_no=reportwl.exam_id and patregister.clinicno=mwlwl.accession_no";
            string d_GetValue = RisSetup_Class.GetINI("setup", "search_historyreport");
            //if (d_GetValue == "name")
            d_strSql = d_strSql + " and patient_name='" + p_Name.Trim() + "'";
            //else if (d_GetValue == "patid")
            d_strSql = d_strSql + " and specialty='" + p_patient_id.Trim() + "'";

            d_strSql = d_strSql + " and accession_no<>'" + p_acceson + "'";
            //'d_strSql = d_strSql + " and clinicno=patid";

            //'得到排序类型
            d_GetValue = RisSetup_Class.GetINI("setup", "order_dir");
            if (d_GetValue != "")
                d_strSql = d_strSql + " order by mwlwl.trigger_dttm " + d_GetValue;


            //'执行语句并返回结果记录集
            return RISOracle_Class.GetDS(d_strSql, "联合查询patexam和patregister表和mwlwl表和reportwl表出错" + "\r\n" + d_strSql);
        }
        // '根据姓名来查询记录
        public static DataSet Findpatexamhistroy(string p_Name, string p_acceson)
        {
            string d_strSql = "";
            d_strSql = "select patient_name,patient_sex,patient_birth_date,scheduled_dttm,conclusion,REPORT_TEXT,mwlwl.patient_id,scheduled_modality,accession_no,transcriber_name,approver_name,request_department,requested_proc_reason,requested_proc_comments,patient_location from mwlwl,reportwl "
                   + " where mwlwl.accession_no=reportwl.exam_id ";
            string d_GetValue = RisSetup_Class.GetINI("setup", "search_historyreport");
            d_strSql = d_strSql + " and patient_name='" + p_Name.Trim() + "'";
            d_strSql = d_strSql + " and accession_no<>'" + p_acceson + "'";
            //'d_strSql = d_strSql + " and clinicno=patid"

            //'得到排序类型
            d_GetValue = RisSetup_Class.GetINI("setup", "order_dir");
            if (d_GetValue != "")
                d_strSql = d_strSql + " order by mwlwl_key " + d_GetValue;


            //'执行语句并返回结果记录集
            return RISOracle_Class.GetDS(d_strSql, "联合查询patexam和patregister表和mwlwl表和reportwl表出错" + "\r\n" + d_strSql);
        }

        public bool Save_giveup()
        {
            string d_strsql = "";
            d_strsql = "Update patexam Set check_status='重写' where accessno='" + straccessno + "'";
            if (RISOracle_Class.Exec_Cand(d_strsql, "更新patexam表出错" + "\r\n" + d_strsql) == true)
            {
                strcheck_status = "重写";
                return true;
            }
            else
                return false;

        }

        //  '设置报告是否在编辑
        public static bool Setwrite_flag(string p_accessno, string p_writeflag)
        {
            string d_strsql = "Update patexam Set write_flag='" + p_writeflag.Trim() + "' where accessno='" + p_accessno.Trim() + "'";
            return RISOracle_Class.Exec_Cand(d_strsql, "更新patexam表出错" + "\r\n" + d_strsql);
        }

        #endregion
    }
}
