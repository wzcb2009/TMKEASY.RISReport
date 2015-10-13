using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMKEASY.RISReport
{
    public partial class ReportStyle_Form : Form
    {
        public ReportStyle_Form()
        {
            InitializeComponent();

            myEditControl.AllowDragContent = true;
            
            //tabDataSource.Visible = false;
            //this.spDataSource.Visible = false;
            myEditControl.MoveFocusHotKey = MoveFocusHotKeys.Tab;
        }
        /// <summary>
        /// 数据源树状列表控制器
        /// </summary>
        private DataSourceTreeViewControler dstvControler = null;
        private void ReportStyle_Form_Load(object sender, EventArgs e)
        {
            this.myEditControl.EventCanInsertObject +=
                new DCSoft.Writer.CanInsertObjectEventHandler(this.myEditControl_EventCanInsertObject);
            this.myEditControl.EventInsertObject +=
                new DCSoft.Writer.InsertObjectEventHandler(this.myEditControl_EventInsertObject);
            myEditControl.Font = new Font(System.Windows.Forms.Control.DefaultFont.Name, 12);
            myEditControl.Font = new Font("宋体", 9);
            //myEditControl.AutoSetDocumentDefaultFont = true;

            // 初始化设置命令执行器
            myEditControl.CommandControler = myCommandControler;
            myCommandControler.Start();
            myEditControl.DocumentOptions = new DocumentOptions();            // 设置文档处于调试模式
            myEditControl.DocumentOptions.BehaviorOptions.DebugMode = true;          
            myEditControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);
           
            // 注册自定义的输入域下拉列表提供者
            myEditControl.AppHost.Services.AddService(
                typeof(IListItemsProvider),
                new  MyListItemsProvider_Class());
            try
            {
                dstvControler = new DataSourceTreeViewControler(tvwDataSource);
                tvwDataSource.MouseDown += dstvControler.HandleTreeViewMouseDown;
                string fileName = Application.StartupPath + @"\XMLStyle\DataSourceDescriptor.xml";
                if (System.IO.File.Exists(fileName))
                {
                    dstvControler.LoadFile(fileName);
                }
            }
            catch { }
        }
        #region 数据源树状列表操作相关的代码


        private void myEditControl_EventCanInsertObject(object sender, CanInsertObjectEventArgs args)
        {
            if (this.dstvControler != null)
            {
                this.dstvControler.HandleCanInsertObjectEvent(myEditControl, args);
            }
        }

        private void myEditControl_EventInsertObject(object sender, InsertObjectEventArgs args)
        {
            if (this.dstvControler != null)
            {
                this.dstvControler.HandleInsertObjectEvent(myEditControl, args);
            }
        }


        #endregion

        private FlagXTextRangeProvider provider = new FlagXTextRangeProvider();
     

       
        /// <summary>
        /// 设置编辑器控件的快捷菜单
        /// </summary>
        private void SetContextMenu()
        {
            //this.myEditControl.ContextMenuStrip = null;
            //return;

            if (Math.Abs(myEditControl.Selection.Length) == 1)
            {
                XTextElement element = this.myEditControl.Selection.ContentElements[0];
                if (element is XTextImageElement)
                {
                    this.myEditControl.ContextMenuStrip = this.cmImage;
                    return;
                }
            }
            bool isInCell = false;
            if (myEditControl.Selection.Cells != null && myEditControl.Selection.Cells.Count > 0)
            {
                isInCell = true;
            }
            else
            {
                XTextContainerElement c = null;
                int index = 0;
                myEditControl.Document.Content.GetCurrentPositionInfo(out c, out index);
                if (c is XTextTableCellElement || c.OwnerCell != null)
                {
                    isInCell = true;
                }
            }
            if (isInCell)
            {
                myEditControl.ContextMenuStrip = cmTableCell;
                return;
            }
            myEditControl.ContextMenuStrip = cmEdit;
        }

        private void UpdateFormText()
        {
            string text = "DCSoft.Writer";
            if (string.IsNullOrEmpty(this.myEditControl.Document.Info.Title) == false)
            {
                text = myEditControl.Document.Info.Title + "-" + text;
            }
            else if (string.IsNullOrEmpty(this.myEditControl.Document.FileName) == false)
            {
                text = myEditControl.Document.FileName + " - " + text;
            }
            if (myEditControl.Document.Modified)
            {
                text = text + " *";
            }
            this.Text = text;
        }

        private void myEditControl_SelectionChanged(object eventSender, WriterEventArgs args)
        {
            //XTextFieldElement field = (XTextFieldElement)myEditControl.Document.CurrentField;
            //field.EditorTextExt = "bbb";

            provider.Document = myEditControl.Document;
            provider.Prefix = '{';
            provider.Endfix = '}';
            XTextRange range = provider.GetRange(myEditControl.CurrentElement);
            if (range != null)
            {
                myEditControl.HighlightRange = new HighlightInfo(range);
            }
            else
            {
                myEditControl.HighlightRange = null;
            }


            //XTextLine line = myEditControl.Document.CurrentContentElement.CurrentLine;
            //if (line != null && line.OwnerPage != null)
            //{
            //    string txt =
            //        string.Format(ResourceStrings._LINE,
            //        Convert.ToString(myEditControl.CurrentLineOwnerPageIndex),
            //        Convert.ToString(myEditControl.CurrentLineIndexInPage),
            //        Convert.ToString(myEditControl.CurrentColumnIndex));
            //    if (myEditControl.Selection.Length != 0)
            //    {
            //        txt = txt + string.Format(
            //            ResourceStrings._SELECTELEMENTS,
            //            Math.Abs(myEditControl.Selection.Length));
            //    }
            //    Point p = myEditControl.SelectionStartPosition;
            //    this.lblPosition.Text = txt + " X:" + p.X + " Y:" + p.Y;
            //}

            UpdateFormText();

            SetContextMenu();

            if (this.dstvControler != null)
            {
                this.dstvControler.UpdateCurrentDataSourceNode(myEditControl);
            }
            //this.Text = myEditControl.CaretPosition.ToString();
        }

        private void myEditControl_HoverElementChanged(object eventSender, WriterEventArgs args)
        {
            provider.Document = myEditControl.Document;
            provider.Prefix = '{';
            provider.Endfix = '}';
            if (myEditControl.HoverElement != null && myEditControl.HoverElement.Parent is XTextInputFieldElement)
            {
                XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.HoverElement.Parent;
                if (field.IsBackgroundTextElement(myEditControl.HoverElement))
                {
                }
            }
            XTextRange range = provider.GetRange(myEditControl.HoverElement);
            if (range != null)
            {
                this.myEditControl.HighlightRange = new HighlightInfo(range);

            }
            else
            {
                this.myEditControl.HighlightRange = null;
            }
        }

        private void mInsertXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        myEditControl.ExecuteCommand("InsertXML", false, stream);
                    }
                }
            }
        }

        private void btnDataSourceList_Click(object sender, EventArgs e)
        {

        }

        private void ReportStyle_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowErr_Form d_from = new ShowErr_Form("窗口将要关闭,文件还未保存,是否继续关闭","是","否");
            if (d_from.ShowDialog() != DialogResult.OK)
            {
                e.Cancel = true ;
            }
             

        }
    }
}
