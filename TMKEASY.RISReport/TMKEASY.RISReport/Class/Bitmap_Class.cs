using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport 
{
    public class Bitmap_Class
    {
        #region 属性
        #region ID号,自增量
        protected int intid = 0;
        public int id
        {
            get { return intid; }
            set { intid = value; ; }
        }

        #endregion


        #region ACCESSION_NO
        protected string strACCESSION_NO = "";
        public string ACCESSION_NO
        {
            get { return strACCESSION_NO; }
            set { strACCESSION_NO = value; ; }
        }
        #endregion

        #region strBITMAP_ONE
        protected string strBITMAP_ONE = "";
        public string BITMAP_ONE
        {
            get { return strBITMAP_ONE; }
            set { strBITMAP_ONE = value; ; }
        }
        #endregion

        #region strBITMAP_TWO
        protected string strBITMAP_TWO = "";
        public string BITMAP_TWO
        {
            get { return strBITMAP_TWO; }
            set { strBITMAP_TWO = value; ; }
        }
        #endregion

        #region strBITMAP_THREE
        protected string strBITMAP_THREE = "";
        public string BITMAP_THREE
        {
            get { return strBITMAP_THREE; }
            set { strBITMAP_THREE = value; ; }
        }
        #endregion

        #region strBITMAP_FOUR
        protected string strBITMAP_FOUR = "";
        public string BITMAP_FOUR
        {
            get { return strBITMAP_FOUR; }
            set { strBITMAP_FOUR = value; ; }
        }
        #endregion

        #region strBITMAP_FIVE
        protected string strBITMAP_FIVE = "";
        public string BITMAP_FIVE
        {
            get { return strBITMAP_FIVE; }
            set { strBITMAP_FIVE = value; ; }
        }
        #endregion

        #region strBITMAP_SIX
        protected string strBITMAP_SIX = "";
        public string BITMAP_SIX
        {
            get { return strBITMAP_SIX; }
            set { strBITMAP_SIX = value; ; }
        }
        #endregion

        #region strBITMAP_SEVEN
        protected string strBITMAP_SEVEN = "";
        public string BITMAP_SEVEN
        {
            get { return strBITMAP_SEVEN; }
            set { strBITMAP_SEVEN = value; ; }
        }
        #endregion

        #region strBITMAP_EIGHT
        protected string strBITMAP_EIGHT = "";
        public string BITMAP_EIGHT
        {
            get { return strBITMAP_EIGHT; }
            set { strBITMAP_EIGHT = value; ; }
        }
        #endregion

        #region TableName
        protected string strTableName = "";
        public string TableName
        {
            get { return strTableName; }
            set { strTableName = value; ; }
        }
        #endregion

        #endregion

        #region New
        public Bitmap_Class()
        {

        }

        public Bitmap_Class(int p_ID)
        {
            string d_strSql = "";
            d_strSql = "Select * from " + strTableName + " where ID=" + p_ID.ToString();
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            SetPropertyByDs(Ds);
        }

        public Bitmap_Class(string p_ACCESSION_NO)
        {
            string d_strSql = "";
            d_strSql = "Select * from " + strTableName + " where ACCESSION_NO='" + p_ACCESSION_NO.ToString() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询FTPSETUP表出错" + "\r\n " + d_strSql);
            SetPropertyByDs(Ds);
        }

        #endregion

        #region 方法
        public void SetPropertyByDs(DataSet p_Ds)
        {
            if (p_Ds == null)
            {
             ShowErr_Form d_form = new     ShowErr_Form("无法从数据库中取得数据", "错误");
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
            strBITMAP_ONE = p_Ds.Tables[0].Rows[0]["BITMAP_ONE"].ToString().Trim();
            strBITMAP_TWO = p_Ds.Tables[0].Rows[0]["BITMAP_TWO"].ToString().Trim();
            strBITMAP_THREE = p_Ds.Tables[0].Rows[0]["BITMAP_THREE"].ToString().Trim();
            strBITMAP_FOUR = p_Ds.Tables[0].Rows[0]["BITMAP_FOUR"].ToString().Trim();
            strBITMAP_FIVE = p_Ds.Tables[0].Rows[0]["BITMAP_FIVE"].ToString().Trim();
            strBITMAP_SIX = p_Ds.Tables[0].Rows[0]["BITMAP_SIX"].ToString().Trim();
            strBITMAP_SEVEN = p_Ds.Tables[0].Rows[0]["BITMAP_SEVEN"].ToString().Trim();
            strBITMAP_EIGHT = p_Ds.Tables[0].Rows[0]["BITMAP_EIGHT"].ToString().Trim();
            strACCESSION_NO = p_Ds.Tables[0].Rows[0]["ACCESSION_NO"].ToString().Trim();


        }
        //'插入数据
        public bool Insert()
        {
            string d_strSql = "";
            d_strSql = "Insert into " + strTableName + "(  accession_no, bitmap_one, bitmap_two, bitmap_three, bitmap_four, bitmap_five, bitmap_six, bitmap_seven, bitmap_eight) values ('" + strACCESSION_NO.Trim()
                                       + "','" + strBITMAP_ONE.Trim()
                                       + "','" + strBITMAP_TWO.Trim()
                                       + "','" + strBITMAP_THREE.Trim()
                                       + "','" + strBITMAP_FOUR.Trim()
                                       + "','" + strBITMAP_FIVE.Trim()
                                       + "','" + strBITMAP_SIX.Trim()
                                       + "','" + strBITMAP_SEVEN.Trim()
                                       + "','" + strBITMAP_EIGHT.Trim() + "')";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入FTPSETUP表出错" + "\r\n " + d_strSql);


        }
        public bool SaveBitmap()
        {

            DataSet Ds = SelectBitmapByAccessno(strACCESSION_NO);
            if (Ds == null)
            {
                ShowErr_Form d_form = new ShowErr_Form("无法从数据库中取得数据", "错误");
                d_form.ShowDialog();
                return false;
            }
            if (Ds.Tables.Count == 0)
            {
                return false;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return Insert();
            }
            else
            {
                return Update();
            }
        }
        public bool Update()
        {
            string d_strSql = "";
            d_strSql = "Update " + strTableName + " Set accession_no='" + strACCESSION_NO.Trim()
                                        + "',bitmap_one='" + strBITMAP_ONE.Trim()
                                        + "',bitmap_two='" + strBITMAP_TWO.Trim()
                                        + "',bitmap_three='" + strBITMAP_THREE.Trim()
                                        + "',bitmap_four='" + strBITMAP_FOUR.Trim()
                                        + "',bitmap_five='" + strBITMAP_FIVE.Trim()
                                        + "',bitmap_six='" + strBITMAP_SIX.Trim()
                                        + "',bitmap_seven='" + strBITMAP_SEVEN.Trim()
                                        + "',bitmap_eight='" + strBITMAP_EIGHT.Trim()
                                        + "' where ID=" + intid.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "更新RIS_VOLUME_SETUP表出错" + "\r\n " + d_strSql);
        }

        public bool Delete()
        {
            string d_strSql = "";
            d_strSql = "Delete from " + strTableName + " where id=" + intid.ToString().Trim();
            return RISOracle_Class.Exec_Cand(d_strSql, "删除FTPSETUP表出错" + "\r\n " + d_strSql);
        }

        public DataSet SelectBitmapByAccessno(string p_Accession)
        {
            string d_strSql = "select * from " + strTableName + " where Accession_no='" + p_Accession + "'";
            return RISOracle_Class.GetDS(d_strSql, "查询ES_BITMAP表出错" + "\r\n " + d_strSql);
        }



        #endregion
    }
}
