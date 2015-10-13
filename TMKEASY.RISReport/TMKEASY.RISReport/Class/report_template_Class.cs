using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport
{
    public class report_template_Class : template_Class
    {
        //#region 属性
        //#region template_id
        //private int inttemplate_id = 0;
        //public int template_id
        //{
        //   get
        //    {
        //        return inttemplate_id;

        //    }
        //    set
        //    {
        //        inttemplate_id = value;;;

        //    }
        //}
        //#endregion

        //#region dep
        //private  string strdep = "";
        //public string dep
        //{
        //   get
        //    {
        //        return strdep;

        //    }
        //    set
        //    {
        //        strdep = value;;;

        //    }
        //}
        //#endregion

        //#region template_part
        //private   string strtemplate_part = "";
        //public string template_part
        //{
        //   get
        //    {
        //        return strtemplate_part;

        //    }
        //    set
        //    {
        //        strtemplate_part = value;;;

        //    }
        //}
        //#endregion

        //#region template_name
        //private   string strtemplate_name = "";
        //public string template_name
        //{
        //   get
        //    {
        //        return strtemplate_name;

        //    }
        //    set
        //    {
        //        strtemplate_name = value;;;

        //    }
        //}
        //#endregion

        //#region template_describle
        //private   string strtemplate_describle = "";
        //public string template_describle
        //{
        //   get
        //    {
        //        return strtemplate_describle;

        //    }
        //    set
        //    {
        //        strtemplate_describle = value;;;

        //    }
        //}
        //#endregion

        //#region disease_type
        //private   string strdisease_type = "";
        //public string disease_type
        //{
        //   get
        //    {
        //        return strdisease_type;

        //    }
        //    set
        //    {
        //        strdisease_type = value;;;

        //    }
        //}
        //#endregion

        //#region template_time
        //private DateTime datetemplate_time = Convert.ToDateTime("1900-1-1");
        //public DateTime template_time
        //{
        //   get
        //    {
        //        return datetemplate_time;

        //    }
        //    set
        //    {
        //        datetemplate_time = value;;;

        //    }
        //}
        //#endregion

        //#region template_grade
        //private   string strtemplate_grade = "";
        //public string template_grade
        //{
        //   get
        //    {
        //        return strtemplate_grade;

        //    }
        //    set
        //    {
        //        strtemplate_grade = value;;;

        //    }
        //}
        //#endregion

        //#region template_diag
        //private   string strtemplate_diag = "";
        //public string template_diag
        //{
        //   get
        //    {
        //        return strtemplate_diag;

        //    }
        //    set
        //    {
        //        strtemplate_diag = value;;;

        //    }
        //}
        //#endregion

        //#region xml_describle
        //private   string strxml_describle = "";
        //public string xml_describle
        //{
        //   get
        //    {
        //        return strxml_describle;

        //    }
        //    set
        //    {
        //        strxml_describle = value;;;

        //    }
        //}
        //#endregion

        //#region xml_diag
        //private   string strxml_diag = "";
        //public string xml_diag
        //{
        //   get
        //    {
        //        return strxml_diag;

        //    }
        //    set
        //    {
        //        strxml_diag = value;;;

        //    }
        //}
        //#endregion

        //#region 医院代码
        //private   string strhospital_code = "";
        //public string hospital_code
        //{
        //   get{ return strhospital_code; }
        //    set { strhospital_code = value;;; }
        //}
        //#endregion
        //#endregion

        #region New
        public report_template_Class()
            : base()
        {

        }
        public report_template_Class(DataTable p_Table)
            : base(p_Table)
        {
            SetPropertyByDs(p_Table);
        }
        public report_template_Class(string p_template_grade, int p_ID)
            : base(p_template_grade, p_ID)
        {
            LoadModelPlanByID(p_template_grade, p_ID);
        }

        public report_template_Class(string p_template_grade, string p_dep, string p_template_part, string p_disease_type, string p_template_name)
            : base(p_template_grade, p_dep, p_template_part, p_disease_type, p_template_name)
        {

            LoadModelPlanByName(p_template_grade, p_dep, p_template_part, p_disease_type, p_template_name);
        }
        #endregion

        #region 方法
        private void LoadModelPlanByID(string p_template_grade, int p_ID)
        {
            string d_strSql = "";
            string d_Table = "";
            if (p_template_grade == "公有")
            {
                d_Table = "report_template";
            }
            else
            {
                d_Table = "report_template_private";
            }
            d_strSql = "Select * from " + d_Table + " where template_id=" + p_ID.ToString();
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询" + d_Table + "表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法得到模板", "提示");

                d_form.ShowDialog();
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法得到模板", "提示");


                return;
            }
            SetPropertyByDs(Ds.Tables[0]);
        }

        private void LoadModelPlanByName(string p_template_grade, string p_dep, string p_template_part, string p_disease_type, string p_template_name)
        {
            string d_strSql = "";
            string d_Table = "";
            if (p_template_grade == "公有")
            {
                d_Table = "report_template";
            }
            else
            {
                d_Table = "report_template_private";
            }
            d_strSql = "Select * from " + d_Table + " where template_name='" + p_template_name
                                                 + "' and template_part='" + p_template_part
                                                 + "' and dep='" + p_dep.Trim()
                                                 + "' and disease_type='" + p_disease_type
                                                 + "' and template_grade='" + p_template_grade + "' ";
            //d_strSql += "and hospital_code='" + Share_Class.User.hospital_code + "' ";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "插入" + d_Table + "表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法得到模板", "提示");
                d_form.ShowDialog();

                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法得到模板", "提示");

                d_form.ShowDialog();
                return;
            }
            SetPropertyByDs(Ds.Tables[0]);
        }

        private void SetPropertyByDs(DataTable p_Table)
        {

            inttemplate_id = Convert.ToInt32(p_Table.Rows[0]["template_id"]);
            strdep = p_Table.Rows[0]["dep"].ToString();
            strtemplate_part = p_Table.Rows[0]["template_part"].ToString();
            strtemplate_name = p_Table.Rows[0]["template_name"].ToString();
            strtemplate_describle = p_Table.Rows[0]["template_describle"].ToString();
            strdisease_type = p_Table.Rows[0]["disease_type"].ToString();
            datetemplate_time = Convert.IsDBNull(p_Table.Rows[0]["template_time"]) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(p_Table.Rows[0]["template_time"]);
            strtemplate_grade = p_Table.Rows[0]["template_grade"].ToString();
            strtemplate_diag = p_Table.Rows[0]["template_diag"].ToString();
            //strhospital_code = p_Table.Rows[0]["hospital_code"].ToString().Trim();
            try
            {
                strxml_diag = Convert.IsDBNull(p_Table.Rows[0]["xml_diag"]) ? "" : System.Text.Encoding.Default.GetString((byte[])p_Table.Rows[0]["xml_diag"]);
            }
            catch { strxml_diag = ""; }
            try
            {
                strxml_describle = Convert.IsDBNull(p_Table.Rows[0]["xml_describle"]) ? "" : System.Text.Encoding.Default.GetString((byte[])p_Table.Rows[0]["xml_describle"]);
            }
            catch { strxml_describle = ""; }
        }

        /// <summary> 
        /// 判断是否存在相同的模版 
        /// </summary> 
        /// <param name="oldid"></param> 
        /// <param name="t_part"></param> 
        /// <param name="t_diseasetype"></param> 
        /// <param name="t_name"></param> 
        /// <returns></returns> 
        private bool Exists(int oldid, string t_part, string t_diseasetype, string t_name, string t_dep, string t_grade)
        {
            string d_Table = "report_template";
            if ((t_grade == "公有模版") || (t_grade == "公有"))
            {
                t_grade = "公有模版";
                d_Table = "report_template";
            }
            else
            {
                t_grade = Share_Class.User.user_id;
                d_Table = "Report_Template_private";
            }
            string sqlstr = "select * from " + d_Table + " where template_grade='" + t_grade + "' ";
            // sqlstr += " and hospital_code='" + Share_Class.User.hospital_code + "'";
            sqlstr += "  and dep='" + t_dep + "' and  template_part='" + t_part + "'   and  disease_type='" + t_diseasetype + "' and template_name='" + t_name + "'" + (oldid > 0 ? " and template_id<>" + oldid.ToString() : "");

            DataSet ds = RISOracle_Class.GetDS(sqlstr, "查询report_template表出错" + "\r\n " + sqlstr);
            //   '执行语句并返回结果记录集()

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /*
            /// <summary> 
            /// 判断是否存在相同的模版 
            /// </summary> 
            /// <param name="oldid"></param> 
            /// <param name="t_part"></param> 
            /// <param name="t_diseasetype"></param> 
            /// <param name="t_name"></param> 
            /// <returns></returns> 
            private bool  Exists(int  oldid  , string  t_part , string  t_diseasetype , string  t_name ,string t_dep, string  t_grade ) {
                string d_Table = "report_template";
                if ((t_grade == "公有模版") || (t_grade == "公有"))
                {
                    t_grade = "公有模版";
                    d_Table = "report_template";
                }
                else
                {
                    t_grade = Share_Class.User.user_id;
                    d_Table = "Report_Template_private";
                }
                string sqlstr = "select * from " + d_Table + " where template_grade='" + t_grade + "' and dep='" + t_dep + "' and  template_part='" + t_part + "'  and disease_type='" + t_diseasetype + "' and template_name='" + t_name + "' and template_grade='" + t_grade + "' " + (oldid > 0 ? " and template_id<>" + oldid.ToString() : "");

                DataSet ds = Public_Class.GetDS(sqlstr, "查询us_report_template表出错" + "\r\n " + sqlstr);
              //  '执行语句并返回结果记录集()

                if( ds.Tables[0].Rows.Count == 0 ){
                    return false;
                }else{
                    return true;
                }

            }

         */

        /// <summary> 
        /// 新增模版,并返回最新的id 
        /// </summary> 
        /// <param name="t_part"></param> 
        /// <param name="t_diseasetype"></param> 
        /// <param name="t_name"></param> 
        /// <param name="t_describe"></param> 
        /// <param name="t_diagnose"></param> 
        /// <param name="t_groupsn"></param> 
        /// <param name="t_modulesn"></param> 
        /// <returns></returns> 
        public int Insert(string t_part, string t_diseasetype, string t_name, string t_describe, string t_diagnose, string t_dep, string t_grade)
        {

            string d_Table = "report_template";
            if ((t_grade == "公有模版") || (t_grade == "公有"))
            {
                t_grade = "公有模版";
                d_Table = "report_template";
            }
            else
            {
                t_grade = Share_Class.User.user_id;
                d_Table = "Report_Template_private";
            }
            if (Exists(0, t_part, t_diseasetype, t_name, t_dep, t_grade))
            {
                ShowErr_Form d_form = new ShowErr_Form("已经存在相同的模版名称,无法新增!", "错误");
                d_form.ShowDialog();
                return 0;
            }
            string SqlStr = "";
            SqlStr = "insert into " + d_Table + "(template_part,disease_type,template_name,template_describle,template_diag ,template_grade,dep";
            //SqlStr += ",hospital_code";
            SqlStr += ") values ('" + t_part.Trim() + "','" + t_diseasetype.Trim() + "','" + t_name.Trim() + "','" + t_describe.Trim() + "','" + t_diagnose.Trim() + "' ,'" + t_grade + "','" + t_dep + "'";
            // SqlStr += ",'" + Share_Class.User.hospital_code + "';
            SqlStr += ")";
            if (RISOracle_Class.Exec_Cand(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr) == false)
            {
                ShowErr_Form d_form = new ShowErr_Form("模版插入失败", "错误");
                d_form.ShowDialog();
                return 0;
            }
            else
            {
                SqlStr = "select max(template_id) as id from " + d_Table + "";
                // SqlStr += " where   hospital_code='" + Share_Class.User.hospital_code + "' ";
                DataSet ds = RISOracle_Class.GetDS(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr);
                if (ds.Tables == null)
                {
                    return 0;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            // '执行语句并返回结果记录集()

        }
        public int Insert()
        {

            string d_Table = "report_template";
            if ((strtemplate_grade == "公有模版") || (strtemplate_grade == "公有"))
            {
                strtemplate_grade = "公有";
                d_Table = "report_template";
            }
            else
            {
                strtemplate_grade = Share_Class.User.user_id;
                d_Table = "Report_Template_private";
            }
            if (Exists(0, strtemplate_part, strdisease_type, strtemplate_name, strdep, strtemplate_grade))
            {
                ShowErr_Form d_form = new ShowErr_Form("已经存在相同的模版名称,无法新增!", "错误");
                d_form.ShowDialog();
                return 0;
            }
            string SqlStr = "";
            SqlStr = "insert into " + d_Table + "(template_part,disease_type,template_name,template_describle,template_diag ,template_grade,dep";
            //SqlStr += ",hospital_code";
            SqlStr += ") values ('" + strtemplate_part.Trim() + "','" + strdisease_type.Trim() + "','" + strtemplate_name.Trim() + "','" + strtemplate_describle.Trim() + "','" + strtemplate_diag.Trim() + "' ,'" + strtemplate_grade + "','" + strdep + "'";
            // SqlStr += ",'" + Share_Class.User.hospital_code + "';
            SqlStr += ")";
            if (RISOracle_Class.Exec_Cand(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr) == false)
            {
                ShowErr_Form d_form = new ShowErr_Form("模版插入失败", "错误");
                d_form.ShowDialog();
                return 0;
            }
            else
            {
                SqlStr = "select max(template_id) as id from " + d_Table + "";
                // SqlStr += " where   hospital_code='" + Share_Class.User.hospital_code + "' ";
                DataSet ds = RISOracle_Class.GetDS(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr);
                if (ds.Tables == null)
                {
                    return 0;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            // '执行语句并返回结果记录集()

        }
        /*
            /// <summary> 
            /// 新增模版,并返回最新的id 
            /// </summary> 
            /// <param name="t_part"></param> 
            /// <param name="t_diseasetype"></param> 
            /// <param name="t_name"></param> 
            /// <param name="t_describe"></param> 
            /// <param name="t_diagnose"></param> 
            /// <param name="t_groupsn"></param> 
            /// <param name="t_modulesn"></param> 
            /// <returns></returns> 
            public int  Insert(string  t_part , string  t_diseasetype , string  t_name , string  t_describe , string  t_diagnose , string  t_groupsn ,     string  t_modulesn , string  t_grade ) {
                if( Exists(0, t_part, t_diseasetype, t_name) ){
                    Public_Class. ShowErr_Form("已经存在相同的模版名称,无法新增!", "错误");
             
                    return 0;
                }
                if ((t_grade == "公有模版") || (t_grade == "公有"))
                {
                    t_grade = "公有模版";
                }else{
                    t_grade = Share_Class.User.user_id;
                }
                string  SqlStr="";
                SqlStr = "insert into report_template(dep,template_grade,template_part,disease_type,template_name,template_describle,template_diag ) values ('" + strdep + "','" + t_grade + "','" + t_part.Trim() + "','" + t_diseasetype.Trim() + "','" + t_name.Trim() + "','" + t_describe.Trim() + "','" + t_diagnose.Trim() + "' )";
                if(  Public_Class.Exec_Cand(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr) == false ){
                   Public_Class. ShowErr_Form("模版插入失败", "错误");
             
                    return 0;
                }else{
                    SqlStr = "select max(template_id) as id from report_template";
                    DataSet ds = Public_Class.GetDS(SqlStr, "查询report_template表出错" + "\r\n " + SqlStr);
                    if( ds.Tables ==null ){
                        return 0;
                    }
                    if( ds.Tables[0].Rows.Count == 0 ){
                        return 0;
                    }
                    return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                }
               // '执行语句并返回结果记录集()

        }

         */

        /// <summary> 
        /// 修改模版 
        /// </summary> 
        /// <param name="id">要修改的模版id</param> 
        /// <param name="t_part"></param> 
        /// <param name="t_diseasetype"></param> 
        /// <param name="t_name"></param> 
        /// <param name="t_describe"></param> 
        /// <param name="t_diagnose"></param> 
        /// <param name="t_groupsn"></param> 
        /// <param name="t_modulesn"></param> 
        public bool Modify(int id, string t_part, string t_diseasetype, string t_name, string t_describe, string t_diagnose, string t_dep, string t_grade)
        {
            string d_Table = "report_template";
            if ((t_grade == "公有模版") || (t_grade == "公有"))
            {
                t_grade = "公有模版";
                d_Table = "report_template";
            }
            else
            {
                t_grade = Share_Class.User.user_id;
                d_Table = "Report_Template_private";
            }
            if (Exists(id, t_part, t_diseasetype, t_name, t_dep, t_grade))
            {
                ShowErr_Form d_form = new ShowErr_Form("已经存在相同的模版名称,无法修改!", "错误");
                d_form.ShowDialog();
                return false;
            }

            string SqlStr = "";
            SqlStr = "update  " + d_Table + " set template_part='" + t_part.Trim() + "',disease_type='" + t_diseasetype.Trim() + "',template_name='" + t_name.Trim() + "',template_describle='" + t_describe.Trim() + "',template_diag='" + t_diagnose.Trim() + "'  where template_id='" + id.ToString() + "' ";
            return RISOracle_Class.Exec_Cand(SqlStr, "更新report_template表出错" + "\r\n " + SqlStr);

        }
        public bool Modify()
        {
            string d_Table = "report_template";
            if ((strtemplate_grade == "公有模版") || (strtemplate_grade == "公有"))
            {
                strtemplate_grade = "公有模版";
                d_Table = "report_template";
            }
            else
            {
                strtemplate_grade = Share_Class.User.user_id;
                d_Table = "Report_Template_private";
            }
            if (Exists(inttemplate_id, strtemplate_part, strdisease_type, strtemplate_name, strdep, strtemplate_grade))
            {
                ShowErr_Form d_form = new ShowErr_Form("已经存在相同的模版名称,无法修改!", "错误");
                d_form.ShowDialog();
                return false;
            }

            string SqlStr = "";
            SqlStr = "update  " + d_Table + " set template_part='" + strtemplate_part.Trim() + "',disease_type='" + strdisease_type.Trim() + "',template_name='" + strtemplate_name.Trim() + "',template_describle='" + strtemplate_describle.Trim() + "',template_diag='" + strtemplate_diag.Trim() + "'  where template_id='" + inttemplate_id.ToString() + "' ";
            return RISOracle_Class.Exec_Cand(SqlStr, "更新report_template表出错" + "\r\n " + SqlStr);

        }
        /*
            /// <summary> 
            /// 修改模版 
            /// </summary> 
            /// <param name="id">要修改的模版id</param> 
            /// <param name="t_part"></param> 
            /// <param name="t_diseasetype"></param> 
            /// <param name="t_name"></param> 
            /// <param name="t_describe"></param> 
            /// <param name="t_diagnose"></param> 
            /// <param name="t_groupsn"></param> 
            /// <param name="t_modulesn"></param> 
           public void Modify(int   id, string  t_part , string  t_diseasetype , string  t_name , string  t_describe , string  t_diagnose , string  t_groupsn , string  t_modulesn , string  t_grade ){
               string d_Table = "report_template";
               if ((t_grade == "公有模版") || (t_grade == "公有"))
               {
                   t_grade = "公有模版";
                   d_Table = "report_template";
               }
               else
               {
                   t_grade = Share_Class.User.user_id;
                   d_Table = "Report_Template_private";
               }
               if(Exists(id, t_part, t_diseasetype, t_name) ){
                    Public_Class.  ShowErr_Form("已经存在相同的模版名称,无法修改!", "错误");
                    return;

                }
               if ((t_grade == "公有模版") || (t_grade == "公有"))
               {
                   t_grade = "公有模版";
                }else{
                    t_grade = Share_Class.User.user_id;
                }
                string  SqlStr="";
                SqlStr = "update report_template set template_part='" + t_part.Trim() + "',disease_type='" + t_diseasetype.Trim() + "',template_name='" + t_name.Trim() + "',template_describle='" + t_describe.Trim() + "',template_diag='" + t_diagnose.Trim() + "',template_grade='" + t_grade + "' where template_id='" + id.ToString() + "' ";
                Public_Class.Exec_Cand(SqlStr, "更新report_template表出错" + "\r\n " + SqlStr);

            }
        */
        public bool Update(string p_xml_describle, string p_xml_diag, string p_id)
        {
            string d_strSql = "";
            string d_Table = "report_template";


            if ((strtemplate_grade == "公有") || (strtemplate_grade == "公有模版"))
             {
                 d_Table = "report_template";
             }
             else
             {
                 d_Table = "Report_Template_private";
             }
             d_strSql = "Update " + d_Table + " set xml_describle=:Byte    where template_id='" + p_id.ToString() + "' ";
            byte[] b_diag = System.Text.Encoding.Default.GetBytes(p_xml_diag);
            byte[] b_describle = System.Text.Encoding.Default.GetBytes(p_xml_describle);
            RISOracle_Class.Exec_Cand_Blob(d_strSql, b_describle, d_strSql);
            d_strSql = "Update " + d_Table + " set xml_diag=:Byte where template_id='" + p_id.ToString() + "' ";
            return RISOracle_Class.Exec_Cand_Blob(d_strSql, b_diag, d_strSql);
        }

        public bool Delete(int id)
        {
            string SqlStr = "";
            if ((strtemplate_grade == "公有") || (strtemplate_grade == "公有模版"))
                SqlStr = "delete from report_template where template_id=" + id.ToString();
            else
                SqlStr = "delete from Report_Template_private where template_id=" + id.ToString();
            //string SqlStr = "delete from report_template where template_id=" + id.ToString();
            return RISOracle_Class.Exec_Cand(SqlStr, "删除report_template表出错" + "\r\n " + SqlStr);
        }
        public bool Delete()
        {

            string SqlStr = "";
            if ((strtemplate_grade == "公有") || (strtemplate_grade == "公有模版"))
                SqlStr = "delete from report_template where template_id=" + inttemplate_id.ToString();
            else
                SqlStr = "delete from Report_Template_private where template_id=" + inttemplate_id.ToString();
            return RISOracle_Class.Exec_Cand(SqlStr, "删除report_template表出错" + "\r\n " + SqlStr);
        }
        public static DataTable GetTemplateList(string p_template_grade, string p_dep, string p_Part)
        {
            string d_strSql = "";
            string d_Table = "REPORT_TEMPLATE_ORDER";
            string[] strRowFilter = new string[1] { "" };
            if (p_Part != "")
                strRowFilter[0] = " t_part='" + p_Part + "'";
            if ((p_template_grade == "公有") || (p_template_grade == "公有模版"))
            {
                setup_REPORT_TEMPLATE_ORDER_Class.Update_REPORT_TEMPLATE_ORDER(p_dep);
                setup_REPORT_TEMPLATE_ORDER_Class.Delete_REPORT_TEMPLATE_ORDER(p_dep);
                d_Table = "REPORT_TEMPLATE_ORDER";
                d_strSql = "Select t_name as t_part from " + d_Table.Trim() + " where t_dept='" + p_dep + "' and t_grade='部位排序' ";
                //   d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "'  ";
                d_strSql = d_strSql + " order by t_search_id asc";
                //strRowFilter[0] = " t_part='" + p_Part + "'";
            }
            else
            {
                d_Table = "Report_Template_private";
                d_strSql = "Select Distinct template_part t_part from " + d_Table.Trim() + " where 1=1  and dep='" + p_dep + "' ";
                //   d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
                d_strSql = d_strSql + " and template_grade='" + p_template_grade + "'";

            }

            DataSet Ds = new DataSet();
            Ds = RISOracle_Class.GetDS(d_strSql, "查询ReportStyle表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
                return null;
            }
            if (Ds.Tables.Count == 0)
            {
                return null;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            if (Ds.Tables[0].Rows.Count == 1)
            {
                return Ds.Tables[0];
            }
            return TableByFilter(Ds.Tables[0], 0, strRowFilter);

        }

        public static DataTable TableByFilter(DataTable p_Table, int i, string[] strRowFilter)
        {
            DataTable dt = new DataTable();
            DataView dv = new DataView(p_Table);
            if (strRowFilter[i] != "")
            {

                dv.RowFilter = strRowFilter[i];
                dt = dv.ToTable();
                if (dt.Rows.Count == 0)
                {
                    return p_Table;
                }
                else if (dt.Rows.Count == 1)
                {
                    return dt;
                }
                // else if (i > 0)
                //{
                return dt;
                //}
                //else
                //{

                //    return TableByFilter(dt, i, strRowFilter);
                //}
            }
            return p_Table;
        }

        public static DataTable Getdisease_typeBytemplate_part(string p_template_grade, string p_dep, string p_Part)
        {
            string d_strSql = "";
            string d_Table = "REPORT_TEMPLATE_ORDER";

            if ((p_template_grade == "公有") || (p_template_grade == "公有模版"))
            {
                setup_REPORT_TEMPLATE_ORDER_Class.Update_DiseasetypeByT_Part(p_Part.Trim(), p_dep);
                setup_REPORT_TEMPLATE_ORDER_Class.Delete_DiseasetypeByT_Part(p_Part.Trim(), p_dep);
                d_Table = "REPORT_TEMPLATE_ORDER";
                d_strSql = "Select t_name from " + d_Table.Trim() + " where  t_part='" + p_Part + "' and t_dept='" + p_dep + "' and  t_grade='结果归类排序' ";
                //  d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "'  ";
                d_strSql = d_strSql + " order by t_search_id asc";

            }
            else
            {
                d_Table = "Report_Template_private";
                d_strSql = "Select Distinct disease_type from " + d_Table.Trim() + " where 1=1  and dep='" + p_dep + "' ";
                //   d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "'  ";
                d_strSql = d_strSql + " and template_grade='" + p_template_grade + "' and template_part='" + p_Part + "'";
                d_strSql = d_strSql + " order by disease_type desc";

            }


            DataSet Ds = new DataSet();
            Ds = RISOracle_Class.GetDS(d_strSql, "查询ReportStyle表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
                d_form.ShowDialog();
                return null;
            }
            if (Ds.Tables.Count == 0)
            {
                return null;
            }
            //if (Ds.Tables[0].Rows.Count == 0)
            //{
            //    return null;
            //}
            //if (Ds.Tables[0].Rows.Count == 1)
            //{
            //    return Ds.Tables[0];
            //}
            return Ds.Tables[0];

        }

        public static DataTable Get_template_nameBydisease_type(string p_template_grade, string p_dep, string p_Part, string p_disease_type)
        {
            string d_strSql = "";
            string d_Table = "REPORT_TEMPLATE_ORDER";

            if ((p_template_grade == "公有") || (p_template_grade == "公有模版"))
            {
                p_template_grade = "公有";


                //{
                setup_REPORT_TEMPLATE_ORDER_Class.Update_t_Name(p_Part.Trim(), p_disease_type, p_dep);
                setup_REPORT_TEMPLATE_ORDER_Class.Delete_t_Name(p_Part.Trim(), p_disease_type, p_dep);
                d_Table = "REPORT_TEMPLATE_ORDER";
                d_strSql = "Select id,t_name from " + d_Table.Trim() + " where t_disease_type='" + p_disease_type + "' and   t_part='" + p_Part + "' and t_dept='" + p_dep + "' and  t_grade='模版名称排序'  ";
                d_strSql = d_strSql + " order by t_search_id asc";

                //}
                //else
                //{
                //d_Table = "report_template";
            }
            else
            {
                d_Table = "Report_Template_private";
                d_strSql = "Select template_id ,template_name from " + d_Table.Trim() + " where 1=1  and disease_type='" + p_disease_type + "' and dep='" + p_dep + "' ";
                d_strSql = d_strSql + " and template_grade='" + p_template_grade + "' and template_part='" + p_Part + "'";
                if (Share_Class.User.hospital_code != "")
                    d_strSql = d_strSql + "and hospital_code='" + Share_Class.User.hospital_code + "' ";
                d_strSql = d_strSql + " order by template_id  desc";
            }





            //}


            DataSet Ds = new DataSet();
            Ds = RISOracle_Class.GetDS(d_strSql, "查询ReportStyle表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
                d_form.ShowDialog();
                return null;
            }
            if (Ds.Tables.Count == 0)
            {
                return null;
            }
            //if (Ds.Tables[0].Rows.Count == 0)
            //{
            //    return null;
            //}

            return Ds.Tables[0];

        }

        public static DataSet GetRightTemplate(string p_template_part, string p_dep)
        {

            string[] d_arrstr;
            d_arrstr = p_template_part.Split(new char[] { ',' });
            string d_strSql = "Select * from report_template where dep='" + p_dep.Trim() + "' ";
            for (int i = 0; i < d_arrstr.Length; i++)
            {
                if (i == 0)
                    d_strSql = d_strSql + " and ( template_part like '%" + d_arrstr[i] + "%'";
                else
                    d_strSql = d_strSql + "or template_part like '%" + d_arrstr[i] + "%'";

            }
            d_strSql = d_strSql + ")";
            d_strSql = d_strSql + " and  disease_type='正常' and template_name='正常'";
            return RISOracle_Class.GetDS(d_strSql, "查询report_template表出错" + "\r\n" + d_strSql);
        }

        public static DataSet GetTempTemplate(string p_template_part, string p_dep)
        {
            string[] d_arrstr;
            d_arrstr = p_template_part.Split(new char[] { ',' });
            string d_strSql = "Select * from report_template where dep='" + p_dep.Trim() + "' ";
            for (int i = 0; i < d_arrstr.Length; i++)
            {
                if (i == 0)
                    d_strSql = d_strSql + " and ( template_part like '%" + d_arrstr[i] + "%'";
                else
                    d_strSql = d_strSql + "or template_part like '%" + d_arrstr[i] + "%'";

            }
            d_strSql = d_strSql + ")";
            d_strSql = d_strSql + " and  disease_type='临时报告' and template_name='临时报告'";
            return RISOracle_Class.GetDS(d_strSql, "查询report_template表出错" + "\r\n" + d_strSql);
        }
        public static DataSet GetAlltemplate_part()
        {

            string d_strSql = "Select Distinct t.template_part from "
                         + "(Select Distinct template_part from REPORT_TEMPLATE union Select Distinct template_part from REPORT_TEMPLATE_PRIVATE) t"
                          + " where not t.template_part is null order by t.template_part desc";
            return RISOracle_Class.GetDS(d_strSql, "查询report_template表出错" + "\r\n" + d_strSql);
        }




        #endregion
    }
}
