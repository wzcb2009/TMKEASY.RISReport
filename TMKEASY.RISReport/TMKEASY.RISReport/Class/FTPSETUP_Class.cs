using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class FTPSETUP_Class
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


        #region FTP的IP地址
        private string strFTPHost = "";
        public string FTPHost
        {
            get
            {
                return strFTPHost
            ;
            }
            set
            {
                strFTPHost = value
            ;
            }
        }
        #endregion

        #region FTP端口号
        private string strFTPPort = "";
        public string FTPPort
        {
            get
            {
                return strFTPPort
            ;
            }
            set
            {
                strFTPPort = value
            ;
            }
        }
        #endregion

        #region FTP用户
        private string strFTPUserName = "";
        public string FTPUserName
        {
            get
            {
                return strFTPUserName
            ;
            }
            set
            {
                strFTPUserName = value
            ;
            }
        }
        #endregion

        #region FTP密码
        private string strFTPPassword = "";
        public string FTPPassword
        {
            get
            {
                return strFTPPassword
            ;
            }
            set
            {
                strFTPPassword = value
            ;
            }
        }
        #endregion

        #region FTP文件夹名称
        private string strFTPFileName = "";
        public string FTPFileName
        {
            get
            {
                return strFTPFileName
            ;
            }
            set
            {
                strFTPFileName = value
            ;
            }
        }
        #endregion

        #region FTP服务器绝对路径
        private string strFTPServiceFileName = "";
        public string FTPServiceFileName
        {
            get
            {
                return strFTPServiceFileName
            ;
            }
            set
            {
                strFTPServiceFileName = value
            ;
            }
        }
        #endregion

        #region FTP编号
        private string strFTPCode = "";
        public string FTPCode
        {
            get
            {
                return strFTPCode
            ;
            }
            set
            {
                strFTPCode = value
            ;
            }
        }
        #endregion

        #region FTP容积率
        private string strFTPThr = "";
        public string FTPThr
        {
            get
            {
                return strFTPThr
            ;
            }
            set
            {
                strFTPThr = value
            ;
            }
        }
        #endregion

        #region FTP状态
        private string strFTPStatus = "";
        public string FTPStatus
        {
            get
            {
                return strFTPStatus
            ;
            }
            set
            {
                strFTPStatus = value
            ;
            }
        }
        #endregion

        #region 备注
        private string strFTPRemark = "";
        public string FTPRemark
        {
            get
            {
                return strFTPRemark
            ;
            }
            set
            {
                strFTPRemark = value
            ;
            }
        }
        #endregion

        #endregion

        #region New
        public FTPSETUP_Class()
        {

        }

        public FTPSETUP_Class(int p_ID)
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP where ID=" + p_ID.ToString();
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            SetPropertyByDs(Ds);
        }

        public FTPSETUP_Class(string p_FTPCode)
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP where FTPCode='" + p_FTPCode.ToString() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            SetPropertyByDs(Ds);
        }

        #endregion

        #region 方法
        public void SetPropertyByDs(DataSet p_Ds)
        {
            if (p_Ds == null)
            {
                   ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
                   d_form.ShowDialog();

                return;
            }
            if (p_Ds.Tables.Count == 0)
            {
                return;
            }
            if (p_Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            intid = Convert.ToInt32(p_Ds.Tables[0].Rows[0]["ID"]);
            strFTPHost = p_Ds.Tables[0].Rows[0]["FTPHost"].ToString().Trim();
            strFTPPort = p_Ds.Tables[0].Rows[0]["FTPPort"].ToString().Trim();
            strFTPUserName = p_Ds.Tables[0].Rows[0]["FTPUserName"].ToString().Trim();
            strFTPPassword = p_Ds.Tables[0].Rows[0]["FTPPassword"].ToString().Trim();
            strFTPFileName = p_Ds.Tables[0].Rows[0]["FTPFileName"].ToString().Trim();
            strFTPServiceFileName = p_Ds.Tables[0].Rows[0]["FTPServiceFileName"].ToString().Trim();
            strFTPCode = p_Ds.Tables[0].Rows[0]["FTPCode"].ToString().Trim();
            strFTPThr = p_Ds.Tables[0].Rows[0]["FTPThr"].ToString().Trim();
            strFTPStatus = p_Ds.Tables[0].Rows[0]["FTPStatus"].ToString().Trim();
            strFTPRemark = p_Ds.Tables[0].Rows[0]["FTPRemark"].ToString().Trim();

        }
        //'插入数据
        public bool Insert()
        {
            string d_strSql = "";
            d_strSql = "Insert into FTPSETUP(FTPHost,FTPPort,FTPUserName,FTPPassword,FTPFileName,FTPServiceFileName,FTPCode,FTPThr,FTPStatus,FTPRemark) values ('" + strFTPHost.Trim()
                                        + "','" + strFTPPort.Trim()
                                        + "','" + strFTPUserName.Trim()
                                        + "','" + strFTPPassword.Trim()
                                        + "','" + strFTPFileName.Trim()
                                        + "','" + strFTPServiceFileName.Trim()
                                        + "','" + strFTPCode.Trim()
                                        + "','" + strFTPThr.Trim()
                                        + "','" + strFTPStatus.Trim()
                                        + "','" + strFTPRemark.Trim() + "')";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入FTPSETUP表出错" + "\r\n " + d_strSql);
        }

        public bool Update()
        {
            string d_strSql = "";
            d_strSql = "Update FTPSETUP Set FTPHost='" + strFTPHost.Trim()
                                        + "',FTPPort='" + strFTPPort.Trim()
                                        + "',FTPUserName='" + strFTPUserName.Trim()
                                        + "',FTPPassword='" + strFTPPassword.Trim()
                                        + "',FTPFileName='" + strFTPFileName.Trim()
                                        + "',FTPServiceFileName='" + strFTPServiceFileName.Trim()
                                        + "',FTPCode='" + strFTPCode.Trim()
                                        + "',FTPThr='" + strFTPThr.Trim()
                                        + "',FTPStatus='" + strFTPStatus.Trim()
                                        + "',FTPRemark='" + strFTPRemark.Trim()
                                        + "' where ID=" + intid.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "更新RIS_VOLUME_SETUP表出错" + "\r\n " + d_strSql);
        }

        public bool Delete()
        {
            string d_strSql = "";
            d_strSql = "Delete from FTPSETUP where id=" + intid.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "删除FTPSETUP表出错" + "\r\n " + d_strSql);
        }

        public DataSet GetAll()
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP ";
            return RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
        }

        public DataSet GetNowData()
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP where FTPStatus='开启' ";
            return RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
        }

        public void GetDataByFTPStatus()
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP where FTPStatus='开启'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            SetPropertyByDs(Ds);
        }

        // '库中是否有此内容
        public bool ContentNotIsInDmb(string p_Content)
        {
            string d_strSql = "";
            d_strSql = "Select * from FTPSETUP where FTPCode='" + p_Content.Trim() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            if (Ds == null)
            {
                return false;
            }
            if (Ds.Tables.Count == 0)
            {
                return true;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
                return false;
        }


        #endregion
    }
}
