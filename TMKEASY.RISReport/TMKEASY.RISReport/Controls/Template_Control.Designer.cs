namespace TMKEASY.RISReport
{
    partial class Template_Control
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template_Control));
            this.describe_EditControl = new DCSoft.Writer.Controls.WriterControl();
            this.myCommandControler = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.cmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFont = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAlignCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAlignRight = new System.Windows.Forms.ToolStripMenuItem();
            this.cmProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.插入医学表达式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入复选框元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.myImageList = new System.Windows.Forms.ImageList(this.components);
            this.imgsControl = new System.Windows.Forms.ImageList(this.components);
            this.插入输入域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入横线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.myCommandControler)).BeginInit();
            this.cmEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // describe_EditControl
            // 
            this.describe_EditControl.AllowDrop = true;
            this.describe_EditControl.AutoScroll = true;
            this.describe_EditControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.describe_EditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.describe_EditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.describe_EditControl.Location = new System.Drawing.Point(0, 0);
            this.describe_EditControl.Name = "describe_EditControl";
            this.describe_EditControl.PageSpacing = 0;
            this.describe_EditControl.RegisterCode = "023E4EA500000000000024000000E6B8A9E5B79EE58DA1E69893E7BD91E7BB9CE68A80E69CAFE69C8" +
    "9E99990E585ACE58FB8FD02080000004B617969536F66740400";
            this.describe_EditControl.Size = new System.Drawing.Size(363, 386);
            this.describe_EditControl.TabIndex = 18;
            // 
            // cmRedo
            // 
            this.myCommandControler.SetCommandName(this.cmRedo, "Redo");
            this.cmRedo.Image = ((System.Drawing.Image)(resources.GetObject("cmRedo.Image")));
            this.cmRedo.Name = "cmRedo";
            this.cmRedo.Size = new System.Drawing.Size(152, 22);
            this.cmRedo.Text = "重复";
            // 
            // cmUndo
            // 
            this.myCommandControler.SetCommandName(this.cmUndo, "Undo");
            this.cmUndo.Image = ((System.Drawing.Image)(resources.GetObject("cmUndo.Image")));
            this.cmUndo.Name = "cmUndo";
            this.cmUndo.Size = new System.Drawing.Size(152, 22);
            this.cmUndo.Text = "撤销";
            // 
            // cmCut
            // 
            this.myCommandControler.SetCommandName(this.cmCut, "Cut");
            this.cmCut.Image = ((System.Drawing.Image)(resources.GetObject("cmCut.Image")));
            this.cmCut.Name = "cmCut";
            this.cmCut.Size = new System.Drawing.Size(152, 22);
            this.cmCut.Text = "剪切";
            // 
            // cmCopy
            // 
            this.myCommandControler.SetCommandName(this.cmCopy, "Copy");
            this.cmCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmCopy.Image")));
            this.cmCopy.Name = "cmCopy";
            this.cmCopy.Size = new System.Drawing.Size(152, 22);
            this.cmCopy.Text = "复制";
            // 
            // cmPaste
            // 
            this.myCommandControler.SetCommandName(this.cmPaste, "Paste");
            this.cmPaste.Image = ((System.Drawing.Image)(resources.GetObject("cmPaste.Image")));
            this.cmPaste.Name = "cmPaste";
            this.cmPaste.Size = new System.Drawing.Size(152, 22);
            this.cmPaste.Text = "粘贴";
            // 
            // cmDelete
            // 
            this.myCommandControler.SetCommandName(this.cmDelete, "Delete");
            this.cmDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmDelete.Image")));
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(152, 22);
            this.cmDelete.Text = "删除";
            // 
            // cmColor
            // 
            this.myCommandControler.SetCommandName(this.cmColor, "Color");
            this.cmColor.Name = "cmColor";
            this.cmColor.Size = new System.Drawing.Size(152, 22);
            this.cmColor.Text = "颜色";
            // 
            // cmFont
            // 
            this.myCommandControler.SetCommandName(this.cmFont, "Font");
            this.cmFont.Image = ((System.Drawing.Image)(resources.GetObject("cmFont.Image")));
            this.cmFont.Name = "cmFont";
            this.cmFont.Size = new System.Drawing.Size(152, 22);
            this.cmFont.Text = "字体...";
            // 
            // cmAlignLeft
            // 
            this.myCommandControler.SetCommandName(this.cmAlignLeft, "AlignLeft");
            this.cmAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("cmAlignLeft.Image")));
            this.cmAlignLeft.Name = "cmAlignLeft";
            this.cmAlignLeft.Size = new System.Drawing.Size(152, 22);
            this.cmAlignLeft.Text = "左对齐";
            // 
            // cmAlignCenter
            // 
            this.myCommandControler.SetCommandName(this.cmAlignCenter, "AlignCenter");
            this.cmAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("cmAlignCenter.Image")));
            this.cmAlignCenter.Name = "cmAlignCenter";
            this.cmAlignCenter.Size = new System.Drawing.Size(152, 22);
            this.cmAlignCenter.Text = "居中对齐";
            // 
            // cmAlignRight
            // 
            this.myCommandControler.SetCommandName(this.cmAlignRight, "AlignRight");
            this.cmAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("cmAlignRight.Image")));
            this.cmAlignRight.Name = "cmAlignRight";
            this.cmAlignRight.Size = new System.Drawing.Size(152, 22);
            this.cmAlignRight.Text = "右对齐";
            // 
            // cmProperties
            // 
            this.myCommandControler.SetCommandName(this.cmProperties, "ElementProperties");
            this.cmProperties.Name = "cmProperties";
            this.cmProperties.Size = new System.Drawing.Size(152, 22);
            this.cmProperties.Text = "属性...";
            // 
            // toolStripMenuItem1
            // 
            this.myCommandControler.SetCommandName(this.toolStripMenuItem1, "Superscript");
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "上标";
            // 
            // toolStripMenuItem2
            // 
            this.myCommandControler.SetCommandName(this.toolStripMenuItem2, "Subscript");
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "下标";
            // 
            // 插入医学表达式ToolStripMenuItem
            // 
            this.myCommandControler.SetCommandName(this.插入医学表达式ToolStripMenuItem, "InsertMedicalExpression");
            this.插入医学表达式ToolStripMenuItem.Name = "插入医学表达式ToolStripMenuItem";
            this.插入医学表达式ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.插入医学表达式ToolStripMenuItem.Text = "插入医学表达式...";
            // 
            // 插入复选框元素ToolStripMenuItem
            // 
            this.myCommandControler.SetCommandName(this.插入复选框元素ToolStripMenuItem, "InsertCheckBox");
            this.插入复选框元素ToolStripMenuItem.Name = "插入复选框元素ToolStripMenuItem";
            this.插入复选框元素ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.插入复选框元素ToolStripMenuItem.Text = "插入复选框元素...";
            // 
            // insertToolStripMenuItem
            // 
            this.myCommandControler.SetCommandName(this.insertToolStripMenuItem, "InsertListField");
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.insertToolStripMenuItem.Text = "插入下拉列表";
            // 
            // cmEdit
            // 
            this.cmEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入ToolStripMenuItem,
            this.cmRedo,
            this.cmUndo,
            this.toolStripMenuItem4,
            this.cmCut,
            this.cmCopy,
            this.cmPaste,
            this.cmDelete,
            this.toolStripMenuItem5,
            this.cmColor,
            this.cmFont,
            this.toolStripMenuItem6,
            this.cmAlignLeft,
            this.cmAlignCenter,
            this.cmAlignRight,
            this.toolStripMenuItem8,
            this.cmProperties,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.cmEdit.Name = "cmEdit";
            this.cmEdit.Size = new System.Drawing.Size(153, 380);
            // 
            // 插入ToolStripMenuItem
            // 
            this.插入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入输入域ToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.插入医学表达式ToolStripMenuItem,
            this.插入复选框元素ToolStripMenuItem,
            this.插入横线ToolStripMenuItem});
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.插入ToolStripMenuItem.Text = "插入";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(149, 6);
            // 
            // myImageList
            // 
            this.myImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImageList.ImageStream")));
            this.myImageList.TransparentColor = System.Drawing.Color.White;
            this.myImageList.Images.SetKeyName(0, "");
            this.myImageList.Images.SetKeyName(1, "");
            this.myImageList.Images.SetKeyName(2, "");
            this.myImageList.Images.SetKeyName(3, "");
            this.myImageList.Images.SetKeyName(4, "");
            this.myImageList.Images.SetKeyName(5, "");
            this.myImageList.Images.SetKeyName(6, "");
            this.myImageList.Images.SetKeyName(7, "");
            this.myImageList.Images.SetKeyName(8, "");
            this.myImageList.Images.SetKeyName(9, "");
            this.myImageList.Images.SetKeyName(10, "");
            this.myImageList.Images.SetKeyName(11, "");
            this.myImageList.Images.SetKeyName(12, "");
            this.myImageList.Images.SetKeyName(13, "");
            this.myImageList.Images.SetKeyName(14, "");
            this.myImageList.Images.SetKeyName(15, "");
            this.myImageList.Images.SetKeyName(16, "");
            this.myImageList.Images.SetKeyName(17, "");
            this.myImageList.Images.SetKeyName(18, "");
            this.myImageList.Images.SetKeyName(19, "");
            this.myImageList.Images.SetKeyName(20, "");
            this.myImageList.Images.SetKeyName(21, "");
            this.myImageList.Images.SetKeyName(22, "");
            this.myImageList.Images.SetKeyName(23, "");
            this.myImageList.Images.SetKeyName(24, "");
            this.myImageList.Images.SetKeyName(25, "");
            this.myImageList.Images.SetKeyName(26, "");
            this.myImageList.Images.SetKeyName(27, "");
            this.myImageList.Images.SetKeyName(28, "");
            this.myImageList.Images.SetKeyName(29, "");
            this.myImageList.Images.SetKeyName(30, "");
            this.myImageList.Images.SetKeyName(31, "");
            this.myImageList.Images.SetKeyName(32, "");
            // 
            // imgsControl
            // 
            this.imgsControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgsControl.ImageStream")));
            this.imgsControl.TransparentColor = System.Drawing.Color.Red;
            this.imgsControl.Images.SetKeyName(0, "IconAssembly.bmp");
            // 
            // 插入输入域ToolStripMenuItem
            // 
            this.myCommandControler.SetCommandName(this.插入输入域ToolStripMenuItem, "InsertInputField");
            this.插入输入域ToolStripMenuItem.Name = "插入输入域ToolStripMenuItem";
            this.插入输入域ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.插入输入域ToolStripMenuItem.Text = "插入文本输入域";
            // 
            // 插入横线ToolStripMenuItem
            // 
            this.myCommandControler.SetCommandName(this.插入横线ToolStripMenuItem, "InsertHorizontalLine");
            this.插入横线ToolStripMenuItem.Name = "插入横线ToolStripMenuItem";
            this.插入横线ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.插入横线ToolStripMenuItem.Text = "插入横线";
            // 
            // Template_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.describe_EditControl);
            this.Name = "Template_Control";
            this.Size = new System.Drawing.Size(363, 386);
            this.Load += new System.EventHandler(this.Template_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myCommandControler)).EndInit();
            this.cmEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DCSoft.Writer.Controls.WriterControl describe_EditControl;
        private DCSoft.Writer.Commands.WriterCommandControler myCommandControler;
        private System.Windows.Forms.ContextMenuStrip cmEdit;
        private System.Windows.Forms.ToolStripMenuItem cmRedo;
        private System.Windows.Forms.ToolStripMenuItem cmUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem cmCut;
        private System.Windows.Forms.ToolStripMenuItem cmCopy;
        private System.Windows.Forms.ToolStripMenuItem cmPaste;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cmColor;
        private System.Windows.Forms.ToolStripMenuItem cmFont;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cmAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem cmAlignCenter;
        private System.Windows.Forms.ToolStripMenuItem cmAlignRight;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem cmProperties;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ImageList myImageList;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入医学表达式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入复选框元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ImageList imgsControl;
        private System.Windows.Forms.ToolStripMenuItem 插入输入域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入横线ToolStripMenuItem;
    }
}
