using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    class setup_registerpart_Dmb_Class
    {
        //'�õ������豸
        public static DataSet Getmodality()
        {
            string d_strSql = "";
            d_strSql = "Select Distinct modality from registerpart  where 1=1";
            d_strSql = d_strSql + " and (dep in('CT' ,'XRAY','DSA' ,'MRI','ECT','PETCT'))";
            d_strSql = d_strSql + "order by modality";
            return RISOracle_Class.GetDS(d_strSql, "��ѯregisterpart�����" + "\r\n" + d_strSql);
        }
    }
}
