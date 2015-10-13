using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.OracleClient;

namespace TMKEASY.RISReport 
{
   public  class patregister_Class: Table.patregister 
    {
        #region New
        public patregister_Class()
        {

        }

        //'ͨ������ID���½����˵Ǽ���Ϣ
        public patregister_Class(string p_clinicno)
        {
            string d_strSql = "";
            d_strSql = "Select * from patregister where clinicno='" + p_clinicno.Trim() + "'";
            DataSet Ds = RISOracle_Class.GetDS(d_strSql, "��ѯpatregister�����" + "\r\n" + d_strSql);
            SetPropertyByDs(Ds);
        }

        ////'ͨ�����������סԺ�źͲ������ͽ����˵Ǽ���Ϣ
        //public patregister_Class(string p_Patient_id, string p_pat_type)
        //{
        //    string d_strSql = "";
        //    //'ͨ�����������סԺ�źͲ������͵õ�����ID
        //    d_strSql = "Select * from patexam where Patient_id='" + p_Patient_id.Trim() + "' and pat_type='" + p_pat_type.Trim() + "'";
        //    DataSet Ds = RISOracle_Class.GetDS(d_strSql, "��ѯpatexam�����" + "\r\n" + d_strSql);
        //    SetPropertyByDs(Ds);
        //}
        #endregion

        #region ����
         
        

        //'ͨ�����ĵõ�ƴ��
        public static string GetSpellbyChName(string p_Name)
        {
            if (p_Name == "")
            {
                return "";
            }
            string d_Spell = "";
            string d_strSql = "";
            // '��дѡ��ƴ����Sql���
            for (int i = 0; i < p_Name.Length ; i++)
            {
                d_strSql = "Select spell from tspell where chinese='" + p_Name.Substring(i, 1) + "' and rownum<2";
                DataSet Ds = RISOracle_Class.GetDS(d_strSql, "��ѯtspell�����" + "\r\n" + d_strSql);
                if ((Ds == null) || (Ds.Tables[0].Rows.Count == 0))
                {
                    d_Spell = d_Spell + p_Name.Substring(i, 1);
                }
                if (Ds.Tables[0].Rows.Count == 1)
                {
                    d_Spell = d_Spell + " " + Ds.Tables[0].Rows[0]["spell"].ToString().Trim();
                }
            }
            return d_Spell.Trim();
        }

      
        //'�޸�FTP����
        public static bool UpdateFTPCode(string p_FTPCode, string p_ACCESSION_NO)
        {
            string d_strSql = "";
            d_strSql = "update patregister set FTPCode='" + p_FTPCode + "' where clinicno='" + p_ACCESSION_NO + "'";
            return RISOracle_Class.Exec_Cand(d_strSql, d_strSql);
        }

        //'�޸�·��״̬
        public static bool UpdateROUTE_STATUS(string p_ACCESSION_NO)
        {

            string d_strSql = "";
            d_strSql = "update patregister set ROUTE_STATUS='no' where clinicno='" + p_ACCESSION_NO + "'";
            return RISOracle_Class.Exec_Cand(d_strSql, d_strSql);
        }

        // '���Ӳ����˵Ǽ���Ϣ
        public override bool Insert()
        {

            string sqlstr = "";
            ArrayList Par_Array = new ArrayList();

            OracleParameter parv_streamid = new OracleParameter();
            parv_streamid.ParameterName = "v_streamid";
            parv_streamid.OracleType = OracleType.Number;
            parv_streamid.Direction = ParameterDirection.Output;
            Par_Array.Add(parv_streamid);

            OracleParameter parv_streamdate = new OracleParameter();
            parv_streamdate.ParameterName = "v_streamdate";
            parv_streamdate.OracleType = OracleType.DateTime;
            parv_streamdate.Direction = ParameterDirection.Output;
            Par_Array.Add(parv_streamdate);



            if (RISOracle_Class.Exec_Cand("streamidstore", Par_Array, "ִ�д洢����streamidstore����") == false)
            {// 'ִ�д洢���̳����˳������ص������false
                return false;
            }
            else
            {
                strclinicno = Convert.ToDateTime(parv_streamdate.Value).ToString("yyyyMMdd");       //          '�����strclinicno��patexam���е�accessno��ͬ������accessno����������Ҫ�ٲ���
                strclinicno = strclinicno + Convert.ToInt32(parv_streamid.Value).ToString("000#");
                sqlstr = this.InsertSQL(); ;
                RISOracle_Class.Exec_Cand(sqlstr, "����patregister�����" + "\r\n" + sqlstr);

                return true;
            }

        }

       public override bool Update()
        {

            string sqlstr = this.UpdateSQL();
            return RISOracle_Class.Exec_Cand(sqlstr, "����patregister�����" + "\r\n" + sqlstr);


        }

        //'�޸�FTP����
       public static bool Updatedoctorcode( string p_accessno,string p_codetype, string p_codename)
        {
            string d_strSql = ""; 
            d_strSql = "update patregister set " + p_codetype + "='" + p_codename + "' where clinicno='" + p_accessno + "' ";
        return RISOracle_Class.Exec_Cand(d_strSql, d_strSql);
        }

        //'�޸�FTP����
       public static bool UpdatePrintStatus(string p_printStatus, string p_ACCESSION_NO)
        {
            string d_strSql = "";
            d_strSql = "Update Patregister set print_status='" + p_printStatus + "' where clinicno='" + p_ACCESSION_NO + "'";
            return RISOracle_Class.Exec_Cand(d_strSql, d_strSql);
        }

        #endregion
    }
}
