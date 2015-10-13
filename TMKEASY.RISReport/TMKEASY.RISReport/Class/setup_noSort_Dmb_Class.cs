using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport
{
    public class setup_noSort_Dmb_Class
    {


        //'�õ�����������м�¼
        public static DataSet GetAll(string p_DBTable)
        {
            string d_strSql = "";
            d_strSql = "Select * from " + p_DBTable + " order by ID";
            return RISOracle_Class.GetDS(d_strSql, "��ѯ" + p_DBTable + "�����" + "\r\n" + d_strSql);
        }
        //  'ͨ���豸�õ�����
        public static string machinetypebycheckroom(string d_modality, string p_checkroom, string p_dep)
        {
            string d_strSql = "Select machinetype from check_room where modality='" + d_modality + "' and check_room='" + p_checkroom + "' and dep='" + p_dep + "'";
            DataSet ds = RISOracle_Class.GetDS(d_strSql, "��ѯcheck_room�����" + "\r\n" + d_strSql);
            if (ds == null)
                return "";

            if (ds.Tables.Count == 0)
                return "";

            if (ds.Tables[0].Rows.Count == 0)
                return "";

            try
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
