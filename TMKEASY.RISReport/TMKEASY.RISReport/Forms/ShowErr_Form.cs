using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TMKEASY.RISReport 
{
    public partial class ShowErr_Form : KY.ShowErr .ShowErr_Form 
    {
        public ShowErr_Form()
            :base ()
        {
            InitializeComponent();
        }
        public ShowErr_Form( Collection p_Err)
            : base(p_Err)
        {
            InitializeComponent();
        }
        public ShowErr_Form(string p_Content)
            : base(p_Content)
        {
            InitializeComponent();
        }
        public ShowErr_Form(string p_Err, string p_Title)
            : base(p_Err, p_Title)
        {
            InitializeComponent();
        }
        public ShowErr_Form(string p_Content, string p_ButtonText1, string p_ButtonText2)
            : base(p_Content, p_ButtonText1, p_ButtonText2)
        {
            InitializeComponent();
        }
        public ShowErr_Form(string p_Content, string p_ButtonText1, string p_ButtonText2, string p_ButtonText3)
            : base(p_Content ,p_ButtonText1 ,p_ButtonText2 ,p_ButtonText3 )
        {
            InitializeComponent();
        }
    }
}