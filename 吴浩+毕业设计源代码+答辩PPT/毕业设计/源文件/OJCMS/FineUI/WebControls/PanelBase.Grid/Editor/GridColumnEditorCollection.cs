
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    FieldCollection.cs
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
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Collections;

namespace FineUI
{
    /// <summary>
    /// 控件集合
    /// </summary>
    public class GridColumnEditorCollection : BaseCollection<Field>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public GridColumnEditorCollection(GridColumn parent)
            : base(parent)
        {

        }

    }
}
