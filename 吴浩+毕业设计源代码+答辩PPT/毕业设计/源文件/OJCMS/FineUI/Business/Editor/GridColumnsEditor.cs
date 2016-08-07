
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridColumnsEditor.cs
 * CreatedOn:   2013-01-02
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
    /// 为设计时提供的表格列集合编辑器
    /// </summary>
    public class GridColumnsEditor : CollectionEditor
    {
        private Type[] types;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">控件类型</param>
        public GridColumnsEditor(Type type)
            : base(type)
        {
            types = new Type[] { 
                typeof(BoundField), 
                typeof(CheckBoxField), 
                typeof(HyperLinkField), 
                typeof(TemplateField), 
                typeof(ImageField),
                typeof(WindowField),
                typeof(LinkButtonField)
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
