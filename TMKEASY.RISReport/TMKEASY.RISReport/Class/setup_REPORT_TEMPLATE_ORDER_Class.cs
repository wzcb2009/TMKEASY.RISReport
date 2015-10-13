using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport 
{
  public   class setup_REPORT_TEMPLATE_ORDER_Class
    {
        public static bool Update_REPORT_TEMPLATE_ORDER(string p_dep)
        {
            string d_strSql = "";
            d_strSql = "Insert into REPORT_TEMPLATE_ORDER(id,t_name,t_search_id,t_grade,t_dept,t_disease_type,t_part ";
            // d_strSql += ",hospital_code ";
            d_strSql += ")  select distinct 0,TEMPLATE_PART,50,'部位排序','" + p_dep + "','',''";
            // d_strSql += " ,hospital_code ";
            d_strSql += " from report_template where not TEMPLATE_PART is null and dep='" + p_dep + "' and not TEMPLATE_PART is null and TEMPLATE_GRADE='公有' ";
            // d_strSql += "  and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and TEMPLATE_PART not in (select t_name from REPORT_TEMPLATE_ORDER where t_dept='" + p_dep + "'  and t_grade='部位排序' ";
            // d_strSql += "  and hospital_code='" + Share_Class.User.hospital_code + "'";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }

        public static bool Delete_REPORT_TEMPLATE_ORDER(string p_dep)
        {
            string d_strSql = "";
            d_strSql = "delete REPORT_TEMPLATE_ORDER where t_grade='部位排序'  ";
            //  d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and t_dept='" + p_dep + "'";
            d_strSql += " and  t_name not in (select distinct TEMPLATE_PART from  report_template";
            d_strSql += " where not TEMPLATE_PART is null and dep='" + p_dep + "' and not TEMPLATE_PART is null   and TEMPLATE_GRADE='公有' ";
            //   d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "'";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "删除REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }
        public static bool Update_DiseasetypeByT_Part(string T_Part, string p_dep)
        {
            string d_strSql = "";
            d_strSql = "Insert into REPORT_TEMPLATE_ORDER(id,t_name,t_search_id,t_grade,t_dept,t_disease_type,t_part";
            //d_strSql += ",hospital_code";
            d_strSql += ") select distinct 0,DISEASE_TYPE,50,'结果归类排序','" + p_dep + "','','" + T_Part + "'";
            //d_strSql += ",hospital_code ";
            d_strSql += " from  report_template where TEMPLATE_PART='" + T_Part + "'  and dep='" + p_dep + "' ";
            d_strSql += " and not DISEASE_TYPE is null and TEMPLATE_GRADE='公有' ";
            //d_strSql += "  and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and DISEASE_TYPE not in (select t_name from REPORT_TEMPLATE_ORDER where t_dept='" + p_dep + "' and t_grade='结果归类排序'  ";
            d_strSql += "  and t_part='" + T_Part + "' ";
            // d_strSql += "  and hospital_code='" + Share_Class.User.hospital_code + "'";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }

        public static bool Delete_DiseasetypeByT_Part(string T_Part, string p_dep)
        {
            string d_strSql = "";
            d_strSql = "delete REPORT_TEMPLATE_ORDER where t_grade='结果归类排序' and t_dept='" + p_dep + "'";
            d_strSql += " and  t_part='" + T_Part + "' ";
            //d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and  t_name not in (select distinct DISEASE_TYPE from  report_template ";
            d_strSql += " where not DISEASE_TYPE is null  and  TEMPLATE_PART='" + T_Part + "' ";
            d_strSql += " and dep='" + p_dep + "'  and TEMPLATE_GRADE='公有' ";
            // d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "删除REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }
        public static bool Update_t_Name(string T_Part, string t_Diseasetype, string p_dep)
        {
            string d_strSql = "";
            d_strSql = "Insert into REPORT_TEMPLATE_ORDER(id,t_name,t_search_id,t_grade,t_dept,t_disease_type,t_part";
            // d_strSql += ",hospital_code";
            d_strSql += ") select distinct 0,TEMPLATE_NAME ,50,'模版名称排序','" + p_dep + "','" + t_Diseasetype + "','" + T_Part + "'";
            // d_strSql += ",hospital_code ";
            d_strSql += " from  report_template where TEMPLATE_PART='" + T_Part + "' and dep='" + p_dep + "'  ";
            d_strSql += " and DISEASE_TYPE='" + t_Diseasetype + "'  and not TEMPLATE_NAME is null  ";
            //d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and TEMPLATE_GRADE='公有'and TEMPLATE_NAME not in (select t_name from REPORT_TEMPLATE_ORDER ";
            d_strSql += " where t_dept='" + p_dep + "'     and t_part='" + T_Part + "' and t_disease_type='" + t_Diseasetype + "' and t_grade='模版名称排序' ";
            //  d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }

        public static bool Delete_t_Name(string T_Part, string t_Diseasetype, string p_dep)
        {
            string d_strSql = "";
            d_strSql = "delete REPORT_TEMPLATE_ORDER where t_grade='模版名称排序' and t_dept='" + p_dep + "'  ";
            d_strSql += " and  t_part='" + T_Part + "' and t_disease_type='" + t_Diseasetype + "' ";
            //  d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " and  t_name not in (select distinct TEMPLATE_NAME from  report_template ";
            d_strSql += " where not TEMPLATE_NAME is null and DISEASE_TYPE='" + t_Diseasetype + "' ";
            d_strSql += " and dep='" + p_dep + "' and  TEMPLATE_PART='" + T_Part + "' ";
            d_strSql += " and TEMPLATE_GRADE='公有' ";
            //  d_strSql += " and hospital_code='" + Share_Class.User.hospital_code + "' ";
            d_strSql += " )";
            return RISOracle_Class.Exec_Cand(d_strSql, "删除REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }
        public static bool UpdateSearch_id(string d_t_search_id, int d_id)
        {
            string d_strSql = "";
            d_strSql = "Update REPORT_TEMPLATE_ORDER Set t_search_id='" + d_t_search_id.ToString().Trim() + "' where id=" + d_id.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "更新REPORT_TEMPLATE_ORDER表出错" + "\r\n" + d_strSql);
        }
    }
}
