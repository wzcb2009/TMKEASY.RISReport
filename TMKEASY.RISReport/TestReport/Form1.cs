using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMKEASY.RISReport;

namespace TestReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseReport_Class d_report = new BaseReport_Class();
            d_report.Show(this.textBox1.Text.Trim(), "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TMKEASY.RISReport.template_Word_form d_form = new template_Word_form(97,Application.StartupPath ,"");
            d_form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportStyle_Form d_form = new ReportStyle_Form();
            d_form.Show();
        }


    }
}