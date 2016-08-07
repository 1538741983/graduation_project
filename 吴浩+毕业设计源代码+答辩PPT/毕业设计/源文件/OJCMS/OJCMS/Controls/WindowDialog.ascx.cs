using System;
using System.Drawing;
using System.Web.UI.WebControls;
using FineUI;

namespace OJCMS.Controls
{
    public partial class WindowDialog : System.Web.UI.UserControl
    {
        private Size normalSize = new Size(700, 400);

        protected void Page_Load(object sender, EventArgs e)
        {
            SetWindowsSize();
        }

        /// <summary>
        /// 根据大小类型设置弹出窗体的大小
        /// </summary>
        private void SetWindowsSize()
        {
            switch (sizeType)
            {
                case SizeType.Small:
                    this.Window1.Height = 400;
                    this.Window1.Width = 700;
                    break;
                case SizeType.Normal:
                    this.Window1.Height = 400;
                    this.Window1.Width = 700;
                    break;
                case SizeType.Big:
                    this.Window1.Height = Unit.Percentage(normalSize.Height * 1.5);
                    this.Window1.Width = Unit.Percentage(normalSize.Width * 1.5);
                    break;
            }
        }

        public string GetShowReference(string iframeUrl, string windowTitle)
        {
            return this.Window1.GetShowReference(iframeUrl, windowTitle);
        }

        public string GetShowReference(string iframeUrl, string windowTitle, Unit width, Unit height)
        {
            return this.Window1.GetShowReference(iframeUrl, windowTitle, width, height);
        }

        protected void Window1_OnClose(object sender, WindowCloseEventArgs e)
        {

        }

        /// <summary>
        /// 大小类型
        /// </summary>
        private SizeType sizeType;
        public SizeType SizeType
        {
            get { return this.sizeType; }
            set
            {
                this.sizeType = value;
                SetWindowsSize();
            }
        }
    }

    public enum SizeType
    {
        Small,
        Normal,
        Big
    }
}