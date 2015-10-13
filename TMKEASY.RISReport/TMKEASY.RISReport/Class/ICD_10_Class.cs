using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TMKEASY.RISReport
{
    class ICD_10_Class
    {

        #region 属性

        #region 序号
        private int intID = 0;
        public int ID
        {
            get
            {
                return intID;
            }
            set
            {
                intID = value;
            }
        }
        #endregion

        #region 第一级名称
        private string strFIRST_LEVEL_NAME = "";
        public string FIRST_LEVEL_NAME
        {
            get
            {
                return strFIRST_LEVEL_NAME;
            }
            set
            {
                strFIRST_LEVEL_NAME = value;
            }
        }
        #endregion

        #region 第一级代码
        private string strFIRST_LEVEL_CODE = "";
        public string FIRST_LEVEL_CODE
        {
            get
            {
                return strFIRST_LEVEL_CODE;
            }
            set
            {
                strFIRST_LEVEL_CODE = value;
            }
        }
        #endregion

        #region 第一级首拼码
        private string strFIRST_LEVEL_SPELL = "";
        public string FIRST_LEVEL_SPELL
        {
            get
            {
                return strFIRST_LEVEL_SPELL;
            }
            set
            {
                strFIRST_LEVEL_SPELL = value;
            }
        }
        #endregion

        #region 第一级排序码
        private string strFIRST_LEVEL_SORT = "";
        public string FIRST_LEVEL_SORT
        {
            get
            {
                return strFIRST_LEVEL_SORT;
            }
            set
            {
                strFIRST_LEVEL_SORT = value;
            }
        }
        #endregion

        #region 第二级名称
        private string strSECOND_LEVEL_NAME = "";
        public string SECOND_LEVEL_NAME
        {
            get
            {
                return strSECOND_LEVEL_NAME;
            }
            set
            {
                strSECOND_LEVEL_NAME = value;
            }
        }
        #endregion

        #region 第二级代码
        private string strSECOND_LEVEL_CODE = "";
        public string SECOND_LEVEL_CODE
        {
            get
            {
                return strSECOND_LEVEL_CODE;
            }
            set
            {
                strSECOND_LEVEL_CODE = value;
            }
        }
        #endregion

        #region 第二级首拼码
        private string strSECOND_LEVEL_SPELL = "";
        public string SECOND_LEVEL_SPELL
        {
            get
            {
                return strSECOND_LEVEL_SPELL;
            }
            set
            {
                strSECOND_LEVEL_SPELL = value;
            }
        }
        #endregion

        #region 第二级排序码
        private string strSECOND_LEVEL_SORT = "";
        public string SECOND_LEVEL_SORT
        {
            get
            {
                return strSECOND_LEVEL_SORT;
            }
            set
            {
                strSECOND_LEVEL_SORT = value;
            }
        }
        #endregion

        #region 第三级名称
        private string strTHIRD_LEVEL_NAME = "";
        public string THIRD_LEVEL_NAME
        {
            get
            {
                return strTHIRD_LEVEL_NAME;
            }
            set
            {
                strTHIRD_LEVEL_NAME = value;
            }
        }
        #endregion

        #region 第三级代码
        private string strTHIRD_LEVEL_CODE = "";
        public string THIRD_LEVEL_CODE
        {
            get
            {
                return strTHIRD_LEVEL_CODE;
            }
            set
            {
                strTHIRD_LEVEL_CODE = value;
            }
        }
        #endregion

        #region 第三级首拼码
        private string strTHIRD_LEVEL_SPELL = "";
        public string THIRD_LEVEL_SPELL
        {
            get
            {
                return strTHIRD_LEVEL_SPELL;
            }
            set
            {
                strTHIRD_LEVEL_SPELL = value;
            }
        }
        #endregion

        #region 第三级排序码
        private string strTHIRD_LEVEL_SORT = "";
        public string THIRD_LEVEL_SORT
        {
            get
            {
                return strTHIRD_LEVEL_SORT;
            }
            set
            {
                strTHIRD_LEVEL_SORT = value;
            }
        }
        #endregion

        #region 第四级名称
        private string strFOURTH_LEVEL_NAME = "";
        public string FOURTH_LEVEL_NAME
        {
            get
            {
                return strFOURTH_LEVEL_NAME;
            }
            set
            {
                strFOURTH_LEVEL_NAME = value;
            }
        }
        #endregion

        #region 第四级代码
        private string strFOURTH_LEVEL_CODE = "";
        public string FOURTH_LEVEL_CODE
        {
            get
            {
                return strFOURTH_LEVEL_CODE;
            }
            set
            {
                strFOURTH_LEVEL_CODE = value;
            }
        }
        #endregion

        #region 第四级首拼码
        private string strFOURTH_LEVEL_SPELL = "";
        public string FOURTH_LEVEL_SPELL
        {
            get
            {
                return strFOURTH_LEVEL_SPELL;
            }
            set
            {
                strFOURTH_LEVEL_SPELL = value;
            }
        }
        #endregion

        #region 第四级排序码
        private string strFOURTH_LEVEL_SORT = "";
        public string FOURTH_LEVEL_SORT
        {
            get
            {
                return strFOURTH_LEVEL_SORT;
            }
            set
            {
                strFOURTH_LEVEL_SORT = value;
            }
        }
        #endregion

        #region 备注
        private string strREMARK = "";
        public string REMARK
        {
            get
            {
                return strREMARK;
            }
            set
            {
                strREMARK = value;
            }
        }
        #endregion

        #region 备注2"
        private string strREMARK2 = "";
        public string REMARK2
        {
            get
            {
                return strREMARK2;
            }
            set
            {
                strREMARK2 = value;
            }
        }
        #endregion

        #endregion

        #region New
        public ICD_10_Class() { }



        public ICD_10_Class(string DirName)
        {
            string d_strSql = "";
            DataSet ds = new DataSet();

            if (DirName == null)
                return;

            d_strSql = "select * from ICD_10 where FOURTH_LEVEL_NAME='" + DirName.Trim() + "'";
            ds = RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);
            strFIRST_LEVEL_NAME = DirName.ToString().Trim();
            strFIRST_LEVEL_CODE = ds.Tables[0].Rows[0]["FIRST_LEVEL_CODE"].ToString().Trim();
            strFIRST_LEVEL_SPELL = ds.Tables[0].Rows[0]["FIRST_LEVEL_SPELL"].ToString().Trim();
            strFIRST_LEVEL_SORT = ds.Tables[0].Rows[0]["FIRST_LEVEL_SORT"].ToString().Trim();
            strSECOND_LEVEL_NAME = ds.Tables[0].Rows[0]["SECOND_LEVEL_NAME"].ToString().Trim();
            strSECOND_LEVEL_CODE = ds.Tables[0].Rows[0]["SECOND_LEVEL_CODE"].ToString().Trim();
            strSECOND_LEVEL_SPELL = ds.Tables[0].Rows[0]["SECOND_LEVEL_SPELL"].ToString().Trim();
            strSECOND_LEVEL_SORT = ds.Tables[0].Rows[0]["SECOND_LEVEL_SORT"].ToString().Trim();
            strTHIRD_LEVEL_NAME = ds.Tables[0].Rows[0]["THIRD_LEVEL_NAME"].ToString().Trim();
            strTHIRD_LEVEL_CODE = ds.Tables[0].Rows[0]["THIRD_LEVEL_CODE"].ToString().Trim();
            strTHIRD_LEVEL_SPELL = ds.Tables[0].Rows[0]["THIRD_LEVEL_SPELL"].ToString().Trim();
            strTHIRD_LEVEL_SORT = ds.Tables[0].Rows[0]["THIRD_LEVEL_SORT"].ToString().Trim();
            strFOURTH_LEVEL_NAME = ds.Tables[0].Rows[0]["FOURTH_LEVEL_NAME"].ToString().Trim();
            strFOURTH_LEVEL_CODE = ds.Tables[0].Rows[0]["FOURTH_LEVEL_CODE"].ToString().Trim();
            strFOURTH_LEVEL_SPELL = ds.Tables[0].Rows[0]["FOURTH_LEVEL_SPELL"].ToString().Trim();
            strFOURTH_LEVEL_SORT = ds.Tables[0].Rows[0]["FOURTH_LEVEL_SORT"].ToString().Trim();
            strREMARK = ds.Tables[0].Rows[0]["REMARK"].ToString().Trim();
            strREMARK2 = ds.Tables[0].Rows[0]["REMARK2"].ToString().Trim();
        }


        #endregion

        #region 方法"

        #region 得到所有信息"

        public DataSet GetAllData()
        {
            string d_strSql = "";

            d_strSql = "select * from ICD_10";

            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);
        }

        #endregion

        #region 得到第一级目录"

        public DataSet GetFIRST_LEVEL_NAME()
        {
            string d_strSql = "";
            d_strSql = "select distinct FIRST_LEVEL_NAME from ICD_10 where FIRST_LEVEL_NAME is not null";
            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 得到第二级目录"

        public DataSet GetSECOND_LEVEL_NAME()
        {
            string d_strSql = "";

            d_strSql = "select distinct SECOND_LEVEL_NAME from ICD_10 where SECOND_LEVEL_NAME is not null";

            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 根据第一级目录得到第二级目录"

        public DataSet GetSECOND_LEVEL_NAME(string p_FIRST_LEVEL_NAME)
        {
            string d_strSql = "";

            d_strSql = "select distinct SECOND_LEVEL_NAME from ICD_10 where (FIRST_LEVEL_NAME='" + p_FIRST_LEVEL_NAME + "'and SECOND_LEVEL_NAME is not null)";

            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 根据第二级目录得到第三级目录"

        public DataSet GetTHIRD_LEVEL_NAME(string p_SECOND_LEVEL_NAME)
        {
            string d_strSql = "";

            d_strSql = "select distinct THIRD_LEVEL_NAME from ICD_10 where (SECOND_LEVEL_NAME='" + p_SECOND_LEVEL_NAME + "' and THIRD_LEVEL_NAME is not null)";
            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 根据第三级目录得到第四级目录"

        public DataSet GetFOURTH_LEVEL_NAME(string p_THIRD_LEVEL_NAME)
        {
            string d_strSql = "";

            d_strSql = "select distinct FOURTH_LEVEL_NAME from ICD_10 where (THIRD_LEVEL_NAME='" + p_THIRD_LEVEL_NAME + "' and FOURTH_LEVEL_NAME is not null)";
            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 根据拼音码得到第四级目录"

        public DataSet GetFOURTH_LEVEL_NAMEByFOURTH_LEVEL_SPELL(string p_FOURTH_LEVEL_SPELL)
        {
            string d_strSql = "";

            p_FOURTH_LEVEL_SPELL = p_FOURTH_LEVEL_SPELL.ToUpper();
            //  'd_strSql = "select distinct FOURTH_LEVEL_NAME from ICD_10 where (FOURTH_LEVEL_SPELL like '%" + p_FOURTH_LEVEL_SPELL + "' or FOURTH_LEVEL_CODE like '" + p_FOURTH_LEVEL_SPELL + "%') and FOURTH_LEVEL_NAME is not null and rownum<100"
            d_strSql = "select FOURTH_LEVEL_NAME from ICD_10 where (FOURTH_LEVEL_SPELL like '" + p_FOURTH_LEVEL_SPELL + "%' or FOURTH_LEVEL_NAME  like '%" + p_FOURTH_LEVEL_SPELL + "%') and FOURTH_LEVEL_NAME is not null and rownum<500 order by FOURTH_LEVEL_NAME,FOURTH_LEVEL_SPELL asc ";
            return RISOracle_Class.GetDS(d_strSql, "查询ICD_10表出错" + "\r\n" + d_strSql);

        }

        #endregion

        #region 添加疾病"

        public bool Insert()
        {
            string d_strSql = "";
            d_strSql = "Insert into ICD_10(FIRST_LEVEL_NAME,FIRST_LEVEL_CODE,FIRST_LEVEL_SPELL,FIRST_LEVEL_SORT,SECOND_LEVEL_NAME,SECOND_LEVEL_CODE,SECOND_LEVEL_SPELL,SECOND_LEVEL_SORT,THIRD_LEVEL_NAME,THIRD_LEVEL_CODE,THIRD_LEVEL_SPELL,THIRD_LEVEL_SORT,FOURTH_LEVEL_NAME,FOURTH_LEVEL_CODE,FOURTH_LEVEL_SPELL,FOURTH_LEVEL_SORT,REMARK,REMARK2)  values ( '" + strFIRST_LEVEL_NAME.ToString()
                                                       + "','" + strFIRST_LEVEL_CODE.ToString()
                                                       + "','" + strFIRST_LEVEL_SPELL.ToString()
                                                       + "','" + strFIRST_LEVEL_SORT.ToString()
                                                       + "','" + strSECOND_LEVEL_NAME.ToString()
                                                       + "','" + strSECOND_LEVEL_CODE.ToString()
                                                       + "','" + strSECOND_LEVEL_SPELL.ToString()
                                                       + "','" + strSECOND_LEVEL_SORT.ToString()
                                                       + "','" + strTHIRD_LEVEL_NAME.ToString()
                                                       + "','" + strTHIRD_LEVEL_CODE.ToString()
                                                       + "','" + strTHIRD_LEVEL_SPELL.ToString()
                                                       + "','" + strTHIRD_LEVEL_SORT.ToString()
                                                       + "','" + strFOURTH_LEVEL_NAME.ToString()
                                                       + "','" + strFOURTH_LEVEL_CODE.ToString()
                                                       + "','" + strFOURTH_LEVEL_SPELL.ToString()
                                                       + "','" + strFOURTH_LEVEL_SORT.ToString()
                                                       + "','" + strREMARK.ToString()
                                                       + "','" + strREMARK2.ToString() + "')";
            return RISOracle_Class.Exec_Cand(d_strSql, "插入ICD_10表出错" + "\r\n" + d_strSql);
        }

        #endregion

        #region 修改疾病"

        public bool Update()
        {
            string d_strSql = "";
            d_strSql = "Update ICD_10 set "
                                   + "FIRST_LEVEL_NAME= '" + strFIRST_LEVEL_NAME + "',"
                                   + "FIRST_LEVEL_CODE='" + strFIRST_LEVEL_CODE + "',"
                                   + "FIRST_LEVEL_SPELL= '" + strFIRST_LEVEL_SPELL + "',"
                                   + "FIRST_LEVEL_SORT='" + strFIRST_LEVEL_SORT + "',"
                                   + "SECOND_LEVEL_NAME='" + strSECOND_LEVEL_NAME + "',"
                                   + "SECOND_LEVEL_CODE='" + strSECOND_LEVEL_CODE + "',"
                                   + "SECOND_LEVEL_SPELL='" + strSECOND_LEVEL_SPELL + "',"
                                   + "SECOND_LEVEL_SORT='" + strSECOND_LEVEL_SORT + "',"
                                   + "THIRD_LEVEL_NAME='" + strTHIRD_LEVEL_NAME + "',"
                                   + "THIRD_LEVEL_CODE='" + strTHIRD_LEVEL_CODE + "',"
                                   + "THIRD_LEVEL_SPELL='" + strTHIRD_LEVEL_SPELL + "',"
                                   + "THIRD_LEVEL_SORT='" + strTHIRD_LEVEL_SORT + "',"
                                   + "FOURTH_LEVEL_NAME='" + strFOURTH_LEVEL_NAME + "',"
                                   + "FOURTH_LEVEL_CODE='" + strFOURTH_LEVEL_CODE + "',"
                                   + "FOURTH_LEVEL_SPELL='" + strFOURTH_LEVEL_SPELL + "',"
                                   + "FOURTH_LEVEL_SORT='" + strFOURTH_LEVEL_SORT + "',"
                                   + "REMARK='" + strREMARK + "',"
                                   + "REMARK2='" + strREMARK2 + "'"
                                   + "where ID=" + intID.ToString().Trim() + "";
            return RISOracle_Class.Exec_Cand(d_strSql, "更新ICD_10表出错" + "\r\n" + d_strSql);
        }

        #endregion

        #region 删除疾病

        public bool Delete()
        {
            string d_strSql = "";
            d_strSql = "Delete ICD_10 where id='" + intID.ToString().Trim() + "'";
            return RISOracle_Class.Exec_Cand(d_strSql, "删除ICD_10表出错" + "\r\n" + d_strSql);
        }

        #endregion


        #endregion

    }
}
