using System;

namespace OJCMS.APPCode
{
    public class MenuModel
    {
        public Int64 Id { get; set; }// 功能代码 
        public string Name { get; set; }// 功能名称 
        public Int64? ParentId { get; set; }// 父节点   
        public int TreeLevel { get; set; }
        public string MicoHelp { get; set; }// 微帮助   
        public string NavigateUrl { get; set; }// 调用内容 
        public string Para { get; set; }// 调用参数 
        public int Num { get; set; }// 菜单排序 
        public bool IsTreeLeaf { get; set; }
        public string Code { get; set; }//编码
    }
}