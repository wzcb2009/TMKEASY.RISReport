using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport 
{
    public class RisSetup_Class
    {
        #region ∂¡»°≈‰÷√

        public static string GetINI(string Section, string AppName)
        {
            return KY.RisSetup.RisSetup_Class.GetINI(Section, AppName, "rissetup.ini");
        }
        public static bool WriteINI(string Section, string AppName, string lpContent)
        {
            return KY.RisSetup.RisSetup_Class.WriteINI(Section, AppName, lpContent, "rissetup.ini");
        }
        public static string GetINI_Oracle(string Section, string AppName)
        {
            return OracleSetup.OracleSetup_Class.GetItemValue(Section, "ALL", AppName, "RIS", Share_Class.Dir, Share_Class.hospital_code );
        }
        public static bool WriteINI_Oracle(string Section, string AppName, string lpContent)
        {
            return OracleSetup.OracleSetup_Class.SetItemValue(Section, "ALL", AppName, lpContent, "RIS", Share_Class.Dir, Share_Class.hospital_code);
        }
        #endregion
    }
}
