using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport
{
    public class EventArgs_Class : EventArgs
    {
        #region ���ʺ�
        private string straccessno = "";
        public string accessno
        {
            get { return straccessno; }
            set { straccessno = value; }
        }
        #endregion
        public EventArgs_Class()
        {
        }
        public EventArgs_Class(string d_straccessno)
        {
            straccessno = d_straccessno;
        }
    }
}
