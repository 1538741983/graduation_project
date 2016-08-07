using System;
using System.Collections.Generic;
using System.Text;

namespace FineUI
{
    public class ModifiedCell
    {
        private int rowIndex;

        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }


        private int columnIndex;

        public int ColumnIndex
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }

        private string columnID;

        public string ColumnID
        {
            get { return columnID; }
            set { columnID = value; }
        }


        private string cellValue;

        public string CellValue
        {
            get { return cellValue; }
            set { cellValue = value; }
        }


        private string oldCellValue;

        public string OldCellValue
        {
            get { return oldCellValue; }
            set { oldCellValue = value; }
        }

    }
}
