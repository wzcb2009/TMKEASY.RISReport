using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class RISOracle_Class
    {
        #region Êý¾Ý¿â
        public static DataSet GetDS(string strSql, string Modulename)
        {
            
            return KY.Database.Database_Class.GetDS(strSql, Modulename, "rissetup.ini", "ORACLE", "RIS", Share_Class.Dir);
        }

        public static DataSet GetDS(string spName, ArrayList Pars, string Modulename)
        {
            return KY.Database.Database_Class.GetDS(spName, Pars, Modulename, "rissetup.ini", "ORACLE", "RIS", Share_Class.Dir);
        }
        public static bool Exec_Cand(string strSql, string Modulename)
        {
            //if (Share_Class.WebService != "")
            //{
            //    string p_err = "";
            //    bool  ret = KY.Database.Database_Class.Exec_Cand_Webservice (strSql, Modulename, Share_Class.WebService, ref p_err, Share_Class.Dir);
            //    if (p_err != "")
            //    {
            //        WriteFlog(p_err);
            //        ShowErr_Form(p_err, "´íÎó");
            //        return false ;
            //    }
            //    else
            //        return ret;
            //}
            //else
            return KY.Database.Database_Class.Exec_Cand(strSql, Modulename, "rissetup.ini", "ORACLE", "RIS", Share_Class.Dir);
        }
        public static bool Exec_Cand(string strSql, ArrayList Pars, string Modulename)
        {
            return KY.Database.Database_Class.Exec_Cand(strSql, Pars, Modulename, "rissetup.ini", "ORACLE", "RIS", Share_Class.Dir);
        }

        public static bool Exec_Cand_Blob(string strSql, byte[] Pars, string Modulename)
        {
            //if (Share_Class.WebService != "")
            //{
            //    string p_err = "";
            //    bool ret = KY.Database.Database_Class.Exec_Cand_Webservice(strSql,Pars ,Modulename, Share_Class.WebService, ref p_err, Share_Class.Dir);
            //    if (p_err != "")
            //    {
            //        WriteFlog(p_err);
            //        ShowErr_Form(p_err, "´íÎó");
            //        return false;
            //    }
            //    else
            //        return ret;
            //}
            //else
            return KY.Database.Database_Class.Exec_Cand(strSql, Pars, Modulename, "rissetup.ini", "ORACLE", "RIS", Share_Class.Dir);

        }

        #endregion

    }
}
