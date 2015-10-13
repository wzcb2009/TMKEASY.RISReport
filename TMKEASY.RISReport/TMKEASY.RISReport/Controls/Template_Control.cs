using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
 

namespace TMKEASY.RISReport
{
    public partial class Template_Control : UserControl
    {
        public Template_Control()
        {
            InitializeComponent();
        }

        private void Template_Control_Load(object sender, EventArgs e)
        {
            describe_EditControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);
            describe_EditControl.ExecuteCommand(StandardCommandNames.AutoLineViewMode, false, null);
            describe_EditControl.ContextMenuStrip = cmEdit;
            describe_EditControl.CommandControler = myCommandControler;

            

            //myEditControl.CommandControler.UpdateBindingControlStatus();
            myCommandControler.Start();
            
        }
        public void FillTemplate(string templatexml, string templatetext)
        {
            try
            {
                describe_EditControl.ExecuteCommand("FileNew", false, null);
                if (templatexml.IndexOf("XTextDocument") > -1)
                {
                    //describe_EditControl.ExecuteCommand("InsertXML", false, templatexml);

                    describe_EditControl.ExecuteCommand(StandardCommandNames.InsertXML, false, templatexml);
                    XTextElement ele = describe_EditControl.Document.Content.GetPreElement(describe_EditControl.Document.CurrentElement);
                    if (ele != null && ele is XTextParagraphFlagElement)
                    {
                        describe_EditControl.Document.Body.Elements.Remove(ele);
                    }
                    

                   // describe_EditControl.LoadDocumentFromString(templatexml.ToString(), "xml");
                   
                }
                else
                {
                   
                    describe_EditControl.ExecuteCommand("InsertString", false, templatetext);
                }
                describe_EditControl.RefreshDocument();
            }
            catch { }
        }
        public string GetTemplateText()
        {
           return describe_EditControl.Document.Text.Trim();
        }
        public string GetTemplateXML()
        {
            return (string)describe_EditControl.ExecuteCommand("ViewXMLSource", false, null);
        }
    }
}
