
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RealTextField.cs
 * CreatedOn:   2008-07-24
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
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
using System.Drawing.Design;

namespace FineUI
{
    /// <summary>
    /// 表单文本输入框字段基类（抽象类）
    /// </summary>
    public abstract class RealTextField : TextField, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public RealTextField()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Text");

            AddGzippedAjaxProperties("Text");
        }

        #endregion

        #region EmptyText

        /// <summary>
        /// 文本框为空时显示的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本框为空时显示的文本")]
        public virtual string EmptyText
        {
            get
            {
                object obj = FState["EmptyText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["EmptyText"] = value;
            }
        }


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
        /// 是否自动回发（文本值改变）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发（文本值改变）")]
        public bool AutoPostBack
        {
            get
            {
                object obj = FState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// 启用失去焦点事件
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用失去焦点事件")]
        public bool EnableBlurEvent
        {
            get
            {
                object obj = FState["EnableBlurEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableBlurEvent"] = value;
            }
        }

        ///// <summary>
        ///// Enable server validate, trigger the Validate event.
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("Enable server validate, trigger the Validate event.")]
        //public bool EnableServerValidate
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableServerValidate"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableServerValidate"] = value;
        //    }
        //}

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


            if (!String.IsNullOrEmpty(EmptyText))
            {
                OB.AddProperty("emptyText", EmptyText);
            }

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("value", Text);
            }

            if (AutoPostBack)
            {
                //OB.Listeners.AddProperty("change", JsHelper.GetFunction(GetPostBackEventReference()), true);
                AddListener("change", GetPostBackEventReference());

                #region old code
                //// First remove change event, because we has already register this event in super class - Field.
                //OB.Listeners.RemoveProperty("change");

                //string changeScript = "F.util.setPageStateChanged();";
                //changeScript += GetPostBackEventReference();
                //OB.Listeners.AddProperty("change", JsHelper.GetFunction(changeScript), true);

                //else if (EnableServerValidate)
                //{
                //    // The Validate event will not be triggered when the filed fail to pass the client side validte.
                //    //changeScript += String.Format("if(X.{0}.isValid()){{{1}}}", ClientJavascriptID, GetPostBackEventReference("Validate"));
                //}
                //else if (AutoPostBack && EnableServerValidate)
                //{
                //    changeScript += GetPostBackEventReference("#VALIDATE#").Replace("'#VALIDATE#'", String.Format("{0}.isValid() ? 'Validate' : ''"));
                //} 
                #endregion
            }

            if (EnableBlurEvent)
            {
                //OB.Listeners.AddProperty("blur", JsHelper.GetFunction(GetPostBackEventReference("Blur")), true);
                AddListener("blur", GetPostBackEventReference("Blur"));
            }

            //if (EnableServerValidate)
            //{
            //    OB.Listeners.AddProperty("blur", JsHelper.GetFunctionWrapper(GetPostBackEventReference("Validate")), true);
            //}
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[UniqueID];

            // 只有启用表单控件时，才判断Text是否改变
            // 对于TextBox，如果禁用了（disabled="disabled"）则postValue == null，也就是说此表单字段不会提交到服务器（这是浏览器行为）。
            if (Enabled)
            {
                // If post value is empty, null or equals to the EmptyText property, we can consider it to be String.Empty.
                if (String.IsNullOrEmpty(postValue) || postValue == EmptyText)
                {
                    postValue = String.Empty;
                }

                if (Text != postValue)
                {
                    Text = postValue;
                    FState.BackupPostDataProperty("Text");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }

        #endregion

        #region OnTextChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 文本改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("文本改变事件（需要启用AutoPostBack）")]
        public virtual event EventHandler TextChanged
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

        #region OnBlur

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public virtual void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "Blur")
            {
                OnBlur(EventArgs.Empty);
            }
        }


        private object _handlerKeyBlur = new object();

        /// <summary>
        /// 失去焦点事件（需要启用EnableBlurEvent）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("失去焦点事件（需要启用EnableBlurEvent）")]
        public virtual event EventHandler Blur
        {
            add
            {
                Events.AddHandler(_handlerKeyBlur, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKeyBlur, value);
            }
        }

        /// <summary>
        /// 触发失去焦点事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnBlur(EventArgs e)
        {
            EventHandler handler = Events[_handlerKeyBlur] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region old code

        //#region OnValidate

        ///// <summary>
        ///// Form field server validate event.
        ///// </summary>
        //[Category(CategoryName.ACTION)]
        //[Description("Form field server validate event.")]
        //public virtual event EventHandler Validate
        //{
        //    add
        //    {
        //        Events.AddHandler(validateHandlerKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(validateHandlerKey, value);
        //    }
        //}

        //private object validateHandlerKey = new object();

        //public virtual void OnValidate(EventArgs e)
        //{
        //    EventHandler handler = Events[validateHandlerKey] as EventHandler;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        //#endregion

        //#region IPostBackEventHandler

        //public void RaisePostBackEvent(string eventArgument)
        //{
        //    if (eventArgument == "Validate")
        //    {
        //        OnValidate(EventArgs.Empty);
        //    }
        //}

        //#endregion 

        #endregion
    }
}
