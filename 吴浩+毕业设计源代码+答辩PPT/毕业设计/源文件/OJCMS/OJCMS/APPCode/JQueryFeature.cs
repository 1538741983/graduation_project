namespace OJCMS.APPCode
{
    public class JQueryFeature
    {
        #region 相关字段
        private int _id;
        private string _name;
        private int _level;
        private bool _enableSelect;
        #endregion

        #region 相关属性

        /// <summary>
        /// 树形结构节点ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 树形结构节点名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 节点级别
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        /// <summary>
        /// 是否可选
        /// </summary>
        public bool EnableSelect
        {
            get { return _enableSelect; }
            set { _enableSelect = value; }
        }
        #endregion

        #region 相关方法
        public JQueryFeature(int id, string name, int level, bool enableSelect)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.EnableSelect = enableSelect;
        }
        #endregion
    }
}