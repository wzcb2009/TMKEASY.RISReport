using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport
{
    public class flog_Class
    {
        #region 日志
        public static void WriteFlog(string p_Content, string p_Flog)
        {
            KY.Log.flog_Class.WriteFlog(p_Content, p_Flog);// '将详细错误信息写入日志
        }
        public static void WriteFlog(string p_Content)
        {
            KY.Log.flog_Class.WriteFlog(p_Content, Share_Class.Dir + @"\log");// '将详细错误信息写入日志
        }

        #endregion
        public static void Insertflog(string p_fthings, string p_AllContent, string p_type, string p_accessno)
        {
            KY.Flog.flog_Class Flog = new KY.Flog.flog_Class(Share_Class.User.userflag, Share_Class.User.user_id, Share_Class.Dir);
            Flog.Insertflog(p_fthings, p_accessno, Share_Class.GetIPAndAddress(), "TMKEASY.RISReport：patexam_Class：" + p_type + " ", "放射报告模块");
        }
    }
}
