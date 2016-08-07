namespace OJ.BLL.PageList
{
    public class PageList<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public T[] DataList { get; set; }
    }
}
