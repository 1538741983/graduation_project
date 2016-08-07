
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RegionCollection.cs
 * CreatedOn:   2008-06-12
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

namespace FineUI
{
    /// <summary>
    /// Region控件集合
    /// </summary>
    public class RegionCollection : BaseCollection<Region>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public RegionCollection(PanelBase parent)
            : base(parent)
        {

        }
        /*
        private PanelBase panelBase;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="panelBase">面板实例</param>
        public RegionCollection(PanelBase panelBase)
        {
            this.panelBase = panelBase;
        }


        protected override void InsertItem(int index, Region item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperNode = false;
            panelBase.Controls.AddAt(index, item);
        }
        */
    }
}
