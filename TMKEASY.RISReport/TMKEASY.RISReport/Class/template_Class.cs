using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class template_Class
    {
        #region 属性
        #region template_id
        protected int inttemplate_id = 0;
        public int template_id
        {
            get { return inttemplate_id; }
            set { inttemplate_id = value; }
        }
        #endregion

        #region dep
        protected string strdep = "";
        public string dep
        {
            get { return strdep; }
            set { strdep = value; }
        }
        #endregion

        #region dep_area
        protected string strdep_area = "";
        public string dep_area
        {
            get { return strdep_area; }
            set { strdep_area = value; }
        }
        #endregion

        #region template_part
        protected string strtemplate_part = "";
        public string template_part
        {
            get
            {
                return strtemplate_part;

            }
            set
            {
                strtemplate_part = value;

            }
        }
        #endregion

        #region template_name
        protected string strtemplate_name = "";
        public string template_name
        {
            get { return strtemplate_name; }
            set { strtemplate_name = value; }
        }
        #endregion

        #region template_describle
        protected string strtemplate_describle = "";
        public string template_describle
        {
            get { return strtemplate_describle; }
            set { strtemplate_describle = value; }
        }
        #endregion

        #region disease_type
        protected string strdisease_type = "";
        public string disease_type
        {
            get { return strdisease_type; }
            set { strdisease_type = value; }
        }
        #endregion

        #region template_time
        protected DateTime datetemplate_time = Convert.ToDateTime("1900-1-1");
        public DateTime template_time
        {
            get { return datetemplate_time; }
            set { datetemplate_time = value; }
        }
        #endregion

        #region template_grade
        protected string strtemplate_grade = "";
        public string template_grade
        {
            get { return strtemplate_grade; }
            set { strtemplate_grade = value; }
        }
        #endregion

        #region template_diag
        protected string strtemplate_diag = "";
        public string template_diag
        {
            get { return strtemplate_diag; }
            set { strtemplate_diag = value; }
        }
        #endregion

        #region xml_describle
        protected string strxml_describle = "";
        public string xml_describle
        {
            get { return strxml_describle; }
            set { strxml_describle = value; }
        }
        #endregion

        #region xml_diag
        protected string strxml_diag = "";
        public string xml_diag
        {
            get { return strxml_diag; }
            set { strxml_diag = value; }
        }
        #endregion

        //#region 医院代码
        //protected string strhospital_code = "";
        //public string hospital_code
        //{
        //    get { return strhospital_code; }
        //    set { strhospital_code = value; }
        //}
        //#endregion

        #region TableName
        protected string strTableName = "";
        public string TableName
        {
            get { return strTableName; }
            set { strTableName = value; }
        }
        #endregion


        #endregion

        #region New
        public template_Class()
        {

        }
        public template_Class(DataTable p_Table)
        {

        }
        public template_Class(string p_template_grade, int p_ID)
        {

        }
        public template_Class(string p_template_grade, int p_ID, string p_dep)
        {

        }
        public template_Class(string p_template_grade, string p_dep, string p_template_part, string p_disease_type, string p_template_name)
        {

        }

        #endregion

        #region 方法

        //public virtual DataTable GetTemplateList(string p_template_grade, string p_dep, string p_Part)
        //{
        //    return null;

        //}

        //public virtual DataTable TableByFilter(DataTable p_Table, int i, string[] strRowFilter)
        //{
        //    return null;
        //}

        //public virtual DataTable Getdisease_typeBytemplate_part(string p_template_grade, string p_dep, string p_Part)
        //{
        //    return null;

        //}

        //public virtual DataTable Get_template_nameBydisease_type(string p_template_grade, string p_dep, string p_Part, string p_disease_type)
        //{
        //    return null;
        //}

        //public virtual DataSet GetRightTemplate(string p_template_part, string p_dep)
        //{

        //    return null;
        //}

        //public virtual DataSet GetTempTemplate(string p_template_part, string p_dep)
        //{
        //    return null;
        //}

        ///// <summary> 
        ///// 判断是否存在相同的模版 
        ///// </summary> 
        ///// <param name="oldid"></param> 
        ///// <param name="t_part"></param> 
        ///// <param name="t_diseasetype"></param> 
        ///// <param name="t_name"></param> 
        ///// <returns></returns> 
        //private bool Exists(int oldid, string t_part, string t_diseasetype, string t_name, string t_dep, string t_grade)
        //{

        //        return true;


        //}
        ///*
        //    /// <summary> 
        //    /// 判断是否存在相同的模版 
        //    /// </summary> 
        //    /// <param name="oldid"></param> 
        //    /// <param name="t_part"></param> 
        //    /// <param name="t_diseasetype"></param> 
        //    /// <param name="t_name"></param> 
        //    /// <returns></returns> 
        //    private bool  Exists(int  oldid  , string  t_part , string  t_diseasetype , string  t_name ,string t_dep, string  t_grade ) {
        //        string d_Table = "report_template";
        //        if ((t_grade == "公有模版") || (t_grade == "公有"))
        //        {
        //            t_grade = "公有模版";
        //            d_Table = "report_template";
        //        }
        //        else
        //        {
        //            t_grade = Share_Class.User.user_id;
        //            d_Table = "Report_Template_private";
        //        }
        //        string sqlstr = "select * from " + d_Table + " where template_grade='" + t_grade + "' and dep='" + t_dep + "' and  template_part='" + t_part + "'  and disease_type='" + t_diseasetype + "' and template_name='" + t_name + "' and template_grade='" + t_grade + "' " + (oldid > 0 ? " and template_id<>" + oldid.ToString() : "");

        //        DataSet ds = Public_Class.GetDS(sqlstr, "查询us_report_template表出错" + "\r\n " + sqlstr);
        //      //  '执行语句并返回结果记录集()

        //        if( ds.Tables[0].Rows.Count == 0 ){
        //            return false;
        //        }else{
        //            return true;
        //        }

        //    }

        // */

        ///// <summary> 
        ///// 新增模版,并返回最新的id 
        ///// </summary> 
        ///// <param name="t_part"></param> 
        ///// <param name="t_diseasetype"></param> 
        ///// <param name="t_name"></param> 
        ///// <param name="t_describe"></param> 
        ///// <param name="t_diagnose"></param> 
        ///// <param name="t_groupsn"></param> 
        ///// <param name="t_modulesn"></param> 
        ///// <returns></returns> 
        //public int Insert(string t_part, string t_diseasetype, string t_name, string t_describe, string t_diagnose, string t_dep, string t_grade)
        //{           
        //        return 0;            
        //    // '执行语句并返回结果记录集()
        //}


        ///// <summary> 
        ///// 修改模版 
        ///// </summary> 
        ///// <param name="id">要修改的模版id</param> 
        ///// <param name="t_part"></param> 
        ///// <param name="t_diseasetype"></param> 
        ///// <param name="t_name"></param> 
        ///// <param name="t_describe"></param> 
        ///// <param name="t_diagnose"></param> 
        ///// <param name="t_groupsn"></param> 
        ///// <param name="t_modulesn"></param> 
        //public bool Modify(int id, string t_part, string t_diseasetype, string t_name, string t_describe, string t_diagnose, string t_dep, string t_grade)
        //{
        //    return true;

        //}


        //public bool Update(string p_xml_describle, string p_xml_diag, string p_id)
        //{
        //    return true;
        //}

        //public void Delete(int id)
        //{

        //}
        #endregion
    }
}
