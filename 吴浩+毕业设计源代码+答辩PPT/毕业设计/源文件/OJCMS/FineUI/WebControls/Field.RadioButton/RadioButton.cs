
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RadioButton.cs
 * CreatedOn:   2008-06-20
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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

namespace FineUI
{
    /// <summary>
    /// 单选框控件
    /// </summary>
    [Designer("FineUI.Design.RadioButtonDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RadioButton Label=\"Label\" Text=\"RadioButton\" runat=server></{0}:RadioButton>")]
    [ToolboxBitmap(typeof(RadioButton), "toolbox.RadioButton.bmp")]
    [Description("单选框控件")]
    public class RadioButton : Field, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public RadioButton()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Checked");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
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
        /// [AJAX属性]是否选中
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否选中")]
        public bool Checked
        {
            get
            {
                object obj = FState["Checked"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Checked"] = value;

                ProcessOthersInGroup();
            }
        }

        /// <summary>
        /// 设置本组内其他RadioButton的Checked属性为false
        /// 简单处理，只查找和此RadioButton在同一个层级的RadioButton
        /// </summary>
        private void ProcessOthersInGroup()
        {
            // 如果页面已经加载完毕，并且此RadioButton的属于某一个Group
            // 则在设置这个控件的Checked属性时需要考虑本组内其他控件的Checked属性。
            if (Page != null && !String.IsNullOrEmpty(GroupName) && Checked)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is RadioButton)
                    {
                        RadioButton rbtn = c as RadioButton;
                        if (rbtn != this && rbtn.GroupName == this.GroupName)
                        {
                            rbtn.Checked = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 分组的名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("分组的名称")]
        public string GroupName
        {
            get
            {
                object obj = FState["GroupName"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["GroupName"] = value;
            }
        }


        /// <summary>
        /// 是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发")]
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


        #endregion

        #region HiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string CheckedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Checked", ClientID);
            }
        }

        #endregion

        #region OnInitControl

        /// <summary>
        /// 初始化控件
        /// </summary>
        protected override void OnInitControl()
        {
            base.OnInitControl();

            ProcessOthersInGroup();
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
            if (PropertyModified("Checked"))
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


            #region options
            OB.AddProperty("checked", Checked);

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("boxLabel", Text);
            }

            if (!String.IsNullOrEmpty(GroupName))
            {
                OB.RemoveProperty("name");
                OB.AddProperty("name", GroupName);
                OB.AddProperty("inputValue", ClientID);
            }

            #endregion

            #region AutoPostBack

            if (AutoPostBack)
            {
                string checkScript = String.Empty;
                if (!String.IsNullOrEmpty(GroupName))
                {
                    checkScript = "if(F.util.checkGroupLastTime('" + GroupName + "')){" + GetPostBackEventReference() + "}";
                }
                else
                {
                    checkScript = GetPostBackEventReference();
                }

                //OB.Listeners.AddProperty("change", JsHelper.GetFunction(checkScript), true);
                AddListener("change", checkScript);
            }

            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Radio',{1});", XID, OB.ToString());
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
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            // 不管单选框是否在分组中，每个单选框的Checked都在POST参数中
            bool postChecked = Convert.ToBoolean(postCollection[CheckedHiddenFieldID]);
            if (Checked != postChecked)
            {
                Checked = postChecked;
                FState.BackupPostDataProperty("Checked");
                return true;
            }

            //if (String.IsNullOrEmpty(GroupName))
            //{
            //    // This radio button is not in a group
            //    string postValue = postCollection[postDataKey];
            //    bool postChecked = !String.IsNullOrEmpty(postValue);
            //    if (Checked != postChecked)
            //    {
            //        Checked = postChecked;
            //        FState.BackupPostDataProperty("Checked");
            //        return true;
            //    }
            //}
            //else
            //{
            //    // This radio is in a group
            //    string postValue = postCollection[GroupName];
            //    if (!String.IsNullOrEmpty(postValue))
            //    {
            //        bool postChecked = (ClientID == postValue) ? true : false;
            //        if (Checked != postChecked)
            //        {
            //            Checked = postChecked;
            //            FState.BackupPostDataProperty("Checked");
            //            return true;
            //        }
            //    }
            //}

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnCheckedChanged(new CheckedEventArgs(Checked));
        }

        #region OnCheckedChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 单选框状态改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("单选框状态改变事件（需要启用AutoPostBack）")]
        public event EventHandler<CheckedEventArgs> CheckedChanged
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
        /// 触发单选框状态改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnCheckedChanged(CheckedEventArgs e)
        {
            EventHandler<CheckedEventArgs> handler = Events[_handlerKey] as EventHandler<CheckedEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #endregion
    }
}
