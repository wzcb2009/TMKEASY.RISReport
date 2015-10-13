using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport
{
    public class BaseReport_Class
    {
        public   BaseReport_Class()
        {

            Share_Class.User = new Userinfo_Class("XRAY", "admin");
            Share_Class.hospital_name  = "";
        }

        public   BaseReport_Class(string p_Dir, int Userid)
        {
            Share_Class.Dir = p_Dir;
            Share_Class.User = new Userinfo_Class(Userid);
            Share_Class.hospital_name = "";

        }

        public   BaseReport_Class(string p_Dir, int Userid, string p_HOSPITALNAME){
        Share_Class.Dir = p_Dir;
        Share_Class.User = new Userinfo_Class(Userid);
        Share_Class.hospital_name = p_HOSPITALNAME;
        //If p_HOSPITALNAME = "织金县人民医院" Then
        //    Share_Class.SoftVersion = "0857020"
        //ElseIf p_HOSPITALNAME = "" Then
        //    Share_Class.SoftVersion = "0593010"
        //Else
        //Share_Class.SoftVersion = "0577002";
        //End If

    }



        public void Show(string p_accessno, string p_ReportType)
        {
            //patexam_Class p_patexam = new patexam_Class(p_accessno);

            Report_Form d_Form = new Report_Form(p_accessno);
            d_Form.AdvanceReport += new Report_Form.PassDataBetweenFormHandler(ReturnFunction);
            d_Form.SaveReport  += new Report_Form.PassDataBetweenFormHandler(ReturnFunction);
            d_Form.Show();

        }


        //  '// 添加一个委托 
        public delegate void PassDataBetweenFormHandler(object sender, EventArgs_Class e);
        //'// 添加一个PassDataBetweenFormHandler 类型的事件 
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public void ReturnFunction(object sender, EventArgs_Class e)
        {
            //Dim args As New PassDataWinFormEventArgs_Class(e.accessno)
            //RaiseEvent PassDataBetweenForm(sender, args)
             PassDataBetweenForm(sender, e);
        }
    }
}
