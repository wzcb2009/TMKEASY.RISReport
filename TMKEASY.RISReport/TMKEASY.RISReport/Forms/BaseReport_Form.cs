using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class BaseReport_Form : Form
    {

        public BaseReport_Form()
        {
            InitializeComponent();
            clsPatexam = new patexam_Class();
            clsPatregister = new patregister_Class();
        }
        public BaseReport_Form(string p_accessno)
        {
            InitializeComponent();
            clsPatexam = new patexam_Class(p_accessno);
            clsPatregister = new patregister_Class(p_accessno);
        }
        public virtual void ReBulid(string p_accessno)
        {
            clsPatexam = new patexam_Class(p_accessno);
            clsPatregister = new patregister_Class(p_accessno);
        }
        public BaseReport_Form(patexam_Class p_Patexam)
        {
            InitializeComponent();
            clsPatexam = p_Patexam;
            clsPatregister = new patregister_Class(p_Patexam.accessno);
        }

        #region 属性

        #region 当前报告对象
        protected patexam_Class clsPatexam;
        public patexam_Class CurPatexam
        {
            get { return clsPatexam; }
        }
        #endregion

        #region 当前报告对象
        protected patregister_Class clsPatregister;
        public patregister_Class CurPatregister
        {
            get { return clsPatregister; }
        }
        #endregion

        #region 图像
        protected RIS.Vedio.PanelImageList clsPanelImageList;
        public RIS.Vedio.PanelImageList CurPanelImageList
        {
            get { return clsPanelImageList; }
        }
        #endregion
        #endregion
        #region 方法
        public virtual bool Save()
        {
            return false;
        }

        public virtual bool advance(string p_status)
        {
            return false;
        }

        public virtual void report_rewrite()
        {

        }

        public virtual void FillTemplate(report_template_Class p_Template)
        {

        }
        public virtual void FillTemplate(template_Class p_Template)
        {

        }
        public virtual void FillTemplate(string p_template_describle, string p_template_diag)
        {

        }
        public virtual void Filldiag_word(string p_diag_word, string p_Table)
        {

        }
        //'得到模板内容
        public virtual void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref patexam_Class p_patexam)
        {
        }
        //'得到模板内容
        public virtual void getTemplateContent(ref string p_template_diag, ref string p_template_describle, ref string p_template_part, ref string p_dep)
        {
        }

        public virtual void ExecuteCommand(string exestr)
        {

        }
        public virtual void ExecuteCommand(string exestr, bool showUI, object parameter)
        {

        }
        public virtual void ExecuteCommand(string exestr, bool showUI)
        {

        }
        public virtual object ReturnExecuteCommand(string exestr, bool showUI, object parameter)
        {
            return null;
        }
        public virtual void PrintDocument(string d_PrintStatus)
        {

        }
        public virtual void Filldiseasetype(string p_diseasetype)
        {

        }
        public virtual void OpenPacsImage()
        {

        }
        public virtual void SetExcludeKeywords()
        {
        }
        public virtual void ImageAdd(string p_imagefile, string p_imagename, int p_imageindex)
        {

        }
        public virtual void ImageDel(List<string> p_imagename, int p_count)
        {

        }

        public virtual void ReCreateReportStyle(string p_type)
        {

        }
        #endregion

    }
}