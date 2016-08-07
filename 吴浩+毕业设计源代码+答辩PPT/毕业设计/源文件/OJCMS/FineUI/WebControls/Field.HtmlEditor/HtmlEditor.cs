
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    HtmlEditor.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 *      ->2008-04-28    改名为 HtmlEditor
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
using Newtonsoft.Json.Linq;

namespace FineUI
{
    /// <summary>
    /// HTML编辑框控件
    /// </summary>
    [Designer("FineUI.Design.HtmlEditorDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HtmlEditor Label=\"Label\" Text=\"\" Height=\"250px\" runat=server></{0}:HtmlEditor>")]
    [ToolboxBitmap(typeof(HtmlEditor), "toolbox.HtmlEditor.bmp")]
    [Description("HTML编辑框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HtmlEditor : Field, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public HtmlEditor()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Text");

            AddGzippedAjaxProperties("Text");
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Enabled
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Readonly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// [AJAX属性]文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]文本")]
        public virtual string Text
        {
            get
            {
                object obj = FState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Text"] = value;
            }
        }


        /// <summary>
        /// 启用左右定位
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用左右定位")]
        public bool EnableAlignments
        {
            get
            {
                object obj = FState["EnableAlignments"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableAlignments"] = value;
            }
        }

        /// <summary>
        /// 启用颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用颜色")]
        public bool EnableColors
        {
            get
            {
                object obj = FState["EnableColors"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableColors"] = value;
            }
        }


        /// <summary>
        /// 启用字体
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用字体")]
        public bool EnableFont
        {
            get
            {
                object obj = FState["EnableFont"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableFont"] = value;
            }
        }


        /// <summary>
        /// 启用调整字体大小
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用调整字体大小")]
        public bool EnableFontSize
        {
            get
            {
                object obj = FState["EnableFontSize"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableFontSize"] = value;
            }
        }


        /// <summary>
        /// 启用格式化
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用格式化")]
        public bool EnableFormat
        {
            get
            {
                object obj = FState["EnableFormat"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableFormat"] = value;
            }
        }


        /// <summary>
        /// 启用创建链接
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用创建链接")]
        public bool EnableLinks
        {
            get
            {
                object obj = FState["EnableLinks"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableLinks"] = value;
            }
        }


        /// <summary>
        /// 启用创建列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用创建列表")]
        public bool EnableLists
        {
            get
            {
                object obj = FState["EnableLists"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableLists"] = value;
            }
        }


        /// <summary>
        /// 启用源码视图
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用源码视图")]
        public bool EnableSourceEdit
        {
            get
            {
                object obj = FState["EnableSourceEdit"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableSourceEdit"] = value;
            }
        }


        /// <summary>
        /// 字体列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("字体列表")]
        //[Editor("System.Web.UI.Design.WebControls.DataFieldEditor", typeof(UITypeEditor))]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] FontFamilies
        {
            get
            {
                object obj = FState["FontFamilies"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                FState["FontFamilies"] = value;
            }
        }

        /// <summary>
        /// 启用中文字体
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用中文字体")]
        public bool EnableChineseFont
        {
            get
            {
                object obj = FState["EnableChineseFont"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableChineseFont"] = value;
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
            if (PropertyModified("Text"))
            {
                sb.AppendFormat("{0}.f_setValue();", XID);
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (!EnableAlignments) OB.AddProperty("enableAlignments", false);
            if (!EnableColors) OB.AddProperty("enableColors", false);
            if (!EnableFont) OB.AddProperty("enableFont", false);
            if (!EnableFontSize) OB.AddProperty("enableFontSize", false);
            if (!EnableFormat) OB.AddProperty("enableFormat", false);
            if (!EnableLinks) OB.AddProperty("enableLinks", false);
            if (!EnableLists) OB.AddProperty("enableLists", false);
            if (!EnableSourceEdit) OB.AddProperty("enableSourceEdit", false);

            #region Fonts

            string[] fonts = null;
            if (EnableChineseFont)
            {
                fonts = new string[] { "宋体", "黑体", "仿宋", "楷体", "隶书", "幼圆", "Arial", "Courier New", "Tahoma", "Times New Roman", "Verdana" };
            }
            else if (FontFamilies != null)
            {
                fonts = FontFamilies;
            }

            if (fonts != null && fonts.Length > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (string fontName in fonts)
                {
                    ab.AddProperty(fontName);
                }

                OB.AddProperty("fontFamilies", ab);
            }

            #endregion

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("value", Text);
            }

            
            // 如果Text属性存在于FState中，则不要重复设置value属性，而是在render事件中使用FState的值
            if (FState.ModifiedProperties.Contains("Text"))
            {
                //OB.RemoveProperty("value");
                //OB.Listeners.AddProperty("initialize", JsHelper.GetFunction("cmp.f_setValue();", "cmp"), true);
                OB.AddProperty("value", String.Format("{0}.Text", GetFStateScriptID()), true);

            }


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.HtmlEditor',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// 回发到服务器，判断控件的属性是否变化，
        /// 如果变化返回true，则RaisePostDataChangedEvent
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[UniqueID];

            //// Extjs4.0.1 没能正确的设置 htmleditor 的提交隐藏字段，这个在更高版本中可能要删除
            //string postValue = postCollection[ClientID + "_Text"];

            if (postValue != null && Text != postValue)
            {
                Text = postValue;
                FState.BackupPostDataProperty("Text");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 文本改变事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("文本改变事件")]
        public event EventHandler TextChanged
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

        private object _handlerKey = new object();

        /// <summary>
        /// 触发文本改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnTextChanged(EventArgs e)
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
