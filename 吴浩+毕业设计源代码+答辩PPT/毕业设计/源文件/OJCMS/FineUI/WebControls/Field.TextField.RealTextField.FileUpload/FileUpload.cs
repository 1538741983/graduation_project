
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    FileUpload.cs
 * CreatedOn:   2011-12-25
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2011-12-25    30372245@qq.com  
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;

namespace FineUI
{
    /// <summary>
    /// 文件上传控件
    /// </summary>
    [Designer("FineUI.Design.FileUploadDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FileUpload Label=\"Label\" runat=\"server\"></{0}:FileUpload>")]
    [ToolboxBitmap(typeof(FileUpload), "toolbox.FileUpload.bmp")]
    [Description("文件上传控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class FileUpload : RealTextField, IPostBackEventHandler
    {
        
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public FileUpload()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 允许上传的文件类型（仅部分浏览器支持）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("允许上传的文件类型（仅部分浏览器支持）")]
        public string AcceptFileTypes
        {
            get
            {
                object obj = FState["AcceptFileTypes"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["AcceptFileTypes"] = value;
            }
        }


        /// <summary>
        /// 按钮文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮文本")]
        public string ButtonText
        {
            get
            {
                object obj = FState["ButtonText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ButtonText"] = value;
            }
        }

        /// <summary>
        /// 是否只显示按钮，不显示只读输入框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否只显示按钮，不显示只读输入框")]
        public bool ButtonOnly
        {
            get
            {
                object obj = FState["ButtonOnly"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ButtonOnly"] = value;
            }
        }



        /// <summary>
        /// 按钮图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("按钮图标")]
        public Icon ButtonIcon
        {
            get
            {
                object obj = FState["ButtonIcon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                FState["ButtonIcon"] = value;
            }
        }

        /// <summary>
        /// 按钮图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string ButtonIconUrl
        {
            get
            {
                object obj = FState["ButtonIconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ButtonIconUrl"] = value;
            }
        }


        /// <summary>
        /// 上传的文件
        /// </summary>
        [Description("上传的文件")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpPostedFile PostedFile
        {
            get
            {
                return Page.Request.Files[UniqueID];
            }
        }

        /// <summary>
        /// 是否包含文件
        /// </summary>
        [Description("是否包含文件")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasFile
        {
            get
            {
                return PostedFile != null && PostedFile.ContentLength > 0;
            }
        }

        /// <summary>
        /// 客户端文件名称，包含目录路径（IE下为完成路径，Chrome下为文件名）
        /// </summary>
        [Description("客户端文件名称，包含目录路径（IE下为完成路径，Chrome下为文件名）")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName
        {
            get
            {
                return PostedFile.FileName;
            }
        }


        /// <summary>
        /// 客户端文件名称，不包含目录路径
        /// </summary>
        [Description("客户端文件名称，不包含目录路径")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShortFileName
        {
            get
            {
                string fileName = FileName;
                int lastSlashIndex = fileName.LastIndexOf("\\");
                if (lastSlashIndex >= 0)
                {
                    fileName = fileName.Substring(lastSlashIndex + 1);
                }
                return fileName;
            }
        }


        #endregion

        #region Public

        /// <summary>
        /// 将上载文件的内容保存到 Web 服务器上的指定路径
        /// </summary>
        /// <param name="filename">保存的文件的名称</param>
        public void SaveAs(string filename)
        {
            if (HasFile)
            {
                PostedFile.SaveAs(filename);
            }
        }


        #endregion

        #region OnPreRender


        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            //AddStartupAbsoluteScript("F.form_upload_file=true;");


            if (!String.IsNullOrEmpty(ButtonText))
            {
                OB.AddProperty("buttonText", ButtonText);
            }

            if (ButtonOnly)
            {
                OB.AddProperty("buttonOnly", true);
            }


            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(ButtonIcon, ButtonIconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                OptionBuilder buttonOB = new OptionBuilder();
                //buttonOB.AddProperty("cls", " x-btn-text-icon");
                buttonOB.AddProperty("icon", resolvedIconUrl);

                OB.AddProperty("buttonConfig", buttonOB);
            }

            //if (AutoPostBack)
            //{
            //    OB.Listeners.RemoveProperty("change");
            //    OB.Listeners.AddProperty("fileselected", JsHelper.GetFunction(GetPostBackEventReference()), true);
            //}

            if (!String.IsNullOrEmpty(AcceptFileTypes))
            {
                string acceptScript = "cmp.fileInputEl.set({accept:'" + AcceptFileTypes + "'});";
                //OB.Listeners.AddProperty("afterrender", JsHelper.GetFunction(acceptScript, "cmp"), true);
                AddListener("afterrender", acceptScript, "cmp");
            }

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.File',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            // FileUpload控件不响应回发数据改变事件（因此此控件不保存文本值，也无法判断文本是否改变）
            return false;
        }

       

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            OnFileSelected(EventArgs.Empty);
        }


        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 文件选定事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("文件选定事件（需要启用AutoPostBack）")]
        public virtual event EventHandler FileSelected
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }

        /// <summary>
        /// 触发文件选定事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnFileSelected(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
