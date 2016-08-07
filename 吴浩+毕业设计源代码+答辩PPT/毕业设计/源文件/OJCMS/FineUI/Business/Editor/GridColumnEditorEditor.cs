
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    FieldEditor.cs
 * CreatedOn:   2013-05-01
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
using System.Text;
using System.ComponentModel.Design;

namespace FineUI
{
    /// <summary>
    /// 为设计时提供的表格列编辑器集合编辑器
    /// </summary>
    public class GridColumnEditorEditor : CollectionEditor
    {
        private Type[] types;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">控件类型</param>
        public GridColumnEditorEditor(Type type)
            : base(type)
        {
            types = new Type[] {
                typeof(CheckBox),
                typeof(CheckBoxList),
                typeof(HtmlEditor),
                typeof(Label),
                typeof(HyperLink),
                typeof(Image),
                typeof(LinkButton),
                typeof(RadioButton),
                typeof(RadioButtonList),
                typeof(DropDownList),
                typeof(DatePicker),
                typeof(FileUpload),
                typeof(HiddenField),
                typeof(NumberBox),
                typeof(TextArea),
                typeof(TextBox),
                typeof(TimePicker),
                typeof(TriggerBox),
                typeof(TwinTriggerBox)
                
            };
        }

        /// <summary>
        /// 获取此集合编辑器可包含的数据类型
        /// </summary>
        /// <returns>类型集合</returns>
        protected override Type[] CreateNewItemTypes()
        {
            return types;
        }

    }
}
