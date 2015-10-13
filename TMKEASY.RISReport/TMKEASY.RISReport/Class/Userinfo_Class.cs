using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

namespace TMKEASY.RISReport 
{
    class Userinfo_Class : Table.Userinfo 
    {
        #region New

        public Userinfo_Class()
            : base()
        {
        }

        // '通过用户号建一个用户对象
        public Userinfo_Class(int p_ID)
            : base(p_ID)
        {
            LoadDataByID(p_ID);
        }

        public Userinfo_Class(string p_userflag, string p_user_id, string p_password)
            : base(p_userflag, p_user_id, p_password)
        {
            string d_strSql = "";
            d_strSql = "Select * from Userinfo where user_pwd='" + p_password.Trim() + "' and user_id='" + p_user_id.Trim() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" + "\r\n" + d_strSql);// '从数据库中调出用户信息
            if (Ds == null)
            {
                return;
            }
            if (Ds.Tables.Count == 0)
            {
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            else
            {

                SetPropertyByDs(Ds.Tables[0].Rows[0]);
            }
           
        }

        public Userinfo_Class(string p_userflag, string p_user_id)
            : base(p_userflag, p_user_id)
        {
            string d_strSql = "";
            d_strSql = "Select * from Userinfo where userflag='" + p_userflag.Trim() + "' and(user_id='" + p_user_id.Trim() + "' or  user_id='" + p_user_id.Trim() + "')";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" + "\r\n" + d_strSql);//'从数据库中调出用户信息
            if (Ds == null)
            {
                return;
            }
            if (Ds.Tables.Count == 0)
            {
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            else
            {

                SetPropertyByDs(Ds.Tables[0].Rows[0]);
            }
        }

        #endregion
        #region 方法
        // '根据ID得到用户基本资料
        private void LoadDataByID(int p_ID)
        {
            string d_strSql = "";
            //  '得到用户的基本信息
            d_strSql = "Select * from Userinfo where ID=" + p_ID.ToString().Trim();
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                return;
            }
            if (Ds.Tables.Count == 0)
            {
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            else
            {

                SetPropertyByDs(Ds.Tables[0].Rows[0]);
            }
        }

        //'根据ID得到用户基本资料
        public void LoadDataByName(string p_userflag, string p_user_id)
        {
            string d_strSql = "";
            //'得到用户的基本信息
            if (p_userflag == "")
            {
                d_strSql = "Select * from Userinfo where Name='" + p_user_id.Trim() + "'";
            }
            else
            {
                d_strSql = "Select * from Userinfo where Name='" + p_user_id.Trim() + "' and Dept='" + p_userflag + "'";
            }

            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" + "\r\n" + d_strSql);
            if (Ds == null)
            {
                return;
            }
            if (Ds.Tables.Count == 0)
            {
                return;
            }
            if (Ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            else
            {

                SetPropertyByDs(Ds.Tables[0].Rows[0]);
            }
        }
        //private void LoadData(DataRow p_Dw)
        //{
        //    intID = Convert.ToInt32(p_Dw["ID"]);
        //    struser_id = p_Dw["user_id"].ToString().Trim();
        //    struser_des = p_Dw["user_des"].ToString().Trim();
        //    struserflag = p_Dw["userflag"].ToString().Trim();
        //    struser_grade = p_Dw["user_grade"].ToString().Trim();
        //    strdoctor_code = p_Dw["doctor_code"].ToString().Trim();
        //    strreportdoc = p_Dw["reportdoc"].ToString().Trim();
        //    string d_user_status = p_Dw["user_status"].ToString().Trim();
        //    strhospital_code = p_Dw["hospital_code"].ToString().Trim();
        //    if (d_user_status == "1")
        //    {
        //        strgrade = KeyCode_Class.User_Getkey(p_Dw["grade"].ToString().Trim());
        //        struser_pwd = KeyCode_Class.User_Getkey(p_Dw["user_pwd"].ToString().Trim());
        //    }
        //    else
        //    {
        //        strgrade = p_Dw["grade"].ToString().Trim();
        //        struser_pwd = p_Dw["user_pwd"].ToString().Trim();
        //    }
        //}

        //'得到用户通过部门
        public static DataSet GetUserByDept(string p_userflag)
        {
            string d_strSql = "Select * from userinfo where userflag='" + p_userflag.Trim() + "' ";
            return RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" + "\r\n" + d_strSql);
        }
       //  '得到所有用户
        public static DataSet GetAllDept()
        {

            string d_strSql = "Select DISTINCT userflag from userinfo where userflag in ('CT','XRAY','MRI','ECT','PETCT','体检放射')  order by userflag";
            return RISOracle_Class.GetDS(d_strSql, "查询Userinfo表出错" +  "\r\n" + d_strSql);
        }

        public static Image GetUserImage(string p_docname, string p_doccode)
        {
            Image d_image;
            try {
                string d_str = "";
                DataSet ds = new DataSet();
                MemoryStream s  = new  MemoryStream();
                byte[] MyData = null;
                if (p_doccode != "")
                {
                    d_str = "select * from userinfo where doctor_code ='" + p_doccode + "'";
                    ds = RISOracle_Class.GetDS(d_str, d_str);
                    try
                    {
                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                                if (ds.Tables[0].Rows.Count > 0)
                                    MyData = (Byte[])ds.Tables[0].Rows[0]["user_image"];
                        }
                    }
                    catch { MyData = null; }
                }
                if (MyData == null)
                {
                    d_str = "select * from userinfo where user_id ='" + p_docname + "' and userflag in ('CT','XRAY','MRI','ECT','PETCT','体检放射')  and user_image is not null";
                    ds = RISOracle_Class.GetDS(d_str, d_str);
                    try
                    {
                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                                if (ds.Tables[0].Rows.Count > 0)
                                    MyData = (Byte[])ds.Tables[0].Rows[0]["user_image"];
                        }
                    }
                    catch { MyData = null; }
                }
                if (MyData != null)
                {
                    s.Write(MyData, 0, MyData.Length);
                    d_image = Image.FromStream(s);
                }
                else
                    d_image = null;               
                
            }
            catch  ( Exception ex){
                d_image = null ;
            }
            return d_image;
        }


        #endregion
    }
}
