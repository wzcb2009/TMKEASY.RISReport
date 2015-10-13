using System;
using System.Collections.Generic;
using System.Text;

namespace TMKEASY.RISReport 
{
    public class ES_Bitmap_Class : Bitmap_Class
    {
        #region New
        public ES_Bitmap_Class()
            : base()
        {
            strTableName = "ES_Bitmap";
        }

        public ES_Bitmap_Class(int p_ID)
            : base(p_ID)
        {
            strTableName = "ES_Bitmap";
        }

        public ES_Bitmap_Class(string p_ACCESSION_NO)
            : base(p_ACCESSION_NO)
        {
            strTableName = "ES_Bitmap";
        }

        #endregion
    }
}
